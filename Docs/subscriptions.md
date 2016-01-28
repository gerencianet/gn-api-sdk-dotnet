## Creating subscriptions

If you ever have to recurrently charge your clients, you can create a different kind of charge, one that belongs to a subscription. This way, subsequent charges will be automatically created based on plan configuration and the charge value is charged in your customers' credit card, or the banking billet is generated and sent to the custumer, accoding to the plan’s configuration.

The plan configuration receive two params: `repeats` and `interval`:

The `repeats` parameter defines how many times the transaction will be repeated. If you don't provide it, the subscription will create charges indefinitely.

The `interval` parameter defines the interval, in months, that a charge has to be generated. The minimum value is 1, and the maximum is 24.

It's worth to mention that this mechanics is triggered only if the customer commits the subscription. In other words, it takes effect when the customer pays the first charge.

At last, it boils down to creating a plan and then the subscription. The plan can be reused for generating other subscriptions:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var plan = new {
    name = "My first plan",
    repeats = 24,
    interval = 2
};

var subscription = new
{
    items = new[] {
        new {
            name = "Product 1",
            value = 1000,
            amount = 2
        }
    }
};

var planResponse = endpoints.CreatePlan(null, planBody);

var subscriptionParam = new {
    id = planResponse.data.plan_id
};

var subscriptionResponse = endpoints.CreateSubscription(subscriptionParam, subscriptionBody);
Console.WriteLine(subscriptionResponse);
```

### Deleting a plan:
*(works just for plans that doesn't have a subscription associated):*

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var param = new
{
    id = 1000
};

var response = endpoints.DeletePlan(param);
Console.WriteLine(response);
```

And the response
```js
{
  "code": 200
}
```


### Canceling subscriptions

You can cancel active subscriptions at any time:

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);

var params = new {
    id = 1
};

var response = endpoints.CancelSubscription(param);
Console.WriteLine(response);
```

Response:

```js
{
  "code": 200
}
```