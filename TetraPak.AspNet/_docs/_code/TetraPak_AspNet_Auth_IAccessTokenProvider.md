#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## IAccessTokenProvider Interface
Implementors of this class are capable of providing an access token from a request context.   
```csharp
public interface IAccessTokenProvider
```

Derived  
&#8627; [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')  
### Methods
<a name='TetraPak_AspNet_Auth_IAccessTokenProvider_GetAccessTokenAsync(bool)'></a>
## IAccessTokenProvider.GetAccessTokenAsync(bool) Method
Gets an access token from the request context.  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(bool forceStandardHeader=false);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_IAccessTokenProvider_GetAccessTokenAsync(bool)_forceStandardHeader'></a>
`forceStandardHeader` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set the configured (see [AuthorizationHeader](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_AuthorizationHeader 'TetraPak.AspNet.TetraPakAuthConfig.AuthorizationHeader')) authorization  
header is ignored in favour of the HTTP standard [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization') header.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
