#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TetraPakTokenExchangeService Class
Use this service for easy token exchange.  
```csharp
public class TetraPakTokenExchangeService :
TetraPak.AspNet.Api.Auth.ITokenExchangeService,
TetraPak.AspNet.IMessageIdProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakTokenExchangeService  

Implements [ITokenExchangeService](TetraPak_AspNet_Api_Auth_ITokenExchangeService.md 'TetraPak.AspNet.Api.Auth.ITokenExchangeService'), [TetraPak.AspNet.IMessageIdProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IMessageIdProvider 'TetraPak.AspNet.IMessageIdProvider')  
### Constructors
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_TetraPakTokenExchangeService(TetraPak_AspNet_AmbientData)'></a>
## TetraPakTokenExchangeService.TetraPakTokenExchangeService(AmbientData) Constructor
Initializes the [TetraPakTokenExchangeService](TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService.md 'TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeService').  
```csharp
public TetraPakTokenExchangeService(TetraPak.AspNet.AmbientData ambientData);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_TetraPakTokenExchangeService(TetraPak_AspNet_AmbientData)_ambientData'></a>
`ambientData` [TetraPak.AspNet.AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AmbientData 'TetraPak.AspNet.AmbientData')  
Provides ambient data from the request/response roundtrip.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[ambientData](TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService.md#TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_TetraPakTokenExchangeService(TetraPak_AspNet_AmbientData)_ambientData 'TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeService.TetraPakTokenExchangeService(TetraPak.AspNet.AmbientData).ambientData') was unassigned.  
            
[TetraPak.AspNet.ConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ConfigurationException 'TetraPak.AspNet.ConfigurationException')  
The [TetraPak.AspNet.AmbientData.AuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AmbientData.AuthConfig 'TetraPak.AspNet.AmbientData.AuthConfig') instance was not of type [TetraPakApiAuthConfig](TetraPak_AspNet_Api_Auth_TetraPakApiAuthConfig.md 'TetraPak.AspNet.Api.Auth.TetraPakApiAuthConfig').  
  
### Properties
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_AuthConfig'></a>
## TetraPakTokenExchangeService.AuthConfig Property
Gets the auth configuration code API.  
```csharp
protected TetraPak.AspNet.Api.Auth.TetraPakApiAuthConfig AuthConfig { get; }
```
#### Property Value
[TetraPakApiAuthConfig](TetraPak_AspNet_Api_Auth_TetraPakApiAuthConfig.md 'TetraPak.AspNet.Api.Auth.TetraPakApiAuthConfig')
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_Logger'></a>
## TetraPakTokenExchangeService.Logger Property
Gets a logging provider.  
```csharp
protected Microsoft.Extensions.Logging.ILogger Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
### Methods
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken)'></a>
## TetraPakTokenExchangeService.ExchangeAccessTokenAsync(Credentials, ActorToken, CancellationToken) Method
Exchanges a specified access token for a new, to be used for consuming a service.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Api.Auth.TokenExchangeResponse>> ExchangeAccessTokenAsync(TetraPak.Credentials credentials, TetraPak.ActorToken accessToken, System.Threading.CancellationToken cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken)_credentials'></a>
`credentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
Specifies the credentials used for the token exchange  
(typically [TetraPak.BasicAuthCredentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.BasicAuthCredentials 'TetraPak.BasicAuthCredentials') carrying client id and client secret).  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken)_accessToken'></a>
`accessToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
The access token to be exchanged.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
A cancellation token.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TokenExchangeResponse](TetraPak_AspNet_Api_Auth_TokenExchangeResponse.md 'TetraPak.AspNet.Api.Auth.TokenExchangeResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and.  
On success the value also carries the requested result; otherwise a [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') might  
be carried instead.  

Implements [ExchangeAccessTokenAsync(Credentials, ActorToken, CancellationToken)](TetraPak_AspNet_Api_Auth_ITokenExchangeService.md#TetraPak_AspNet_Api_Auth_ITokenExchangeService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken) 'TetraPak.AspNet.Api.Auth.ITokenExchangeService.ExchangeAccessTokenAsync(TetraPak.Credentials, TetraPak.ActorToken, System.Threading.CancellationToken)')  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_GetMessageId(bool)'></a>
## TetraPakTokenExchangeService.GetMessageId(bool) Method
Retrieves a request message id if available.   
```csharp
public string GetMessageId(bool enforce=false);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_GetMessageId(bool)_enforce'></a>
`enforce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set a message id will be generated and injected into the request/response context.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value if a message id was available (or enforced); otherwise `null`.  

Implements [GetMessageId(bool)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IMessageIdProvider.GetMessageId#TetraPak_AspNet_IMessageIdProvider_GetMessageId_System_Boolean_ 'TetraPak.AspNet.IMessageIdProvider.GetMessageId(System.Boolean)')  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_OnGetAuthorizationFrom(TetraPak_AspNet_Api_Auth_TokenExchangeResponse)'></a>
## TetraPakTokenExchangeService.OnGetAuthorizationFrom(TokenExchangeResponse) Method
Creates a [System.Net.Http.Headers.AuthenticationHeaderValue](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.Headers.AuthenticationHeaderValue 'System.Net.Http.Headers.AuthenticationHeaderValue') from a [TokenExchangeResponse](TetraPak_AspNet_Api_Auth_TokenExchangeResponse.md 'TetraPak.AspNet.Api.Auth.TokenExchangeResponse').   
```csharp
public virtual System.Net.Http.Headers.AuthenticationHeaderValue OnGetAuthorizationFrom(TetraPak.AspNet.Api.Auth.TokenExchangeResponse tokenExchangeResponse);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService_OnGetAuthorizationFrom(TetraPak_AspNet_Api_Auth_TokenExchangeResponse)_tokenExchangeResponse'></a>
`tokenExchangeResponse` [TokenExchangeResponse](TetraPak_AspNet_Api_Auth_TokenExchangeResponse.md 'TetraPak.AspNet.Api.Auth.TokenExchangeResponse')  
A response from a token exchange.    
  
#### Returns
[System.Net.Http.Headers.AuthenticationHeaderValue](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.Headers.AuthenticationHeaderValue 'System.Net.Http.Headers.AuthenticationHeaderValue')  

Implements [OnGetAuthorizationFrom(TokenExchangeResponse)](TetraPak_AspNet_Api_Auth_ITokenExchangeService.md#TetraPak_AspNet_Api_Auth_ITokenExchangeService_OnGetAuthorizationFrom(TetraPak_AspNet_Api_Auth_TokenExchangeResponse) 'TetraPak.AspNet.Api.Auth.ITokenExchangeService.OnGetAuthorizationFrom(TetraPak.AspNet.Api.Auth.TokenExchangeResponse)')  
  
