## Detailing charges

It's very simple to get details from a charge. You just need the id:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = new {
    id = 1
};

var response = endpoints.DetailCharge(param);
Console.WriteLine(response);
```

As response, you will receive all the information about the charge (including if it belongs to a subscription or carnet):

```js
{
  "code": 200,
  "data": {
    "charge_id": 1300,
    "subscription_id": 12,
    "total": 2000,
    "status": "new",
    "custom_id": null,
    "created_at": "2015-05-14",
    "notification_url": "http://yourdomain.com",
    "items": [
      {
        "name": "Product 1",
        "value": 1000,
        "amount": 2
      }
    ],
    "history": [
      {
        "message": "Cobrança criada",
        "created_at": "2015-05-14 15:39:14"
      }
    ]
  }
}
```
