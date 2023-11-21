[WCF for the Real World, Not Hello World](https://www.codeproject.com/Articles/627240/WCF-for-the-Real-World-Not-Hello-World) is an article published in 2012.
This repository is based on the download source of the article which is now upgrated for .NET Framework 4.8.

When establishing a localhost:8998 Website in local IIS, please make sure "WCF Services / HTTP Activation" is enabled:

1. Go "Turn Windows features on or off"
1. Check .NET Framwork 4.8 Advanced Services / WCF Services / HTTP Activation"

# .NET Core

According to "[Client Support for Calling WCF/CoreWCF with System.ServiceModel 6.0 Is Here!](https://devblogs.microsoft.com/dotnet/wcf-client-60-has-been-released/)", Microsoft has no commitment to full WCF support, but:

1. Quick though not so dirty implementation of [WCF Client Libraries](https://github.com/dotnet/wcf), along with a few NuGet packages.
1. A community project [CoreWCF](https://github.com/dotnet/wcf).


## .NET Core WCF Client Example

Focus on the following csproj projects:

1. RealWorldServiceCoreClientApi.csproj
1. TestRealWorldCoreIntegration.csproj

However, not like the counterpart for .NET Framework, "app.config" is not utilized anymore, and this config file will cause the xUnit VS runner to fail. So I have hard coded the binding and the address for "System.ServiceModel.ClientBase". And in a real world program, it shouldn't be hard for you to create an app level json based config in "appSettings.json" and use app codes to instanciate respective bindings.


## I Miss the Goold Old Day with WCF

