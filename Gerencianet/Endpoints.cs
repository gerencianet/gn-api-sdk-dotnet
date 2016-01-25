using Gerencianet.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Text;

namespace Gerencianet
{
    public class Endpoints : DynamicObject
    {
        private const string ApiBaseURL = "https://api.gerencianet.com.br/v1";
        private const string ApiBaseSandboxURL = "https://sandbox.gerencianet.com.br/v1";
        private const string Version = "0.0.1";

        private JObject endpoints;
        private string clientId;
        private string clientSecret;
        private string token;
        private HttpHelper httpHelper;

        public Endpoints(string clientId, string clientSecret, bool sandbox)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            string jsonString = Resources.ResourceManager.GetString("endpoints");
            this.endpoints = JObject.Parse(jsonString);
            this.httpHelper = new HttpHelper();
            this.httpHelper.BaseUrl = sandbox ? Endpoints.ApiBaseSandboxURL : Endpoints.ApiBaseURL;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        { 
            JObject endpoint = null;
            endpoint = (JObject)this.endpoints[binder.Name];
            
            if (endpoint == null)
                throw new GnException(0, "invalid_endpoint", string.Format("Método '{0}' inexistente", binder.Name));

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
            WebRequest request = this.httpHelper.GetWebRequest("/authorize", "post", null);
            string credentials = string.Format("{0}:{1}", this.clientId, this.clientSecret);
            string encodedAuth = Convert.ToBase64String(Encoding.GetEncoding("UTF-8").GetBytes(credentials));
            request.Headers.Add("Authorization", string.Format("Basic {0}", encodedAuth));
            request.Headers.Add("api-sdk", string.Format("dotnet-{0}", Endpoints.Version));

            try
            {
                dynamic response = this.httpHelper.SendRequest(request, body);
                this.token = response.access_token;
            }
            catch (WebException)
            {
                throw new GnException(401, "authorization_error", "Could not authenticate. Please make sure you are using correct credentials and if you are using then in the correct environment.");
            }
        }

        private object RequestEndpoint(string endpoint, string method, object query, object body)
        {
            WebRequest request = this.httpHelper.GetWebRequest(endpoint, method, query);
            request.Headers.Add("Authorization", string.Format("Bearer {0}", this.token));
            request.Headers.Add("api-sdk", string.Format("dotnet-{0}", Version));

            try
            {
                return httpHelper.SendRequest(request, body);
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
        
    }

}
