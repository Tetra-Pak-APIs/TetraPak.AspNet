#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api').[BackendService&lt;TEndpoints&gt;](TetraPak_AspNet_Api_BackendService_TEndpoints_.md 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;')
## BackendService&lt;TEndpoints&gt;.OnGetHttpClientAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
This method gets invoked when the class needs a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') instance.  
The calling code expects the returned client to be fully configured according to the  
options specified in [clientOptions](TetraPak_AspNet_Api_BackendService_TEndpoints__OnGetHttpClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_).md#TetraPak_AspNet_Api_BackendService_TEndpoints__OnGetHttpClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_clientOptions 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.OnGetHttpClientAsync(TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;).clientOptions').  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpClient>> OnGetHttpClientAsync(TetraPak.AspNet.Api.HttpClientOptions clientOptions, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnGetHttpClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
Specifies how to configure/authorize the requested client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnGetHttpClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') to be used for cancelling the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
