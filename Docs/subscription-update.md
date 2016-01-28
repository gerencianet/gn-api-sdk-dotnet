## Updating subscriptions

### Changing the metadata

You can update the `custom_id` or the `notification_url` of a subscription.

It is important to keep in mind that all the subscription charges will be updated. If you want to update only one, check [Updating charges](/docs/charge-update).

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = new
{
    id = 1,
};

var body = new
{
    notification_url = "http://yourdomain.com",
    custom_id = "my_new_id"
};

var response = endpoints.UpdateSubscriptionMetadata(param, body);
Console.WriteLine(response);

```

If everything goes well, the return will be:

```c#
{
  "code": 200
}
```
