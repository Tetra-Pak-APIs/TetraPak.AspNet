#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ITetraPakAuthConfigDelegate Interface
Classes implementing this contract can be passed as a delegate to customize several aspects  
of Tetra Pak related configuration.   
```csharp
public interface ITetraPakAuthConfigDelegate :
TetraPak.AspNet.Auth.IClientConfigProvider
```

Derived  
&#8627; [TetraPakAuthConfigDelegate](TetraPak_AspNet_TetraPakAuthConfigDelegate.md 'TetraPak.AspNet.TetraPakAuthConfigDelegate')  

Implements [IClientConfigProvider](TetraPak_AspNet_Auth_IClientConfigProvider.md 'TetraPak.AspNet.Auth.IClientConfigProvider')  
### Methods
<a name='TetraPak_AspNet_ITetraPakAuthConfigDelegate_ResolveConfiguredEnvironment(string)'></a>
## ITetraPakAuthConfigDelegate.ResolveConfiguredEnvironment(string) Method
Called to resolve the configured (or null, when un-configured) runtime environment.  
```csharp
TetraPak.RuntimeEnvironment ResolveConfiguredEnvironment(string configuredValue);
```
#### Parameters
<a name='TetraPak_AspNet_ITetraPakAuthConfigDelegate_ResolveConfiguredEnvironment(string)_configuredValue'></a>
`configuredValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') representation of the configured value.
  
#### Returns
[TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment')  
A resolved [TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment') value.  
  
#### See Also
- [TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig')
