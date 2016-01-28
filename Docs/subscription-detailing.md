## Detailing subscriptions

Works just like the charge detailing, but here you pass the subscription id:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = new {
    id = 12
};

var response = endpoints.DetailSubscription(param);
Console.WriteLine(response);
```

Response:

```js
{
  "code": 200,
  "data": {
    "subscription_id": 12,
    "value": 2000,
    "status": "new",
    "payment_method": null,
    "next_execution": null,
    "next_expire_at": null,
    "interval": 1,
    "repeats": 2,
    "processed_amount": 0,
    "created_at": "2015-05-14 15:39:14",
    "history": [
      {
        "charge_id": 233,
        "status": "new",
        "created_at": "2015-05-14 15:39:14"
      }
    ]
  }
}
```

Note that if you [detail a charge](/docs/charge-detailing.md) that belongs to a subscription, the response will have a `subscription` block with data about it, including the `subscription_id`. If you need the subscription information, you can do this:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = new {
    id = 233
};

var chargeResponse = endpoints.DetailCharge(param);

param = new {
    id = chargeResponse.data.subscription_id
};

var subscriptionResponse = endpoints.DetailSubscription(param);
Console.WriteLine(subscriptionResponse);
```
