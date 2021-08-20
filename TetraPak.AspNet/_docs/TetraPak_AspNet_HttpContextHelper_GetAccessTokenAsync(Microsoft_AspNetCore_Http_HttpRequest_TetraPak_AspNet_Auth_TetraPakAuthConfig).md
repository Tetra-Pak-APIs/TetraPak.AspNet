#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[HttpContextHelper](TetraPak_AspNet_HttpContextHelper.md 'TetraPak.AspNet.HttpContextHelper')
## HttpContextHelper.GetAccessTokenAsync(HttpRequest, TetraPakAuthConfig) Method
Tries obtaining an access token from the request.   
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(this Microsoft.AspNetCore.Http.HttpRequest self, TetraPak.AspNet.Auth.TetraPakAuthConfig authConfig);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_Auth_TetraPakAuthConfig)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_Auth_TetraPakAuthConfig)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') instance indicating success/failure. On success the outcome  
holds the access token in its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value') property. On failure the outcome   
declares the problem via its [TetraPak.Outcome.Exception](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome.Exception 'TetraPak.Outcome.Exception') property.   
#### See Also
- [GetAccessToken(HttpRequest, TetraPakAuthConfig)](TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_Auth_TetraPakAuthConfig).md 'TetraPak.AspNet.HttpContextHelper.GetAccessToken(Microsoft.AspNetCore.Http.HttpRequest, TetraPak.AspNet.Auth.TetraPakAuthConfig)')
