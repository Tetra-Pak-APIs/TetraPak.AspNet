#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## IHttpClientProvider Interface
Classes implementing this interface can be used as a factory for obtaining [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')s.  
```csharp
public interface IHttpClientProvider
```

Derived  
&#8627; [TetraPakHttpClientProvider](TetraPak_AspNet_TetraPakHttpClientProvider.md 'TetraPak.AspNet.TetraPakHttpClientProvider')  
### Methods
<a name='TetraPak_AspNet_IHttpClientProvider_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)'></a>
## IHttpClientProvider.GetHttpClientAsync(HttpClientOptions?, Nullable&lt;CancellationToken&gt;) Method
Creates and returns a (configured) [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') for use with a specific service.   
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpClient>> GetHttpClientAsync(TetraPak.AspNet.HttpClientOptions? options=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_IHttpClientProvider_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_options'></a>
`options` [HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions')  
(optional)<br/>  
A (customizable) set of options to describe the requested [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient').  
  
<a name='TetraPak_AspNet_IHttpClientProvider_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and, on success, carrying  
the requested client as its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value'); otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
