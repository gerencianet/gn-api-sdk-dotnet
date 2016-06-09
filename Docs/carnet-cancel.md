### Canceling the carnet

Only `active` carnets can be canceled:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);
var param = new
{
    id = 1000
};

var response = endpoints.CancelCarnet(param);
Console.WriteLine(response);
```

If everything goes well, the return will be:

```c#
{
  "code": 200
}
```

