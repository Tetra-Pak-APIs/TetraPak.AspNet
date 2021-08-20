#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth').[TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')
## TetraPakAuthConfig.OnResolveRuntimeEnvironment(string, ITetraPakAuthConfigDelegate) Method
Invoked from ctor to resolve the runtime environment.  
```csharp
protected virtual TetraPak.RuntimeEnvironment OnResolveRuntimeEnvironment(string configuredStringValue, TetraPak.AspNet.Auth.ITetraPakAuthConfigDelegate configDelegate);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_TetraPakAuthConfig_OnResolveRuntimeEnvironment(string_TetraPak_AspNet_Auth_ITetraPakAuthConfigDelegate)_configuredStringValue'></a>
`configuredStringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The configured [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value to be resolved.  
  
<a name='TetraPak_AspNet_Auth_TetraPakAuthConfig_OnResolveRuntimeEnvironment(string_TetraPak_AspNet_Auth_ITetraPakAuthConfigDelegate)_configDelegate'></a>
`configDelegate` [ITetraPakAuthConfigDelegate](TetraPak_AspNet_Auth_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.Auth.ITetraPakAuthConfigDelegate')  
(optional)<br />  
A custom delegate to be allowed to affect the result.  
  
#### Returns
[TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment')  
A resolved [TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment') value.  
