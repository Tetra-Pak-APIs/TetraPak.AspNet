#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## AmbientData Class
Provides ambient data to an ASP.NET Core/5+ project throughout a request/response roundtrip.  
```csharp
public class AmbientData :
TetraPak.AspNet.IMessageIdProvider,
TetraPak.AspNet.Auth.IAccessTokenProvider,
TetraPak.AspNet.Auth.IIdentityTokenProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AmbientData  

Implements [IMessageIdProvider](TetraPak_AspNet_IMessageIdProvider.md 'TetraPak.AspNet.IMessageIdProvider'), [IAccessTokenProvider](TetraPak_AspNet_Auth_IAccessTokenProvider.md 'TetraPak.AspNet.Auth.IAccessTokenProvider'), [IIdentityTokenProvider](TetraPak_AspNet_Auth_IIdentityTokenProvider.md 'TetraPak.AspNet.Auth.IIdentityTokenProvider')  

| Constructors | |
| :--- | :--- |
| [AmbientData(TetraPakAuthConfig, IHttpContextAccessor, ITimeLimitedRepositories)](TetraPak_AspNet_AmbientData_AmbientData(TetraPak_AspNet_Auth_TetraPakAuthConfig_Microsoft_AspNetCore_Http_IHttpContextAccessor_TetraPak_Caching_ITimeLimitedRepositories).md 'TetraPak.AspNet.AmbientData.AmbientData(TetraPak.AspNet.Auth.TetraPakAuthConfig, Microsoft.AspNetCore.Http.IHttpContextAccessor, TetraPak.Caching.ITimeLimitedRepositories)') | Initializes the [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData') instance.<br/> |

| Properties | |
| :--- | :--- |
| [AuthConfig](TetraPak_AspNet_AmbientData_AuthConfig.md 'TetraPak.AspNet.AmbientData.AuthConfig') | Gets an auth config value. <br/> |
| [Cache](TetraPak_AspNet_AmbientData_Cache.md 'TetraPak.AspNet.AmbientData.Cache') | Gets a ambient cache.<br/> |
| [HttpContext](TetraPak_AspNet_AmbientData_HttpContext.md 'TetraPak.AspNet.AmbientData.HttpContext') | Gets the current [HttpContext](TetraPak_AspNet_AmbientData_HttpContext.md 'TetraPak.AspNet.AmbientData.HttpContext') instance.<br/> |
| [Logger](TetraPak_AspNet_AmbientData_Logger.md 'TetraPak.AspNet.AmbientData.Logger') | Gets a logging provider.<br/> |
| [this[string]](TetraPak_AspNet_AmbientData_this_string_.md 'TetraPak.AspNet.AmbientData.this[string]') | Indexer to get or set an ambient value.<br/> |

| Methods | |
| :--- | :--- |
| [GetAccessTokenAsync(bool)](TetraPak_AspNet_AmbientData_GetAccessTokenAsync(bool).md 'TetraPak.AspNet.AmbientData.GetAccessTokenAsync(bool)') | Gets an access token from the request context.<br/> |
| [GetIdTokenAsync()](TetraPak_AspNet_AmbientData_GetIdTokenAsync().md 'TetraPak.AspNet.AmbientData.GetIdTokenAsync()') | Gets an identity token from the request context.<br/> |
| [GetMessageId(bool)](TetraPak_AspNet_AmbientData_GetMessageId(bool).md 'TetraPak.AspNet.AmbientData.GetMessageId(bool)') | Retrieves a request message id if available. <br/> |
| [GetValue(string, object)](TetraPak_AspNet_AmbientData_GetValue(string_object).md 'TetraPak.AspNet.AmbientData.GetValue(string, object)') | Gets an ambient value.<br/> |
| [GetValue&lt;T&gt;(string, T)](TetraPak_AspNet_AmbientData_GetValue_T_(string_T).md 'TetraPak.AspNet.AmbientData.GetValue&lt;T&gt;(string, T)') | Gets an ambient value of a specified type.<br/> |
| [IsApiEndpoint()](TetraPak_AspNet_AmbientData_IsApiEndpoint().md 'TetraPak.AspNet.AmbientData.IsApiEndpoint()') | Returns a value indicating whether the routed endpoint is an API endpoint (not a view).<br/> |
| [SetValue(string, object)](TetraPak_AspNet_AmbientData_SetValue(string_object).md 'TetraPak.AspNet.AmbientData.SetValue(string, object)') | Sets an ambient value.<br/> |
