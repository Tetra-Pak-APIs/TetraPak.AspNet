#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TetraPakApiClaimsTransformation Class
Performs automatic claims transformation but ensures the access token used to  
call the user information service gets exchanged (necessary for APIs).  
(See [TetraPak.AspNet.TetraPakClaimsTransformation](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakClaimsTransformation 'TetraPak.AspNet.TetraPakClaimsTransformation') for more details).  
```csharp
public class TetraPakApiClaimsTransformation : TetraPak.AspNet.TetraPakClaimsTransformation
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.AspNet.TetraPakClaimsTransformation](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakClaimsTransformation 'TetraPak.AspNet.TetraPakClaimsTransformation') &#129106; TetraPakApiClaimsTransformation  
### Example
```csharp
public void ConfigureServices(IServiceCollection services)  
{  
    :  
    services.AddTetraPakWebApiClaimsTransformation();  
    :  
}  
```
### Constructors
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiClaimsTransformation_TetraPakApiClaimsTransformation(TetraPak_AspNet_Identity_TetraPakUserInformation_TetraPak_AspNet_Api_Auth_ITokenExchangeService_TetraPak_AspNet_Auth_IClientCredentialsProvider)'></a>
## TetraPakApiClaimsTransformation.TetraPakApiClaimsTransformation(TetraPakUserInformation, ITokenExchangeService, IClientCredentialsProvider) Constructor
Initializes the [TetraPakApiClaimsTransformation](TetraPak_AspNet_Api_Auth_TetraPakApiClaimsTransformation.md 'TetraPak.AspNet.Api.Auth.TetraPakApiClaimsTransformation') instance.  
```csharp
public TetraPakApiClaimsTransformation(TetraPak.AspNet.Identity.TetraPakUserInformation userInformation, TetraPak.AspNet.Api.Auth.ITokenExchangeService tokenExchangeService, TetraPak.AspNet.Auth.IClientCredentialsProvider clientCredentialsProvider=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiClaimsTransformation_TetraPakApiClaimsTransformation(TetraPak_AspNet_Identity_TetraPakUserInformation_TetraPak_AspNet_Api_Auth_ITokenExchangeService_TetraPak_AspNet_Auth_IClientCredentialsProvider)_userInformation'></a>
`userInformation` [TetraPak.AspNet.Identity.TetraPakUserInformation](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Identity.TetraPakUserInformation 'TetraPak.AspNet.Identity.TetraPakUserInformation')  
Used internally to obtain user information.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiClaimsTransformation_TetraPakApiClaimsTransformation(TetraPak_AspNet_Identity_TetraPakUserInformation_TetraPak_AspNet_Api_Auth_ITokenExchangeService_TetraPak_AspNet_Auth_IClientCredentialsProvider)_tokenExchangeService'></a>
`tokenExchangeService` [ITokenExchangeService](TetraPak_AspNet_Api_Auth_ITokenExchangeService.md 'TetraPak.AspNet.Api.Auth.ITokenExchangeService')  
User internally to support the token exchange auth flow,  
which is necessary when consuming user information from the Tetra Pak Auth Services.   
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiClaimsTransformation_TetraPakApiClaimsTransformation(TetraPak_AspNet_Identity_TetraPakUserInformation_TetraPak_AspNet_Api_Auth_ITokenExchangeService_TetraPak_AspNet_Auth_IClientCredentialsProvider)_clientCredentialsProvider'></a>
`clientCredentialsProvider` [TetraPak.AspNet.Auth.IClientCredentialsProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IClientCredentialsProvider 'TetraPak.AspNet.Auth.IClientCredentialsProvider')  
Used internally to obtain client credentials.  
  
  
### Methods
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiClaimsTransformation_OnGetAccessTokenAsync(System_Threading_CancellationToken)'></a>
## TetraPakApiClaimsTransformation.OnGetAccessTokenAsync(CancellationToken) Method
Invoked from [TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync(System.Security.Claims.ClaimsPrincipal)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync#TetraPak_AspNet_TetraPakClaimsTransformation_TransformAsync_System_Security_Claims_ClaimsPrincipal_ 'TetraPak.AspNet.TetraPakClaimsTransformation.TransformAsync(System.Security.Claims.ClaimsPrincipal)') to acquire an access token.  
```csharp
protected override System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> OnGetAccessTokenAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiClaimsTransformation_OnGetAccessTokenAsync(System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') object used to allow operation cancellation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
