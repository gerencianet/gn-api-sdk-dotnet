using Newtonsoft.Json;
using System;

namespace Gerencianet
{
    public class GnException : Exception
    {
        private int errorCode;
        private string errorType;

        public GnException(int code, string error, string message)
            :base(message)
        {
            this.errorCode = code;
            this.errorType = error;
        }

        public int Code
        {
            get {
                return this.errorCode;
            }
        }
        
        public string ErrorType
        {
            get
            {
                return this.errorType;
            }
        }

        public static GnException Build(string json)
        {
            object def = new { };
            dynamic jsonObject = JsonConvert.DeserializeAnonymousType(json, def);

            int code = jsonObject.code;
            string error = jsonObject.error.ToString();
            string description = jsonObject.error_description.ToString();

            return new GnException(code, error, description);
        }
    }
}
