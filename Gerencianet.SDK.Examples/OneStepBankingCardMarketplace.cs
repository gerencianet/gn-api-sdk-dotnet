using System;
namespace Gerencianet.SDK.Examples
{
   class OneStepCreditCard
   {
       public static void Execute()
       {
           dynamic endpoints = new Endpoints(Credentials.Default.ClientId, Credentials.Default.ClientSecret, Credentials.Default.Sandbox);
           var body = new
           {
               items = new[] {
                    new {
                        name = "Product 1",
                        value = 590,
                        amount = 2,
                        marketplace = new {
                        repasses = new [] { new {
                            payee_code = "Insira_aqui_o_indentificador_da_conta_destino",
                            percentage = 2500
                          },
                          new {
                            payee_code = "Insira_aqui_o_indentificador_da_conta_destino",
                            percentage = 1500
                          }
                        }
                      }
                    }
                },
               shippings = new[] {
                   new {
                       name = "Default Shipping Cost",
                       value = 10
                   }
               },
               payment = new
               {
                   credit_card = new
                   {
                       installments = 1,
                       payment_token = "InsiraAquiUmPayeementeCode",
                       billing_address = new
                       {
                           street = "Av. JK",
                           number = 909,
                           neighborhood = "Bauxita",
                           zipcode = "35400000",
                           city = "Ouro Preto",
                           state = "MG"
                       },
                       customer = new
                       {
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
               var response = endpoints.OneStep(null, body);
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