using System;

namespace Gerencianet.SDK.Examples
{
    class SettleCarnetParcel
    {
        public static void Execute()
        {
            dynamic endpoints = new Endpoints(Credentials.Default.ClientId, Credentials.Default.ClientSecret, Credentials.Default.Sandbox);

            var param = new
            {
                id = 0,
                parcel = 1
            };

            try
            {
                var response = endpoints.SettleCarnetParcel(param);
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
