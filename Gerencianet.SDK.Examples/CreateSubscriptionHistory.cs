using System;

namespace Gerencianet.SDK.Examples
{
    class CreateChargeHistory
    {
        public static void Execute()
        {
            dynamic endpoints = new Endpoints(Credentials.Default.ClientId, Credentials.Default.ClientSecret, Credentials.Default.Sandbox);

            var param = new {
                id = 1000
            };

            var body = new
            {
                description = "This subscription was not fully paid"
            };


            try
            {
                var response = endpoints.CreateSubscriptionHistory(param, body);
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
