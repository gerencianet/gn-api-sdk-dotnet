## Paying subscriptions

### 1. Banking billets

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var body = new {
    payment = new {
        banking_billet = new {
            expire_at = "2016-12-12",
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

var param = new {
    id = chargeResult.data.charge_id
};

var response = endpoints.PaySubscription(param, body);
Console.WriteLine(response);
```

### 2. Credit card

Here it's necessary to use the customer's *credit card* to submit the payment. A `payment_token` represents a credit card, as explained at the end of this page.

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = {
    id = 123
};

var body = new {
    payment = new {
        credit_card = new {
            installments = 1,
            payment_token = "", // see credit card flow to see how to get this
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

var response = endpoints.PaySubscription(param, body);
Console.WriteLine(response);
```

Response:

```js
{
  "code": 200,
  "data": {
    "subscription_id": 11,
    "status": "active",
    "plan": {
      "id": 1000,
      "interval": 2,
      "repeats": null
    },
    "charge": {
      "id": 1053,
      "status": "waiting"
    },
    "total": 1150,
    "payment": "credit_card"
  }
}
```

For getting installment values, including interests, check [Getting Installments](/Docs/payment-data.md).

##### Payment tokens

A `payment_token` represents a credit card number at Gerencianet.

For testing purposes, you can go to your application playground in your Gerencianet's account. At the payment endpoint you'll see a button that generates one token for you. This payment token will point to a random test credit card number.

When in production, it will depend if your project is a web app or a mobile app.

For web apps you should follow this [guide](https://docs.gerencianet.com.br/#/checkout/card). It basically consists of copying/pasting a script tag in your checkout page.

For mobile apps you should use this [SDK for Android](https://github.com/gerencianet/gn-api-sdk-android) or this [SDK for iOS](https://github.com/gerencianet/gn-api-sdk-ios).
