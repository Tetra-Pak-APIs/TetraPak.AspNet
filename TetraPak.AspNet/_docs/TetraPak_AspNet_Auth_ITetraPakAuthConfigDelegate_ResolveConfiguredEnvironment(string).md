#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth').[ITetraPakAuthConfigDelegate](TetraPak_AspNet_Auth_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.Auth.ITetraPakAuthConfigDelegate')
## ITetraPakAuthConfigDelegate.ResolveConfiguredEnvironment(string) Method
Called to resolve the configured (or null, when un-configured) runtime environment.  
```csharp
TetraPak.RuntimeEnvironment ResolveConfiguredEnvironment(string stringValue);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_ITetraPakAuthConfigDelegate_ResolveConfiguredEnvironment(string)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') representation of the configured value.
  
#### Returns
[TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment')  
A resolved [TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment') value.  
