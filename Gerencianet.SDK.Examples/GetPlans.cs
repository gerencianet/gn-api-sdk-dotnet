using System;

namespace Gerencianet.SDK.Examples
{
    class GetPlans
    {
        public static void Execute()
        {
            dynamic endpoints = new Endpoints(Credentials.Default.ClientId, Credentials.Default.ClientSecret, true);

            var param = new
            {
                // name = "My Plan",
                limit = 20,
                offset = 0
            };

            try
            {
                var response = endpoints.GetPlans(param);
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
