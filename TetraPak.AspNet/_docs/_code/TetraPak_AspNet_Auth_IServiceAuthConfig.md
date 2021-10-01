#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## IServiceAuthConfig Interface
Classes implementing this contract can provide information needed for authorization purposes.   
```csharp
public interface IServiceAuthConfig
```

Derived  
&#8627; [TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig')  
### Properties
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_AmbientData'></a>
## IServiceAuthConfig.AmbientData Property
Gets an [AmbientData](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_AmbientData 'TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData') object.  
```csharp
TetraPak.AspNet.AmbientData AmbientData { get; }
```
#### Property Value
[AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')
  
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
[ConfigurationException](TetraPak_AspNet_ConfigurationException.md 'TetraPak.AspNet.ConfigurationException')  
The configured (textual) value could not be parsed into a [GrantType](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_GrantType 'TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType') (enum) value.   
  
<a name='TetraPak_AspNet_Auth_IServiceAuthConfig_ParentConfig'></a>
## IServiceAuthConfig.ParentConfig Property
Gets a declaring configuration (when this configuration is a sub configuration).  
```csharp
TetraPak.AspNet.Auth.IServiceAuthConfig? ParentConfig { get; }
```
#### Property Value
[IServiceAuthConfig](TetraPak_AspNet_Auth_IServiceAuthConfig.md 'TetraPak.AspNet.Auth.IServiceAuthConfig')
  
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
unaffected by delegates or other internal types of logic.  
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
  
