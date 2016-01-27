using System;

namespace Gerencianet.SDK.Examples
{
    class AllInOne
    {
        public static void Execute()
        {
            dynamic endpoints = new Endpoints(Credentials.Default.ClientId, Credentials.Default.ClientSecret, true);

            var chargeBody = new {
                items = new[] {
                    new {
                        name = "Product 1",
                        value = 1000,
                        amount = 2
                    }
                },
                shippings = new[] {
                    new {
                        name = "Default Shipping Cost",
                        value = 100
                    },
                    new {
                        name = "Adicional Shipping Cost",
                        value = 150
                    }
                }
            };

            var paymentBody = new {
                payment = new {
                    credit_card = new {
                        installments = 1,
                        payment_token = "8c888fe1e7d96112020cf9fcf5e4db5b9dba5cf6",
                        billing_address = new {
                            street = "Av. JK",
                            number = 909,
                            neighborhood = "Bauxita",
                            zipcode = "35400000",
                            city = "Ouro Preto",
                            state = "MG"
                        },
                        customer = new {
                            name = "Gorbadoc Oldbuck",
                            email = "oldbuck@gerencianet.com.br",
                            cpf = "04267484171",
                            birth = "1977-01-15",
                            phone_number = "5144916523"
                        }
                    }
                }
            };

            try
            {
                var chargeResponse = endpoints.CreateCharge(null, chargeBody);
                Console.WriteLine(chargeResponse);

                var paymentResponse = endpoints.PayCharge(new {
                    id = chargeResponse.data.charge_id
                }, paymentBody);
                Console.WriteLine(paymentResponse);
            }
            catch (GnException e)
            {
                Console.WriteLine(e.ErrorType);
                Console.WriteLine(e.Message);
            }
        }
    }
}
