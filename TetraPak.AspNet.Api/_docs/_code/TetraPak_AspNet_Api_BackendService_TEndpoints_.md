#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## BackendService&lt;TEndpoints&gt; Class
Supports configuration for an individual backend service, and a collection of service endpoints.   
```csharp
public class BackendService<TEndpoints> :
TetraPak.AspNet.Api.IBackendService,
TetraPak.AspNet.Auth.IServiceAuthConfig,
TetraPak.AspNet.Auth.IAccessTokenProvider
    where TEndpoints : TetraPak.AspNet.Api.ServiceEndpoints
```
#### Type parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__TEndpoints'></a>
`TEndpoints`  
The [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') of service endpoints.  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BackendService&lt;TEndpoints&gt;  

Implements [IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService'), [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig'), [TetraPak.AspNet.Auth.IAccessTokenProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IAccessTokenProvider 'TetraPak.AspNet.Auth.IAccessTokenProvider')  
### Constructors
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__BackendService(TEndpoints)'></a>
## BackendService&lt;TEndpoints&gt;.BackendService(TEndpoints) Constructor
Initializes the [BackendService&lt;TEndpoints&gt;](TetraPak_AspNet_Api_BackendService_TEndpoints_.md 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;')
```csharp
public BackendService(TEndpoints endpoints);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__BackendService(TEndpoints)_endpoints'></a>
`endpoints` [TEndpoints](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__TEndpoints 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.TEndpoints')  
The service's supported endpoint.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[endpoints](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__BackendService(TEndpoints)_endpoints 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.BackendService(TEndpoints).endpoints') was `null`.  
            
  
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
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__ClientId'></a>
## BackendService&lt;TEndpoints&gt;.ClientId Property
Gets a client identity to be submitted when requesting authorization.  
```csharp
public string? ClientId { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Implements [ClientId](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.ClientId 'TetraPak.AspNet.Auth.IServiceAuthConfig.ClientId')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__ClientSecret'></a>
## BackendService&lt;TEndpoints&gt;.ClientSecret Property
Gets a client secret to be submitted when requesting authorization.  
```csharp
public string? ClientSecret { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Implements [ClientSecret](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.ClientSecret 'TetraPak.AspNet.Auth.IServiceAuthConfig.ClientSecret')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__Config'></a>
## BackendService&lt;TEndpoints&gt;.Config Property
Gets the Tetra Pak configuration.  
```csharp
protected TetraPak.AspNet.TetraPakConfig Config { get; }
```
#### Property Value
[TetraPak.AspNet.TetraPakConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig 'TetraPak.AspNet.TetraPakConfig')
  
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
public TetraPak.AspNet.HttpClientOptions DefaultClientOptions { get; }
```
#### Property Value
[TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')

Implements [DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__Endpoints'></a>
## BackendService&lt;TEndpoints&gt;.Endpoints Property
Gets the endpoint configuration.  
```csharp
public TEndpoints Endpoints { get; }
```
#### Property Value
[TEndpoints](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__TEndpoints 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.TEndpoints')
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GrantType'></a>
## BackendService&lt;TEndpoints&gt;.GrantType Property
Specifies the grant type (a.k.a. OAuth "flow") used at this configuration level.  
```csharp
public TetraPak.AspNet.Auth.GrantType GrantType { get; }
```
#### Property Value
[TetraPak.AspNet.Auth.GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.GrantType 'TetraPak.AspNet.Auth.GrantType')
#### Exceptions
[TetraPak.AspNet.ServerConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ServerConfigurationException 'TetraPak.AspNet.ServerConfigurationException')  
The configured (textual) value could not be parsed into a [TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType 'TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType') (enum) value.   

Implements [GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType 'TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__Logger'></a>
## BackendService&lt;TEndpoints&gt;.Logger Property
Gets logging provider.    
```csharp
protected Microsoft.Extensions.Logging.ILogger? Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__ParentConfig'></a>
## BackendService&lt;TEndpoints&gt;.ParentConfig Property
Gets a declaring configuration (when this configuration is a sub configuration).  
```csharp
public TetraPak.AspNet.Auth.IServiceAuthConfig ParentConfig { get; }
```
#### Property Value
[TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')

Implements [ParentConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.ParentConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig.ParentConfig')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__Scope'></a>
## BackendService&lt;TEndpoints&gt;.Scope Property
Gets a scope to be requested for authorization.  
```csharp
public TetraPak.MultiStringValue Scope { get; }
```
#### Property Value
[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')

Implements [Scope](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.Scope 'TetraPak.AspNet.Auth.IServiceAuthConfig.Scope')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__ServiceName'></a>
## BackendService&lt;TEndpoints&gt;.ServiceName Property
Gets the identity of the service. This identity should be unique with the runtime context.   
```csharp
public string ServiceName { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Implements [ServiceName](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_ServiceName 'TetraPak.AspNet.Api.IBackendService.ServiceName')  
  
### Methods
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.AuthorizeAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
Obtains authorization to consume the service.   
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> AuthorizeAsync(TetraPak.AspNet.HttpClientOptions clientOptions, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
Specifies options for the client to be used during the authorization.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
Allows canceling the authorization process.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [AuthorizeAsync(HttpClientOptions, Nullable<CancellationToken>)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.Api.IBackendService.AuthorizeAsync(TetraPak.AspNet.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAccessTokenAsync(bool)'></a>
## BackendService&lt;TEndpoints&gt;.GetAccessTokenAsync(bool) Method
Gets an access token from the request context.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(bool forceStandardHeader=false);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAccessTokenAsync(bool)_forceStandardHeader'></a>
`forceStandardHeader` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set the configured (see [TetraPak.AspNet.TetraPakConfig.AuthorizationHeader](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig.AuthorizationHeader 'TetraPak.AspNet.TetraPakConfig.AuthorizationHeader')) authorization  
header is ignored in favour of the HTTP standard [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization') header.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetAccessTokenAsync(bool)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IAccessTokenProvider.GetAccessTokenAsync#TetraPak_AspNet_Auth_IAccessTokenProvider_GetAccessTokenAsync_System_Boolean_ 'TetraPak.AspNet.Auth.IAccessTokenProvider.GetAccessTokenAsync(System.Boolean)')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)'></a>
## BackendService&lt;TEndpoints&gt;.GetAsync&lt;T&gt;(string, HttpQuery?, HttpClientOptions?, Nullable&lt;CancellationToken&gt;, string?) Method
Sends a GET request to the backend service to retrieve an object of a specified type.  
```csharp
public System.Threading.Tasks.Task<TetraPak.AspNet.HttpEnumOutcome<T>> GetAsync<T>(string path, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, string? messageId=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_T'></a>
`T`  
Specifies the type of object to be retrieved.
  
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br/>  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows cancelling the operation.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt/>  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpEnumOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpEnumOutcome-1 'TetraPak.AspNet.HttpEnumOutcome`1')[T](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_T 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.GetAsync&lt;T&gt;(string, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;, string?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpEnumOutcome-1 'TetraPak.AspNet.HttpEnumOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetAsync<T>(string, HttpQuery?, HttpClientOptions?, Nullable<CancellationToken>, string?)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;, string?)')  
#### See Also
- [GetAsync(string, HttpQuery?, HttpClientOptions?, Nullable&lt;CancellationToken&gt;, string?)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;, string?)')
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)'></a>
## BackendService&lt;TEndpoints&gt;.GetAsync(string, HttpQuery?, HttpClientOptions?, Nullable&lt;CancellationToken&gt;, string?) Method
Sends a GEt request to the backend service to retrieve a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage').  
```csharp
public System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> GetAsync(string path, TetraPak.AspNet.HttpQuery? queryParameters=null, TetraPak.AspNet.HttpClientOptions? clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, string? messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_queryParameters'></a>
`queryParameters` [TetraPak.AspNet.HttpQuery](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpQuery 'TetraPak.AspNet.HttpQuery')  
(optional)  
Query parameters.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br/>  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows cancelling the operation.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt/>  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetAsync(string, HttpQuery?, HttpClientOptions?, Nullable<CancellationToken>, string?)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_) 'TetraPak.AspNet.Api.IBackendService.GetAsync(string, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;, string?)')  
#### See Also
- [GetAsync&lt;T&gt;(string, HttpQuery?, HttpClientOptions?, Nullable&lt;CancellationToken&gt;, string?)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetAsync_T_(string_TetraPak_AspNet_HttpQuery__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken__string_) 'TetraPak.AspNet.Api.IBackendService.GetAsync&lt;T&gt;(string, TetraPak.AspNet.HttpQuery?, TetraPak.AspNet.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;, string?)')
  
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
(optional)<br/>  
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
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetClientSecretAsync(AuthContext, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientSecretAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientSecretAsync_TetraPak_AspNet_AuthContext,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientSecretAsync(TetraPak.AspNet.AuthContext,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetConfiguredValue(string)'></a>
## BackendService&lt;TEndpoints&gt;.GetConfiguredValue(string) Method
Gets a "raw" configured value, as it is specified within the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') sources,  
unaffected by delegates or other (internal) logic.  
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
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetEndpoint(string)'></a>
## BackendService&lt;TEndpoints&gt;.GetEndpoint(string) Method
Gets a named service endpoint.  
```csharp
public TetraPak.AspNet.Api.ServiceEndpoint GetEndpoint(string name);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetEndpoint(string)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the requested endpoint.  
  
#### Returns
[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[name](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__GetEndpoint(string)_name 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.GetEndpoint(string).name') was unassigned (`null` or just whitespace).  
            

Implements [GetEndpoint(string)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_GetEndpoint(string) 'TetraPak.AspNet.Api.IBackendService.GetEndpoint(string)')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.GetScopeAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a scope to be requested for authorization while, optionally, specifying a default scope.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> GetScopeAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows canceling ot the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.GetScopeAsync(AuthContext, MultiStringValue?, Nullable&lt;CancellationToken&gt;) Method
Gets a scope to be requested for authorization while, optionally, specifying a default scope.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> GetScopeAsync(TetraPak.AspNet.AuthContext authContext, TetraPak.MultiStringValue? useDefault=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_useDefault'></a>
`useDefault` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
(optional)<br/>  
Specifies a default value to be returned if scope cannot be resolved.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
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
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnAuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.OnAuthorizeAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
(virtual method)<br/>  
Invoked after initial preparation by [AuthorizeAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;)](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.AuthorizeAsync(TetraPak.AspNet.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;)').  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> OnAuthorizeAsync(TetraPak.AspNet.HttpClientOptions clientOptions, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnAuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
Specifies options for the client to be used during the authorization.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnAuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
Allows canceling the authorization process.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
### Remarks
The default implementation simply calls [Endpoints](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__Endpoints 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.Endpoints')'  
internal [TetraPak.AspNet.IAuthorizationService](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IAuthorizationService 'TetraPak.AspNet.IAuthorizationService')
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnGetHttpClientAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.OnGetHttpClientAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
This method gets invoked when the class needs a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') instance.  
The calling code expects the returned client to be fully configured according to the  
options specified in [clientOptions](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__OnGetHttpClientAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_clientOptions 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.OnGetHttpClientAsync(TetraPak.AspNet.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;).clientOptions').  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpClient>> OnGetHttpClientAsync(TetraPak.AspNet.HttpClientOptions clientOptions, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnGetHttpClientAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
Specifies how to configure/authorize the requested client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnGetHttpClientAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') to be used for cancelling the request.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpRequestMessage_System_Collections_Generic_IEnumerable_System_Exception__string_)'></a>
## BackendService&lt;TEndpoints&gt;.OnServiceConfigurationError(HttpRequestMessage, IEnumerable&lt;Exception&gt;, string?) Method
Called by an internal method when it discovers a configuration issue,  
allowing for a consistent response to all such issues.  
```csharp
protected virtual TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage> OnServiceConfigurationError(System.Net.Http.HttpRequestMessage request, System.Collections.Generic.IEnumerable<System.Exception> issues, string? messageId);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpRequestMessage_System_Collections_Generic_IEnumerable_System_Exception__string_)_request'></a>
`request` [System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage')  
The ongoing request.    
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpRequestMessage_System_Collections_Generic_IEnumerable_System_Exception__string_)_issues'></a>
`issues` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of issues found.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpRequestMessage_System_Collections_Generic_IEnumerable_System_Exception__string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt/>  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')  
An [TetraPak.AspNet.HttpEnumOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpEnumOutcome-1 'TetraPak.AspNet.HttpEnumOutcome`1') to indicate success/failure and, on success, also carry  
one or more [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')s or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PatchAsync(string_object__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.PatchAsync(string, object?, HttpClientOptions?, Nullable&lt;CancellationToken&gt;) Method
Sends a PATCH request to the backend service.  
```csharp
public System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PatchAsync(string path, object? data, TetraPak.AspNet.HttpClientOptions? clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PatchAsync(string_object__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PatchAsync(string_object__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_data'></a>
`data` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The content to be patched.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PatchAsync(string_object__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br/>  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PatchAsync(string_object__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows cancelling the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [PatchAsync(string, object?, HttpClientOptions?, Nullable<CancellationToken>)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_PatchAsync(string_object__TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.Api.IBackendService.PatchAsync(string, object?, TetraPak.AspNet.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PatchAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.PatchAsync(string, HttpContent, HttpClientOptions?, Nullable&lt;CancellationToken&gt;) Method
Sends a PATCH request to the backend service.  
```csharp
public System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PatchAsync(string path, System.Net.Http.HttpContent content, TetraPak.AspNet.HttpClientOptions? clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PatchAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PatchAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The content to be patched.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PatchAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br/>  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PatchAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows cancelling the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [PatchAsync(string, HttpContent, HttpClientOptions?, Nullable<CancellationToken>)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_PatchAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.Api.IBackendService.PatchAsync(string, System.Net.Http.HttpContent, TetraPak.AspNet.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.PostAsync(string, HttpContent, HttpClientOptions?, Nullable&lt;CancellationToken&gt;) Method
Sends a POST request to the backend service.  
```csharp
public System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PostAsync(string path, System.Net.Http.HttpContent content, TetraPak.AspNet.HttpClientOptions? clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The content to be posted.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br/>  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows cancelling the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [PostAsync(string, HttpContent, HttpClientOptions?, Nullable<CancellationToken>)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_PostAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.Api.IBackendService.PostAsync(string, System.Net.Http.HttpContent, TetraPak.AspNet.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PutAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.PutAsync(string, HttpContent, HttpClientOptions?, Nullable&lt;CancellationToken&gt;) Method
Sends a PUT request to the backend service.  
```csharp
public System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> PutAsync(string path, System.Net.Http.HttpContent content, TetraPak.AspNet.HttpClientOptions? clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PutAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path to the requested resource.   
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PutAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_content'></a>
`content` [System.Net.Http.HttpContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpContent 'System.Net.Http.HttpContent')  
The content to be put.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PutAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_DefaultClientOptions 'TetraPak.AspNet.Api.IBackendService.DefaultClientOptions'))<br/>  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__PutAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows cancelling the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [PutAsync(string, HttpContent, HttpClientOptions?, Nullable<CancellationToken>)](TetraPak_AspNet_Api_IBackendService.md#TetraPak_AspNet_Api_IBackendService_PutAsync(string_System_Net_Http_HttpContent_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.Api.IBackendService.PutAsync(string, System.Net.Http.HttpContent, TetraPak.AspNet.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__SendAsync(System_Net_Http_HttpRequestMessage_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)'></a>
## BackendService&lt;TEndpoints&gt;.SendAsync(HttpRequestMessage, HttpClientOptions?, Nullable&lt;CancellationToken&gt;) Method
Sends a HTTP request and returns the outcome.   
```csharp
public System.Threading.Tasks.Task<TetraPak.AspNet.HttpOutcome<System.Net.Http.HttpResponseMessage>> SendAsync(System.Net.Http.HttpRequestMessage request, TetraPak.AspNet.HttpClientOptions? clientOptions=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__SendAsync(System_Net_Http_HttpRequestMessage_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_request'></a>
`request` [System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage')  
The HTTP request to be sent.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__SendAsync(System_Net_Http_HttpRequestMessage_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_clientOptions'></a>
`clientOptions` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional; default=[DefaultClientOptions](TetraPak_AspNet_Api_BackendService_TEndpoints_.md#TetraPak_AspNet_Api_BackendService_TEndpoints__DefaultClientOptions 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;.DefaultClientOptions'))<br/>  
Specifies options for creating a client.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__SendAsync(System_Net_Http_HttpRequestMessage_TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Allows cancelling the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.AspNet.HttpOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpOutcome-1 'TetraPak.AspNet.HttpOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
