#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[HttpContextHelper](TetraPak_AspNet_HttpContextHelper.md 'TetraPak.AspNet.HttpContextHelper')
## HttpContextHelper.GetAccessToken(HttpContext, TetraPakAuthConfig) Method
Returns the request access token, or `null` if unavailable.   
```csharp
public static TetraPak.ActorToken GetAccessToken(this Microsoft.AspNetCore.Http.HttpContext self, TetraPak.AspNet.Auth.TetraPakAuthConfig authConfig);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_Auth_TetraPakAuthConfig)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_Auth_TetraPakAuthConfig)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')  
  
#### Returns
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
An [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') instance representing the request's access token if one can be obtained;  
otherwise `null`.  
#### See Also
- [GetAccessToken(HttpRequest, TetraPakAuthConfig)](TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_Auth_TetraPakAuthConfig).md 'TetraPak.AspNet.HttpContextHelper.GetAccessToken(Microsoft.AspNetCore.Http.HttpRequest, TetraPak.AspNet.Auth.TetraPakAuthConfig)')
