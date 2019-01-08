using System;

namespace Gerencianet.SDK.Examples
{
    class SettleCharge
    {
        public static void Execute()
        {
            dynamic endpoints = new Endpoints(Credentials.Default.ClientId, Credentials.Default.ClientSecret, Credentials.Default.Sandbox);

            var param = new
            {
                id = 1
            };

            try
            {
                var response = endpoints.settleCharge(param);
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
