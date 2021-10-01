#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## ServiceEndpointCollection Class
A specialized [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') for named URLs.  
```csharp
public class ServiceEndpointCollection : TetraPak.Configuration.ConfigurationSection,
TetraPak.AspNet.Auth.IServiceAuthConfig,
System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, TetraPak.AspNet.Api.ServiceEndpoint>>,
System.Collections.IEnumerable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') &#129106; ServiceEndpointCollection  

Implements [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')  
### Constructors
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_ServiceEndpointCollection(TetraPak_AspNet_Auth_IServiceAuthConfig_string)'></a>
## ServiceEndpointCollection.ServiceEndpointCollection(IServiceAuthConfig, string) Constructor
Initializes the [ServiceEndpointCollection](TetraPak_AspNet_Api_ServiceEndpointCollection.md 'TetraPak.AspNet.Api.ServiceEndpointCollection').  
```csharp
public ServiceEndpointCollection(TetraPak.AspNet.Auth.IServiceAuthConfig serviceAuthConfig, string sectionIdentifier="Endpoints");
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_ServiceEndpointCollection(TetraPak_AspNet_Auth_IServiceAuthConfig_string)_serviceAuthConfig'></a>
`serviceAuthConfig` [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')  
Provides access to the service configuration.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_ServiceEndpointCollection(TetraPak_AspNet_Auth_IServiceAuthConfig_string)_sectionIdentifier'></a>
`sectionIdentifier` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the service configuration section.  
  
  
### Properties
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_AmbientData'></a>
## ServiceEndpointCollection.AmbientData Property
Gets an [TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData 'TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData') object.  
```csharp
public TetraPak.AspNet.AmbientData AmbientData { get; }
```
#### Property Value
[TetraPak.AspNet.AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AmbientData 'TetraPak.AspNet.AmbientData')

Implements [AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData 'TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_BasePath'></a>
## ServiceEndpointCollection.BasePath Property
A default base path.  
```csharp
public string? BasePath { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_ClientId'></a>
## ServiceEndpointCollection.ClientId Property
Gets or sets a configured client id at this configuration level.  
```csharp
public virtual string? ClientId { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_ClientOptions'></a>
## ServiceEndpointCollection.ClientOptions Property
Gets pre-configured client options.   
```csharp
public virtual TetraPak.AspNet.Api.HttpClientOptions ClientOptions { get; }
```
#### Property Value
[HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_ClientSecret'></a>
## ServiceEndpointCollection.ClientSecret Property
Gets or sets a configured client secret at this configuration level.  
```csharp
public virtual string? ClientSecret { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_Configuration'></a>
## ServiceEndpointCollection.Configuration Property
Gets the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') instance used to populate the properties.  
```csharp
public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
```
#### Property Value
[Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')

Implements [Configuration](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.Configuration 'TetraPak.AspNet.Auth.IServiceAuthConfig.Configuration')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GrantType'></a>
## ServiceEndpointCollection.GrantType Property
Gets or sets the grant type (a.k.a. OAuth "flow") used at this configuration level.  
```csharp
public virtual TetraPak.AspNet.Auth.GrantType GrantType { get; set; }
```
#### Property Value
[TetraPak.AspNet.Auth.GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.GrantType 'TetraPak.AspNet.Auth.GrantType')
#### Exceptions
[TetraPak.AspNet.ConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ConfigurationException 'TetraPak.AspNet.ConfigurationException')  

Implements [GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType 'TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_Host'></a>
## ServiceEndpointCollection.Host Property
The default host address.  
```csharp
public string? Host { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_IsValid'></a>
## ServiceEndpointCollection.IsValid Property
Gets a value indicating that the endpoints (configuration) is valid (no unresolved issues where found).  
```csharp
public bool IsValid { get; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
#### See Also
- [GetIssues()](TetraPak_AspNet_Api_ServiceEndpointCollection.md#TetraPak_AspNet_Api_ServiceEndpointCollection_GetIssues() 'TetraPak.AspNet.Api.ServiceEndpointCollection.GetIssues()')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_ParentConfig'></a>
## ServiceEndpointCollection.ParentConfig Property
Gets a declaring configuration (when this configuration is a sub configuration).  
```csharp
public TetraPak.AspNet.Auth.IServiceAuthConfig ParentConfig { get; }
```
#### Property Value
[TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')

Implements [ParentConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.ParentConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig.ParentConfig')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_Scope'></a>
## ServiceEndpointCollection.Scope Property
Gets or sets a scope of identity claims, a this configuration level,  
to be requested while authenticating the identity. When omitted a default scope will be used.  
```csharp
public virtual TetraPak.MultiStringValue Scope { get; set; }
```
#### Property Value
[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_ServiceAuthConfig'></a>
## ServiceEndpointCollection.ServiceAuthConfig Property
Gets the service auth configuration.  
```csharp
public TetraPak.AspNet.Auth.IServiceAuthConfig ServiceAuthConfig { get; set; }
```
#### Property Value
[TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_this_string_'></a>
## ServiceEndpointCollection.this[string] Property
Gets a named [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
```csharp
public TetraPak.AspNet.Api.ServiceEndpoint this[string endpointName] { get; }
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_this_string__endpointName'></a>
`endpointName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the requested [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
  
#### Property Value
[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')
  
### Methods
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpointCollection.GetClientIdAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client id.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<string>> GetClientIdAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetClientIdAsync(AuthContext, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientIdAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientIdAsync_TetraPak_AspNet_AuthContext,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientIdAsync(TetraPak.AspNet.AuthContext,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpointCollection.GetClientSecretAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client secret.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<string>> GetClientSecretAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetClientSecretAsync(AuthContext, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientSecretAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientSecretAsync_TetraPak_AspNet_AuthContext,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientSecretAsync(TetraPak.AspNet.AuthContext,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetConfiguredValue(string)'></a>
## ServiceEndpointCollection.GetConfiguredValue(string) Method
Gets a "raw" configured value, as it is specified within the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') sources,  
unaffected by delegates or other internal types of logic.  
```csharp
public string GetConfiguredValue(string key);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetConfiguredValue(string)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the requested value.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') when a value is configured; otherwise `null`.  

Implements [GetConfiguredValue(string)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetConfiguredValue#TetraPak_AspNet_Auth_IServiceAuthConfig_GetConfiguredValue_System_String_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetConfiguredValue(System.String)')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetEndpoint(string)'></a>
## ServiceEndpointCollection.GetEndpoint(string) Method
Gets a named endpoint. Intended to be called from endpoint properties getter.  
```csharp
public TetraPak.AspNet.Api.ServiceEndpoint GetEndpoint(string propertyName=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetEndpoint(string)_propertyName'></a>
`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The (property) name of the endpoint.  
  
#### Returns
[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
A [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') object on success,  
or a [ServiceInvalidEndpoint](TetraPak_AspNet_Api_ServiceInvalidEndpoint.md 'TetraPak.AspNet.Api.ServiceInvalidEndpoint') on failure.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetEnumerator()'></a>
## ServiceEndpointCollection.GetEnumerator() Method
Returns an enumerator that iterates through the collection.
```csharp
public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string,TetraPak.AspNet.Api.ServiceEndpoint>> GetEnumerator();
```
#### Returns
[System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')  
An enumerator that can be used to iterate through the collection.

Implements [GetEnumerator()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1.GetEnumerator 'System.Collections.Generic.IEnumerable`1.GetEnumerator'), [GetEnumerator()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable.GetEnumerator 'System.Collections.IEnumerable.GetEnumerator')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetIssues()'></a>
## ServiceEndpointCollection.GetIssues() Method
Gets a collection of unresolved issues found for the endpoints.   
```csharp
public System.Collections.Generic.IEnumerable<System.Exception>? GetIssues();
```
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception'), or `null`.  
#### See Also
- [IsValid](TetraPak_AspNet_Api_ServiceEndpointCollection.md#TetraPak_AspNet_Api_ServiceEndpointCollection_IsValid 'TetraPak.AspNet.Api.ServiceEndpointCollection.IsValid')
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpointCollection.GetScopeAsync(AuthContext, MultiStringValue?, Nullable&lt;CancellationToken&gt;) Method
Gets a scope to be requested for authorization while, optionally, specifying a default scope.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> GetScopeAsync(TetraPak.AspNet.AuthContext authContext, TetraPak.MultiStringValue? useDefault=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_useDefault'></a>
`useDefault` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
(optional)<br/>  
Specifies a default value to be returned if scope cannot be resolved.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetScopeAsync(AuthContext, MultiStringValue?, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetScopeAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetScopeAsync_TetraPak_AspNet_AuthContext,TetraPak_MultiStringValue,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetScopeAsync(TetraPak.AspNet.AuthContext,TetraPak.MultiStringValue,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_OnInitializeEndpoints(TetraPak_AspNet_Auth_IServiceAuthConfig_string)'></a>
## ServiceEndpointCollection.OnInitializeEndpoints(IServiceAuthConfig, string) Method
Called during object initialization (from ctor) to initialize all endpoints from the  
service's configuration ([serviceAuthConfig](TetraPak_AspNet_Api_ServiceEndpointCollection.md#TetraPak_AspNet_Api_ServiceEndpointCollection_OnInitializeEndpoints(TetraPak_AspNet_Auth_IServiceAuthConfig_string)_serviceAuthConfig 'TetraPak.AspNet.Api.ServiceEndpointCollection.OnInitializeEndpoints(TetraPak.AspNet.Auth.IServiceAuthConfig, string).serviceAuthConfig')).  
```csharp
protected virtual void OnInitializeEndpoints(TetraPak.AspNet.Auth.IServiceAuthConfig serviceAuthConfig, string sectionIdentifier);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_OnInitializeEndpoints(TetraPak_AspNet_Auth_IServiceAuthConfig_string)_serviceAuthConfig'></a>
`serviceAuthConfig` [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')  
Provides access to the service configuration.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpointCollection_OnInitializeEndpoints(TetraPak_AspNet_Auth_IServiceAuthConfig_string)_sectionIdentifier'></a>
`sectionIdentifier` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the service configuration section.  
  
  
