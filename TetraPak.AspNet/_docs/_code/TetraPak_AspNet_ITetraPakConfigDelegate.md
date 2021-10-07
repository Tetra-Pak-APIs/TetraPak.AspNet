#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ITetraPakConfigDelegate Interface
Classes implementing this contract can be passed as a delegate to customize several aspects  
of Tetra Pak related configuration.   
```csharp
public interface ITetraPakConfigDelegate :
TetraPak.AspNet.Auth.IClientConfigDelegate
```

Derived  
&#8627; [TetraPakConfigDelegate](TetraPak_AspNet_TetraPakConfigDelegate.md 'TetraPak.AspNet.TetraPakConfigDelegate')  

Implements [IClientConfigDelegate](TetraPak_AspNet_Auth_IClientConfigDelegate.md 'TetraPak.AspNet.Auth.IClientConfigDelegate')  
### Methods
<a name='TetraPak_AspNet_ITetraPakConfigDelegate_ResolveConfiguredEnvironment(string)'></a>
## ITetraPakConfigDelegate.ResolveConfiguredEnvironment(string) Method
Called to resolve the configured (or null, when un-configured) runtime environment.  
```csharp
TetraPak.RuntimeEnvironment ResolveConfiguredEnvironment(string configuredValue);
```
#### Parameters
<a name='TetraPak_AspNet_ITetraPakConfigDelegate_ResolveConfiguredEnvironment(string)_configuredValue'></a>
`configuredValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') representation of the configured value.
  
#### Returns
[TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment')  
A resolved [TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment') value.  
  
#### See Also
- [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')
