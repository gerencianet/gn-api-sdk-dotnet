using System;

namespace Gerencianet.SDK.Examples
{
    class DetailSubscription
    {
        public static void Execute()
        {
            dynamic endpoints = new Endpoints(Credentials.Default.ClientId, Credentials.Default.ClientSecret, true); ;

            var param = new
            {
                id = 1002
            };

            try
            {
                var response = endpoints.DetailSubscription(param);
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
