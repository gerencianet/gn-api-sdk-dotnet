### Canceling carnet parcel

You can cancel carnet parcel. To this, the charge status must be `new`, `waiting` or `unpaid`.

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);
var param = new
{
    id = 1000, 
    parcel = 1
};

var response = endpoints.CancelParcel(param);
Console.WriteLine(response);
```

If everything goes well, the return will be:

```c#
{
  "code": 200
}
```

