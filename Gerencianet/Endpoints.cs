using Gerencianet.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Gerencianet
{
    public class Endpoints : DynamicObject
    {
        private const string Version = "0.0.1";
        private const string ApiBaseURL = "https://api.gerencianet.com.br/v1";
        private const string ApiBaseSandboxURL = "https://sandbox.gerencianet.com.br/v1";

        private JObject endpoints;
        private string clientId;
        private string clientSecret;
        private bool sandbox;
        private string baseUrl;
        private string token;

        public Endpoints(string clientId, string clientSecret, bool sandbox)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.sandbox = sandbox;
            string jsonString = Resources.ResourceManager.GetString("endpoints");
            this.endpoints = JObject.Parse(jsonString);
            this.baseUrl = this.sandbox ? ApiBaseSandboxURL : ApiBaseURL;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            JObject endpoint = null;
            try
            {
                endpoint = (JObject)this.endpoints[binder.Name];
            }
            catch (NullReferenceException e)
            {
                throw new GnException(0, "invalid_endpoint", string.Format("Método '%s' inexistente", binder.Name));
            }

            var route = (string)endpoint["route"];
            var method = (string)endpoint["method"];
            object body = new { };
            object query = new { };

            if (args.Length > 0 && args[0] != null)
                query = args[0];

            if (args.Length > 1 && args[1] != null)
                body = args[1];

            if (token == null)
                Authenticate();

            try
            {
                result = RequestEndpoint(route, method, query, body);
                return true;
            }
            catch (GnException e)
            {
                if (e.Code == 401)
                {
                    this.Authenticate();
                    result = this.RequestEndpoint(route, method, query, body);
                    return true;
                }
                else
                {
                    throw e;
                }
            }

        }

        private void Authenticate()
        {
            object body = new
            {
                grant_type = "client_credentials"
            };
            WebRequest request = this.GetWebRequest("/authorize", "post", null, body);
            string credentials = string.Format("%s:%s", this.clientId, this.clientSecret);
            string encodedAuth = Convert.ToBase64String(Encoding.GetEncoding("UTF-8").GetBytes(credentials));
            request.Headers.Add("Authorization", string.Format("Basic %s", encodedAuth));

            try
            {
                dynamic response = SendRequest(request);
                this.token = (string) response.access_token;
            }
            catch (WebException e)
            {
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                throw new GnException(401, "authorization_error", "Could not authenticate. Please make sure you are using correct credentials and if you are using then in the correct environment.");
            }
        }

        private object RequestEndpoint(string endpoint, string method, object query, object body)
        {
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebRequest request = this.GetWebRequest(endpoint, method, query, body);
            request.Headers.Add("Authorization", string.Format("Bearer %s", this.token));

            try
            {
                return SendRequest(request);
            }
            catch (WebException e)
            {
                if (e.Response != null && (e.Response is HttpWebResponse))
                {
                    StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                    throw GnException.Build(reader.ReadToEnd());
                }
                else
                {
                    throw new GnException(500, "internal_server_error", "Ocorreu um erro no servidor");
                }
            }
        }

        private WebRequest GetWebRequest(string endpoint, string method, object query, object body)
        {
            if (query != null)
            {
                MatchCollection matchCollection = Regex.Matches(endpoint, ":([a-zA-Z0-9]+)");
                for (int i = 0; i < matchCollection.Count; i++)
                {
                    string resource = matchCollection[i].Groups[1].Value;
                    try
                    {
                        var value = (string)query.GetType().GetProperty(resource).GetValue(query, null).ToString();
                        endpoint = Regex.Replace(endpoint, string.Format(":%s", resource), value);
                    }
                    catch (NullReferenceException e)
                    {}
                }
            }

            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebRequest request = HttpWebRequest.Create(string.Format("%s%s", this.baseUrl, endpoint));
            request.Method = method;
            request.ContentType = "application/json";
            request.Headers.Add("api-sdk", string.Format("dotnet-%s", Version));

            if (!method.Equals("get") && body != null)
            {
                Stream postStream = request.GetRequestStream();
                var data = Encoding.UTF8.GetBytes(JObject.FromObject(body).ToString());
                postStream.Write(data, 0, data.Length);
            }

            return request;
        }

        private object SendRequest(WebRequest request)
        {
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            object def = new {};
            return JsonConvert.DeserializeAnonymousType(reader.ReadToEnd(), def);
        }
        
    }

}
