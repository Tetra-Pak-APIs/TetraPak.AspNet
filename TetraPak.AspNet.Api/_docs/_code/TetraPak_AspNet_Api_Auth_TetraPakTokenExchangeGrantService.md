#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TetraPakTokenExchangeGrantService Class
Use this service for easy token exchange.  
```csharp
public class TetraPakTokenExchangeGrantService :
TetraPak.AspNet.Api.Auth.ITokenExchangeGrantService,
TetraPak.AspNet.IMessageIdProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakTokenExchangeGrantService  

Implements [ITokenExchangeGrantService](TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService.md 'TetraPak.AspNet.Api.Auth.ITokenExchangeGrantService'), [TetraPak.AspNet.IMessageIdProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IMessageIdProvider 'TetraPak.AspNet.IMessageIdProvider')  
### Constructors
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_TetraPakTokenExchangeGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider)'></a>
## TetraPakTokenExchangeGrantService.TetraPakTokenExchangeGrantService(TetraPakConfig, IHttpClientProvider) Constructor
Initializes the [TetraPakTokenExchangeGrantService](TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService.md 'TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeGrantService').  
```csharp
public TetraPakTokenExchangeGrantService(TetraPak.AspNet.TetraPakConfig config, TetraPak.AspNet.IHttpClientProvider httpClientProvider);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_TetraPakTokenExchangeGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider)_config'></a>
`config` [TetraPak.AspNet.TetraPakConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig 'TetraPak.AspNet.TetraPakConfig')  
The Tetra Pak integration configuration.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_TetraPakTokenExchangeGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider)_httpClientProvider'></a>
`httpClientProvider` [TetraPak.AspNet.IHttpClientProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IHttpClientProvider 'TetraPak.AspNet.IHttpClientProvider')  
A HttpClient factory.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[config](TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService.md#TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_TetraPakTokenExchangeGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider)_config 'TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeGrantService.TetraPakTokenExchangeGrantService(TetraPak.AspNet.TetraPakConfig, TetraPak.AspNet.IHttpClientProvider).config') was unassigned.  
            
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Any parameter was `null`.  
  
### Properties
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_Config'></a>
## TetraPakTokenExchangeGrantService.Config Property
Gets the auth configuration code API.  
```csharp
protected TetraPak.AspNet.TetraPakConfig Config { get; }
```
#### Property Value
[TetraPak.AspNet.TetraPakConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig 'TetraPak.AspNet.TetraPakConfig')
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_Logger'></a>
## TetraPakTokenExchangeGrantService.Logger Property
Gets a logging provider.  
```csharp
protected Microsoft.Extensions.Logging.ILogger? Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
### Methods
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken)'></a>
## TetraPakTokenExchangeGrantService.ExchangeAccessTokenAsync(Credentials, ActorToken, CancellationToken) Method
Exchanges a specified access token for a new, to be used for consuming a service.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Api.Auth.TokenExchangeResponse>> ExchangeAccessTokenAsync(TetraPak.Credentials credentials, TetraPak.ActorToken accessToken, System.Threading.CancellationToken cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken)_credentials'></a>
`credentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
Specifies the credentials used for the token exchange  
(typically [TetraPak.BasicAuthCredentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.BasicAuthCredentials 'TetraPak.BasicAuthCredentials') carrying client id and client secret).  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken)_accessToken'></a>
`accessToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
The access token to be exchanged.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
A cancellation token.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TokenExchangeResponse](TetraPak_AspNet_Api_Auth_TokenExchangeResponse.md 'TetraPak.AspNet.Api.Auth.TokenExchangeResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and.  
On success the value also carries the requested result; otherwise a [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') might  
be carried instead.  

Implements [ExchangeAccessTokenAsync(Credentials, ActorToken, CancellationToken)](TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService.md#TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken) 'TetraPak.AspNet.Api.Auth.ITokenExchangeGrantService.ExchangeAccessTokenAsync(TetraPak.Credentials, TetraPak.ActorToken, System.Threading.CancellationToken)')  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_GetMessageId(bool)'></a>
## TetraPakTokenExchangeGrantService.GetMessageId(bool) Method
Retrieves a request message id if available.   
```csharp
public string? GetMessageId(bool enforce=false);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_GetMessageId(bool)_enforce'></a>
`enforce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set a message id will be generated and injected into the request/response context.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value if a message id was available (or enforced); otherwise `null`.  

Implements [GetMessageId(bool)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IMessageIdProvider.GetMessageId#TetraPak_AspNet_IMessageIdProvider_GetMessageId_System_Boolean_ 'TetraPak.AspNet.IMessageIdProvider.GetMessageId(System.Boolean)')  
  
