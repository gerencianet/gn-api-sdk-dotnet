## Updating carnets

### Changing the metadata

You can update the `custom_id` and the `notification_url` of a carnet at any time.

It's important to keep in mind that all the charges of the carnet will be updated. If you want to update only one charge, check [Updating charges](/Docs/charge-update.md).

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

var response = endpoints.UpdateCarnetMetadata(param, body);
Console.WriteLine(response);
```

If everything goes well, the response will be:

```js
{
  "code": 200
}
```

### Updating the expiration date of a parcel

Only parcels with status `waiting` or `unpaid` can have expiration date set or updated:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = new {
    id = 1,
    parcel = 1
};

var body = new {
    expire_at = "2020-12-12"
};

var response = endpoints.UpdateParcel(param, body);
Console.WriteLine(response);
```

If everything goes well, the response will be:

```js
{
  "code": 200
}
```
