#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TetraPakJwtApiClaimsTransformation Class
Performs automatic claims transformation but ensures the access token used to  
call the user information service gets exchanged (necessary for APIs).  
(See [TetraPak.AspNet.TetraPakJwtClaimsTransformation](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakJwtClaimsTransformation 'TetraPak.AspNet.TetraPakJwtClaimsTransformation') for more details).  
```csharp
public sealed class TetraPakJwtApiClaimsTransformation : TetraPak.AspNet.TetraPakJwtClaimsTransformation
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.AspNet.TetraPakClaimsTransformation](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakClaimsTransformation 'TetraPak.AspNet.TetraPakClaimsTransformation') &#129106; [TetraPak.AspNet.TetraPakJwtClaimsTransformation](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakJwtClaimsTransformation 'TetraPak.AspNet.TetraPakJwtClaimsTransformation') &#129106; TetraPakJwtApiClaimsTransformation  
### Example
```csharp
public void ConfigureServices(IServiceCollection services)
{
    :
    services.AddTetraPakWebApiClaimsTransformation();
    :
}
```
### Methods
<a name='TetraPak_AspNet_Api_Auth_TetraPakJwtApiClaimsTransformation_OnGetAccessTokenAsync(System_Threading_CancellationToken)'></a>
## TetraPakJwtApiClaimsTransformation.OnGetAccessTokenAsync(CancellationToken) Method
Can be invoked to acquire an access token from the [TetraPak.AspNet.TetraPakClaimsTransformation.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakClaimsTransformation.HttpContext 'TetraPak.AspNet.TetraPakClaimsTransformation.HttpContext').  
```csharp
protected override System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> OnGetAccessTokenAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakJwtApiClaimsTransformation_OnGetAccessTokenAsync(System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') object used to allow operation cancellation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
