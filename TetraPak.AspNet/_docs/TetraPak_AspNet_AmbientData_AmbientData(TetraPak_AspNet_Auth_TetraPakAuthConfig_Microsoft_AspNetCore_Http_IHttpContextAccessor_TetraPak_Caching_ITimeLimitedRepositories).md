#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')
## AmbientData.AmbientData(TetraPakAuthConfig, IHttpContextAccessor, ITimeLimitedRepositories) Constructor
Initializes the [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData') instance.  
```csharp
public AmbientData(TetraPak.AspNet.Auth.TetraPakAuthConfig authConfig, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, TetraPak.Caching.ITimeLimitedRepositories cache=null);
```
#### Parameters
<a name='TetraPak_AspNet_AmbientData_AmbientData(TetraPak_AspNet_Auth_TetraPakAuthConfig_Microsoft_AspNetCore_Http_IHttpContextAccessor_TetraPak_Caching_ITimeLimitedRepositories)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')  
The Tetra Pak auth configuration.  
  
<a name='TetraPak_AspNet_AmbientData_AmbientData(TetraPak_AspNet_Auth_TetraPakAuthConfig_Microsoft_AspNetCore_Http_IHttpContextAccessor_TetraPak_Caching_ITimeLimitedRepositories)_httpContextAccessor'></a>
`httpContextAccessor` [Microsoft.AspNetCore.Http.IHttpContextAccessor](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.IHttpContextAccessor 'Microsoft.AspNetCore.Http.IHttpContextAccessor')  
A [Microsoft.AspNetCore.Http.IHttpContextAccessor](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.IHttpContextAccessor 'Microsoft.AspNetCore.Http.IHttpContextAccessor') that is required for many of the ambient data operations.  
  
<a name='TetraPak_AspNet_AmbientData_AmbientData(TetraPak_AspNet_Auth_TetraPakAuthConfig_Microsoft_AspNetCore_Http_IHttpContextAccessor_TetraPak_Caching_ITimeLimitedRepositories)_cache'></a>
`cache` [TetraPak.Caching.ITimeLimitedRepositories](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Caching.ITimeLimitedRepositories 'TetraPak.Caching.ITimeLimitedRepositories')  
(optional)<br />  
A caching mechanism for public availability through the [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData') instance.  
  
