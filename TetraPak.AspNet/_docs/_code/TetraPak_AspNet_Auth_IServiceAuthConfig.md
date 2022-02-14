#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## IServiceAuthConfig Interface
Classes implementing this contract can provide information needed for authorization purposes.   
```csharp
public interface IServiceAuthConfig
```

Derived  
&#8627; [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
### Properties
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_AmbientData'></a>
## IServiceAuthConfig.AmbientData Property
Gets an [AmbientData](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_AmbientData 'TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData') object.  
```csharp
TetraPak.AspNet.AmbientData AmbientData { get; }
```
#### Property Value
[AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_ClientId'></a>
## IServiceAuthConfig.ClientId Property
Gets a configured client id at this configuration level.  
```csharp
string? ClientId { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_ClientSecret'></a>
## IServiceAuthConfig.ClientSecret Property
Gets a configured client secret at this configuration level.  
```csharp
string? ClientSecret { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_ConfigPath'></a>
## IServiceAuthConfig.ConfigPath Property
Gets the configuration path.  
```csharp
TetraPak.Configuration.ConfigPath? ConfigPath { get; }
```
#### Property Value
[TetraPak.Configuration.ConfigPath](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigPath 'TetraPak.Configuration.ConfigPath')
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_Configuration'></a>
## IServiceAuthConfig.Configuration Property
Gets the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') instance used to populate the properties.  
```csharp
Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
```
#### Property Value
[Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GrantType'></a>
## IServiceAuthConfig.GrantType Property
Specifies the grant type (a.k.a. OAuth "flow") used at this configuration level.  
```csharp
TetraPak.AspNet.Auth.GrantType GrantType { get; }
```
#### Property Value
[GrantType](TetraPak_AspNet_Auth_GrantType.md 'TetraPak.AspNet.Auth.GrantType')
#### Exceptions
[HttpServerConfigurationException](TetraPak_AspNet_HttpServerConfigurationException.md 'TetraPak.AspNet.HttpServerConfigurationException')  
The configured (textual) value could not be parsed into a [GrantType](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_GrantType 'TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType') (enum) value.   
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_ParentConfig'></a>
## IServiceAuthConfig.ParentConfig Property
Gets a declaring configuration (when this configuration is a sub configuration).  
```csharp
TetraPak.AspNet.Auth.IServiceAuthConfig? ParentConfig { get; }
```
#### Property Value
[IServiceAuthConfig](TetraPak_AspNet_Auth_IServiceAuthConfig.md 'TetraPak.AspNet.Auth.IServiceAuthConfig')
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_Scope'></a>
## IServiceAuthConfig.Scope Property
Gets an authorization scope at this configuration level.  
```csharp
TetraPak.MultiStringValue? Scope { get; }
```
#### Property Value
[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')
  
### Methods
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## IServiceAuthConfig.GetClientIdAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client id.  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<string>> GetClientIdAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## IServiceAuthConfig.GetClientSecretAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client secret.  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<string>> GetClientSecretAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GetConfiguredValue(string)'></a>
## IServiceAuthConfig.GetConfiguredValue(string) Method
Gets a "raw" configured value, as it is specified within the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') sources,  
unaffected by delegates or other (internal) logic.  
```csharp
string? GetConfiguredValue(string key);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GetConfiguredValue(string)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the requested value.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') when a value is configured; otherwise `null`.  
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)'></a>
## IServiceAuthConfig.GetScopeAsync(AuthContext, MultiStringValue?, Nullable&lt;CancellationToken&gt;) Method
Gets a scope to be requested for authorization while, optionally, specifying a default scope.  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> GetScopeAsync(TetraPak.AspNet.AuthContext authContext, TetraPak.MultiStringValue? useDefault=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_useDefault'></a>
`useDefault` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
(optional)<br/>  
Specifies a default value to be returned if scope cannot be resolved.  
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_IsAuthIdentifier(string)'></a>
## IServiceAuthConfig.IsAuthIdentifier(string) Method
Examines a string and returns a value to indicate whether the value identifies  
an attribute used for auth configuration. This is to ensure there is no risk of confusing  
services or endpoints with such attributes.   
```csharp
bool IsAuthIdentifier(string identifier);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_IsAuthIdentifier(string)_identifier'></a>
`identifier` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The identifier being examined.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [identifier](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_IsAuthIdentifier(string)_identifier 'TetraPak.AspNet.Auth.IServiceAuthConfig.IsAuthIdentifier(string).identifier') matches an auth configuration attribute; otherwise `false`.   
            
### Remarks
Examples of auth identifiers: "`ConfigPath`", "`GrantType`",  
"`ClientId`", "`ClientSecret`", "`Scope`".  
  
