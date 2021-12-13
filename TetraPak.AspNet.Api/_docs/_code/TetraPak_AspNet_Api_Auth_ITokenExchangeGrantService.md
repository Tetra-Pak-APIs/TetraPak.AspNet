#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## ITokenExchangeGrantService Interface
Implementors of this interface can be used for exchanging access tokens.    
```csharp
public interface ITokenExchangeGrantService
```

Derived  
&#8627; [TetraPakTokenExchangeGrantService](TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService.md 'TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeGrantService')  
### Methods
<a name='TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)'></a>
## ITokenExchangeGrantService.ExchangeAccessTokenAsync(Credentials, ActorToken, bool, Nullable&lt;CancellationToken&gt;) Method
Exchanges a specified access token for a new, to be used for consuming a service.  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Api.Auth.TokenExchangeResponse>> ExchangeAccessTokenAsync(TetraPak.Credentials credentials, TetraPak.ActorToken subjectToken, bool forceAuthorization=false, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)_credentials'></a>
`credentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
Specifies the credentials used for the token exchange  
(typically [TetraPak.BasicAuthCredentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.BasicAuthCredentials 'TetraPak.BasicAuthCredentials') carrying client id and client secret).  
  
<a name='TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)_subjectToken'></a>
`subjectToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
The access token to be exchanged.  
  
<a name='TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)_forceAuthorization'></a>
`forceAuthorization` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to force a new client authorization (overriding/replacing any cached authorization).   
  
<a name='TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Enables cancellation of the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TokenExchangeResponse](TetraPak_AspNet_Api_Auth_TokenExchangeResponse.md 'TetraPak.AspNet.Api.Auth.TokenExchangeResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and.  
On success the value also carries the requested result; otherwise a [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') might  
be carried instead.  
### Remarks
Please note that (as of 2021-11-01) Tetra Pak auth services does not allow Token Exchange for  
non-human identities (a.k.a. "system identities").  




  
What this means is that if you pass an [subjectToken](TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService.md#TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)_subjectToken 'TetraPak.AspNet.Api.Auth.ITokenExchangeGrantService.ExchangeAccessTokenAsync(TetraPak.Credentials, TetraPak.ActorToken, bool, System.Nullable&lt;System.Threading.CancellationToken&gt;).subjectToken')  
that was ultimately issued from a Client Credentials Grant the token exchange will fail  
with a `400 Bad Request`.  
You can examine the [subjectToken](TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService.md#TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)_subjectToken 'TetraPak.AspNet.Api.Auth.ITokenExchangeGrantService.ExchangeAccessTokenAsync(TetraPak.Credentials, TetraPak.ActorToken, bool, System.Nullable&lt;System.Threading.CancellationToken&gt;).subjectToken') using the  
extension method [TetraPak.AspNet.Auth.JwtHelper.IsSystemIdentityToken(TetraPak.ActorToken)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.JwtHelper.IsSystemIdentityToken#TetraPak_AspNet_Auth_JwtHelper_IsSystemIdentityToken_TetraPak_ActorToken_ 'TetraPak.AspNet.Auth.JwtHelper.IsSystemIdentityToken(TetraPak.ActorToken)').  




  
For more details please see article using the link found in this constant:  
[TetraPak.AspNet.Documentations.Docs.DevPortal.TokenExchangeSubjectTokenTypes](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Documentations.Docs.DevPortal.TokenExchangeSubjectTokenTypes 'TetraPak.AspNet.Documentations.Docs.DevPortal.TokenExchangeSubjectTokenTypes')
  
