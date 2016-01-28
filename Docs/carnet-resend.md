### Resending the carnet

To resend the carnet, it must have a `active` status.

If the carnet contemplates this requirement, you just have to provide the carnet id and a email to resend it:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);
var param = new
{
    id = 1000
};

var body = new
{
    email = "oldbuck@gerencianet.com.br"
};

var response = endpoints.ResendCarnet(param, body);
Console.WriteLine(response);
```

If everything goes well, the return will be:

```js
{
  "code": 200
}
```
