#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakClaimsTransformation Class
Add this class to the DI configuration to automatically provide a Tetra Pak identity to any request.  
The class constructor also needs [AmbientData](TetraPak_AspNet_TetraPakClaimsTransformation.md#TetraPak_AspNet_TetraPakClaimsTransformation_AmbientData 'TetraPak.AspNet.TetraPakClaimsTransformation.AmbientData') and   
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
### Constructors
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_TetraPakClaimsTransformation(TetraPak_AspNet_Identity_TetraPakUserInformation_TetraPak_AspNet_Auth_IClientCredentialsProvider_TetraPak_Caching_ITimeLimitedRepositories)'></a>
## TetraPakClaimsTransformation.TetraPakClaimsTransformation(TetraPakUserInformation, IClientCredentialsProvider, ITimeLimitedRepositories) Constructor
Initializes the [TetraPakClaimsTransformation](TetraPak_AspNet_TetraPakClaimsTransformation.md 'TetraPak.AspNet.TetraPakClaimsTransformation') instance.  
```csharp
public TetraPakClaimsTransformation(TetraPak.AspNet.Identity.TetraPakUserInformation userInformation, TetraPak.AspNet.Auth.IClientCredentialsProvider clientCredentialsProvider=null, TetraPak.Caching.ITimeLimitedRepositories cache=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_TetraPakClaimsTransformation(TetraPak_AspNet_Identity_TetraPakUserInformation_TetraPak_AspNet_Auth_IClientCredentialsProvider_TetraPak_Caching_ITimeLimitedRepositories)_userInformation'></a>
`userInformation` [TetraPakUserInformation](TetraPak_AspNet_Identity_TetraPakUserInformation.md 'TetraPak.AspNet.Identity.TetraPakUserInformation')  
Used internally to obtain user information.  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_TetraPakClaimsTransformation(TetraPak_AspNet_Identity_TetraPakUserInformation_TetraPak_AspNet_Auth_IClientCredentialsProvider_TetraPak_Caching_ITimeLimitedRepositories)_clientCredentialsProvider'></a>
`clientCredentialsProvider` [IClientCredentialsProvider](TetraPak_AspNet_Auth_IClientCredentialsProvider.md 'TetraPak.AspNet.Auth.IClientCredentialsProvider')  
(optional)<br/>  
Used internally to obtain client credentials.  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_TetraPakClaimsTransformation(TetraPak_AspNet_Identity_TetraPakUserInformation_TetraPak_AspNet_Auth_IClientCredentialsProvider_TetraPak_Caching_ITimeLimitedRepositories)_cache'></a>
`cache` [TetraPak.Caching.ITimeLimitedRepositories](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Caching.ITimeLimitedRepositories 'TetraPak.Caching.ITimeLimitedRepositories')  
(optional)<br/>  
Used internally to cache already resolved claims principals.     
  
  
### Properties
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_AmbientData'></a>
## TetraPakClaimsTransformation.AmbientData Property
Gets an ambient data provider.  
```csharp
protected TetraPak.AspNet.AmbientData AmbientData { get; }
```
#### Property Value
[AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_AuthConfig'></a>
## TetraPakClaimsTransformation.AuthConfig Property
Gets the Tetra Pak configuration object.   
```csharp
protected TetraPak.AspNet.TetraPakAuthConfig AuthConfig { get; }
```
#### Property Value
[TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig')
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_HttpContext'></a>
## TetraPakClaimsTransformation.HttpContext Property
Gets the current [HttpContext](TetraPak_AspNet_TetraPakClaimsTransformation.md#TetraPak_AspNet_TetraPakClaimsTransformation_HttpContext 'TetraPak.AspNet.TetraPakClaimsTransformation.HttpContext') instance.  
```csharp
protected Microsoft.AspNetCore.Http.HttpContext HttpContext { get; }
```
#### Property Value
[Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_Logger'></a>
## TetraPakClaimsTransformation.Logger Property
Gets a logger provider.  
```csharp
protected Microsoft.Extensions.Logging.ILogger Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
### Methods
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_OnGetAccessTokenAsync(System_Threading_CancellationToken)'></a>
## TetraPakClaimsTransformation.OnGetAccessTokenAsync(CancellationToken) Method
Invoked from [TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync(System.Security.Claims.ClaimsPrincipal)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync#TetraPak_AspNet_TetraPakClaimsTransformation_TransformAsync_System_Security_Claims_ClaimsPrincipal_ 'TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync(System.Security.Claims.ClaimsPrincipal)') to acquire an access token.  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> OnGetAccessTokenAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_OnGetAccessTokenAsync(System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') object used to allow operation cancellation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_OnGetClientCredentials()'></a>
## TetraPakClaimsTransformation.OnGetClientCredentials() Method
Call this method to obtain client credentials.  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.Credentials>> OnGetClientCredentials();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials') object or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_OnGetIdTokenAsync(System_Threading_CancellationToken)'></a>
## TetraPakClaimsTransformation.OnGetIdTokenAsync(CancellationToken) Method
Invoked from [TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync(System.Security.Claims.ClaimsPrincipal)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync#TetraPak_AspNet_TetraPakClaimsTransformation_TransformAsync_System_Security_Claims_ClaimsPrincipal_ 'TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync(System.Security.Claims.ClaimsPrincipal)') to acquire an identity token.  
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
  
