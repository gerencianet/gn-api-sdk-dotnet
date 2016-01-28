## Updating charges

### Cha nging the metadata

You can update the `custom_id` or the `notification_url` of a charge:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = new {
    id = 1
};

var body = new {
    notification_url = "http://yourdomain.com",
    custom_id = "my_new_id"
};

var response = endpoints.UpdateChargeMetadata(param, body);
Console.WriteLine(response);
```

If everything goes well, the return will be:

```js
{
  "code": 200
}
```

### Updating the expiration date of a billet

Only charges with status `waiting` or `unpaid` and with payment method `banking_billet` can have the `expire_at` changed:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = new {
    id = 1
};

var body = new {
    expire_at = "2018-12-12"
};

var response = endpoints.UpdateBillet(param, body);
Console.WriteLine(response);
```

If everything goes well, the return will be:

```js
{
  "code": 200
}
```
