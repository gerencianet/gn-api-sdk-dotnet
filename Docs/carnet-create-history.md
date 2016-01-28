## Adding information to carnet's history

It is possible to add information to the history of a carnet. These informations will be listed when [detailing a carnet](https://github.com/gerencianet/gn-api-sdk-dotnet/tree/master/Docs/carnet-detailing.md).

The process to add information to history is shown below:


```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = new {
    id = 1001
};

var body = new
{
    description = "This carnet is about a service"
};

var response = endpoints.CreateCarnetHistory(param, body);
Console.WriteLine(response);
```

If everything goes well, the return will be:

```js
{
  "code": 200
}
```
