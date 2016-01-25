using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Gerencianet.Tests
{
    [TestFixture]
    class HttpHelperTest
    {
        private HttpHelper httpHelper;

        [SetUp]
        public void Init()
        {
            this.httpHelper = new HttpHelper();
        }

        [Test]
        public void GetWebRequestTest()
        {
            this.httpHelper.BaseUrl = "https://myapi.example.com";
            string endpoint = "/user/:userId/address/:addressId";
            string method = "post";
            object query = new
            {
                userId = 124,
                addressId = 298,
                someVar = "value",
                otherVar = "foobar"
            };
            object body = new
            {
                address = "4636 Route 70 Vienna, VA 22180"
            };
            WebRequest request = this.httpHelper.GetWebRequest(endpoint, method, query);

            Assert.IsTrue(request.RequestUri.Equals("https://myapi.example.com/user/124/address/298?someVar=value&otherVar=foobar"), "RequestUri should contain all resources and/or query string");
            Assert.IsTrue(request.Method.Equals("POST"), "http method should be post");
        }

        [Test]
        public void SendRequestTest()
        {
            var request = new WebRequestMock();
            request.Method = "POST";
            request.SetResponseData("{'status': 200, 'message': 'Successful request'}");

            var postData = new
            {
                myData = "abc123"
            };

            dynamic responseData = this.httpHelper.SendRequest(request, postData);
            Assert.IsTrue(responseData.status==200, "response status should be equal 200");
            Assert.IsTrue(((string)responseData.message).Equals("Successful request"), "response message is not correct");
        }
    }
    

    class WebRequestMock : WebRequest
    {
        private string method;
        private WebResponseMock response;

        public override string Method
        {
            get
            {
                return this.method;
            }
            set
            {
                this.method = value;
            }
        }

        public override Stream GetRequestStream()
        {
            return new MemoryStream();
        }

        public override WebResponse GetResponse()
        {
            return this.response;
        }

        public void SetResponseData(string data)
        {
            this.response = new WebResponseMock(data);
        }
    }

    class WebResponseMock : WebResponse
    {
        private string data;

        public WebResponseMock (string data)
        {
            this.data = data;
        }

        public override Stream GetResponseStream()
        {
            var responseStream = new MemoryStream();
            var dataBytes = Encoding.UTF8.GetBytes(this.data);
            responseStream.Write(dataBytes, 0, this.data.Length);
            responseStream.Seek(0, SeekOrigin.Begin);
            return responseStream;
        }
    }
}
