#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[HttpContextHelper](TetraPak_AspNet_HttpContextHelper.md 'TetraPak.AspNet.HttpContextHelper')
## HttpContextHelper.GetAccessTokenAsync(HttpContext, TetraPakAuthConfig, bool) Method
Tries obtaining an access token from the request.   
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(this Microsoft.AspNetCore.Http.HttpContext self, TetraPak.AspNet.Auth.TetraPakAuthConfig authConfig, bool forceStandardHeader=false);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_Auth_TetraPakAuthConfig_bool)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_Auth_TetraPakAuthConfig_bool)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')  
A Tetra Pak configuration object.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_Auth_TetraPakAuthConfig_bool)_forceStandardHeader'></a>
`forceStandardHeader` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br />  
When set the configured (see [AuthorizationHeader](TetraPak_AspNet_Auth_TetraPakAuthConfig_AuthorizationHeader.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig.AuthorizationHeader')) authorization  
header is ignored in favour of the HTTP standard [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization') header.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') instance indicating success/failure. On success the outcome  
holds the access token in its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value') property. On failure the outcome   
declares the problem via its [TetraPak.Outcome.Exception](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome.Exception 'TetraPak.Outcome.Exception') property.   
#### See Also
- [GetAccessToken(HttpContext, TetraPakAuthConfig)](TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_Auth_TetraPakAuthConfig).md 'TetraPak.AspNet.HttpContextHelper.GetAccessToken(Microsoft.AspNetCore.Http.HttpContext, TetraPak.AspNet.Auth.TetraPakAuthConfig)')
