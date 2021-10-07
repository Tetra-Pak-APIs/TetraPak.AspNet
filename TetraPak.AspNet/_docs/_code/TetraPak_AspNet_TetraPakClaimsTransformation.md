#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakClaimsTransformation Class
A basic (abstract) implementation of the [ITetraPakClaimsTransformation](TetraPak_AspNet_ITetraPakClaimsTransformation.md 'TetraPak.AspNet.ITetraPakClaimsTransformation') interface.  
```csharp
public abstract class TetraPakClaimsTransformation :
TetraPak.AspNet.ITetraPakClaimsTransformation
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakClaimsTransformation  

Derived  
&#8627; [TetraPakJwtClaimsTransformation](TetraPak_AspNet_TetraPakJwtClaimsTransformation.md 'TetraPak.AspNet.TetraPakJwtClaimsTransformation')  

Implements [ITetraPakClaimsTransformation](TetraPak_AspNet_ITetraPakClaimsTransformation.md 'TetraPak.AspNet.ITetraPakClaimsTransformation')  
### Properties
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_Cache'></a>
## TetraPakClaimsTransformation.Cache Property
Gets the supported cache service (if any).   
```csharp
protected TetraPak.Caching.ITimeLimitedRepositories? Cache { get; }
```
#### Property Value
[TetraPak.Caching.ITimeLimitedRepositories](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Caching.ITimeLimitedRepositories 'TetraPak.Caching.ITimeLimitedRepositories')
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_ClientCredentials'></a>
## TetraPakClaimsTransformation.ClientCredentials Property
Gets a Tetra Client Credentials flow service.    
```csharp
protected TetraPak.AspNet.Auth.IClientCredentialsProvider? ClientCredentials { get; set; }
```
#### Property Value
[IClientCredentialsProvider](TetraPak_AspNet_Auth_IClientCredentialsProvider.md 'TetraPak.AspNet.Auth.IClientCredentialsProvider')
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_Context'></a>
## TetraPakClaimsTransformation.Context Property
Gets the current HTTP context.  
```csharp
protected Microsoft.AspNetCore.Http.HttpContext? Context { get; set; }
```
#### Property Value
[Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_DefaultServiceScope'></a>
## TetraPakClaimsTransformation.DefaultServiceScope Property
Gets or sets the global (static) default service scope to be used for all  
[ITetraPakClaimsTransformation](TetraPak_AspNet_ITetraPakClaimsTransformation.md 'TetraPak.AspNet.ITetraPakClaimsTransformation') delegates as they are being registered  
with the dependency injection service locator.  
```csharp
public static TetraPak.AspNet.ServiceScope DefaultServiceScope { get; set; }
```
#### Property Value
[ServiceScope](TetraPak_AspNet_ServiceScope.md 'TetraPak.AspNet.ServiceScope')
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_IdentitySource'></a>
## TetraPakClaimsTransformation.IdentitySource Property
Gets the configured identity source (see: [TetraPakIdentitySource](TetraPak_AspNet_Auth_TetraPakIdentitySource.md 'TetraPak.AspNet.Auth.TetraPakIdentitySource')).  
```csharp
protected TetraPak.AspNet.Auth.TetraPakIdentitySource IdentitySource { get; set; }
```
#### Property Value
[TetraPakIdentitySource](TetraPak_AspNet_Auth_TetraPakIdentitySource.md 'TetraPak.AspNet.Auth.TetraPakIdentitySource')
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_Logger'></a>
## TetraPakClaimsTransformation.Logger Property
Gets a logger provider.  
```csharp
protected Microsoft.Extensions.Logging.ILogger? Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_TetraPakConfig'></a>
## TetraPakClaimsTransformation.TetraPakConfig Property
Gets the Tetra Pak configuration object.   
```csharp
protected TetraPak.AspNet.TetraPakConfig? TetraPakConfig { get; set; }
```
#### Property Value
[TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_UserInformation'></a>
## TetraPakClaimsTransformation.UserInformation Property
Gets a Tetra Pak User Information service.   
```csharp
protected TetraPak.AspNet.Identity.TetraPakUserInformation? UserInformation { get; set; }
```
#### Property Value
[TetraPakUserInformation](TetraPak_AspNet_Identity_TetraPakUserInformation.md 'TetraPak.AspNet.Identity.TetraPakUserInformation')
  
### Methods
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_GetClientCredentials()'></a>
## TetraPakClaimsTransformation.GetClientCredentials() Method
Obtains and returns the client credentials, either from the Tetra Pak integration configuration  
([TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig') or from an injected delegate ([IClientCredentialsProvider](TetraPak_AspNet_Auth_IClientCredentialsProvider.md 'TetraPak.AspNet.Auth.IClientCredentialsProvider')).  
```csharp
protected System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.Credentials>> GetClientCredentials();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials') object or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_OnGetIdTokenAsync(System_Threading_CancellationToken)'></a>
## TetraPakClaimsTransformation.OnGetIdTokenAsync(CancellationToken) Method
Invoked from [OnTransformAsync(ClaimsPrincipal)](TetraPak_AspNet_TetraPakClaimsTransformation.md#TetraPak_AspNet_TetraPakClaimsTransformation_OnTransformAsync(System_Security_Claims_ClaimsPrincipal) 'TetraPak.AspNet.TetraPakClaimsTransformation.OnTransformAsync(System.Security.Claims.ClaimsPrincipal)') to acquire an identity token.  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> OnGetIdTokenAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_OnGetIdTokenAsync(System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') object used to allow operation cancellation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_OnTransformAsync(System_Security_Claims_ClaimsPrincipal)'></a>
## TetraPakClaimsTransformation.OnTransformAsync(ClaimsPrincipal) Method
(Must be overridden)<br/>  
Invoked, internally, to decorate the context [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal').  
Please note that the [principal](TetraPak_AspNet_TetraPakClaimsTransformation.md#TetraPak_AspNet_TetraPakClaimsTransformation_OnTransformAsync(System_Security_Claims_ClaimsPrincipal)_principal 'TetraPak.AspNet.TetraPakClaimsTransformation.OnTransformAsync(System.Security.Claims.ClaimsPrincipal).principal') is a cloned instance of the  
[System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') attached to [Context](TetraPak_AspNet_TetraPakClaimsTransformation.md#TetraPak_AspNet_TetraPakClaimsTransformation_Context 'TetraPak.AspNet.TetraPakClaimsTransformation.Context').  
```csharp
protected abstract System.Threading.Tasks.Task<System.Security.Claims.ClaimsPrincipal> OnTransformAsync(System.Security.Claims.ClaimsPrincipal principal);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_OnTransformAsync(System_Security_Claims_ClaimsPrincipal)_principal'></a>
`principal` [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal')  
The (incoming) [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') object.  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_TransformAsync(System_Security_Claims_ClaimsPrincipal)'></a>
## TetraPakClaimsTransformation.TransformAsync(ClaimsPrincipal) Method
Provides a central transformation point to change the specified principal.   
```csharp
public System.Threading.Tasks.Task<System.Security.Claims.ClaimsPrincipal> TransformAsync(System.Security.Claims.ClaimsPrincipal principal);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_TransformAsync(System_Security_Claims_ClaimsPrincipal)_principal'></a>
`principal` [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal')  
The [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') to transform.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The transformed principal.  

Implements [TransformAsync(ClaimsPrincipal)](TetraPak_AspNet_ITetraPakClaimsTransformation.md#TetraPak_AspNet_ITetraPakClaimsTransformation_TransformAsync(System_Security_Claims_ClaimsPrincipal) 'TetraPak.AspNet.ITetraPakClaimsTransformation.TransformAsync(System.Security.Claims.ClaimsPrincipal)')  
  
