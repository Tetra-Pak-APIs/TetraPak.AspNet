#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## HttpServiceProvider Class
Implements base functionality for providing HTTP clients  
to be used when consuming configured backend services.   
```csharp
public class HttpServiceProvider :
TetraPak.AspNet.Api.IHttpServiceProvider,
TetraPak.AspNet.Api.IApiLoggerProvider,
TetraPak.AspNet.IMessageIdProvider,
TetraPak.AspNet.Auth.IAccessTokenProvider,
TetraPak.AspNet.Api.ITetraPakDiagnosticsProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpServiceProvider  

Implements [IHttpServiceProvider](TetraPak_AspNet_Api_IHttpServiceProvider.md 'TetraPak.AspNet.Api.IHttpServiceProvider'), [IApiLoggerProvider](TetraPak_AspNet_Api_IApiLoggerProvider.md 'TetraPak.AspNet.Api.IApiLoggerProvider'), [TetraPak.AspNet.IMessageIdProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IMessageIdProvider 'TetraPak.AspNet.IMessageIdProvider'), [TetraPak.AspNet.Auth.IAccessTokenProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IAccessTokenProvider 'TetraPak.AspNet.Auth.IAccessTokenProvider'), [TetraPak.AspNet.Api.ITetraPakDiagnosticsProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.ITetraPakDiagnosticsProvider 'TetraPak.AspNet.Api.ITetraPakDiagnosticsProvider')  
### Properties
<a name='TetraPak_AspNet_Api_HttpServiceProvider_ClientCredentialsService'></a>
## HttpServiceProvider.ClientCredentialsService Property
Gets a [IClientCredentialsService](TetraPak_AspNet_Api_Auth_IClientCredentialsService.md 'TetraPak.AspNet.Api.Auth.IClientCredentialsService') for acquiring a token to be used  
with clients consuming services.  
```csharp
protected TetraPak.AspNet.Api.Auth.IClientCredentialsService ClientCredentialsService { get; }
```
#### Property Value
[IClientCredentialsService](TetraPak_AspNet_Api_Auth_IClientCredentialsService.md 'TetraPak.AspNet.Api.Auth.IClientCredentialsService')
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_Logger'></a>
## HttpServiceProvider.Logger Property
Gets a logging provider.  
```csharp
protected Microsoft.Extensions.Logging.ILogger Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_TokenExchangeService'></a>
## HttpServiceProvider.TokenExchangeService Property
Gets a [ITokenExchangeService](TetraPak_AspNet_Api_Auth_ITokenExchangeService.md 'TetraPak.AspNet.Api.Auth.ITokenExchangeService') for acquiring a token to be used  
with clients consuming services.    
```csharp
protected TetraPak.AspNet.Api.Auth.ITokenExchangeService TokenExchangeService { get; }
```
#### Property Value
[ITokenExchangeService](TetraPak_AspNet_Api_Auth_ITokenExchangeService.md 'TetraPak.AspNet.Api.Auth.ITokenExchangeService')
  
### Methods
<a name='TetraPak_AspNet_Api_HttpServiceProvider_AuthenticateAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger)'></a>
## HttpServiceProvider.AuthenticateAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;, ILogger) Method
Authenticates a specific service.   
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> AuthenticateAsync(TetraPak.AspNet.Api.HttpClientOptions options, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, Microsoft.Extensions.Logging.ILogger logger=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_HttpServiceProvider_AuthenticateAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger)_options'></a>
`options` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_AuthenticateAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_AuthenticateAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
(optional)<br/>  
An [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger') instance.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and, on success, carrying  
the requested token as its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value'); otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [AuthenticateAsync(HttpClientOptions, Nullable<CancellationToken>, ILogger)](TetraPak_AspNet_Api_IHttpServiceProvider.md#TetraPak_AspNet_Api_IHttpServiceProvider_AuthenticateAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger) 'TetraPak.AspNet.Api.IHttpServiceProvider.AuthenticateAsync(TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, Microsoft.Extensions.Logging.ILogger)')  
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_GetAccessTokenAsync(bool)'></a>
## HttpServiceProvider.GetAccessTokenAsync(bool) Method
Gets an access token from the request context.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(bool forceStandardHeader=false);
```
#### Parameters
<a name='TetraPak_AspNet_Api_HttpServiceProvider_GetAccessTokenAsync(bool)_forceStandardHeader'></a>
`forceStandardHeader` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set the configured (see [TetraPak.AspNet.TetraPakConfig.AuthorizationHeader](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig.AuthorizationHeader 'TetraPak.AspNet.TetraPakConfig.AuthorizationHeader')) authorization  
header is ignored in favour of the HTTP standard [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization') header.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetAccessTokenAsync(bool)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IAccessTokenProvider.GetAccessTokenAsync#TetraPak_AspNet_Auth_IAccessTokenProvider_GetAccessTokenAsync_System_Boolean_ 'TetraPak.AspNet.Auth.IAccessTokenProvider.GetAccessTokenAsync(System.Boolean)')  
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_GetClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger_bool)'></a>
## HttpServiceProvider.GetClientAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;, ILogger, bool) Method
Creates and returns a (configured) [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') for use with a specific service.   
```csharp
public virtual System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpClient>> GetClientAsync(TetraPak.AspNet.Api.HttpClientOptions options=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, Microsoft.Extensions.Logging.ILogger logger=null, bool authenticate=true);
```
#### Parameters
<a name='TetraPak_AspNet_Api_HttpServiceProvider_GetClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger_bool)_options'></a>
`options` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional)<br/>  
A (customizable) set of options to describe the requested [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient').  
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_GetClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger_bool)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_GetClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger_bool)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
(optional)<br/>  
An [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger') instance.  
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_GetClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger_bool)_authenticate'></a>
`authenticate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether the created client should automatically be configured.  
Set to false to avoid implicitly invoking the [AuthenticateAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;, ILogger)](TetraPak_AspNet_Api_IHttpServiceProvider.md#TetraPak_AspNet_Api_IHttpServiceProvider_AuthenticateAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger) 'TetraPak.AspNet.Api.IHttpServiceProvider.AuthenticateAsync(TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, Microsoft.Extensions.Logging.ILogger)') method.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and, on success, carrying  
the requested client as its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value'); otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetClientAsync(HttpClientOptions, Nullable<CancellationToken>, ILogger, bool)](TetraPak_AspNet_Api_IHttpServiceProvider.md#TetraPak_AspNet_Api_IHttpServiceProvider_GetClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger_bool) 'TetraPak.AspNet.Api.IHttpServiceProvider.GetClientAsync(TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, Microsoft.Extensions.Logging.ILogger, bool)')  
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_GetMessageId(bool)'></a>
## HttpServiceProvider.GetMessageId(bool) Method
Retrieves a request message id if available.   
```csharp
public string GetMessageId(bool enforce=false);
```
#### Parameters
<a name='TetraPak_AspNet_Api_HttpServiceProvider_GetMessageId(bool)_enforce'></a>
`enforce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set a message id will be generated and injected into the request/response context.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value if a message id was available (or enforced); otherwise `null`.  

Implements [GetMessageId(bool)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IMessageIdProvider.GetMessageId#TetraPak_AspNet_IMessageIdProvider_GetMessageId_System_Boolean_ 'TetraPak.AspNet.IMessageIdProvider.GetMessageId(System.Boolean)')  
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_GetTokenExchangeService()'></a>
## HttpServiceProvider.GetTokenExchangeService() Method
Acquires a token exchange service.  
```csharp
public System.Threading.Tasks.Task<TetraPak.AspNet.Api.Auth.ITokenExchangeService> GetTokenExchangeService();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ITokenExchangeService](TetraPak_AspNet_Api_Auth_ITokenExchangeService.md 'TetraPak.AspNet.Api.Auth.ITokenExchangeService')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetTokenExchangeService()](TetraPak_AspNet_Api_IHttpServiceProvider.md#TetraPak_AspNet_Api_IHttpServiceProvider_GetTokenExchangeService() 'TetraPak.AspNet.Api.IHttpServiceProvider.GetTokenExchangeService()')  
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_OnClientCredentialsAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_System_Nullable_System_Threading_CancellationToken_)'></a>
## HttpServiceProvider.OnClientCredentialsAuthenticationAsync(IServiceAuthConfig, Nullable&lt;CancellationToken&gt;) Method
This method is called to acquire a token using the Client Credentials grant type.   
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> OnClientCredentialsAuthenticationAsync(TetraPak.AspNet.Auth.IServiceAuthConfig authConfig, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_HttpServiceProvider_OnClientCredentialsAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_System_Nullable_System_Threading_CancellationToken_)_authConfig'></a>
`authConfig` [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')  
Specifies the authentication credentials and options.  
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_OnClientCredentialsAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[TetraPak.AspNet.ConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ConfigurationException 'TetraPak.AspNet.ConfigurationException')  
There where issues with the configured options, such as client id/secret.  
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken_System_Nullable_System_Threading_CancellationToken_)'></a>
## HttpServiceProvider.OnTokenExchangeAuthenticationAsync(IServiceAuthConfig, ActorToken, Nullable&lt;CancellationToken&gt;) Method
This method is called to acquire a token using the Token Exchange grant type.   
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> OnTokenExchangeAuthenticationAsync(TetraPak.AspNet.Auth.IServiceAuthConfig authConfig, TetraPak.ActorToken accessToken, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_HttpServiceProvider_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken_System_Nullable_System_Threading_CancellationToken_)_authConfig'></a>
`authConfig` [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')  
Specifies the authentication credentials and options.  
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken_System_Nullable_System_Threading_CancellationToken_)_accessToken'></a>
`accessToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
The access token to be exchanged.  
  
<a name='TetraPak_AspNet_Api_HttpServiceProvider_OnTokenExchangeAuthenticationAsync(TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_ActorToken_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[TetraPak.AspNet.ConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ConfigurationException 'TetraPak.AspNet.ConfigurationException')  
There where issues with the configured options, such as client id/secret.  
  
