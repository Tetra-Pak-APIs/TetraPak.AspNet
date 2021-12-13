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
<a name='TetraPak_AspNet_Api_IBackendService_ServiceName'></a>
## IBackendService.ServiceName Property
Gets the identity of the service. This identity should be unique with the runtime context.   
```csharp
string ServiceName { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
### Methods
<a name='TetraPak_AspNet_Api_IBackendService_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)'></a>
## IBackendService.AuthorizeAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
Obtains authorization to consume the service.   
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> AuthorizeAsync(TetraPak.AspNet.HttpClientOptions clientOptions, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
Specifies options for the client to be used during the authorization.  
  
<a name='TetraPak_AspNet_Api_IBackendService_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
Allows canceling the authorization process.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_IBackendService_DeleteRawAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)'></a>
## IBackendService.DeleteRawAsync(string, HttpQuery?, RequestOptions?) Method
Sends a GET request to the backend service to retrieve an object of a specified type.  
```csharp
System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> DeleteRawAsync(string path, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_DeleteRawAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_IBackendService_DeleteRawAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_IBackendService_DeleteRawAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### See Also
- [GetRawAsync(string, HttpQuery?, RequestOptions?)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetRawAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_) 'TetraPak.AspNet.Api.IBackendService.GetRawAsync(string, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?)')
  
<a name='TetraPak_AspNet_Api_IBackendService_GetCollectionAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)'></a>
## IBackendService.GetCollectionAsync&lt;T&gt;(string, HttpQuery?, RequestOptions?) Method
Sends a GET request to the backend service to retrieve an object of a specified type.  
```csharp
System.Threading.Tasks.Task<TetraPak.AspNet.HttpEnumOutcome<T>> GetCollectionAsync<T>(string path, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_IBackendService_GetCollectionAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_T'></a>
`T`  
Specifies the type of object to be retrieved.
  
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_GetCollectionAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_IBackendService_GetCollectionAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetCollectionAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpEnumOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpEnumOutcome-1 'TetraPak.AspNet.HttpEnumOutcome`1')[T](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetCollectionAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_T 'TetraPak.AspNet.Api.IBackendService.GetCollectionAsync&lt;T&gt;(string, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpEnumOutcome-1 'TetraPak.AspNet.HttpEnumOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### See Also
- [GetRawAsync(string, HttpQuery?, RequestOptions?)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetRawAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_) 'TetraPak.AspNet.Api.IBackendService.GetRawAsync(string, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?)')
  
<a name='TetraPak_AspNet_Api_IBackendService_GetEndpoint(string)'></a>
## IBackendService.GetEndpoint(string) Method
Gets a named service endpoint.  
```csharp
TetraPak.AspNet.Api.ServiceEndpoint GetEndpoint(string name);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_GetEndpoint(string)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the requested endpoint.  
  
#### Returns
[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[name](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetEndpoint(string)_name 'TetraPak.AspNet.Api.IBackendService.GetEndpoint(string).name') was unassigned (`null` or just whitespace).  
            
  
<a name='TetraPak_AspNet_Api_IBackendService_GetEndpoints()'></a>
## IBackendService.GetEndpoints() Method
Gets a collection of [System.Collections.Generic.KeyValuePair&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2') with all endpoint names (key)  
and the corresponding [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') (value).  
```csharp
System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string,TetraPak.AspNet.Api.ServiceEndpoint>> GetEndpoints();
```
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of key value pairs with the names of endpoints as keys.   
  
<a name='TetraPak_AspNet_Api_IBackendService_GetRawAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)'></a>
## IBackendService.GetRawAsync(string, HttpQuery?, RequestOptions?) Method
Sends a GEt request to the backend service to retrieve a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage').  
```csharp
System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> GetRawAsync(string path, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_GetRawAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_IBackendService_GetRawAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_IBackendService_GetRawAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### See Also
- [GetCollectionAsync&lt;T&gt;(string, HttpQuery?, RequestOptions?)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetCollectionAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_) 'TetraPak.AspNet.Api.IBackendService.GetCollectionAsync&lt;T&gt;(string, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?)')
  
<a name='TetraPak_AspNet_Api_IBackendService_PatchRawAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)'></a>
## IBackendService.PatchRawAsync(string, HttpContent, RequestOptions?) Method
Sends a PATCH request to the backend service.  
```csharp
System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PatchRawAsync(string path, System.Net.Http.HttpContent content, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_PatchRawAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_IBackendService_PatchRawAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The content to be patched.  
  
<a name='TetraPak_AspNet_Api_IBackendService_PatchRawAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_IBackendService_PostRawAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)'></a>
## IBackendService.PostRawAsync(string, HttpContent, RequestOptions?) Method
Sends a POST request to the backend service.  
```csharp
System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PostRawAsync(string path, System.Net.Http.HttpContent content, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_PostRawAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_IBackendService_PostRawAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The content to be posted.  
  
<a name='TetraPak_AspNet_Api_IBackendService_PostRawAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_IBackendService_PutRawAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)'></a>
## IBackendService.PutRawAsync(string, HttpContent, RequestOptions?) Method
Sends a PUT request to the backend service.  
```csharp
System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PutRawAsync(string path, System.Net.Http.HttpContent content, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IBackendService_PutRawAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_IBackendService_PutRawAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The content to be put.  
  
<a name='TetraPak_AspNet_Api_IBackendService_PutRawAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
