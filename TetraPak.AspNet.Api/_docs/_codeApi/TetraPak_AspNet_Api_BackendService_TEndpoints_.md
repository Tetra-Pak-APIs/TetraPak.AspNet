#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## BackendService&lt;TEndpoints&gt; Class
Supports configuration for an individual backend service, and a collection of service endpoints.   
```csharp
public class BackendService<TEndpoints> :
TetraPak.AspNet.Api.IBackendService,
TetraPak.AspNet.Auth.IServiceAuthConfig
    where TEndpoints : TetraPak.AspNet.Api.ServiceEndpoints
```
#### Type parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__TEndpoints'></a>
`TEndpoints`  
The [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') of service endpoints.  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BackendService&lt;TEndpoints&gt;  

Implements [IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService'), [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')  
### Properties
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__AmbientData'></a>
## BackendService&lt;TEndpoints&gt;.AmbientData Property
Gets an [TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData 'TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData') object.  
```csharp
public TetraPak.AspNet.AmbientData AmbientData { get; }
```
#### Property Value
[TetraPak.AspNet.AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AmbientData 'TetraPak.AspNet.AmbientData')

Implements [AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData 'TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__AuthConfig'></a>
## BackendService&lt;TEndpoints&gt;.AuthConfig Property
Gets the Tetra Pak configuration.  
```csharp
protected TetraPak.AspNet.TetraPakAuthConfig AuthConfig { get; }
```
#### Property Value
[TetraPak.AspNet.TetraPakAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakAuthConfig 'TetraPak.AspNet.TetraPakAuthConfig')
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__ConfigPath'></a>
## BackendService&lt;TEndpoints&gt;.ConfigPath Property
Gets the configuration path.  
```csharp
public TetraPak.Configuration.ConfigPath? ConfigPath { get; }
```
#### Property Value
[TetraPak.Configuration.ConfigPath](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigPath 'TetraPak.Configuration.ConfigPath')

Implements [ConfigPath](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.ConfigPath 'TetraPak.AspNet.Auth.IServiceAuthConfig.ConfigPath')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__Configuration'></a>
## BackendService&lt;TEndpoints&gt;.Configuration Property
Gets the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') instance used to populate the properties.  
```csharp
public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
```
#### Property Value
[Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')

Implements [Configuration](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.Configuration 'TetraPak.AspNet.Auth.IServiceAuthConfig.Configuration')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__DefaultClientOptions'></a>
## BackendService&lt;TEndpoints&gt;.DefaultClientOptions Property
Gets default options for the creating clients for the backend service.   
```csharp
public TetraPak.AspNet.Api.HttpClientOptions DefaultClientOptions { get; }
```
#### Property Value
[HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')

Implements [DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__Endpoints'></a>
## BackendService&lt;TEndpoints&gt;.Endpoints Property
Gets the endpoint configuration.  
```csharp
public TEndpoints Endpoints { get; set; }
```
#### Property Value
[TEndpoints](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__TEndpoints 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.TEndpoints')
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GrantType'></a>
## BackendService&lt;TEndpoints&gt;.GrantType Property
Specifies the grant type (OAuth) or authorization mechanism.   
```csharp
public TetraPak.AspNet.Auth.GrantType GrantType { get; }
```
#### Property Value
[TetraPak.AspNet.Auth.GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.GrantType 'TetraPak.AspNet.Auth.GrantType')

Implements [GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType 'TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__HttpServiceProvider'></a>
## BackendService&lt;TEndpoints&gt;.HttpServiceProvider Property
Gets a delegate used to provide a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient'),  
used to consumer the backend service.  
```csharp
protected TetraPak.AspNet.Api.IHttpServiceProvider HttpServiceProvider { get; }
```
#### Property Value
[IHttpServiceProvider](TetraPak_AspNet_Api_IHttpServiceProvider.md 'TetraPak.AspNet.Api.IHttpServiceProvider')
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__Logger'></a>
## BackendService&lt;TEndpoints&gt;.Logger Property
Gets logging provider.    
```csharp
protected Microsoft.Extensions.Logging.ILogger? Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__ServiceName'></a>
## BackendService&lt;TEndpoints&gt;.ServiceName Property
Gets the identity of the service. This identity should be unique with the runtime context.   
```csharp
public string ServiceName { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Implements [ServiceName](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_ServiceName 'TetraPak.AspNet.Api.IBackendService.ServiceName')  
  
### Methods
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)'></a>
## BackendService&lt;TEndpoints&gt;.GetAsync(string, string?, HttpClientOptions?, Nullable&lt;CancellationToken&gt;, string?) Method
Sends a GET request to the backend service to retrieve a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage').  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> GetAsync(string path, string? queryParameters=null, TetraPak.AspNet.Api.HttpClientOptions? clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, string? messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_queryParameters'></a>
`queryParameters` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br />  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br />  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt />  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetAsync(string, string, HttpClientOptions, Nullable<CancellationToken>, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')  
#### See Also
- [GetAsync(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync&lt;T&gt;(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync&lt;T&gt;(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)'></a>
## BackendService&lt;TEndpoints&gt;.GetAsync(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string?) Method
Sends a GEt request to the backend service to retrieve a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage').  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> GetAsync(string path, System.Collections.Generic.IDictionary<string,string> queryParameters, TetraPak.AspNet.Api.HttpClientOptions clientOptions, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, string? messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)_queryParameters'></a>
`queryParameters` [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br />  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br />  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt />  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetAsync(string, IDictionary<string,string>, HttpClientOptions, Nullable<CancellationToken>, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')  
#### See Also
- [GetAsync(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync&lt;T&gt;(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync&lt;T&gt;(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)'></a>
## BackendService&lt;TEndpoints&gt;.GetAsync&lt;T&gt;(string, string?, HttpClientOptions?, Nullable&lt;CancellationToken&gt;, string?) Method
Sends a GET request to the backend service to retrieve an object of a specified type.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<T>> GetAsync<T>(string path, string? queryParameters=null, TetraPak.AspNet.Api.HttpClientOptions? clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, string? messageId=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_T'></a>
`T`  
Specifies the type of object to be retrieved.
  
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_queryParameters'></a>
`queryParameters` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br />  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br />  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt />  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[T](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_string__TetraPak_AspNet_Api_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_T 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.GetAsync&lt;T&gt;(string, string?, TetraPak.AspNet.Api.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;, string?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetAsync<T>(string, string, HttpClientOptions, Nullable<CancellationToken>, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')  
#### See Also
- [GetAsync(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync&lt;T&gt;(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)'></a>
## BackendService&lt;TEndpoints&gt;.GetAsync&lt;T&gt;(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string?) Method
Sends a GET request to the backend service to retrieve an object of a specified type.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<T>> GetAsync<T>(string path, System.Collections.Generic.IDictionary<string,string> queryParameters, TetraPak.AspNet.Api.HttpClientOptions clientOptions, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, string? messageId=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)_T'></a>
`T`  
Specifies the type of object to be retrieved.
  
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)_queryParameters'></a>
`queryParameters` [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br />  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br />  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt />  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[T](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string_)_T 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.GetAsync&lt;T&gt;(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetAsync<T>(string, IDictionary<string,string>, HttpClientOptions, Nullable<CancellationToken>, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')  
#### See Also
- [GetAsync(string, IDictionary&lt;string,string&gt;, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_System_Collections_Generic_IDictionary_string_string__TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, System.Collections.Generic.IDictionary&lt;string,string&gt;, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
- [GetAsync&lt;T&gt;(string, string, HttpClientOptions, Nullable&lt;CancellationToken&gt;, string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_string_TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken__string) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, string, TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;, string)')
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.GetClientIdAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client id.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<string>> GetClientIdAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br />  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetClientIdAsync(AuthContext, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientIdAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientIdAsync_TetraPak_AspNet_AuthContext,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientIdAsync(TetraPak.AspNet.AuthContext,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.GetClientSecretAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client secret.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<string>> GetClientSecretAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br />  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetClientSecretAsync(AuthContext, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientSecretAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientSecretAsync_TetraPak_AspNet_AuthContext,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientSecretAsync(TetraPak.AspNet.AuthContext,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetConfiguredValue(string)'></a>
## BackendService&lt;TEndpoints&gt;.GetConfiguredValue(string) Method
Gets a "raw" configured value, as it is specified within the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') sources,  
unaffected by delegates or other internal types of logic.  
```csharp
public string GetConfiguredValue(string key);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetConfiguredValue(string)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the requested value.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') when a value is configured; otherwise `null`.  

Implements [GetConfiguredValue(string)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetConfiguredValue#TetraPak_AspNet_Auth_IServiceAuthConfig_GetConfiguredValue_System_String_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetConfiguredValue(System.String)')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.GetScopeAsync(AuthContext, MultiStringValue?, Nullable&lt;CancellationToken&gt;) Method
Gets a scope to be requested for authorization.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> GetScopeAsync(TetraPak.AspNet.AuthContext authContext, TetraPak.MultiStringValue? useDefault=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_useDefault'></a>
`useDefault` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
(optional)<br />  
Specifies a default value to be returned if scope cannot be resolved.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br />  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetScopeAsync(AuthContext, MultiStringValue?, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetScopeAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetScopeAsync_TetraPak_AspNet_AuthContext,TetraPak_MultiStringValue,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetScopeAsync(TetraPak.AspNet.AuthContext,TetraPak.MultiStringValue,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__IsAuthIdentifier(string)'></a>
## BackendService&lt;TEndpoints&gt;.IsAuthIdentifier(string) Method
Examines a string and returns a value to indicate whether the value identifies  
an attribute used for auth configuration. This is to ensure there is no risk of confusing  
services or endpoints with such attributes.   
```csharp
public bool IsAuthIdentifier(string identifier);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__IsAuthIdentifier(string)_identifier'></a>
`identifier` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The identifier being examined.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [identifier](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__IsAuthIdentifier(string)_identifier 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.IsAuthIdentifier(string).identifier') matches an auth configuration attribute; otherwise `false`.   
            

Implements [IsAuthIdentifier(string)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.IsAuthIdentifier#TetraPak_AspNet_Auth_IServiceAuthConfig_IsAuthIdentifier_System_String_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.IsAuthIdentifier(System.String)')  
### Remarks
Examples of auth identifiers: "`ConfigPath`", "`GrantType`",  
"`ClientId`", "`ClientSecret`", "`Scope`".  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnGetHttpClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.OnGetHttpClientAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
This method gets invoked when the class needs a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') instance.  
The calling code expects the returned client to be fully configured according to the  
options specified in [clientOptions](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__OnGetHttpClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_clientOptions 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.OnGetHttpClientAsync(TetraPak.AspNet.Api.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;).clientOptions').  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpClient>> OnGetHttpClientAsync(TetraPak.AspNet.Api.HttpClientOptions clientOptions, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnGetHttpClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
Specifies how to configure/authorize the requested client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnGetHttpClientAsync(TetraPak_AspNet_Api_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') to be used for cancelling the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpMethod_string_string__System_Collections_Generic_IEnumerable_System_Exception__string_)'></a>
## BackendService&lt;TEndpoints&gt;.OnServiceConfigurationError(HttpMethod, string, string?, IEnumerable&lt;Exception&gt;, string?) Method
Called by an internal method when it discovers a configuration issue,  
allowing for a consistent response to all such issues.  
```csharp
protected virtual TetraPak.Outcome<System.Net.Http.HttpResponseMessage> OnServiceConfigurationError(System.Net.Http.HttpMethod method, string path, string? queryParameters, System.Collections.Generic.IEnumerable<System.Exception> issues, string? messageId);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpMethod_string_string__System_Collections_Generic_IEnumerable_System_Exception__string_)_method'></a>
`method` [System.Net.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMethod 'System.Net.Http.HttpMethod')  
The request HTTP method.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpMethod_string_string__System_Collections_Generic_IEnumerable_System_Exception__string_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The request path.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpMethod_string_string__System_Collections_Generic_IEnumerable_System_Exception__string_)_queryParameters'></a>
`queryParameters` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Any request query parameters.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpMethod_string_string__System_Collections_Generic_IEnumerable_System_Exception__string_)_issues'></a>
`issues` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of issues found.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpMethod_string_string__System_Collections_Generic_IEnumerable_System_Exception__string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt />  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')  
  
