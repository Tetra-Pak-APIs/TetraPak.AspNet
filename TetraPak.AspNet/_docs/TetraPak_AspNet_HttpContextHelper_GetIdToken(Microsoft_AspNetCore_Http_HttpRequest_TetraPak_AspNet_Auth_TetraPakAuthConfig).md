#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[HttpContextHelper](TetraPak_AspNet_HttpContextHelper.md 'TetraPak.AspNet.HttpContextHelper')
## HttpContextHelper.GetIdToken(HttpRequest, TetraPakAuthConfig) Method
Returns the request access token, or `null` if unavailable.   
```csharp
public static TetraPak.ActorToken GetIdToken(this Microsoft.AspNetCore.Http.HttpRequest self, TetraPak.AspNet.Auth.TetraPakAuthConfig authConfig);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetIdToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_Auth_TetraPakAuthConfig)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_Auth_TetraPakAuthConfig)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')  
  
#### Returns
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
An [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') instance representing the request's access token if one can be obtained;  
otherwise `null`.  
#### See Also
- [TetraPak.AspNet.HttpContextHelper.GetIdToken(Microsoft.AspNetCore.Http.HttpContext,TetraPak.AspNet.Auth.TetraPakAuthConfig)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpContextHelper.GetIdToken#TetraPak_AspNet_HttpContextHelper_GetIdToken_Microsoft_AspNetCore_Http_HttpContext,TetraPak_AspNet_Auth_TetraPakAuthConfig_ 'TetraPak.AspNet.HttpContextHelper.GetIdToken(Microsoft.AspNetCore.Http.HttpContext,TetraPak.AspNet.Auth.TetraPakAuthConfig)')
