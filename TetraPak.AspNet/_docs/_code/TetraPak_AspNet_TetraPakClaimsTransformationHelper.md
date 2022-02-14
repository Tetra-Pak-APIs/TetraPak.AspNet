#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakClaimsTransformationHelper Class
Provides convenience methods fo setting up claims transformation.  
```csharp
public static class TetraPakClaimsTransformationHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakClaimsTransformationHelper  
### Methods
<a name='TetraPak_AspNet_TetraPakClaimsTransformationHelper_AddTetraPakClaimsTransformation(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakClaimsTransformationHelper.AddTetraPakClaimsTransformation(IServiceCollection) Method
Sets up DI correctly for claims transformation.  
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakClaimsTransformation(this Microsoft.Extensions.DependencyInjection.IServiceCollection c);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakClaimsTransformationHelper_AddTetraPakClaimsTransformation(Microsoft_Extensions_DependencyInjection_IServiceCollection)_c'></a>
`c` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformationHelper_AddTetraPakCustomClaimsTransformation_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Nullable_TetraPak_AspNet_ServiceScope_)'></a>
## TetraPakClaimsTransformationHelper.AddTetraPakCustomClaimsTransformation&lt;T&gt;(IServiceCollection, Nullable&lt;ServiceScope&gt;) Method
Configures the claims transformation mechanism to include a custom Tetra Pak claims transformer.  
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakCustomClaimsTransformation<T>(this Microsoft.Extensions.DependencyInjection.IServiceCollection c, System.Nullable<TetraPak.AspNet.ServiceScope> serviceScope=null)
    where T : class, TetraPak.AspNet.ITetraPakClaimsTransformation;
```
#### Type parameters
<a name='TetraPak_AspNet_TetraPakClaimsTransformationHelper_AddTetraPakCustomClaimsTransformation_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Nullable_TetraPak_AspNet_ServiceScope_)_T'></a>
`T`  
The custom claims transformer [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') (must implement [ITetraPakClaimsTransformation](TetraPak_AspNet_ITetraPakClaimsTransformation.md 'TetraPak.AspNet.ITetraPakClaimsTransformation')).  
  
#### Parameters
<a name='TetraPak_AspNet_TetraPakClaimsTransformationHelper_AddTetraPakCustomClaimsTransformation_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Nullable_TetraPak_AspNet_ServiceScope_)_c'></a>
`c` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The service collection to be configured.  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformationHelper_AddTetraPakCustomClaimsTransformation_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Nullable_TetraPak_AspNet_ServiceScope_)_serviceScope'></a>
`serviceScope` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[ServiceScope](TetraPak_AspNet_ServiceScope.md 'TetraPak.AspNet.ServiceScope')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional; default [DefaultServiceScope](TetraPak_AspNet_TetraPakClaimsTransformation.md#TetraPak_AspNet_TetraPakClaimsTransformation_DefaultServiceScope 'TetraPak.AspNet.TetraPakClaimsTransformation.DefaultServiceScope'))<br/>  
The service scope to be used by the service locator.   
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The service collection.  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformationHelper_AddTetraPakUserInformation(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakClaimsTransformationHelper.AddTetraPakUserInformation(IServiceCollection) Method
Sets up DI for access to Tetra Pak's User Information services.  
```csharp
public static void AddTetraPakUserInformation(this Microsoft.Extensions.DependencyInjection.IServiceCollection c);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakClaimsTransformationHelper_AddTetraPakUserInformation(Microsoft_Extensions_DependencyInjection_IServiceCollection)_c'></a>
`c` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformationHelper_TryResolveClaim(System_Security_Claims_ClaimsPrincipal_string__string__)'></a>
## TetraPakClaimsTransformationHelper.TryResolveClaim(ClaimsPrincipal, string?, string[]) Method
Looks up a specified [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') claim and returns the outcome.   
```csharp
public static bool TryResolveClaim(this System.Security.Claims.ClaimsPrincipal self, out string? claimType, params string[] fallbackClaimTypes);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakClaimsTransformationHelper_TryResolveClaim(System_Security_Claims_ClaimsPrincipal_string__string__)_self'></a>
`self` [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal')  
The [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') carrying the requested claim.  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformationHelper_TryResolveClaim(System_Security_Claims_ClaimsPrincipal_string__string__)_claimType'></a>
`claimType` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The requested claim type.  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformationHelper_TryResolveClaim(System_Security_Claims_ClaimsPrincipal_string__string__)_fallbackClaimTypes'></a>
`fallbackClaimTypes` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
(optional)<br/>  
One or more claim types to be looked for if [claimType](TetraPak_AspNet_TetraPakClaimsTransformationHelper.md#TetraPak_AspNet_TetraPakClaimsTransformationHelper_TryResolveClaim(System_Security_Claims_ClaimsPrincipal_string__string__)_claimType 'TetraPak.AspNet.TetraPakClaimsTransformationHelper.TryResolveClaim(System.Security.Claims.ClaimsPrincipal, string?, string[]).claimType') cannot be found.   
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the requested [claimType](TetraPak_AspNet_TetraPakClaimsTransformationHelper.md#TetraPak_AspNet_TetraPakClaimsTransformationHelper_TryResolveClaim(System_Security_Claims_ClaimsPrincipal_string__string__)_claimType 'TetraPak.AspNet.TetraPakClaimsTransformationHelper.TryResolveClaim(System.Security.Claims.ClaimsPrincipal, string?, string[]).claimType')  
              (or any [fallbackClaimTypes](TetraPak_AspNet_TetraPakClaimsTransformationHelper.md#TetraPak_AspNet_TetraPakClaimsTransformationHelper_TryResolveClaim(System_Security_Claims_ClaimsPrincipal_string__string__)_fallbackClaimTypes 'TetraPak.AspNet.TetraPakClaimsTransformationHelper.TryResolveClaim(System.Security.Claims.ClaimsPrincipal, string?, string[]).fallbackClaimTypes')) was found; otherwise `false`.   
            
  
