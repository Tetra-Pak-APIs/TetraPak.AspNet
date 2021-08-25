#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api').[IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService')
## IBackendService.PostAsync(string, HttpContent, HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
Sends a POST request to the backend service.  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> PostAsync(string path, System.Net.Http.HttpContent content, TetraPak.AspNet.Api.HttpClientOptions clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_IBackendService_PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The content to be posted.  
  
<a name='TetraPak_AspNet_Api_IBackendService_PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService_DefaultClientOptions.md 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br />  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_IBackendService_PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br />  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
