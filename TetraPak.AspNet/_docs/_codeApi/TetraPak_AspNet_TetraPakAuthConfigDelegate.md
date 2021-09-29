#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakAuthConfigDelegate Class
A partial implementation of the [ITetraPakAuthConfigDelegate](TetraPak_AspNet_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.ITetraPakAuthConfigDelegate') contract.  
```csharp
public class TetraPakAuthConfigDelegate :
TetraPak.AspNet.ITetraPakAuthConfigDelegate,
TetraPak.AspNet.Auth.IClientConfigDelegate
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakAuthConfigDelegate  

Implements [ITetraPakAuthConfigDelegate](TetraPak_AspNet_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.ITetraPakAuthConfigDelegate'), [IClientConfigDelegate](TetraPak_AspNet_Auth_IClientConfigDelegate.md 'TetraPak.AspNet.Auth.IClientConfigDelegate')  
### Constructors
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_TetraPakAuthConfigDelegate(Microsoft_Extensions_Configuration_IConfiguration_TetraPak_SecretsManagement_ISecretsProvider_)'></a>
## TetraPakAuthConfigDelegate.TetraPakAuthConfigDelegate(IConfiguration, ISecretsProvider?) Constructor
Initializes the [TetraPakAuthConfigDelegate](TetraPak_AspNet_TetraPakAuthConfigDelegate.md 'TetraPak.AspNet.TetraPakAuthConfigDelegate').  
```csharp
public TetraPakAuthConfigDelegate(Microsoft.Extensions.Configuration.IConfiguration configuration, TetraPak.SecretsManagement.ISecretsProvider? secretsProvider=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_TetraPakAuthConfigDelegate(Microsoft_Extensions_Configuration_IConfiguration_TetraPak_SecretsManagement_ISecretsProvider_)_configuration'></a>
`configuration` [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')  
The configuration code API.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_TetraPakAuthConfigDelegate(Microsoft_Extensions_Configuration_IConfiguration_TetraPak_SecretsManagement_ISecretsProvider_)_secretsProvider'></a>
`secretsProvider` [TetraPak.SecretsManagement.ISecretsProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.SecretsManagement.ISecretsProvider 'TetraPak.SecretsManagement.ISecretsProvider')  
(optional)<br/>  
A provider of secrets.   
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[configuration](TetraPak_AspNet_TetraPakAuthConfigDelegate.md#TetraPak_AspNet_TetraPakAuthConfigDelegate_TetraPakAuthConfigDelegate(Microsoft_Extensions_Configuration_IConfiguration_TetraPak_SecretsManagement_ISecretsProvider_)_configuration 'TetraPak.AspNet.TetraPakAuthConfigDelegate.TetraPakAuthConfigDelegate(Microsoft.Extensions.Configuration.IConfiguration, TetraPak.SecretsManagement.ISecretsProvider?).configuration') was unassigned (`null`).  
            
  
### Methods
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_GetClientCredentialsAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakAuthConfigDelegate.GetClientCredentialsAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets client credentials (client id and, optionally, client secret).  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.Credentials>> GetClientCredentialsAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_GetClientCredentialsAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the client credentials are requested.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_GetClientCredentialsAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Enables operation cancellation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetClientCredentialsAsync(AuthContext, Nullable<CancellationToken>)](TetraPak_AspNet_Auth_IClientConfigDelegate.md#TetraPak_AspNet_Auth_IClientConfigDelegate_GetClientCredentialsAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.Auth.IClientConfigDelegate.GetClientCredentialsAsync(TetraPak.AspNet.AuthContext, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_GetScopeAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakAuthConfigDelegate.GetScopeAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a scope to be used for the configured client.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> GetScopeAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_GetScopeAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the scope is requested.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_GetScopeAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Enables operation cancellation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetScopeAsync(AuthContext, Nullable<CancellationToken>)](TetraPak_AspNet_Auth_IClientConfigDelegate.md#TetraPak_AspNet_Auth_IClientConfigDelegate_GetScopeAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.Auth.IClientConfigDelegate.GetScopeAsync(TetraPak.AspNet.AuthContext, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_OnGetClientCredentialsAsync(TetraPak_AspNet_AuthContext)'></a>
## TetraPakAuthConfigDelegate.OnGetClientCredentialsAsync(AuthContext) Method
Called to obtain the client secrets for a specified "path".   
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.Credentials>> OnGetClientCredentialsAsync(TetraPak.AspNet.AuthContext authContext);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_OnGetClientCredentialsAsync(TetraPak_AspNet_AuthContext)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
### Remarks
This implementation will use a configured [TetraPak.SecretsManagement.ISecretsProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.SecretsManagement.ISecretsProvider 'TetraPak.SecretsManagement.ISecretsProvider') service when available  
to obtain both client id and client secret. If a client id cannot be found it will  
try resolve the client id from the configuration instead.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_OnGetScopeAsync(TetraPak_AspNet_AuthContext)'></a>
## TetraPakAuthConfigDelegate.OnGetScopeAsync(AuthContext) Method
Called to obtain the client's requested scope.  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> OnGetScopeAsync(TetraPak.AspNet.AuthContext authContext);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_OnGetScopeAsync(TetraPak_AspNet_AuthContext)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_OnResolveConfiguredEnvironment(string_)'></a>
## TetraPakAuthConfigDelegate.OnResolveConfiguredEnvironment(string?) Method
Called internally to resolve the runtime environment.  
```csharp
protected virtual TetraPak.RuntimeEnvironment OnResolveConfiguredEnvironment(string? configuredValue);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_OnResolveConfiguredEnvironment(string_)_configuredValue'></a>
`configuredValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A value obtained from the Tetra Pak configuration.   
  
#### Returns
[TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment')  
A [TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment') value.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_ResolveConfiguredEnvironment(string)'></a>
## TetraPakAuthConfigDelegate.ResolveConfiguredEnvironment(string) Method
Called to resolve the configured (or null, when un-configured) runtime environment.  
```csharp
public virtual TetraPak.RuntimeEnvironment ResolveConfiguredEnvironment(string configuredValue);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_ResolveConfiguredEnvironment(string)_configuredValue'></a>
`configuredValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') representation of the configured value.
  
#### Returns
[TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment')  
A resolved [TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment') value.  

Implements [ResolveConfiguredEnvironment(string)](TetraPak_AspNet_ITetraPakAuthConfigDelegate.md#TetraPak_AspNet_ITetraPakAuthConfigDelegate_ResolveConfiguredEnvironment(string) 'TetraPak.AspNet.ITetraPakAuthConfigDelegate.ResolveConfiguredEnvironment(string)')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_TryGetConfiguredValue(string_TetraPak_AspNet_AuthContext_string__bool)'></a>
## TetraPakAuthConfigDelegate.TryGetConfiguredValue(string, AuthContext, string?, bool) Method
Looks for a configured value within the hierarchy of [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') framework,  
unaffected by delegate or other types of internal logic.  
```csharp
protected static bool TryGetConfiguredValue(string key, TetraPak.AspNet.AuthContext context, out string? value, bool fallbackToParentValue=false);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_TryGetConfiguredValue(string_TetraPak_AspNet_AuthContext_string__bool)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the requested configured value.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_TryGetConfiguredValue(string_TetraPak_AspNet_AuthContext_string__bool)_context'></a>
`context` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
The [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext') instance.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_TryGetConfiguredValue(string_TetraPak_AspNet_AuthContext_string__bool)_value'></a>
`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Passes back the value when found; otherwise `null`.   
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_TryGetConfiguredValue(string_TetraPak_AspNet_AuthContext_string__bool)_fallbackToParentValue'></a>
`fallbackToParentValue` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
Specifies whether to automatically traverse the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') framework,  
looking for the requested value in configurations higher up in the hierarchy.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the requested value was found; otherwise `false`.  
            
  
