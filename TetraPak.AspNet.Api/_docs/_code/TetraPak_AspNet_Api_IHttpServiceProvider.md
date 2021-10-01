#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## IHttpServiceProvider Interface
Provides a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient'), either as a singleton or a transient instance.     
```csharp
public interface IHttpServiceProvider :
TetraPak.AspNet.Api.IApiLoggerProvider,
TetraPak.AspNet.IMessageIdProvider,
TetraPak.AspNet.Auth.IAccessTokenProvider
```

Derived  
&#8627; [HttpServiceProvider](TetraPak_AspNet_Api_HttpServiceProvider.md 'TetraPak.AspNet.Api.HttpServiceProvider')  

Implements [IApiLoggerProvider](TetraPak_AspNet_Api_IApiLoggerProvider.md 'TetraPak.AspNet.Api.IApiLoggerProvider'), [TetraPak.AspNet.IMessageIdProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IMessageIdProvider 'TetraPak.AspNet.IMessageIdProvider'), [TetraPak.AspNet.Auth.IAccessTokenProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IAccessTokenProvider 'TetraPak.AspNet.Auth.IAccessTokenProvider')  
### Methods
<a name='TetraPak_AspNet_Api_IHttpServiceProvider_AuthenticateAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger)'></a>
## IHttpServiceProvider.AuthenticateAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;, ILogger) Method
Authenticates a specific service.   
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> AuthenticateAsync(TetraPak.AspNet.Api.HttpClientOptions options, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, Microsoft.Extensions.Logging.ILogger logger=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IHttpServiceProvider_AuthenticateAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger)_options'></a>
`options` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
  
<a name='TetraPak_AspNet_Api_IHttpServiceProvider_AuthenticateAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')
  
<a name='TetraPak_AspNet_Api_IHttpServiceProvider_AuthenticateAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
(optional)<br/>  
An [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger') instance.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and, on success, carrying  
the requested token as its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value'); otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_IHttpServiceProvider_GetClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger_bool)'></a>
## IHttpServiceProvider.GetClientAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;, ILogger, bool) Method
Creates and returns a (configured) [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') for use with a specific service.   
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpClient>> GetClientAsync(TetraPak.AspNet.Api.HttpClientOptions options=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, Microsoft.Extensions.Logging.ILogger logger=null, bool authenticate=true);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IHttpServiceProvider_GetClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger_bool)_options'></a>
`options` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional)<br/>  
A (customizable) set of options to describe the requested [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient').  
  
<a name='TetraPak_AspNet_Api_IHttpServiceProvider_GetClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger_bool)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')
  
<a name='TetraPak_AspNet_Api_IHttpServiceProvider_GetClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger_bool)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
(optional)<br/>  
An [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger') instance.  
  
<a name='TetraPak_AspNet_Api_IHttpServiceProvider_GetClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger_bool)_authenticate'></a>
`authenticate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether the created client should automatically be configured.  
Set to false to avoid implicitly invoking the [AuthenticateAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;, ILogger)](TetraPak_AspNet_Api_IHttpServiceProvider.md#TetraPak_AspNet_Api_IHttpServiceProvider_AuthenticateAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__Microsoft_Extensions_Logging_ILogger) 'TetraPak.AspNet.Api.IHttpServiceProvider.AuthenticateAsync(TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, Microsoft.Extensions.Logging.ILogger)') method.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and, on success, carrying  
the requested client as its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value'); otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_IHttpServiceProvider_GetTokenExchangeService()'></a>
## IHttpServiceProvider.GetTokenExchangeService() Method
Acquires a token exchange service.  
```csharp
System.Threading.Tasks.Task<TetraPak.AspNet.Api.Auth.ITokenExchangeService> GetTokenExchangeService();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ITokenExchangeService](TetraPak_AspNet_Api_Auth_ITokenExchangeService.md 'TetraPak.AspNet.Api.Auth.ITokenExchangeService')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
