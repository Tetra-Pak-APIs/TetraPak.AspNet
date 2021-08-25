#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakAuthConfigDelegate Class
A partial implementation of the [ITetraPakAuthConfigDelegate](TetraPak_AspNet_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.ITetraPakAuthConfigDelegate') contract.  
```csharp
public abstract class TetraPakAuthConfigDelegate :
TetraPak.AspNet.ITetraPakAuthConfigDelegate,
TetraPak.AspNet.Auth.IClientConfigProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakAuthConfigDelegate  

Implements [ITetraPakAuthConfigDelegate](TetraPak_AspNet_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.ITetraPakAuthConfigDelegate'), [IClientConfigProvider](TetraPak_AspNet_Auth_IClientConfigProvider.md 'TetraPak.AspNet.Auth.IClientConfigProvider')  
### Methods
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_GetClientSecretsAsync(TetraPak_AspNet_AuthContext)'></a>
## TetraPakAuthConfigDelegate.GetClientSecretsAsync(AuthContext) Method
Gets (confidential) client secrets (client id and, optionally, client secret).  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.Credentials>> GetClientSecretsAsync(TetraPak.AspNet.AuthContext authContext);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_GetClientSecretsAsync(TetraPak_AspNet_AuthContext)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetClientSecretsAsync(AuthContext)](TetraPak_AspNet_Auth_IClientConfigProvider.md#TetraPak_AspNet_Auth_IClientConfigProvider_GetClientSecretsAsync(TetraPak_AspNet_AuthContext) 'TetraPak.AspNet.Auth.IClientConfigProvider.GetClientSecretsAsync(TetraPak.AspNet.AuthContext)')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_GetScopeAsync(TetraPak_AspNet_AuthContext)'></a>
## TetraPakAuthConfigDelegate.GetScopeAsync(AuthContext) Method
Gets a scope to be used for the configured client.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> GetScopeAsync(TetraPak.AspNet.AuthContext authContext);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_GetScopeAsync(TetraPak_AspNet_AuthContext)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the scope is requested.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetScopeAsync(AuthContext)](TetraPak_AspNet_Auth_IClientConfigProvider.md#TetraPak_AspNet_Auth_IClientConfigProvider_GetScopeAsync(TetraPak_AspNet_AuthContext) 'TetraPak.AspNet.Auth.IClientConfigProvider.GetScopeAsync(TetraPak.AspNet.AuthContext)')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_OnGetClientSecretsAsync(TetraPak_AspNet_AuthContext)'></a>
## TetraPakAuthConfigDelegate.OnGetClientSecretsAsync(AuthContext) Method
Called to obtain the client secrets for a specified "path".   
```csharp
protected abstract System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.Credentials>> OnGetClientSecretsAsync(TetraPak.AspNet.AuthContext authContext);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfigDelegate_OnGetClientSecretsAsync(TetraPak_AspNet_AuthContext)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
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
(optional; default=`false`)<br />  
Specifies whether to automatically traverse the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') framework,  
looking for the requested value in configurations higher up in the hierarchy.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the requested value was found; otherwise `false`.  
            
  
