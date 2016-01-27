using System;

namespace Gerencianet.SDK.Examples
{
    class CancelSubscription
    {
        public static void Execute()
        {
            dynamic endpoints = new Endpoints(Credentials.Default.ClientId, Credentials.Default.ClientSecret, true);

            var param = new
            {
                id = 0
            };

            try
            {
                var response = endpoints.CancelSubscription(param);
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
