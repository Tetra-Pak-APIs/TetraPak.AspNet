#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## ServiceEndpoints Class
A specialized [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') for named URLs.  
```csharp
public class ServiceEndpoints : TetraPak.Configuration.ConfigurationSection,
TetraPak.AspNet.Auth.IServiceAuthConfig,
TetraPak.AspNet.Auth.IAccessTokenProvider,
TetraPak.AspNet.IHttpClientProvider,
TetraPak.AspNet.IAuthorizationService,
TetraPak.AspNet.Diagnostics.ITetraPakDiagnosticsProvider,
System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, TetraPak.AspNet.Api.ServiceEndpoint>>,
System.Collections.IEnumerable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') &#129106; ServiceEndpoints  

Implements [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig'), [TetraPak.AspNet.Auth.IAccessTokenProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IAccessTokenProvider 'TetraPak.AspNet.Auth.IAccessTokenProvider'), [TetraPak.AspNet.IHttpClientProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IHttpClientProvider 'TetraPak.AspNet.IHttpClientProvider'), [TetraPak.AspNet.IAuthorizationService](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IAuthorizationService 'TetraPak.AspNet.IAuthorizationService'), [TetraPak.AspNet.Diagnostics.ITetraPakDiagnosticsProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Diagnostics.ITetraPakDiagnosticsProvider 'TetraPak.AspNet.Diagnostics.ITetraPakDiagnosticsProvider'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')  
### Constructors
<a name='TetraPak_AspNet_Api_ServiceEndpoints_ServiceEndpoints()'></a>
## ServiceEndpoints.ServiceEndpoints() Constructor
To be used by automatic initialization (see [AddTetraPakServices(IServiceCollection)](TetraPak_AspNet_Api_TetraPakServiceHelper.md#TetraPak_AspNet_Api_TetraPakServiceHelper_AddTetraPakServices(Microsoft_Extensions_DependencyInjection_IServiceCollection) 'TetraPak.AspNet.Api.TetraPakServiceHelper.AddTetraPakServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)')).  
```csharp
protected ServiceEndpoints();
```
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_ServiceEndpoints(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_AspNet_IHttpClientProvider_TetraPak_AspNet_IAuthorizationService_Microsoft_Extensions_Configuration_IConfigurationSection)'></a>
## ServiceEndpoints.ServiceEndpoints(TetraPakConfig, IServiceAuthConfig, IHttpClientProvider, IAuthorizationService, IConfigurationSection) Constructor
Initializes the [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
```csharp
internal ServiceEndpoints(TetraPak.AspNet.TetraPakConfig tetraPakConfig, TetraPak.AspNet.Auth.IServiceAuthConfig serviceAuthConfig, TetraPak.AspNet.IHttpClientProvider httpHttpClientProvider, TetraPak.AspNet.IAuthorizationService authorizationService, Microsoft.Extensions.Configuration.IConfigurationSection section);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoints_ServiceEndpoints(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_AspNet_IHttpClientProvider_TetraPak_AspNet_IAuthorizationService_Microsoft_Extensions_Configuration_IConfigurationSection)_tetraPakConfig'></a>
`tetraPakConfig` [TetraPak.AspNet.TetraPakConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig 'TetraPak.AspNet.TetraPakConfig')  
Initializes [TetraPakConfig](TetraPak_AspNet_Api_ServiceEndpoints.md#TetraPak_AspNet_Api_ServiceEndpoints_TetraPakConfig 'TetraPak.AspNet.Api.ServiceEndpoints.TetraPakConfig').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_ServiceEndpoints(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_AspNet_IHttpClientProvider_TetraPak_AspNet_IAuthorizationService_Microsoft_Extensions_Configuration_IConfigurationSection)_serviceAuthConfig'></a>
`serviceAuthConfig` [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')  
Initializes [ServiceAuthConfig](TetraPak_AspNet_Api_ServiceEndpoints.md#TetraPak_AspNet_Api_ServiceEndpoints_ServiceAuthConfig 'TetraPak.AspNet.Api.ServiceEndpoints.ServiceAuthConfig').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_ServiceEndpoints(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_AspNet_IHttpClientProvider_TetraPak_AspNet_IAuthorizationService_Microsoft_Extensions_Configuration_IConfigurationSection)_httpHttpClientProvider'></a>
`httpHttpClientProvider` [TetraPak.AspNet.IHttpClientProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IHttpClientProvider 'TetraPak.AspNet.IHttpClientProvider')  
A Http Client factory.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_ServiceEndpoints(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_AspNet_IHttpClientProvider_TetraPak_AspNet_IAuthorizationService_Microsoft_Extensions_Configuration_IConfigurationSection)_authorizationService'></a>
`authorizationService` [TetraPak.AspNet.IAuthorizationService](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IAuthorizationService 'TetraPak.AspNet.IAuthorizationService')  
Allows client authorization.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_ServiceEndpoints(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_Auth_IServiceAuthConfig_TetraPak_AspNet_IHttpClientProvider_TetraPak_AspNet_IAuthorizationService_Microsoft_Extensions_Configuration_IConfigurationSection)_section'></a>
`section` [Microsoft.Extensions.Configuration.IConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfigurationSection 'Microsoft.Extensions.Configuration.IConfigurationSection')  
The service configuration section.  
  
  
### Properties
<a name='TetraPak_AspNet_Api_ServiceEndpoints_AmbientData'></a>
## ServiceEndpoints.AmbientData Property
Gets an [AmbientData](TetraPak_AspNet_Api_ServiceEndpoints.md#TetraPak_AspNet_Api_ServiceEndpoints_AmbientData 'TetraPak.AspNet.Api.ServiceEndpoints.AmbientData') object.  
```csharp
public TetraPak.AspNet.AmbientData AmbientData { get; }
```
#### Property Value
[TetraPak.AspNet.AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AmbientData 'TetraPak.AspNet.AmbientData')

Implements [AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData 'TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_BasePath'></a>
## ServiceEndpoints.BasePath Property
A default base path.  
```csharp
public string? BasePath { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_ClientId'></a>
## ServiceEndpoints.ClientId Property
Gets or sets a client identity to be submitted when requesting authorization.  
```csharp
public virtual string? ClientId { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Implements [ClientId](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.ClientId 'TetraPak.AspNet.Auth.IServiceAuthConfig.ClientId')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_ClientOptions'></a>
## ServiceEndpoints.ClientOptions Property
Gets pre-configured client options.   
```csharp
public virtual TetraPak.AspNet.HttpClientOptions ClientOptions { get; }
```
#### Property Value
[TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_ClientSecret'></a>
## ServiceEndpoints.ClientSecret Property
Gets or sets a client secret to be submitted when requesting authorization.  
```csharp
public virtual string? ClientSecret { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Implements [ClientSecret](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.ClientSecret 'TetraPak.AspNet.Auth.IServiceAuthConfig.ClientSecret')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_Configuration'></a>
## ServiceEndpoints.Configuration Property
Gets a globally available [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') instance.  
```csharp
public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
```
#### Property Value
[Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')

Implements [Configuration](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.Configuration 'TetraPak.AspNet.Auth.IServiceAuthConfig.Configuration')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GrantType'></a>
## ServiceEndpoints.GrantType Property
Gets or sets the type of grant used for request authorization.  
```csharp
public virtual TetraPak.AspNet.Auth.GrantType GrantType { get; set; }
```
#### Property Value
[TetraPak.AspNet.Auth.GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.GrantType 'TetraPak.AspNet.Auth.GrantType')
#### Exceptions
[TetraPak.AspNet.ServerConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ServerConfigurationException 'TetraPak.AspNet.ServerConfigurationException')  
The configured value was incorrect (could not be parsed into [GrantType](TetraPak_AspNet_Api_ServiceEndpoints.md#TetraPak_AspNet_Api_ServiceEndpoints_GrantType 'TetraPak.AspNet.Api.ServiceEndpoints.GrantType')).  

Implements [GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType 'TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_Host'></a>
## ServiceEndpoints.Host Property
The default host address.  
```csharp
public string? Host { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_IsValid'></a>
## ServiceEndpoints.IsValid Property
Returns a value indicating whether the collection of endpoints are valid as a whole (no issues found).  
```csharp
public bool IsValid { get; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
#### See Also
- [GetIssues()](TetraPak_AspNet_Api_ServiceEndpoints.md#TetraPak_AspNet_Api_ServiceEndpoints_GetIssues() 'TetraPak.AspNet.Api.ServiceEndpoints.GetIssues()')
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_Methods'></a>
## ServiceEndpoints.Methods Property
Gets or sets a (comma separated) list of allowed HTTP methods.  
```csharp
public virtual TetraPak.MultiStringValue? Methods { get; set; }
```
#### Property Value
[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_ParentConfig'></a>
## ServiceEndpoints.ParentConfig Property
Gets the parent configuration level.  
```csharp
public TetraPak.AspNet.Auth.IServiceAuthConfig ParentConfig { get; }
```
#### Property Value
[TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')

Implements [ParentConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.ParentConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig.ParentConfig')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_Scope'></a>
## ServiceEndpoints.Scope Property
Gets or sets a scope to be requested for authorization.  
```csharp
public virtual TetraPak.MultiStringValue Scope { get; set; }
```
#### Property Value
[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')

Implements [Scope](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.Scope 'TetraPak.AspNet.Auth.IServiceAuthConfig.Scope')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_ServiceAuthConfig'></a>
## ServiceEndpoints.ServiceAuthConfig Property
Gets the service auth configuration.  
```csharp
public TetraPak.AspNet.Auth.IServiceAuthConfig ServiceAuthConfig { get; set; }
```
#### Property Value
[TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_TetraPakConfig'></a>
## ServiceEndpoints.TetraPakConfig Property
Gets the Tetra Pak integration configuration.  
```csharp
public TetraPak.AspNet.TetraPakConfig TetraPakConfig { get; }
```
#### Property Value
[TetraPak.AspNet.TetraPakConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig 'TetraPak.AspNet.TetraPakConfig')
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_this_string_'></a>
## ServiceEndpoints.this[string] Property
Gets a named endpoint ([ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')).  
```csharp
public TetraPak.AspNet.Api.ServiceEndpoint this[string endpointName] { get; }
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoints_this_string__endpointName'></a>
`endpointName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the endpoint.  
  
#### Property Value
[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[endpointName](TetraPak_AspNet_Api_ServiceEndpoints.md#TetraPak_AspNet_Api_ServiceEndpoints_this_string__endpointName 'TetraPak.AspNet.Api.ServiceEndpoints.this[string].endpointName') was unassigned (`null` or just whitespace).  
            
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_TrimHostInResponses'></a>
## ServiceEndpoints.TrimHostInResponses Property
Gets a value that specifies whether to always remove the host element from relationship URLs  
based on this endpoint. If not specified in configuration the value will fall back to the  
configuration service level (the endpoint "parent" section).   
```csharp
public bool TrimHostInResponses { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
### Methods
<a name='TetraPak_AspNet_Api_ServiceEndpoints_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpoints.AuthorizeAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
Authenticates a specific service.   
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> AuthorizeAsync(TetraPak.AspNet.HttpClientOptions options, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoints_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_options'></a>
`options` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
Options for obtaining a client.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and, on success, carrying  
the requested token as its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value'); otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[options](TetraPak_AspNet_Api_ServiceEndpoints.md#TetraPak_AspNet_Api_ServiceEndpoints_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_options 'TetraPak.AspNet.Api.ServiceEndpoints.AuthorizeAsync(TetraPak.AspNet.HttpClientOptions, System.Nullable&lt;System.Threading.CancellationToken&gt;).options') configuration ([TetraPak.AspNet.HttpClientOptions.AuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions.AuthConfig 'TetraPak.AspNet.HttpClientOptions.AuthConfig')) was unassigned.  
            

Implements [AuthorizeAsync(HttpClientOptions, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IAuthorizationService.AuthorizeAsync#TetraPak_AspNet_IAuthorizationService_AuthorizeAsync_TetraPak_AspNet_HttpClientOptions,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.IAuthorizationService.AuthorizeAsync(TetraPak.AspNet.HttpClientOptions,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetAccessTokenAsync(bool)'></a>
## ServiceEndpoints.GetAccessTokenAsync(bool) Method
Gets an access token from the request context.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(bool forceStandardHeader=false);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetAccessTokenAsync(bool)_forceStandardHeader'></a>
`forceStandardHeader` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set the configured (see [TetraPak.AspNet.TetraPakConfig.AuthorizationHeader](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig.AuthorizationHeader 'TetraPak.AspNet.TetraPakConfig.AuthorizationHeader')) authorization  
header is ignored in favour of the HTTP standard [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization') header.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetAccessTokenAsync(bool)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IAccessTokenProvider.GetAccessTokenAsync#TetraPak_AspNet_Auth_IAccessTokenProvider_GetAccessTokenAsync_System_Boolean_ 'TetraPak.AspNet.Auth.IAccessTokenProvider.GetAccessTokenAsync(System.Boolean)')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpoints.GetClientIdAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client id.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<string>> GetClientIdAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetClientIdAsync(AuthContext, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientIdAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientIdAsync_TetraPak_AspNet_AuthContext,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientIdAsync(TetraPak.AspNet.AuthContext,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpoints.GetClientSecretAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client secret.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<string>> GetClientSecretAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetClientSecretAsync(AuthContext, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientSecretAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientSecretAsync_TetraPak_AspNet_AuthContext,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientSecretAsync(TetraPak.AspNet.AuthContext,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetConfiguredValue(string)'></a>
## ServiceEndpoints.GetConfiguredValue(string) Method
Gets a "raw" configured value, as it is specified within the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') sources,  
unaffected by delegates or other (internal) logic.  
```csharp
public string GetConfiguredValue(string key);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetConfiguredValue(string)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the requested value.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') when a value is configured; otherwise `null`.  

Implements [GetConfiguredValue(string)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetConfiguredValue#TetraPak_AspNet_Auth_IServiceAuthConfig_GetConfiguredValue_System_String_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetConfiguredValue(System.String)')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetEndpoint(string)'></a>
## ServiceEndpoints.GetEndpoint(string) Method
Gets a named endpoint. Intended to be called from endpoint properties getter.  
```csharp
public TetraPak.AspNet.Api.ServiceEndpoint GetEndpoint(string propertyName=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetEndpoint(string)_propertyName'></a>
`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The (property) name of the endpoint.  
  
#### Returns
[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
A [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') object on success,  
or a [ServiceInvalidEndpoint](TetraPak_AspNet_Api_ServiceInvalidEndpoint.md 'TetraPak.AspNet.Api.ServiceInvalidEndpoint') on failure.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetEnumerator()'></a>
## ServiceEndpoints.GetEnumerator() Method
Returns an enumerator that iterates through the collection.
```csharp
public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string,TetraPak.AspNet.Api.ServiceEndpoint>> GetEnumerator();
```
#### Returns
[System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')  
An enumerator that can be used to iterate through the collection.

Implements [GetEnumerator()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1.GetEnumerator 'System.Collections.Generic.IEnumerable`1.GetEnumerator'), [GetEnumerator()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable.GetEnumerator 'System.Collections.IEnumerable.GetEnumerator')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpoints.GetHttpClientAsync(HttpClientOptions?, Nullable&lt;CancellationToken&gt;) Method
Creates and returns a (configured) [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') for use with a specific service.   
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpClient>> GetHttpClientAsync(TetraPak.AspNet.HttpClientOptions? options=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_options'></a>
`options` [TetraPak.AspNet.HttpClientOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpClientOptions 'TetraPak.AspNet.HttpClientOptions')  
(optional)<br/>  
A (customizable) set of options to describe the requested [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and, on success, carrying  
the requested client as its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value'); otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetHttpClientAsync(HttpClientOptions?, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IHttpClientProvider.GetHttpClientAsync#TetraPak_AspNet_IHttpClientProvider_GetHttpClientAsync_TetraPak_AspNet_HttpClientOptions,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.IHttpClientProvider.GetHttpClientAsync(TetraPak.AspNet.HttpClientOptions,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetIssues()'></a>
## ServiceEndpoints.GetIssues() Method
Gets all issues found during initialization (typically related to configuration).  
```csharp
public System.Collections.Generic.IEnumerable<System.Exception>? GetIssues();
```
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpoints.GetScopeAsync(AuthContext, MultiStringValue?, Nullable&lt;CancellationToken&gt;) Method
Gets a scope to be requested for authorization while, optionally, specifying a default scope.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> GetScopeAsync(TetraPak.AspNet.AuthContext authContext, TetraPak.MultiStringValue? useDefault=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_useDefault'></a>
`useDefault` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
(optional)<br/>  
Specifies a default value to be returned if scope cannot be resolved.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetScopeAsync(AuthContext, MultiStringValue?, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetScopeAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetScopeAsync_TetraPak_AspNet_AuthContext,TetraPak_MultiStringValue,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetScopeAsync(TetraPak.AspNet.AuthContext,TetraPak.MultiStringValue,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoints_IsAuthIdentifier(string)'></a>
## ServiceEndpoints.IsAuthIdentifier(string) Method
Examines a string and returns a value to indicate whether the value identifies  
an attribute used for auth configuration. This is to ensure there is no risk of confusing  
services or endpoints with such attributes.   
```csharp
public bool IsAuthIdentifier(string identifier);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoints_IsAuthIdentifier(string)_identifier'></a>
`identifier` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The identifier being examined.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [identifier](TetraPak_AspNet_Api_ServiceEndpoints.md#TetraPak_AspNet_Api_ServiceEndpoints_IsAuthIdentifier(string)_identifier 'TetraPak.AspNet.Api.ServiceEndpoints.IsAuthIdentifier(string).identifier') matches an auth configuration attribute; otherwise `false`.   
            

Implements [IsAuthIdentifier(string)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.IsAuthIdentifier#TetraPak_AspNet_Auth_IServiceAuthConfig_IsAuthIdentifier_System_String_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.IsAuthIdentifier(System.String)')  
### Remarks
Examples of auth identifiers: "`ConfigPath`", "`GrantType`",  
"`ClientId`", "`ClientSecret`", "`Scope`".  
  
