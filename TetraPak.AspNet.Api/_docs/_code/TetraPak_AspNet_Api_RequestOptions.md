#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## RequestOptions Class
Can be used to control the behavior of a request.   
```csharp
public class RequestOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RequestOptions  
### Properties
<a name='TetraPak_AspNet_Api_RequestOptions_CancellationToken'></a>
## RequestOptions.CancellationToken Property
(default=[System.Threading.CancellationToken.None](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken.None 'System.Threading.CancellationToken.None'))<br/>  
Gets or sets a cancellation token to be honored by the affected request.  
```csharp
public System.Threading.CancellationToken CancellationToken { get; set; }
```
#### Property Value
[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')
  
<a name='TetraPak_AspNet_Api_RequestOptions_Default'></a>
## RequestOptions.Default Property
Gets a default configuration (see individual properties for default values).  
```csharp
public static TetraPak.AspNet.Api.RequestOptions Default { get; }
```
#### Property Value
[RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')
  
<a name='TetraPak_AspNet_Api_RequestOptions_Distribution'></a>
## RequestOptions.Distribution Property
(default=[Sequential](TetraPak_AspNet_Api_RequestDistribution.md#TetraPak_AspNet_Api_RequestDistribution_Sequential 'TetraPak.AspNet.Api.RequestDistribution.Sequential'))<br/>  
Gets or sets a value to control how a multi-request process is distributed.   
```csharp
public TetraPak.AspNet.Api.RequestDistribution Distribution { get; set; }
```
#### Property Value
[RequestDistribution](TetraPak_AspNet_Api_RequestDistribution.md 'TetraPak.AspNet.Api.RequestDistribution')
### Remarks
This value affects the distribution in a situation where multiple requests are made (such  
as calling [GetAsync&lt;T&gt;(ServiceEndpoint, IEnumerable&lt;string&gt;?, HttpQuery?, RequestOptions?, HttpClientOptions?)](TetraPak_AspNet_Api_ServiceEndpointExtensions.md#TetraPak_AspNet_Api_ServiceEndpointExtensions_GetAsync_T_(TetraPak_AspNet_Api_ServiceEndpoint_System_Collections_Generic_IEnumerable_string___TetraPak_AspNet_HttpQuery__TetraPak_AspNet_Api_RequestOptions__TetraPak_AspNet_HttpClientOptions_) 'TetraPak.AspNet.Api.ServiceEndpointExtensions.GetAsync&lt;T&gt;(TetraPak.AspNet.Api.ServiceEndpoint, System.Collections.Generic.IEnumerable&lt;string&gt;?, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.Api.RequestOptions?, TetraPak.AspNet.HttpClientOptions?)')  
passing a collection of keys). When set to [Sequential](TetraPak_AspNet_Api_RequestDistribution.md#TetraPak_AspNet_Api_RequestDistribution_Sequential 'TetraPak.AspNet.Api.RequestDistribution.Sequential')   
all requests are made in sequence, on the same thread. Set to [Parallel](TetraPak_AspNet_Api_RequestDistribution.md#TetraPak_AspNet_Api_RequestDistribution_Parallel 'TetraPak.AspNet.Api.RequestDistribution.Parallel')  
to allow the process to be made in parallel, distributed over multiple worker threads.  
  
<a name='TetraPak_AspNet_Api_RequestOptions_IsFailureTolerant'></a>
## RequestOptions.IsFailureTolerant Property
(default=`false`)<br/>  
Gets or sets a value that specifies whether all requests should be cancelled if one request fails.  
```csharp
public bool IsFailureTolerant { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Remarks
This value affects how a process where multiple requests are made, such as requesting multiple  
resources using a collection of resource keys. When set and one or more requests fails in a process,  
the process should be cancelled and return a 'failed' overall result. Set to false  
to allow the overall request process to continue.  
  
### Methods
<a name='TetraPak_AspNet_Api_RequestOptions_WithCancellation(System_Threading_CancellationToken)'></a>
## RequestOptions.WithCancellation(CancellationToken) Method
(fluent API)<br/>  
Sets the [CancellationToken](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_CancellationToken 'TetraPak.AspNet.Api.RequestOptions.CancellationToken') property and returns `this`.  
```csharp
public TetraPak.AspNet.Api.RequestOptions WithCancellation(System.Threading.CancellationToken token);
```
#### Parameters
<a name='TetraPak_AspNet_Api_RequestOptions_WithCancellation(System_Threading_CancellationToken)_token'></a>
`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
  
#### Returns
[RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
  
<a name='TetraPak_AspNet_Api_RequestOptions_WithDistribution(TetraPak_AspNet_Api_RequestDistribution)'></a>
## RequestOptions.WithDistribution(RequestDistribution) Method
(fluent API)<br/>  
Sets the [Distribution](TetraPak_AspNet_Api_RequestOptions.md#TetraPak_AspNet_Api_RequestOptions_Distribution 'TetraPak.AspNet.Api.RequestOptions.Distribution') property and returns `this`.  
```csharp
public TetraPak.AspNet.Api.RequestOptions WithDistribution(TetraPak.AspNet.Api.RequestDistribution value);
```
#### Parameters
<a name='TetraPak_AspNet_Api_RequestOptions_WithDistribution(TetraPak_AspNet_Api_RequestDistribution)_value'></a>
`value` [RequestDistribution](TetraPak_AspNet_Api_RequestDistribution.md 'TetraPak.AspNet.Api.RequestDistribution')  
  
#### Returns
[RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions')  
  
