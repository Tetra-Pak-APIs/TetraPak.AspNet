#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## TetraPakApiConfigDelegate Class
Provides api-specific configuration support.     
```csharp
public class TetraPakApiConfigDelegate : TetraPak.AspNet.TetraPakConfigDelegate
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.AspNet.TetraPakConfigDelegate](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfigDelegate 'TetraPak.AspNet.TetraPakConfigDelegate') &#129106; TetraPakApiConfigDelegate  
### Methods
<a name='TetraPak_AspNet_Api_TetraPakApiConfigDelegate_OnGetClientCredentialsFromConfiguration(TetraPak_AspNet_Auth_GrantType)'></a>
## TetraPakApiConfigDelegate.OnGetClientCredentialsFromConfiguration(GrantType) Method
Changes how client credentials are fetched from configuration by first testing  
'ApiClientId' and 'ApiClientSecret' before falling back to the default keys  
('ClientId' and 'ClientSecret').   
```csharp
protected override System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.Credentials>> OnGetClientCredentialsFromConfiguration(TetraPak.AspNet.Auth.GrantType grantType);
```
#### Parameters
<a name='TetraPak_AspNet_Api_TetraPakApiConfigDelegate_OnGetClientCredentialsFromConfiguration(TetraPak_AspNet_Auth_GrantType)_grantType'></a>
`grantType` [TetraPak.AspNet.Auth.GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.GrantType 'TetraPak.AspNet.Auth.GrantType')  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
#### See Also
- [TetraPak.AspNet.TetraPakConfigDelegate.OnGetClientCredentialsAsync(TetraPak.AspNet.AuthContext)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfigDelegate.OnGetClientCredentialsAsync#TetraPak_AspNet_TetraPakConfigDelegate_OnGetClientCredentialsAsync_TetraPak_AspNet_AuthContext_ 'TetraPak.AspNet.TetraPakConfigDelegate.OnGetClientCredentialsAsync(TetraPak.AspNet.AuthContext)')
  
