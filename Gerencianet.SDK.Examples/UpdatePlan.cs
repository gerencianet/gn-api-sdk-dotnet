using System;

namespace Gerencianet.SDK.Examples
{
    class UpdateParcel
    {
        public static void Execute()
        {
            dynamic endpoints = new Endpoints(Credentials.Default.ClientId, Credentials.Default.ClientSecret, Credentials.Default.Sandbox);

            var param = new {
                id = 1001
            };

            var body = new {
                name = "My new plan"
            };

            try
            {
                var response = endpoints.UpdatePlan(param, body);
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
