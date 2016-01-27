using System;

namespace Gerencianet.SDK.Examples
{
    class GetInstallments
    {
        public static void Execute()
        {
            dynamic endpoints = new Endpoints(Credentials.Default.ClientId, Credentials.Default.ClientSecret, true);

            var param = new
            {
                brand = "visa",
                total = 2500
            };

            try
            {
                var response = endpoints.GetInstallments(param);
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
