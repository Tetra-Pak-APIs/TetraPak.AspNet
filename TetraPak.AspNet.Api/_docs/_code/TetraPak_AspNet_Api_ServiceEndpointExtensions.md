#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## ServiceEndpointExtensions Class
Convenient methods to help consuming service endpoints.    
```csharp
public static class ServiceEndpointExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ServiceEndpointExtensions  
### Methods
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQueryParameters__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)'></a>
## ServiceEndpointExtensions.GetAsync(ServiceEndpoint, HttpQueryParameters?, Nullable&lt;CancellationToken&gt;, HttpClientOptions?) Method
Sends an HTTP GET message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> GetAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, TetraPak.AspNet.HttpQueryParameters? queryParameters=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQueryParameters__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQueryParameters__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQueryParameters](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQueryParameters 'TetraPak.AspNet.HttpQueryParameters')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQueryParameters__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQueryParameters__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional)  
Options for the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_HttpQueryParameters__System_Nullable_System_Threading_CancellationToken__TetraPak_AspNet_HttpClientOptions_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync(TetraPak.AspNet.Api.ServiceEndpoint, TetraPak.AspNet.HttpQueryParameters?, System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.AspNet.HttpClientOptions?).serviceEndpoint') was not assigned to a registered service.  
  
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
  
