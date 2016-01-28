### Resending billet

To resend the charge's billet, the charge must have a `waiting` status, and the payment method chosen must be `banking_billet`.

If the charge contemplates these requirements, you just have to provide the charge id and a email to resend the billet:

```
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = new {
    id = 1
};

var body = new {
    email = "oldbuck@gerencianet.com.br"
}

var response = endpoints.ResendBillet(param, body)
Console.WriteLine(response);
```

If everything goes well, the return will be:

```js
{
  "code": 200
}
```
