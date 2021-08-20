#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth').[TetraPakAuth](TetraPak_AspNet_Auth_TetraPakAuth.md 'TetraPak.AspNet.Auth.TetraPakAuth')
## TetraPakAuth.AddTetraPakOidcAuthentication&lt;TCache&gt;(IServiceCollection) Method
Adds the necessary middleware to integrate with Tetra Pak Auth Services using the  
Open Id Connection (OIDC) auth flow.  
```csharp
public static void AddTetraPakOidcAuthentication<TCache>(this Microsoft.Extensions.DependencyInjection.IServiceCollection services)
    where TCache : class, TetraPak.Caching.ITimeLimitedRepositories;
```
#### Type parameters
<a name='TetraPak_AspNet_Auth_TetraPakAuth_AddTetraPakOidcAuthentication_TCache_(Microsoft_Extensions_DependencyInjection_IServiceCollection)_TCache'></a>
`TCache`  
Specifies class to be used for OIDC related caching purposes.   
  
#### Parameters
<a name='TetraPak_AspNet_Auth_TetraPakAuth_AddTetraPakOidcAuthentication_TCache_(Microsoft_Extensions_DependencyInjection_IServiceCollection)_services'></a>
`services` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
An object implementing [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') (can be unassigned).   
  
