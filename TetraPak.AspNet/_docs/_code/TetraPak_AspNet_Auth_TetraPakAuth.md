#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## TetraPakAuth Class
Provides convenience- and extension methods to help with integrating an ASP.NET Core/5+  
web application with the Tetra Pak Auth Services.  
```csharp
public static class TetraPakAuth
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakAuth  
### Methods
<a name='TetraPak_AspNet_Auth_TetraPakAuth_AddTetraPakOidcAuthentication_TCache_(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakAuth.AddTetraPakOidcAuthentication&lt;TCache&gt;(IServiceCollection) Method
Adds and configures middleware to integrate with Tetra Pak Auth Services using the  
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
  
  
<a name='TetraPak_AspNet_Auth_TetraPakAuth_AddTetraPakOidcAuthentication(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakAuth.AddTetraPakOidcAuthentication(IServiceCollection) Method
Adds the necessary middleware to integrate with Tetra Pak Auth Services using the  
Open Id Connection (OIDC) auth flow.  
```csharp
public static void AddTetraPakOidcAuthentication(this Microsoft.Extensions.DependencyInjection.IServiceCollection services);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_TetraPakAuth_AddTetraPakOidcAuthentication(Microsoft_Extensions_DependencyInjection_IServiceCollection)_services'></a>
`services` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
An object implementing [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') (can be unassigned).   
  
  
<a name='TetraPak_AspNet_Auth_TetraPakAuth_UseTetraPakAuthentication(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment)'></a>
## TetraPakAuth.UseTetraPakAuthentication(IApplicationBuilder, IWebHostEnvironment) Method
Configures Tetra Pak specific auth behavior.  
```csharp
public static void UseTetraPakAuthentication(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_TetraPakAuth_UseTetraPakAuthentication(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The application builder object.  
  
<a name='TetraPak_AspNet_Auth_TetraPakAuth_UseTetraPakAuthentication(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment)_env'></a>
`env` [Microsoft.AspNetCore.Hosting.IWebHostEnvironment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Hosting.IWebHostEnvironment 'Microsoft.AspNetCore.Hosting.IWebHostEnvironment')  
Provides information about the hosting environment.   
  
  
