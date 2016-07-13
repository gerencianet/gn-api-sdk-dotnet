# gn-api-sdk-dotnet

> A .NET library for integration of your application with the payment services
provided by [Gerencianet](http://gerencianet.com.br).

[![Build Status](https://travis-ci.org/gerencianet/gn-api-sdk-dotnet.svg)](https://travis-ci.org/gerencianet/gn-api-sdk-dotnet)

**Em caso de dúvidas, você pode verificar a [Documentação](https://docs.gerencianet.com.br) da API na Gerencianet e, necessitando de mais detalhes ou informações, entre em contato com nossa consultoria técnica, via nossos [Canais de Comunicação](https://gerencianet.com.br/central-de-ajuda).**


## Installation

From Visual Studio package manager: Search for ```Gerencianet.SDK```

From command-line with NuGet:

```bash
$ nuget install Gerencianet.SDK
```

## Basic usage

```c#
using Gerencianet.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true);
var body = new
{
    items = new[] {
        new {
            name = "Product 1",
            value = 1000,
            amount = 2
        }
    },
    shippings = new[] {
        new {
            name = "Default Shipping Cost",
            value = 100
        }
    }
};

var response = endpoints.CreateCharge(null, body);
Console.WriteLine(response);
```

## Examples

You can run the examples contained in the project `Gerencianet.SDK.Examples` by uncommenting the lines in `Program.cs` file.

Just remember to set the correct credentials inside `Gerencianet.SDK.Examples/Credentials.Settings` before running.

## Tests

To run the tests, build `Gerencianet.SDK.Tests` and use *nunit3-console*:

```bash
$ nunit3-console ./Gerencianet.SDK.Tests/bin/Release/Gerencianet.SDK.Tests.dll
```

## Additional documentation

### Charges

- [Creating charges](/Docs/charges.md)
- [Paying a charge](/Docs/charge-payment.md)
- [Detailing charges](/Docs/charge-detailing.md)
- [Updating informations](/Docs/charge-update.md)
- [Resending billet](/Docs/charge-resend-billet.md)
- [Adding information to charge's history](/Docs/charge-create-history.md)

### Carnets

- [Creating carnets](/Docs/carnets.md)
- [Detailing carnets](/Docs/carnet-detailing.md)
- [Updating informations](/Docs/carnet-update.md)
- [Resending the carnet](/Docs/carnet-resend.md)
- [Resending carnet parcel](/Docs/carnet-resend-parcel.md)
- [Adding information to carnet's history](/Docs/carnet-create-history.md)
- [Canceling the carnet](/Docs/carnet-cancel.md)
- [Canceling carnet parcel](/Docs/carnet-cancel-parcel.md)

### Subscriptions

- [Creating subscriptions](/Docs/subscriptions.md)
- [Paying a subscription](/Docs/subscription-payment.md)
- [Detailing subscriptions](/Docs/subscription-detailing.md)
- [Updating informations](/Docs/subscription-update.md)

### Marketplace

- [Creating a marketplace](/Docs/charge-with-marketplace.md)

### Notifications

- [Getting notifications](/Docs/notifications.md)

### Payments

- [Getting installments](/Docs/installments.md)

### All in one

- [Usage](/Docs/all-in-one.md)

## Changelog

[CHANGELOG](CHANGELOG.md)

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/gerencianet/gn-api-sdk-dotnet. This project is intended to be a safe, welcoming space for collaboration.

## License

The library is available as open source under the terms of the [MIT License](LICENSE).
