#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## TetraPakApiAuthorizationService Class
This class is intended to be instantiated via a dependency injection mechanism.   
```csharp
internal class TetraPakApiAuthorizationService :
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
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakApiAuthorizationService.AuthorizeAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
Authenticates a specific service.   
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> AuthorizeAsync(TetraPak.AspNet.HttpClientOptions options, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_options'></a>
`options` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
Options for obtaining a client.  
  
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and, on success, carrying  
the requested token as its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value'); otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[options](TetraPak_AspNet_Api_TetraPakApiAuthorizationService.md#TetraPak_AspNet_Api_TetraPakApiAuthorizationService_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_options 'TetraPak.AspNet.Api.TetraPakApiAuthorizationService.AuthorizeAsync(TetraPak.AspNet.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;).options') configuration ([TetraPak.AspNet.HttpClientOptions.AuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions.AuthConfig 'TetraPak.AspNet.HttpClientOptions.AuthConfig')) was unassigned.  
            

Implements [AuthorizeAsync(HttpClientOptions, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IAuthorizationService.AuthorizeAsync#TetraPak_AspNet_IAuthorizationService_AuthorizeAsync_TetraPak_AspNet_HttpClientOptions,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.IAuthorizationService.AuthorizeAsync(TetraPak.AspNet.HttpClientOptions,System.Nullable{System.Threading.CancellationToken})')  
  
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
[TetraPak.AspNet.ServerConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ServerConfigurationException 'TetraPak.AspNet.ServerConfigurationException')  
There where issues with the configured options, such as client id/secret.  
  
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken__bool_System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakApiAuthorizationService.OnTokenExchangeAuthenticationAsync(IServiceAuthConfig, ActorToken?, bool, Nullable&lt;CancellationToken&gt;) Method
This method is called to acquire a token using the Token Exchange grant type.   
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> OnTokenExchangeAuthenticationAsync(TetraPak.AspNet.Auth.IServiceAuthConfig authConfig, TetraPak.ActorToken? subjectToken, bool forceAuthorization, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken__bool_System_Nullable_System_Threading_CancellationToken_)_authConfig'></a>
`authConfig` [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')  
Specifies the authentication credentials and options.  
  
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken__bool_System_Nullable_System_Threading_CancellationToken_)_subjectToken'></a>
`subjectToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
The access token to be exchanged.  
  
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken__bool_System_Nullable_System_Threading_CancellationToken_)_forceAuthorization'></a>
`forceAuthorization` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Specifies whether to force a new client authorization (overriding/replacing any cached authorization).   
  
<a name='TetraPak_AspNet_Api_TetraPakApiAuthorizationService_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken__bool_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[TetraPak.AspNet.ServerConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ServerConfigurationException 'TetraPak.AspNet.ServerConfigurationException')  
There where issues with the configured options, such as client id/secret.  
  
