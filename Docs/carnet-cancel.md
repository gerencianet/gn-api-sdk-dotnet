### Canceling the carnet

You can cancel `active` carnet:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);
var param = new
{
    id = 1000
};

var response = endpoints.CancelCarnet(param, body);
Console.WriteLine(response);
```

If everything goes well, the return will be:

```c#
{
  "code": 200
}
```

