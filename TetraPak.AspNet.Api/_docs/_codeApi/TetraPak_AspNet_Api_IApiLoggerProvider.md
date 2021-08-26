#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## IApiLoggerProvider Interface
Classes implementing this contract can be used to acquire a logging provider.  
```csharp
public interface IApiLoggerProvider
```

Derived  
&#8627; [HttpServiceProvider](TetraPak_AspNet_Api_HttpServiceProvider.md 'TetraPak.AspNet.Api.HttpServiceProvider')  
&#8627; [IHttpServiceProvider](TetraPak_AspNet_Api_IHttpServiceProvider.md 'TetraPak.AspNet.Api.IHttpServiceProvider')  
### Methods
<a name='TetraPak_AspNet_Api_IApiLoggerProvider_GetLogger()'></a>
## IApiLoggerProvider.GetLogger() Method
Gets a logging provider.  
```csharp
Microsoft.Extensions.Logging.ILogger GetLogger();
```
#### Returns
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
A [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger') instance.  
  
