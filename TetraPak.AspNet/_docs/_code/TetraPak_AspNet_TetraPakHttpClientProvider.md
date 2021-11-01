#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakHttpClientProvider Class
```csharp
public abstract class TetraPakHttpClientProvider :
TetraPak.AspNet.IHttpClientProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakHttpClientProvider  

Implements [IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider')  
### Properties
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_Logger'></a>
## TetraPakHttpClientProvider.Logger Property
Gets a logging provider.  
```csharp
protected Microsoft.Extensions.Logging.ILogger? Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
### Methods
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakHttpClientProvider.GetHttpClientAsync(HttpClientOptions?, Nullable&lt;CancellationToken&gt;) Method
Creates and returns a (configured) [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') for use with a specific service.   
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpClient>> GetHttpClientAsync(TetraPak.AspNet.HttpClientOptions? options=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_options'></a>
`options` [HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions')  
(optional)<br/>  
A (customizable) set of options to describe the requested [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient').  
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and, on success, carrying  
the requested client as its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value'); otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetHttpClientAsync(HttpClientOptions?, Nullable<CancellationToken>)](TetraPak_AspNet_IHttpClientProvider.md#TetraPak_AspNet_IHttpClientProvider_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.IHttpClientProvider.GetHttpClientAsync(TetraPak.AspNet.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_OnAuthorizeClientAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakHttpClientProvider.OnAuthorizeClientAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
Called internally to authorize this service as a client.  
```csharp
protected abstract System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> OnAuthorizeClientAsync(TetraPak.AspNet.HttpClientOptions options, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_OnAuthorizeClientAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_options'></a>
`options` [HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions')  
Options, describing the client.   
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_OnAuthorizeClientAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows cancelling the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
