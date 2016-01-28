using System;

namespace Gerencianet.SDK.Examples
{
    class ResendBillet
    {
        public static void Execute()
        {
            dynamic endpoints = new Endpoints(Credentials.Default.ClientId, Credentials.Default.ClientSecret, Credentials.Default.Sandbox);

            var param = new
            {
                id = 1174
            };

            var body = new
            {
                email = "oldbuck@gerencianet.com.br"
            };

            try
            {
                var response = endpoints.ResendBillet(param, body);
                Console.WriteLine(response);
            }
            catch (GnException e)
            {
                Console.WriteLine(e.ErrorType);
                Console.WriteLine(e.Message);
            }
        }
    }
}
