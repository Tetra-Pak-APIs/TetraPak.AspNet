#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api').[BackendService&lt;TEndpoints&gt;](TetraPak_AspNet_Api_BackendService_TEndpoints_.md 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;')
## BackendService&lt;TEndpoints&gt;.GetConfiguredValue(string) Method
Gets a "raw" configured value, as it is specified within the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') sources,  
unaffected by delegates or other internal types of logic.  
```csharp
public string GetConfiguredValue(string key);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetConfiguredValue(string)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the requested value.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') when a value is configured; otherwise `null`.  

Implements [GetConfiguredValue(string)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetConfiguredValue#TetraPak_AspNet_Auth_IServiceAuthConfig_GetConfiguredValue_System_String_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetConfiguredValue(System.String)')  
