# gn-api-sdk-dotnet

> A .NET library for integration of your application with the payment services
provided by [Gerencianet](http://gerencianet.com.br).

[![Build Status](https://travis-ci.org/gerencianet/gn-api-sdk-dotnet.svg)](https://travis-ci.org/gerencianet/gn-api-sdk-dotnet)

## Installation

From Visual Studio package manager: Search for ```Gerencianet.SDK```

From command-line with NuGet:

```bash
$ nuget install Gerencianet.SDK
```
### Tested with
```
dotnet 4.0.0
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

The full documentation with all available endpoints is in https://dev.gerencianet.com.br/.

## Changelog

[CHANGELOG](CHANGELOG.md)

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/gerencianet/gn-api-sdk-dotnet. This project is intended to be a safe, welcoming space for collaboration.

## License

The library is available as open source under the terms of the [MIT License](LICENSE).
