#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## ServiceEndpointExtensions Class
```csharp
public static class ServiceEndpointExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ServiceEndpointExtensions  
### Methods
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpointExtensions.GetAsync(ServiceEndpoint, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
Sends an HTTP GET message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> GetAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Collections.Generic.IDictionary<string,string> queryParameters, TetraPak.AspNet.Api.HttpClientOptions clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_queryParameters'></a>
`queryParameters` [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional)  
Options for the operation.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync(TetraPak.AspNet.Api.ServiceEndpoint, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;).serviceEndpoint') was not assigned to a registered service.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpointExtensions.PostAsync(ServiceEndpoint, HttpContent, HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
Sends an HTTP POST message to the specified [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> PostAsync(this TetraPak.AspNet.Api.ServiceEndpoint serviceEndpoint, System.Net.Http.HttpContent content, TetraPak.AspNet.Api.HttpClientOptions clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_serviceEndpoint'></a>
`serviceEndpoint` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
The [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The content (body) to be posted.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional)  
Options for the operation.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The [serviceEndpoint](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_PostAsync(TetraPak_AspNet_Api_ServiceEndpoint_System_Net_Http_HttpContent_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_serviceEndpoint 'TetraPak.AspNet.Api.ServiceEndpointExtensions.PostAsync(TetraPak.AspNet.Api.ServiceEndpoint, System.Net.Http.HttpContent, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;).serviceEndpoint') was not assigned to a registered service.  
  
