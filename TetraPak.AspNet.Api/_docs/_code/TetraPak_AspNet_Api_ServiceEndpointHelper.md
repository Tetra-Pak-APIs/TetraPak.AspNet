#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## ServiceEndpointHelper Class
Convenient methods to help consuming service endpoints.    
```csharp
public static class ServiceEndpointHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ServiceEndpointHelper  
### Methods
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_AuthorizeAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpointHelper.AuthorizeAsync(ServiceEndpoint, Nullable&lt;CancellationToken&gt;) Method
Obtains authorization for consuming the endpoint.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> AuthorizeAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_AuthorizeAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Nullable_System_Threading_CancellationToken_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The extended service endpoint.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_AuthorizeAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Enables cancellation of the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_AuthorizeAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Nullable_System_Threading_CancellationToken_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.AuthorizeAsync(TetraPak.AspNet.Api.ServiceEndpoint, System.Nullable&lt;System.Threading.CancellationToken&gt;).serviceEndpoint') was unassigned.  
            
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_AuthorizeAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Nullable_System_Threading_CancellationToken_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.AuthorizeAsync(TetraPak.AspNet.Api.ServiceEndpoint, System.Nullable&lt;System.Threading.CancellationToken&gt;).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.DeleteAsync&lt;T&gt;(ServiceEndpoint, IEnumerable&lt;string&gt;?, HttpQuery?, RequestOptions?) Method
Sends an HTTP DELETE message, passing a collection of resource [keys](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_keys 'TetraPak.AspNet.Api.ServiceEndpointHelper.DeleteAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).keys'),  
requesting removal of the corresponding resources, to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
The response is automatically deserialized into a [TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')  
carrying the expected (typed) resources.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<TetraPak.AspNet.ApiDataResponse<T>>> DeleteAsync<T>(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Collections.Generic.IEnumerable<string>? keys, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The extended [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_keys'></a>
`keys` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
One or more keys, to identity the resources to be removed.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)<br/>  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Options for the request.      
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[TetraPak.AspNet.ApiDataResponse&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[T](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_T 'TetraPak.AspNet.Api.ServiceEndpointHelper.DeleteAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.DeleteAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.DeleteRawAsync(ServiceEndpoint, DynamicPath, HttpQuery?, RequestOptions?) Method
Sends an HTTP DELETE message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') and expects  
untyped data in a successful response  
(see [DeleteAsync&lt;T&gt;(ServiceEndpoint, IEnumerable&lt;string&gt;?, HttpQuery?, RequestOptions?)](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_) 'TetraPak.AspNet.Api.ServiceEndpointHelper.DeleteAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?)')  
for retrieving a typed response).  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> DeleteRawAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, TetraPak.DynamicEntities.DynamicPath subPath, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_subPath'></a>
`subPath` [TetraPak.DynamicEntities.DynamicPath](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicPath 'TetraPak.DynamicEntities.DynamicPath')  
One or more key elements to be added to the endpoint path.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Options for the request.     
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.DeleteRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.DynamicEntities.DynamicPath, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was unassigned.  
            
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_DeleteRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.DeleteRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.DynamicEntities.DynamicPath, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.GetAsync&lt;T&gt;(ServiceEndpoint, IEnumerable&lt;string&gt;?, HttpQuery?, RequestOptions?) Method
Sends an HTTP GET message, passing a collection of resource [keys](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_keys 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).keys') requesting the  
corresponding resources, to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
The response is automatically deserialized into a [TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')  
carrying the expected (typed) resources.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<TetraPak.AspNet.ApiDataResponse<T>>> GetAsync<T>(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Collections.Generic.IEnumerable<string>? keys=null, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The extended [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_keys'></a>
`keys` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
One or more keys, to identity the requested resources.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)<br/>  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Options for the request.      
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[TetraPak.AspNet.ApiDataResponse&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[T](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_T 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.GetAsync&lt;T&gt;(ServiceEndpoint, HttpQuery?, RequestOptions?) Method
Sends an HTTP GET message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
The response is automatically deserialized into a [TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')  
carrying the expected (typed) resources.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<TetraPak.AspNet.ApiDataResponse<T>>> GetAsync<T>(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The extended [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)<br/>  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Options for the request.     
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[TetraPak.AspNet.ApiDataResponse&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[T](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_T 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was unassigned.  
            
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.GetRawAsync(ServiceEndpoint, HttpQuery?, RequestOptions?) Method
Sends an HTTP GET message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') to receive a ("raw")  
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') in response, allowing for customized response formatting or logics.  
(see [GetAsync&lt;T&gt;(ServiceEndpoint, HttpQuery?, RequestOptions?)](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_) 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?)')  
for retrieving a typed response).  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> GetRawAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was unassigned.  
            
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
#### See Also
- [GetRawAsync(ServiceEndpoint, HttpQuery?, RequestOptions?)](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_) 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?)')
- [GetAsync&lt;T&gt;(ServiceEndpoint, IEnumerable&lt;string&gt;?, HttpQuery?, RequestOptions?)](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_) 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?)')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.GetRawAsync(ServiceEndpoint, DynamicPath, HttpQuery?, RequestOptions?) Method
Sends an HTTP GET message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') to receive a ("raw")  
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') in response, allowing for customized response formatting or logics.  
(see [GetAsync&lt;T&gt;(ServiceEndpoint, IEnumerable&lt;string&gt;?, HttpQuery?, RequestOptions?)](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_) 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?)')  
for retrieving a typed response).  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> GetRawAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, TetraPak.DynamicEntities.DynamicPath subPath, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_subPath'></a>
`subPath` [TetraPak.DynamicEntities.DynamicPath](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicPath 'TetraPak.DynamicEntities.DynamicPath')  
One or more key elements to be added to the endpoint path.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Options for the request.     
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.DynamicEntities.DynamicPath, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was unassigned.  
            
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_GetRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.GetRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.DynamicEntities.DynamicPath, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetStreamAsync(TetraPak_AspNet_Api_ServiceEndpoint_string__TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.GetStreamAsync(ServiceEndpoint, string?, HttpQuery?, RequestOptions?) Method
Sends an HTTP GET message to consume a specified resource as a [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.IO.Stream>> GetStreamAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, string? key=null, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetStreamAsync(TetraPak_AspNet_Api_ServiceEndpoint_string__TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The extended [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetStreamAsync(TetraPak_AspNet_Api_ServiceEndpoint_string__TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A key, used to identity a requested resource.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetStreamAsync(TetraPak_AspNet_Api_ServiceEndpoint_string__TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)<br/>  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_GetStreamAsync(TetraPak_AspNet_Api_ServiceEndpoint_string__TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Options for the request.      
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
the requested [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_IsJsonApiDataResponse(string_string_)'></a>
## ServiceEndpointHelper.IsJsonApiDataResponse(string, string?) Method
Examines a (presumably downloaded) [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') and resolves whether it is standardized  
Tetra Pak JSON response format and, if so, what version.  
```csharp
public static bool IsJsonApiDataResponse(this string data, out string? version);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_IsJsonApiDataResponse(string_string_)_data'></a>
`data` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') to be examined.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_IsJsonApiDataResponse(string_string_)_version'></a>
`version` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Passes back the format version expressed by the JSON data when successful;  
otherwise passes back `null`.    
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [data](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_IsJsonApiDataResponse(string_string_)_data 'TetraPak.AspNet.Api.ServiceEndpointHelper.IsJsonApiDataResponse(string, string?).data') was found to contain standardized Tetra Pak JSON response  
              format ([TetraPak.AspNet.ApiDataResponse](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse 'TetraPak.AspNet.ApiDataResponse')); otherwise `false`.  
            
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.PatchAsync&lt;T&gt;(ServiceEndpoint, HttpContent, RequestOptions?) Method
Sends an HTTP PATCH message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') for a standardized  
[TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1').  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<TetraPak.AspNet.ApiDataResponse<T>>> PatchAsync<T>(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Net.Http.HttpContent content, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The resourced to be submitted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[TetraPak.AspNet.ApiDataResponse&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[T](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PatchAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_T 'TetraPak.AspNet.Api.ServiceEndpointHelper.PatchAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, TetraPak.AspNet.Api.RequestOptions?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PatchAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.PatchAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.PatchRawAsync(ServiceEndpoint, object?, RequestOptions?) Method
Sends an HTTP PATCH message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') for a "raw"  
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') response, allowing for customized response formatting or logics.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PatchRawAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, object? data, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_data'></a>
`data` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The patched resourced to be submitted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PatchRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.PatchRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, object?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.PatchRawAsync(ServiceEndpoint, HttpContent, RequestOptions?) Method
Sends an HTTP PATCH message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') for a "raw"  
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') response, allowing for customized response formatting or logics.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PatchRawAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Net.Http.HttpContent content, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The patched resourced to be submitted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PatchRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PatchRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.PatchRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_Path(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath)'></a>
## ServiceEndpointHelper.Path(ServiceEndpoint, object?, DynamicPath) Method
Returns the resolved endpoint path from a combination of dynamic path elements and a sub path.   
```csharp
public static string Path(this TetraPak.AspNet.Api.ServiceEndpoint endpoint, object? dynamicPathValues, TetraPak.DynamicEntities.DynamicPath subPath);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_Path(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath)_endpoint'></a>
`endpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The service endpoint to resolve the path for.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_Path(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath)_dynamicPathValues'></a>
`dynamicPathValues` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
An object holding the values to be used when resolving variable elements of the path  
(see [TetraPak.DynamicEntities.DynamicPathHelper.Substitute(TetraPak.DynamicEntities.DynamicPath,System.Object,System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicPathHelper.Substitute#TetraPak_DynamicEntities_DynamicPathHelper_Substitute_TetraPak_DynamicEntities_DynamicPath,System_Object,System_Boolean_ 'TetraPak.DynamicEntities.DynamicPathHelper.Substitute(TetraPak.DynamicEntities.DynamicPath,System.Object,System.Boolean)')).  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_Path(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath)_subPath'></a>
`subPath` [TetraPak.DynamicEntities.DynamicPath](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicPath 'TetraPak.DynamicEntities.DynamicPath')  
A path to be appended to the resolved service endpoint base path.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') representing the service endpoint path.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_Path(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_)'></a>
## ServiceEndpointHelper.Path(ServiceEndpoint, DynamicPath?) Method
Adds one or more key elements to the endpoint path and returns the result as a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String').  
```csharp
public static string Path(this TetraPak.AspNet.Api.ServiceEndpoint endpoint, TetraPak.DynamicEntities.DynamicPath? subPath=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_Path(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_)_endpoint'></a>
`endpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The extended [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_Path(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_DynamicEntities_DynamicPath_)_subPath'></a>
`subPath` [TetraPak.DynamicEntities.DynamicPath](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicPath 'TetraPak.DynamicEntities.DynamicPath')  
(optional)<br/>  
One or more key elements to be added to the endpoint path.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value.  
### Remarks
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') is implicitly always cast to a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
so calling this method is not really necessary but might improve code readability.   
#### See Also
- [Path(ServiceEndpoint, object?, DynamicPath)](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_Path(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_DynamicEntities_DynamicPath) 'TetraPak.AspNet.Api.ServiceEndpointHelper.Path(TetraPak.AspNet.Api.ServiceEndpoint, object?, TetraPak.DynamicEntities.DynamicPath)')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.PostAsync&lt;T&gt;(ServiceEndpoint, object?, RequestOptions?) Method
Sends an HTTP POST message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') for a standardized  
[TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1').  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<TetraPak.AspNet.ApiDataResponse<T>>> PostAsync<T>(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, object? data, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_data'></a>
`data` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The resourced to be submitted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[TetraPak.AspNet.ApiDataResponse&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[T](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_T 'TetraPak.AspNet.Api.ServiceEndpointHelper.PostAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, object?, TetraPak.AspNet.Api.RequestOptions?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.PostAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, object?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.PostAsync&lt;T&gt;(ServiceEndpoint, HttpContent, RequestOptions?) Method
Sends an HTTP POST message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') for a standardized  
[TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1').  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<TetraPak.AspNet.ApiDataResponse<T>>> PostAsync<T>(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Net.Http.HttpContent content, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The resourced to be submitted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[TetraPak.AspNet.ApiDataResponse&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[T](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_T 'TetraPak.AspNet.Api.ServiceEndpointHelper.PostAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, TetraPak.AspNet.Api.RequestOptions?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.PostAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.PostRawAsync(ServiceEndpoint, object?, RequestOptions?) Method
Sends an HTTP POST message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') for a "raw"  
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') response, allowing for customized response formatting or logics.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PostRawAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, object? data, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_data'></a>
`data` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The resourced to be submitted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PostRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.PostRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, object?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.PostRawAsync(ServiceEndpoint, HttpContent, RequestOptions?) Method
Sends an HTTP POST message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') to receive a ("raw")  
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') in response, allowing for customized response formatting or logics.  
(see [PostAsync&lt;T&gt;(ServiceEndpoint, HttpContent, RequestOptions?)](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PostAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_) 'TetraPak.AspNet.Api.ServiceEndpointHelper.PostAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, TetraPak.AspNet.Api.RequestOptions?)')  
for retrieving a typed response).  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PostRawAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Net.Http.HttpContent content, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The resourced to be submitted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PostRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PostRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.PostRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.PutAsync&lt;T&gt;(ServiceEndpoint, object?, RequestOptions?) Method
Sends an HTTP POST message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') for a standardized  
[TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1').  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<TetraPak.AspNet.ApiDataResponse<T>>> PutAsync<T>(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, object? data, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_data'></a>
`data` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The resourced to be submitted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[TetraPak.AspNet.ApiDataResponse&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[T](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_T 'TetraPak.AspNet.Api.ServiceEndpointHelper.PutAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, object?, TetraPak.AspNet.Api.RequestOptions?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.PutAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, object?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.PutAsync&lt;T&gt;(ServiceEndpoint, HttpContent, RequestOptions?) Method
Sends an HTTP POST message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') for a standardized  
[TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1').  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<TetraPak.AspNet.ApiDataResponse<T>>> PutAsync<T>(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Net.Http.HttpContent content, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The resourced to be submitted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[TetraPak.AspNet.ApiDataResponse&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[T](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_T 'TetraPak.AspNet.Api.ServiceEndpointHelper.PutAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, TetraPak.AspNet.Api.RequestOptions?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.PutAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.PutRawAsync(ServiceEndpoint, object?, RequestOptions?) Method
Sends an HTTP PUT message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') for a "raw"  
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') response, allowing for customized response formatting or logics.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PutRawAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, object? data, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_data'></a>
`data` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The resourced to be submitted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PutRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_object__TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.PutRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, object?, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)'></a>
## ServiceEndpointHelper.PutRawAsync(ServiceEndpoint, HttpContent, RequestOptions?) Method
Sends an HTTP PUT message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') for a "raw"  
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') response, allowing for customized response formatting or logics.  
(see [PutAsync&lt;T&gt;(ServiceEndpoint, HttpContent, RequestOptions?)](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PutAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_) 'TetraPak.AspNet.Api.ServiceEndpointHelper.PutAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, TetraPak.AspNet.Api.RequestOptions?)')  
for retrieving a typed response).  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PutRawAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Net.Http.HttpContent content, TetraPak.AspNet.Api.RequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The resourced to be submitted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointHelper_PutRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_options'></a>
`options` [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
(optional; default=[Default](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Default 'TetraPak.AspNet.Api.RequestOptions.Default'))<br/>  
Specifies options for the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.AspNet.HttpOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointHelper.md#TetraPak_AspNet_Api_ServiceEndpointHelper_PutRawAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_RequestOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointHelper.PutRawAsync(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, TetraPak.AspNet.Api.RequestOptions?).serviceEndpoint') was not assigned to a registered service.  
  
