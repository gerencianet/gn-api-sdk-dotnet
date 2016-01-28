## Adding information to charge's history

It is possible to add information to the history of a charge. These informations will be listed when [detailing a charge](/Docs/charge-detailing.md).

The process to add information to history is shown below:


```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = new {
    id = 1000
};

var body = new {
    description = "This charge was not fully paid"
};

var response = endpoints.CreateChargeHistory(param, body);
Console.WriteLine(response);
```

If everything goes well, the return will be:

```js
{
  "code": 200
}
```
