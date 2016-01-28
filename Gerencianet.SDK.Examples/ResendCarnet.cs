using System;

namespace Gerencianet.SDK.Examples
{
    class ResendCarnet
    {
        public static void Execute()
        {
            dynamic endpoints = new Endpoints(Credentials.Default.ClientId, Credentials.Default.ClientSecret, Credentials.Default.Sandbox);

            var param = new
            {
                id = 1001
            };

            var body = new
            {
                email = "oldbuck@gerencianet.com.br"
            };

            try
            {
                var response = endpoints.ResendCarnet(param, body);
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
