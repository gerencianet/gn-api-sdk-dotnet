### Resending carnet parcel

To resend the carnet parcel, the parcel must have a `waiting` status.

If the parcel contemplates this requirement, you just have to provide the carnet id, the parcel number and a email to resend it:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = new {
    id = 1000,
    parcel = 1
};

var body = new {
    email = "oldbuck@gerencianet.com.br"
};

var response = endpoints.ResendParcel(param, body);
Console.WriteLine(response);
```

If everything goes well, the return will be:

```js
{
  "code": 200
}
```
