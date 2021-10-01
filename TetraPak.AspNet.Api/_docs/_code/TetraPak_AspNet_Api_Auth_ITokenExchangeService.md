#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## ITokenExchangeService Interface
Implementors of this interface can be used for exchanging access tokens.    
```csharp
public interface ITokenExchangeService
```

Derived  
&#8627; [TetraPakTokenExchangeService](TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeService.md 'TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeService')  
### Methods
<a name='TetraPak_AspNet_Api_Auth_ITokenExchangeService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken)'></a>
## ITokenExchangeService.ExchangeAccessTokenAsync(Credentials, ActorToken, CancellationToken) Method
Exchanges a specified access token for a new, to be used for consuming a service.  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Api.Auth.TokenExchangeResponse>> ExchangeAccessTokenAsync(TetraPak.Credentials credentials, TetraPak.ActorToken accessToken, System.Threading.CancellationToken cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_ITokenExchangeService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken)_credentials'></a>
`credentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
Specifies the credentials used for the token exchange  
(typically [TetraPak.BasicAuthCredentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.BasicAuthCredentials 'TetraPak.BasicAuthCredentials') carrying client id and client secret).  
  
<a name='TetraPak_AspNet_Api_Auth_ITokenExchangeService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken)_accessToken'></a>
`accessToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
The access token to be exchanged.  
  
<a name='TetraPak_AspNet_Api_Auth_ITokenExchangeService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
A cancellation token.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TokenExchangeResponse](TetraPak_AspNet_Api_Auth_TokenExchangeResponse.md 'TetraPak.AspNet.Api.Auth.TokenExchangeResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and.  
On success the value also carries the requested result; otherwise a [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') might  
be carried instead.  
  
<a name='TetraPak_AspNet_Api_Auth_ITokenExchangeService_OnGetAuthorizationFrom(TetraPak_AspNet_Api_Auth_TokenExchangeResponse)'></a>
## ITokenExchangeService.OnGetAuthorizationFrom(TokenExchangeResponse) Method
Creates a [System.Net.Http.Headers.AuthenticationHeaderValue](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.Headers.AuthenticationHeaderValue 'System.Net.Http.Headers.AuthenticationHeaderValue') from a [TokenExchangeResponse](TetraPak_AspNet_Api_Auth_TokenExchangeResponse.md 'TetraPak.AspNet.Api.Auth.TokenExchangeResponse').   
```csharp
System.Net.Http.Headers.AuthenticationHeaderValue OnGetAuthorizationFrom(TetraPak.AspNet.Api.Auth.TokenExchangeResponse tokenExchangeResponse);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_ITokenExchangeService_OnGetAuthorizationFrom(TetraPak_AspNet_Api_Auth_TokenExchangeResponse)_tokenExchangeResponse'></a>
`tokenExchangeResponse` [TokenExchangeResponse](TetraPak_AspNet_Api_Auth_TokenExchangeResponse.md 'TetraPak.AspNet.Api.Auth.TokenExchangeResponse')  
A response from a token exchange.    
  
#### Returns
[System.Net.Http.Headers.AuthenticationHeaderValue](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.Headers.AuthenticationHeaderValue 'System.Net.Http.Headers.AuthenticationHeaderValue')  
  
