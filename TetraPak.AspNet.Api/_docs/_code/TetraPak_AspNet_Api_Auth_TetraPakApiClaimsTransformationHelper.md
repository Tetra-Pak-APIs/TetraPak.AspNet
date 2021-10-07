#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TetraPakApiClaimsTransformationHelper Class
Provides convenience methods fo setting up claims transformation.  
```csharp
public static class TetraPakApiClaimsTransformationHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakApiClaimsTransformationHelper  
### Methods
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiClaimsTransformationHelper_AddTetraPakApiClaimsTransformation(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakApiClaimsTransformationHelper.AddTetraPakApiClaimsTransformation(IServiceCollection) Method
Sets up DI correctly for API claims transformation.  
```csharp
public static void AddTetraPakApiClaimsTransformation(this Microsoft.Extensions.DependencyInjection.IServiceCollection c);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiClaimsTransformationHelper_AddTetraPakApiClaimsTransformation(Microsoft_Extensions_DependencyInjection_IServiceCollection)_c'></a>
`c` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
### Remarks
The difference between claims transformation in an API is that token exchange services  
must be available for fetching identity from a user information endpoint  
(when [TetraPak.AspNet.TetraPakConfig.IdentitySource](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig.IdentitySource 'TetraPak.AspNet.TetraPakConfig.IdentitySource') = [TetraPak.AspNet.Auth.TetraPakIdentitySource.RemoteService](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.TetraPakIdentitySource.RemoteService 'TetraPak.AspNet.Auth.TetraPakIdentitySource.RemoteService')).  
  
