#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[HttpContextHelper](TetraPak_AspNet_HttpContextHelper.md 'TetraPak.AspNet.HttpContextHelper')
## HttpContextHelper.GetMessageId(HttpRequest, TetraPakAuthConfig, bool) Method
Gets a standardized value used for referencing a unique request.   
```csharp
public static string GetMessageId(this Microsoft.AspNetCore.Http.HttpRequest request, TetraPak.AspNet.Auth.TetraPakAuthConfig authConfig, bool enforce=false);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetMessageId(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_Auth_TetraPakAuthConfig_bool)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetMessageId(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_Auth_TetraPakAuthConfig_bool)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')  
Carries the Tetra Pak authorization configuration.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetMessageId(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_Auth_TetraPakAuthConfig_bool)_enforce'></a>
`enforce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br />  
When set, a random unique string will be generated and attached to the request.    
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A unique [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value.   
