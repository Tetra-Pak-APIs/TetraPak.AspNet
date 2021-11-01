#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## TetraPakApiAuthorizationService Class
```csharp
public class TetraPakApiAuthorizationService :
TetraPak.AspNet.IAuthorizationService,
TetraPak.AspNet.Diagnostics.ITetraPakDiagnosticsProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakApiAuthorizationService  

Implements [TetraPak.AspNet.IAuthorizationService](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IAuthorizationService 'TetraPak.AspNet.IAuthorizationService'), [TetraPak.AspNet.Diagnostics.ITetraPakDiagnosticsProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Diagnostics.ITetraPakDiagnosticsProvider 'TetraPak.AspNet.Diagnostics.ITetraPakDiagnosticsProvider')  
### Properties
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_ClientCredentialsGrantService'></a>
## TetraPakApiAuthorizationService.ClientCredentialsGrantService Property
Gets a [IClientCredentialsGrantService](TetraPak_AspNet_Api_Auth_IClientCredentialsGrantService.md 'TetraPak.AspNet.Api.Auth.IClientCredentialsGrantService') for acquiring a token to be used  
with clients consuming services.  
```csharp
private TetraPak.AspNet.Api.Auth.IClientCredentialsGrantService ClientCredentialsGrantService { get; }
```
#### Property Value
[IClientCredentialsGrantService](TetraPak_AspNet_Api_Auth_IClientCredentialsGrantService.md 'TetraPak.AspNet.Api.Auth.IClientCredentialsGrantService')
  
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_TokenExchangeGrantService'></a>
## TetraPakApiAuthorizationService.TokenExchangeGrantService Property
Gets a [ITokenExchangeGrantService](TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService.md 'TetraPak.AspNet.Api.Auth.ITokenExchangeGrantService') for acquiring a token to be used  
with clients consuming services.    
```csharp
private TetraPak.AspNet.Api.Auth.ITokenExchangeGrantService TokenExchangeGrantService { get; }
```
#### Property Value
[ITokenExchangeGrantService](TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService.md 'TetraPak.AspNet.Api.Auth.ITokenExchangeGrantService')
  
### Methods
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_OnClientCredentialsAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakApiAuthorizationService.OnClientCredentialsAuthenticationAsync(IServiceAuthConfig, Nullable&lt;CancellationToken&gt;) Method
This method is called to acquire a token using the Client Credentials grant type.   
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> OnClientCredentialsAuthenticationAsync(TetraPak.AspNet.Auth.IServiceAuthConfig authConfig, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_OnClientCredentialsAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_System_Nullable_System_Threading_CancellationToken_)_authConfig'></a>
`authConfig` [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')  
Specifies the authentication credentials and options.  
  
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_OnClientCredentialsAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[TetraPak.AspNet.ConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ConfigurationException 'TetraPak.AspNet.ConfigurationException')  
There where issues with the configured options, such as client id/secret.  
  
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken__System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakApiAuthorizationService.OnTokenExchangeAuthenticationAsync(IServiceAuthConfig, ActorToken?, Nullable&lt;CancellationToken&gt;) Method
This method is called to acquire a token using the Token Exchange grant type.   
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> OnTokenExchangeAuthenticationAsync(TetraPak.AspNet.Auth.IServiceAuthConfig authConfig, TetraPak.ActorToken? accessToken, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken__System_Nullable_System_Threading_CancellationToken_)_authConfig'></a>
`authConfig` [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')  
Specifies the authentication credentials and options.  
  
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken__System_Nullable_System_Threading_CancellationToken_)_accessToken'></a>
`accessToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
The access token to be exchanged.  
  
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[TetraPak.AspNet.ConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ConfigurationException 'TetraPak.AspNet.ConfigurationException')  
There where issues with the configured options, such as client id/secret.  
  
