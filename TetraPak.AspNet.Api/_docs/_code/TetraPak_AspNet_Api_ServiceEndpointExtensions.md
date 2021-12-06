#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## ServiceEndpointExtensions Class
Convenient methods to help consuming service endpoints.    
```csharp
public static class ServiceEndpointExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ServiceEndpointExtensions  
### Methods
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_AuthorizeAsync(TetraPak_AspNet_Api_ServiceEndpoint_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpointExtensions.AuthorizeAsync(ServiceEndpoint, HttpMethod, Nullable&lt;CancellationToken&gt;) Method
Obtains authorization for consuming the endpoint.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> AuthorizeAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod httpMethod, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_AuthorizeAsync(TetraPak_AspNet_Api_ServiceEndpoint_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_System_Nullable_System_Threading_CancellationToken_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The extended service endpoint.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_AuthorizeAsync(TetraPak_AspNet_Api_ServiceEndpoint_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_System_Nullable_System_Threading_CancellationToken_)_httpMethod'></a>
`httpMethod` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')  
The HTTP method intended for consuming the endpoint.   
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_AuthorizeAsync(TetraPak_AspNet_Api_ServiceEndpoint_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Enables cancellation of the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)'></a>
## ServiceEndpointExtensions.GetAsync&lt;T&gt;(ServiceEndpoint, object?, IEnumerable&lt;string&gt;?, HttpQuery?, RequestOptions?, HttpClientOptions?) Method
Sends an HTTP GET message, passing a collection of resource [keys](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_keys 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, object?, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?, TetraPak.AspNet.HttpClientOptions?).keys') requesting the  
corresponding resources, to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
The response is automatically deserialized into a [TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')  
carrying the expected (typed) resources.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<TetraPak.AspNet.ApiDataResponse<T>>> GetAsync<T>(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, object? dynamicPathElements=null, System.Collections.Generic.IEnumerable<string>? keys=null, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.Api.RequestOptions? requestOptions=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The extended [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_dynamicPathElements'></a>
`dynamicPathElements` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_keys'></a>
`keys` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
One or more keys, to identity the requested resources.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)<br/>  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_requestOptions'></a>
`requestOptions` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies how multiple requests are made.  
This option affect response times or possible service quota.      
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional)<br/>  
Options for the client to be used for the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[TetraPak.AspNet.ApiDataResponse&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[T](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_T 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, object?, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?, TetraPak.AspNet.HttpClientOptions?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, object?, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?, TetraPak.AspNet.HttpClientOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)'></a>
## ServiceEndpointExtensions.GetAsync&lt;T&gt;(ServiceEndpoint, HttpQuery?, RequestOptions?, HttpClientOptions?) Method
Sends an HTTP GET message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
The response is automatically deserialized into a [TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')  
carrying the expected (typed) resources.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<TetraPak.AspNet.ApiDataResponse<T>>> GetAsync<T>(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.Api.RequestOptions? requestOptions=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The extended [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)<br/>  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_requestOptions'></a>
`requestOptions` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies how multiple requests are made.  
This option affect response times or possible service quota.      
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional)<br/>  
Options for the client to be used for the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[TetraPak.AspNet.ApiDataResponse&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[T](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_T 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?, TetraPak.AspNet.HttpClientOptions?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?, TetraPak.AspNet.HttpClientOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)'></a>
## ServiceEndpointExtensions.GetHttpResponseAsync(ServiceEndpoint, object?, DynamicPath, HttpQuery?, Nullable&lt;CancellationToken&gt;, HttpClientOptions?) Method
Sends an HTTP GET message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') and expects  
untyped data in a successful response  
(see [TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync&lt;&gt;.AspNet.Api.ServiceEndpoint,System.Collections.Generic.IEnumerable{System.String},TetraPak.AspNet.HttpQuery,TetraPak.AspNet.Api.RequestOptions,TetraPak.AspNet.HttpClientOptions)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync--1#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync__1_TetraPak_AspNet_Api_ServiceEndpoint,System_Collections_Generic_IEnumerable{System_String},TetraPak_AspNet_HttpQuery,TetraPak_AspNet_Api_RequestOptions,TetraPak_AspNet_HttpClientOptions_ 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync``1(TetraPak.AspNet.Api.ServiceEndpoint,System.Collections.Generic.IEnumerable{System.String},TetraPak.AspNet.HttpQuery,TetraPak.AspNet.Api.RequestOptions,TetraPak.AspNet.HttpClientOptions)')  
for retrieving a typed response).  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> GetHttpResponseAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, object? dynamicPathElements, TetraPak.DynamicEntities.DynamicPath subPath, TetraPak.AspNet.HttpQuery? queryParameters=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_dynamicPathElements'></a>
`dynamicPathElements` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_subPath'></a>
`subPath` [TetraPak.DynamicEntities.DynamicPath](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicPath 'TetraPak.DynamicEntities.DynamicPath')  
One or more key elements to be added to the endpoint path.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional)  
Options for the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetHttpResponseAsync(TetraPak.AspNet.Api.ServiceEndpoint, object?, TetraPak.DynamicEntities.DynamicPath, TetraPak.AspNet.HttpQuery?, System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.AspNet.HttpClientOptions?).serviceEndpoint') was not assigned to a registered service.  
#### See Also
- [TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync&lt;&gt;.AspNet.Api.ServiceEndpoint,System.Collections.Generic.IEnumerable{System.String},TetraPak.AspNet.HttpQuery,TetraPak.AspNet.Api.RequestOptions,TetraPak.AspNet.HttpClientOptions)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync--1#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync__1_TetraPak_AspNet_Api_ServiceEndpoint,System_Collections_Generic_IEnumerable{System_String},TetraPak_AspNet_HttpQuery,TetraPak_AspNet_Api_RequestOptions,TetraPak_AspNet_HttpClientOptions_ 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync``1(TetraPak.AspNet.Api.ServiceEndpoint,System.Collections.Generic.IEnumerable{System.String},TetraPak.AspNet.HttpQuery,TetraPak.AspNet.Api.RequestOptions,TetraPak.AspNet.HttpClientOptions)')
- [GetAsync&lt;T&gt;(ServiceEndpoint, HttpQuery?, RequestOptions?, HttpClientOptions?)](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_) 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?, TetraPak.AspNet.HttpClientOptions?)')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)'></a>
## ServiceEndpointExtensions.GetHttpResponseAsync(ServiceEndpoint, HttpQuery?, Nullable&lt;CancellationToken&gt;, HttpClientOptions?) Method
Sends an HTTP GET message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') to receive a  
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') back (see remarks).  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> GetHttpResponseAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, TetraPak.AspNet.HttpQuery? queryParameters=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional)  
Options for the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetHttpResponseAsync(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQuery?, System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.AspNet.HttpClientOptions?).serviceEndpoint') was not assigned to a registered service.  
### Remarks
Use this method when you need more control over how to manage the response.  
For more standard responses, please see  
[TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync&lt;&gt;.AspNet.Api.ServiceEndpoint,System.Collections.Generic.IEnumerable{System.String},TetraPak.AspNet.HttpQuery,TetraPak.AspNet.Api.RequestOptions,TetraPak.AspNet.HttpClientOptions)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync--1#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync__1_TetraPak_AspNet_Api_ServiceEndpoint,System_Collections_Generic_IEnumerable{System_String},TetraPak_AspNet_HttpQuery,TetraPak_AspNet_Api_RequestOptions,TetraPak_AspNet_HttpClientOptions_ 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync``1(TetraPak.AspNet.Api.ServiceEndpoint,System.Collections.Generic.IEnumerable{System.String},TetraPak.AspNet.HttpQuery,TetraPak.AspNet.Api.RequestOptions,TetraPak.AspNet.HttpClientOptions)')
#### See Also
- [GetHttpResponseAsync(ServiceEndpoint, HttpQuery?, Nullable&lt;CancellationToken&gt;, HttpClientOptions?)](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetHttpResponseAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_) 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetHttpResponseAsync(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQuery?, System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.AspNet.HttpClientOptions?)')
- [TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync&lt;&gt;.AspNet.Api.ServiceEndpoint,System.Collections.Generic.IEnumerable{System.String},TetraPak.AspNet.HttpQuery,TetraPak.AspNet.Api.RequestOptions,TetraPak.AspNet.HttpClientOptions)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync--1#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync__1_TetraPak_AspNet_Api_ServiceEndpoint,System_Collections_Generic_IEnumerable{System_String},TetraPak_AspNet_HttpQuery,TetraPak_AspNet_Api_RequestOptions,TetraPak_AspNet_HttpClientOptions_ 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync``1(TetraPak.AspNet.Api.ServiceEndpoint,System.Collections.Generic.IEnumerable{System.String},TetraPak.AspNet.HttpQuery,TetraPak.AspNet.Api.RequestOptions,TetraPak.AspNet.HttpClientOptions)')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PatchAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)'></a>
## ServiceEndpointExtensions.PatchAsync(ServiceEndpoint, object?, Nullable&lt;CancellationToken&gt;, HttpClientOptions?) Method
Sends an HTTP PATCH message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> PatchAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, object? data, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PatchAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PatchAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_data'></a>
`data` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The content (body) to be posted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PatchAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows operation cancellation.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PatchAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional)  
Options for the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_PatchAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.PatchAsync(TetraPak.AspNet.Api.ServiceEndpoint, object?, System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.AspNet.HttpClientOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PatchAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)'></a>
## ServiceEndpointExtensions.PatchAsync(ServiceEndpoint, HttpContent, Nullable&lt;CancellationToken&gt;, HttpClientOptions?) Method
Sends an HTTP PATCH message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> PatchAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Net.Http.HttpContent content, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PatchAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PatchAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The content (body) to be put.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PatchAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows operation cancellation.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PatchAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional)  
Options for the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_PatchAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.PatchAsync(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.AspNet.HttpClientOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_Path(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath)'></a>
## ServiceEndpointExtensions.Path(ServiceEndpoint, DynamicPath) Method
Adds one or more key elements to the endpoint path and returns the result as a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String').  
```csharp
public static string Path(this TetraPak.AspNet.Api.ServiceEndpoint endpoint, TetraPak.DynamicEntities.DynamicPath subPath);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_Path(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath)_endpoint'></a>
`endpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The extended [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_Path(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath)_subPath'></a>
`subPath` [TetraPak.DynamicEntities.DynamicPath](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicPath 'TetraPak.DynamicEntities.DynamicPath')  
One or more key elements to be added to the endpoint path.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value.  
### Remarks
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') is implicitly always cast to a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
so calling this method is not really necessary but might improve code readability.   
#### See Also
- [Path(ServiceEndpoint)](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_Path(TetraPak_AspNet_Api_ServiceEndpoint) 'TetraPak.AspNet.Api.ServiceEndpointExtensions.Path(TetraPak.AspNet.Api.ServiceEndpoint)')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_Path(TetraPak_AspNet_Api_ServiceEndpoint)'></a>
## ServiceEndpointExtensions.Path(ServiceEndpoint) Method
Returns the endpoint path as a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String').  
```csharp
public static string Path(this TetraPak.AspNet.Api.ServiceEndpoint endpoint);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_Path(TetraPak_AspNet_Api_ServiceEndpoint)_endpoint'></a>
`endpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The service endpoint.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
### Remarks
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') is implicitly always cast to a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
so calling this method is not really necessary but might improve code readability.   
#### See Also
- [Path(ServiceEndpoint, DynamicPath)](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_Path(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath) 'TetraPak.AspNet.Api.ServiceEndpointExtensions.Path(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.DynamicEntities.DynamicPath)')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)'></a>
## ServiceEndpointExtensions.PostAsync(ServiceEndpoint, object?, Nullable&lt;CancellationToken&gt;, HttpClientOptions?) Method
Sends an HTTP POST message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> PostAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, object? data, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_data'></a>
`data` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The content (body) to be posted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows operation cancellation.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional)  
Options for the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.PostAsync(TetraPak.AspNet.Api.ServiceEndpoint, object?, System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.AspNet.HttpClientOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)'></a>
## ServiceEndpointExtensions.PostAsync(ServiceEndpoint, HttpContent, Nullable&lt;CancellationToken&gt;, HttpClientOptions?) Method
Sends an HTTP POST message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> PostAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Net.Http.HttpContent content, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The content (body) to be posted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows operation cancellation.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional)  
Options for the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.PostAsync(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.AspNet.HttpClientOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PutAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)'></a>
## ServiceEndpointExtensions.PutAsync(ServiceEndpoint, object?, Nullable&lt;CancellationToken&gt;, HttpClientOptions?) Method
Sends an HTTP PUT message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> PutAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, object? data, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PutAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PutAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_data'></a>
`data` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The content (body) to be posted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PutAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows operation cancellation.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PutAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional)  
Options for the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_PutAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.PutAsync(TetraPak.AspNet.Api.ServiceEndpoint, object?, System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.AspNet.HttpClientOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PutAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)'></a>
## ServiceEndpointExtensions.PutAsync(ServiceEndpoint, HttpContent, Nullable&lt;CancellationToken&gt;, HttpClientOptions?) Method
Sends an HTTP PUT message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> PutAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Net.Http.HttpContent content, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PutAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PutAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The content (body) to be put.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PutAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows operation cancellation.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PutAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional)  
Options for the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_PutAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.PutAsync(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.AspNet.HttpClientOptions?).serviceEndpoint') was not assigned to a registered service.  
  
