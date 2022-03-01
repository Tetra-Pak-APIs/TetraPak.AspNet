#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TetraPakTokenExchangeHelper Class
Provides convenient methods for working with OAuth grant flows.   
```csharp
public static class TetraPakTokenExchangeHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakTokenExchangeHelper  
### Methods
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeHelper_AddTetraPakClientCredentialsService(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakTokenExchangeHelper.AddTetraPakClientCredentialsService(IServiceCollection) Method
(fluent api)<br/>  
Adds a Tetra Pak service to support the OAuth Client Credentials Grant flow  
to the service collection and then returns the service collection.  
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakClientCredentialsService(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeHelper_AddTetraPakClientCredentialsService(Microsoft_Extensions_DependencyInjection_IServiceCollection)_collection'></a>
`collection` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeHelper_AddTetraPakTokenExchangeService(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakTokenExchangeHelper.AddTetraPakTokenExchangeService(IServiceCollection) Method
(fluent api)<br/>  
Adds a Tetra Pak service to support the OAuth Token Exchange Grant flow  
to the service collection and then returns the service collection.  
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakTokenExchangeService(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeHelper_AddTetraPakTokenExchangeService(Microsoft_Extensions_DependencyInjection_IServiceCollection)_collection'></a>
`collection` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeHelper_GetLifespan(TetraPak_AspNet_Api_Auth_TokenExchangeResponse)'></a>
## TetraPakTokenExchangeHelper.GetLifespan(TokenExchangeResponse) Method
Parses and returns the [ExpiresIn](TetraPak_AspNet_Api_Auth_TokenExchangeResponse.md#TetraPak_AspNet_Api_Auth_TokenExchangeResponse_ExpiresIn 'TetraPak.AspNet.Api.Auth.TokenExchangeResponse.ExpiresIn') value  
as a [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan') value.  
```csharp
public static System.Nullable<System.TimeSpan> GetLifespan(this TetraPak.AspNet.Api.Auth.TokenExchangeResponse self);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeHelper_GetLifespan(TetraPak_AspNet_Api_Auth_TokenExchangeResponse)_self'></a>
`self` [TokenExchangeResponse](TetraPak_AspNet_Api_Auth_TokenExchangeResponse.md 'TetraPak.AspNet.Api.Auth.TokenExchangeResponse')  
  
#### Returns
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
  
