#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## IRefreshTokenGrantService Interface
Classes implementing this interface are able to perform the OAuth2 Refresh Token Grant flow.   
```csharp
public interface IRefreshTokenGrantService
```
### Methods
<a name='TetraPak_AspNet_Auth_IRefreshTokenGrantService_RefreshTokenAsync(TetraPak_ActorToken_System_Nullable_System_Threading_CancellationToken_)'></a>
## IRefreshTokenGrantService.RefreshTokenAsync(ActorToken, Nullable&lt;CancellationToken&gt;) Method
Submits a refresh token to acquire a new access token.  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Auth.RefreshTokenResponse>> RefreshTokenAsync(TetraPak.ActorToken refreshToken, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_IRefreshTokenGrantService_RefreshTokenAsync(TetraPak_ActorToken_System_Nullable_System_Threading_CancellationToken_)_refreshToken'></a>
`refreshToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
The refresh token to be submitted for a new access token.  
  
<a name='TetraPak_AspNet_Auth_IRefreshTokenGrantService_RefreshTokenAsync(TetraPak_ActorToken_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Enables cancellation of the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[RefreshTokenResponse](TetraPak_AspNet_Auth_RefreshTokenResponse.md 'TetraPak.AspNet.Auth.RefreshTokenResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [RefreshTokenResponse](TetraPak_AspNet_Auth_RefreshTokenResponse.md 'TetraPak.AspNet.Auth.RefreshTokenResponse') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
