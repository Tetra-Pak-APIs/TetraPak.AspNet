#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakClaimsTransformation Class
Add this class to the DI configuration to automatically provide a Tetra Pak identity to any request.  
The class constructor also needs [AmbientData](TetraPak_AspNet_TetraPakClaimsTransformation_AmbientData.md 'TetraPak.AspNet.TetraPakClaimsTransformation.AmbientData') and   
Please note that this is automatically done by calling [TetraPak.AspNet.Auth.TetraPakAuth.AddTetraPakWebClientAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.TetraPakAuth.AddTetraPakWebClientAuthentication#TetraPak_AspNet_Auth_TetraPakAuth_AddTetraPakWebClientAuthentication_Microsoft_Extensions_DependencyInjection_IServiceCollection_ 'TetraPak.AspNet.Auth.TetraPakAuth.AddTetraPakWebClientAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection)').  
```csharp
public class TetraPakClaimsTransformation :
Microsoft.AspNetCore.Authentication.IClaimsTransformation
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakClaimsTransformation  

Implements [Microsoft.AspNetCore.Authentication.IClaimsTransformation](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Authentication.IClaimsTransformation 'Microsoft.AspNetCore.Authentication.IClaimsTransformation')  
### Example
```csharp
public void ConfigureServices(IServiceCollection services)  
{  
    :  
    services.AddTetraPakWebClientClaimsTransformation();  
    :  
}  
```

| Constructors | |
| :--- | :--- |
| [TetraPakClaimsTransformation(AmbientData, TetraPakUserInformation, IHttpContextAccessor, IClientCredentialsProvider)](TetraPak_AspNet_TetraPakClaimsTransformation_TetraPakClaimsTransformation(TetraPak_AspNet_AmbientData_TetraPak_AspNet_Identity_TetraPakUserInformation_Microsoft_AspNetCore_Http_IHttpContextAccessor_TetraPak_AspNet_Auth_IClientCredentialsProvider).md 'TetraPak.AspNet.TetraPakClaimsTransformation.TetraPakClaimsTransformation(TetraPak.AspNet.AmbientData, TetraPak.AspNet.Identity.TetraPakUserInformation, Microsoft.AspNetCore.Http.IHttpContextAccessor, TetraPak.AspNet.Auth.IClientCredentialsProvider)') | Initializes the [TetraPakClaimsTransformation](TetraPak_AspNet_TetraPakClaimsTransformation.md 'TetraPak.AspNet.TetraPakClaimsTransformation') instance.<br/> |

| Properties | |
| :--- | :--- |
| [AmbientData](TetraPak_AspNet_TetraPakClaimsTransformation_AmbientData.md 'TetraPak.AspNet.TetraPakClaimsTransformation.AmbientData') | Gets an ambient data provider.<br/> |
| [AuthConfig](TetraPak_AspNet_TetraPakClaimsTransformation_AuthConfig.md 'TetraPak.AspNet.TetraPakClaimsTransformation.AuthConfig') | Gets the Tetra Pak configuration object. <br/> |
| [HttpContext](TetraPak_AspNet_TetraPakClaimsTransformation_HttpContext.md 'TetraPak.AspNet.TetraPakClaimsTransformation.HttpContext') | Gets the current [HttpContext](TetraPak_AspNet_TetraPakClaimsTransformation_HttpContext.md 'TetraPak.AspNet.TetraPakClaimsTransformation.HttpContext') instance.<br/> |
| [Logger](TetraPak_AspNet_TetraPakClaimsTransformation_Logger.md 'TetraPak.AspNet.TetraPakClaimsTransformation.Logger') | Gets a logger provider.<br/> |

| Methods | |
| :--- | :--- |
| [OnGetAccessTokenAsync(CancellationToken)](TetraPak_AspNet_TetraPakClaimsTransformation_OnGetAccessTokenAsync(System_Threading_CancellationToken).md 'TetraPak.AspNet.TetraPakClaimsTransformation.OnGetAccessTokenAsync(System.Threading.CancellationToken)') | Invoked from [TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync(System.Security.Claims.ClaimsPrincipal)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync#TetraPak_AspNet_TetraPakClaimsTransformation_TransformAsync_System_Security_Claims_ClaimsPrincipal_ 'TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync(System.Security.Claims.ClaimsPrincipal)') to acquire an access token.<br/> |
| [OnGetClientCredentials()](TetraPak_AspNet_TetraPakClaimsTransformation_OnGetClientCredentials().md 'TetraPak.AspNet.TetraPakClaimsTransformation.OnGetClientCredentials()') | Call this method to obtain client credentials.<br/> |
| [OnGetIdTokenAsync(CancellationToken)](TetraPak_AspNet_TetraPakClaimsTransformation_OnGetIdTokenAsync(System_Threading_CancellationToken).md 'TetraPak.AspNet.TetraPakClaimsTransformation.OnGetIdTokenAsync(System.Threading.CancellationToken)') | Invoked from [TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync(System.Security.Claims.ClaimsPrincipal)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync#TetraPak_AspNet_TetraPakClaimsTransformation_TransformAsync_System_Security_Claims_ClaimsPrincipal_ 'TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync(System.Security.Claims.ClaimsPrincipal)') to acquire an identity token.<br/> |
