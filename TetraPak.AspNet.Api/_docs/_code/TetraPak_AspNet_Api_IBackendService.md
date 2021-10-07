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
### Properties
<a name='TetraPak_AspNet_Api_IBackendService_DefaultClientOptions'></a>
## IBackendService.DefaultClientOptions Property
Gets default options for the creating clients for the backend service.   
```csharp
TetraPak.AspNet.Api.HttpClientOptions DefaultClientOptions { get; }
```
#### Property Value
[HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')
  
<a name='TetraPak_AspNet_Api_IBackendService_ServiceName'></a>
## IBackendService.ServiceName Property
Gets the identity of the service. This identity should be unique with the runtime context.   
```csharp
string ServiceName { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
### Methods
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)'></a>
## IBackendService.GetAsync(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string) Method
Sends a GET request to the backend service to retrieve a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage').  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> GetAsync(string path, string queryParameters=null, TetraPak.AspNet.Api.HttpClientOptions clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, string messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_queryParameters'></a>
`queryParameters` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br/>  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt/>  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### See Also
- [GetAsync(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync&lt;T&gt;(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync&lt;T&gt;(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)'></a>
## IBackendService.GetAsync(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string) Method
Sends a GEt request to the backend service to retrieve a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage').  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> GetAsync(string path, System.Collections.Generic.IDictionary<string,string> queryParameters, TetraPak.AspNet.Api.HttpClientOptions clientOptions, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, string messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_queryParameters'></a>
`queryParameters` [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br/>  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt/>  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### See Also
- [GetAsync(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync&lt;T&gt;(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync&lt;T&gt;(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)'></a>
## IBackendService.GetAsync&lt;T&gt;(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string) Method
Sends a GET request to the backend service to retrieve an object of a specified type.  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<T>> GetAsync<T>(string path, string queryParameters=null, TetraPak.AspNet.Api.HttpClientOptions clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, string messageId=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_T'></a>
`T`  
Specifies the type of object to be retrieved.
  
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_queryParameters'></a>
`queryParameters` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br/>  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt/>  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[T](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_T 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### See Also
- [GetAsync(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync&lt;T&gt;(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)'></a>
## IBackendService.GetAsync&lt;T&gt;(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string) Method
Sends a GET request to the backend service to retrieve an object of a specified type.  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<T>> GetAsync<T>(string path, System.Collections.Generic.IDictionary<string,string> queryParameters, TetraPak.AspNet.Api.HttpClientOptions clientOptions, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, string messageId=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_T'></a>
`T`  
Specifies the type of object to be retrieved.
  
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_queryParameters'></a>
`queryParameters` [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br/>  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt/>  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[T](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string)_T 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### See Also
- [GetAsync(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync&lt;T&gt;(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
  
<a name='TetraPak_AspNet_Api_IBackendService_PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)'></a>
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
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br/>  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_IBackendService_PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
