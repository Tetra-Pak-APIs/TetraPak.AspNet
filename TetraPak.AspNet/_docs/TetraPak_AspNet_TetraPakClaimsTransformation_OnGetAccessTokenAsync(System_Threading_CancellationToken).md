#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[TetraPakClaimsTransformation](TetraPak_AspNet_TetraPakClaimsTransformation.md 'TetraPak.AspNet.TetraPakClaimsTransformation')
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
