#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakJwtClaimsTransformation Class
Add this class to the DI configuration to automatically provide a Tetra Pak identity to any request.  
The class constructor also needs [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData') and   
Please note that this is automatically done by calling [TetraPak.AspNet.Auth.TetraPakAuth.AddTetraPakWebClientAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.TetraPakAuth.AddTetraPakWebClientAuthentication#TetraPak_AspNet_Auth_TetraPakAuth_AddTetraPakWebClientAuthentication_Microsoft_Extensions_DependencyInjection_IServiceCollection_ 'TetraPak.AspNet.Auth.TetraPakAuth.AddTetraPakWebClientAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection)').  
```csharp
public class TetraPakJwtClaimsTransformation : TetraPak.AspNet.TetraPakClaimsTransformation
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPakClaimsTransformation](TetraPak_AspNet_TetraPakClaimsTransformation.md 'TetraPak.AspNet.TetraPakClaimsTransformation') &#129106; TetraPakJwtClaimsTransformation  
### Example
```csharp
public void ConfigureServices(IServiceCollection services)
{
    :
    services.AddTetraPakWebClientClaimsTransformation();
    :
}
```
### Methods
<a name='TetraPak_AspNet_TetraPakJwtClaimsTransformation_OnGetAccessTokenAsync(System_Threading_CancellationToken)'></a>
## TetraPakJwtClaimsTransformation.OnGetAccessTokenAsync(CancellationToken) Method
Can be invoked to acquire an access token from the [Context](TetraPak_AspNet_TetraPakClaimsTransformation.md#TetraPak_AspNet_TetraPakClaimsTransformation_Context 'TetraPak.AspNet.TetraPakClaimsTransformation.Context').  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> OnGetAccessTokenAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakJwtClaimsTransformation_OnGetAccessTokenAsync(System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') object used to allow operation cancellation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_TetraPakJwtClaimsTransformation_OnTransformAsync(System_Security_Claims_ClaimsPrincipal)'></a>
## TetraPakJwtClaimsTransformation.OnTransformAsync(ClaimsPrincipal) Method
(Must be overridden)<br/>  
Invoked, internally, to decorate the context [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal').  
Please note that the [principal](TetraPak_AspNet_TetraPakJwtClaimsTransformation.md#TetraPak_AspNet_TetraPakJwtClaimsTransformation_OnTransformAsync(System_Security_Claims_ClaimsPrincipal)_principal 'TetraPak.AspNet.TetraPakJwtClaimsTransformation.OnTransformAsync(System.Security.Claims.ClaimsPrincipal).principal') is a cloned instance of the  
[System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') attached to [Context](TetraPak_AspNet_TetraPakClaimsTransformation.md#TetraPak_AspNet_TetraPakClaimsTransformation_Context 'TetraPak.AspNet.TetraPakClaimsTransformation.Context').  
```csharp
protected override System.Threading.Tasks.Task<System.Security.Claims.ClaimsPrincipal> OnTransformAsync(System.Security.Claims.ClaimsPrincipal principal);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakJwtClaimsTransformation_OnTransformAsync(System_Security_Claims_ClaimsPrincipal)_principal'></a>
`principal` [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal')  
The (incoming) [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') object.  
  
