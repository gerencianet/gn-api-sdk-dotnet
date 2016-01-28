## Create charge and payment

The most common case scenarios consist of the two steps mentioned in the title. The other examples show each part separately. Here goes the most used endpoints grouped in one example.

Create the inputs for the two endpoints:

```c#
var charge = new {
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

var payment = new {
    payment = new {
        credit_card = new {
            installments = 1,
            payment_token = "8c888fe1e7d96112020cf9fcf5e4db5b9dba5cf6", //see credit card flow to see how to get this
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
```

Call the endpoints:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);
var chargeResponse = endpoints.CreateCharge(null, charge);

var paymentParam = new {
    id = chargeResponse.data.charge_id
};

var paymentResponse = endpoints.PayCharge(paymentParam, payment);

Console.WriteLine(chargeResponse);
Console.WriteLine(paymentResponse);
```

Response:

```js
{
  "code": 200,
  "data": {
     "charge_id": 260,
     "total": 2250,
     "status": 'new',
     "custom_id": null,
     "created_at": "2015-05-18"
   }
} //charge created

{
  "code": 200,
  "data": {
     "charge_id": 260,
     "total": 2400,
     "payment": "credit_card",
     "installments": 1,
     "installment_value": 2400
  }
} //payment created
```
