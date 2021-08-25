#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## IBackendService Interface
Classes implementing this contract can be used to consume a backend service.   
```csharp
public interface IBackendService :
TetraPak.AspNet.Auth.IServiceAuthConfig
```

Derived  
&#8627; [BackendService&lt;TEndpoints&gt;](TetraPak_AspNet_Api_BackendService_TEndpoints_.md 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;')  

Implements [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')  

| Properties | |
| :--- | :--- |
| [DefaultClientOptions](TetraPak_AspNet_Api_IBackendService_DefaultClientOptions.md 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions') | Gets default options for the creating clients for the backend service. <br/> |

| Methods | |
| :--- | :--- |
| [GetAsync(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string).md 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)') | Sends a GET request to the backend service to retrieve a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage').<br/> |
| [GetAsync(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string).md 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)') | Sends a GEt request to the backend service to retrieve a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage').<br/> |
| [GetAsync&lt;T&gt;(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string).md 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)') | Sends a GET request to the backend service to retrieve an object of a specified type.<br/> |
| [GetAsync&lt;T&gt;(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string).md 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)') | Sends a GET request to the backend service to retrieve an object of a specified type.<br/> |
| [PostAsync(string, HttpContent, HttpClientOptions, Nullable&lt;CancellationToken&gt;)](TetraPak_AspNet_Api_IBackendService_PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_).md 'TetraPak.AspNet.Api.IBackendService.PostAsync(string, System.Net.Http.HttpContent, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;)') | Sends a POST request to the backend service.<br/> |
