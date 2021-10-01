#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## HttpContextHelper Class
Provides extension and convenience method for [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
```csharp
public static class HttpContextHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpContextHelper  
### Methods
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig)'></a>
## HttpContextHelper.GetAccessToken(HttpContext, TetraPakAuthConfig) Method
Returns the request access token, or `null` if unavailable.   
```csharp
public static TetraPak.ActorToken GetAccessToken(this Microsoft.AspNetCore.Http.HttpContext self, TetraPak.AspNet.TetraPakAuthConfig authConfig);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig')  
  
#### Returns
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
An [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') instance representing the request's access token if one can be obtained;  
otherwise `null`.  
#### See Also
- [GetAccessToken(HttpRequest, TetraPakAuthConfig)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig) 'TetraPak.AspNet.HttpContextHelper.GetAccessToken(Microsoft.AspNetCore.Http.HttpRequest, TetraPak.AspNet.TetraPakAuthConfig)')
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig)'></a>
## HttpContextHelper.GetAccessToken(HttpRequest, TetraPakAuthConfig) Method
Returns the request access token, or `null` if unavailable.   
```csharp
public static TetraPak.ActorToken GetAccessToken(this Microsoft.AspNetCore.Http.HttpRequest self, TetraPak.AspNet.TetraPakAuthConfig authConfig);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig')  
  
#### Returns
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
An [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') instance representing the request's access token if one can be obtained;  
otherwise `null`.  
#### See Also
- [GetAccessToken(HttpContext, TetraPakAuthConfig)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig) 'TetraPak.AspNet.HttpContextHelper.GetAccessToken(Microsoft.AspNetCore.Http.HttpContext, TetraPak.AspNet.TetraPakAuthConfig)')
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig__bool)'></a>
## HttpContextHelper.GetAccessTokenAsync(HttpContext, TetraPakAuthConfig?, bool) Method
Tries obtaining an access token from the request.   
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(this Microsoft.AspNetCore.Http.HttpContext self, TetraPak.AspNet.TetraPakAuthConfig? authConfig, bool forceStandardHeader=false);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig__bool)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig__bool)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig')  
A Tetra Pak configuration object.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig__bool)_forceStandardHeader'></a>
`forceStandardHeader` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set the configured (see [AuthorizationHeader](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_AuthorizationHeader 'TetraPak.AspNet.TetraPakAuthConfig.AuthorizationHeader')) authorization  
header is ignored in favour of the HTTP standard [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization') header.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') instance indicating success/failure. On success the outcome  
holds the access token in its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value') property. On failure the outcome   
declares the problem via its [TetraPak.Outcome.Exception](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome.Exception 'TetraPak.Outcome.Exception') property.   
#### See Also
- [GetAccessToken(HttpContext, TetraPakAuthConfig)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig) 'TetraPak.AspNet.HttpContextHelper.GetAccessToken(Microsoft.AspNetCore.Http.HttpContext, TetraPak.AspNet.TetraPakAuthConfig)')
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig)'></a>
## HttpContextHelper.GetAccessTokenAsync(HttpRequest, TetraPakAuthConfig) Method
Tries obtaining an access token from the request.   
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(this Microsoft.AspNetCore.Http.HttpRequest self, TetraPak.AspNet.TetraPakAuthConfig authConfig);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig')  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') instance indicating success/failure. On success the outcome  
holds the access token in its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value') property. On failure the outcome   
declares the problem via its [TetraPak.Outcome.Exception](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome.Exception 'TetraPak.Outcome.Exception') property.   
#### See Also
- [GetAccessToken(HttpRequest, TetraPakAuthConfig)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig) 'TetraPak.AspNet.HttpContextHelper.GetAccessToken(Microsoft.AspNetCore.Http.HttpRequest, TetraPak.AspNet.TetraPakAuthConfig)')
  
<a name='TetraPak_AspNet_HttpContextHelper_GetDiagnosticsLevel(Microsoft_AspNetCore_Http_HttpRequest_Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_Diagnostics_ServiceDiagnosticsLevel)'></a>
## HttpContextHelper.GetDiagnosticsLevel(HttpRequest, ILogger, ServiceDiagnosticsLevel) Method
Gets a telemetry level from the request (if any).  
```csharp
public static TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel GetDiagnosticsLevel(this Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.Extensions.Logging.ILogger logger, TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel useDefault=TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel.None);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetDiagnosticsLevel(Microsoft_AspNetCore_Http_HttpRequest_Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_Diagnostics_ServiceDiagnosticsLevel)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetDiagnosticsLevel(Microsoft_AspNetCore_Http_HttpRequest_Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_Diagnostics_ServiceDiagnosticsLevel)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
A logger provider.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetDiagnosticsLevel(Microsoft_AspNetCore_Http_HttpRequest_Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_Diagnostics_ServiceDiagnosticsLevel)_useDefault'></a>
`useDefault` [TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel 'TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel')  
A default telemetry level to be returned when no level was specified, or when  
the specified telemetry level could not be successfully parsed.    
  
#### Returns
[TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel 'TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel')  
A [TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel 'TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel') value.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig_)'></a>
## HttpContextHelper.GetIdentityToken(HttpContext, TetraPakAuthConfig?) Method
Returns the request identity token, or `null` if unavailable.  
```csharp
public static TetraPak.ActorToken GetIdentityToken(this Microsoft.AspNetCore.Http.HttpContext self, TetraPak.AspNet.TetraPakAuthConfig? authConfig=null);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig_)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The request [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext') object.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig_)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig')  
(optional)<br/>  
The Tetra Pak integration configuration object. When passed the method will look  
for the identity token in the header specified by [AuthorizationHeader](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_AuthorizationHeader 'TetraPak.AspNet.TetraPakAuthConfig.AuthorizationHeader').  
If not the identity token is assumed to be carried by the header named as [IdToken](TetraPak_AspNet_AmbientData_Keys.md#TetraPak_AspNet_AmbientData_Keys_IdToken 'TetraPak.AspNet.AmbientData.Keys.IdToken').  
  
#### Returns
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
An [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') object representing the request's identity token if one can be obtained;  
otherwise `null`.  
#### See Also
- [GetIdentityToken(HttpRequest, TetraPakAuthConfig)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig) 'TetraPak.AspNet.HttpContextHelper.GetIdentityToken(Microsoft.AspNetCore.Http.HttpRequest, TetraPak.AspNet.TetraPakAuthConfig)')
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig)'></a>
## HttpContextHelper.GetIdentityToken(HttpRequest, TetraPakAuthConfig) Method
Returns the request access token, or `null` if unavailable.   
```csharp
public static TetraPak.ActorToken GetIdentityToken(this Microsoft.AspNetCore.Http.HttpRequest self, TetraPak.AspNet.TetraPakAuthConfig authConfig);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig')  
  
#### Returns
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
An [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') instance representing the request's access token if one can be obtained;  
otherwise `null`.  
#### See Also
- [GetIdentityToken(HttpContext, TetraPakAuthConfig?)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig_) 'TetraPak.AspNet.HttpContextHelper.GetIdentityToken(Microsoft.AspNetCore.Http.HttpContext, TetraPak.AspNet.TetraPakAuthConfig?)')
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig_)'></a>
## HttpContextHelper.GetIdentityTokenAsync(HttpContext, TetraPakAuthConfig?) Method
Asynchronously returns the request identity token, or `null` if unavailable.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetIdentityTokenAsync(this Microsoft.AspNetCore.Http.HttpContext self, TetraPak.AspNet.TetraPakAuthConfig? authConfig=null);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig_)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The request [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext') object.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakAuthConfig_)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig')  
(optional)<br/>  
The Tetra Pak integration configuration object. When passed the method will look  
for the identity token in the header specified by [AuthorizationHeader](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_AuthorizationHeader 'TetraPak.AspNet.TetraPakAuthConfig.AuthorizationHeader').  
If not the identity token is assumed to be carried by the header named as [IdToken](TetraPak_AspNet_AmbientData_Keys.md#TetraPak_AspNet_AmbientData_Keys_IdToken 'TetraPak.AspNet.AmbientData.Keys.IdToken').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') object representing the request's identity token if one can be obtained;  
otherwise `null`.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetMessageId(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig__bool)'></a>
## HttpContextHelper.GetMessageId(HttpRequest, TetraPakAuthConfig?, bool) Method
Gets a standardized value used for referencing a unique request.   
```csharp
public static string? GetMessageId(this Microsoft.AspNetCore.Http.HttpRequest request, TetraPak.AspNet.TetraPakAuthConfig? authConfig, bool enforce=false);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetMessageId(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig__bool)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetMessageId(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig__bool)_authConfig'></a>
`authConfig` [TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig')  
Carries the Tetra Pak authorization configuration.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetMessageId(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakAuthConfig__bool)_enforce'></a>
`enforce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set, a random unique string will be generated and attached to the request.    
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A unique [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value.   
  
<a name='TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)'></a>
## HttpContextHelper.GetSingleValue(IHeaderDictionary, string, string, bool) Method
Gets (and, optionally, sets) a single header value.  
```csharp
public static string? GetSingleValue(this Microsoft.AspNetCore.Http.IHeaderDictionary dictionary, string key, string useDefault, bool setDefault=false);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)_dictionary'></a>
`dictionary` [Microsoft.AspNetCore.Http.IHeaderDictionary](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.IHeaderDictionary 'Microsoft.AspNetCore.Http.IHeaderDictionary')  
The header dictionary to get (set) value from.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the header value.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)_useDefault'></a>
`useDefault` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A default value to be used if one cannot be found in the header dictionary.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)_setDefault'></a>
`setDefault` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`); only applies if [useDefault](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)_useDefault 'TetraPak.AspNet.HttpContextHelper.GetSingleValue(Microsoft.AspNetCore.Http.IHeaderDictionary, string, string, bool).useDefault') is assigned)<br/>  
When set, the [useDefault](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)_useDefault 'TetraPak.AspNet.HttpContextHelper.GetSingleValue(Microsoft.AspNetCore.Http.IHeaderDictionary, string, string, bool).useDefault') value will automatically be added to the header dictionary,  
affecting the request.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A (single) [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetValue_T_(Microsoft_AspNetCore_Http_HttpContext_string_T_)'></a>
## HttpContextHelper.GetValue&lt;T&gt;(HttpContext, string, T?) Method
Gets a value from [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
```csharp
public static T GetValue<T>(this Microsoft.AspNetCore.Http.HttpContext self, string key, T? useDefault=default(T?));
```
#### Type parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetValue_T_(Microsoft_AspNetCore_Http_HttpContext_string_T_)_T'></a>
`T`  
The type of value requested.  
  
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetValue_T_(Microsoft_AspNetCore_Http_HttpContext_string_T_)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetValue_T_(Microsoft_AspNetCore_Http_HttpContext_string_T_)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the requested value.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetValue_T_(Microsoft_AspNetCore_Http_HttpContext_string_T_)_useDefault'></a>
`useDefault` [T](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetValue_T_(Microsoft_AspNetCore_Http_HttpContext_string_T_)_T 'TetraPak.AspNet.HttpContextHelper.GetValue&lt;T&gt;(Microsoft.AspNetCore.Http.HttpContext, string, T?).T')  
(optional)<br/>  
A default value to be returned if the requested value is not carried by [self](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetValue_T_(Microsoft_AspNetCore_Http_HttpContext_string_T_)_self 'TetraPak.AspNet.HttpContextHelper.GetValue&lt;T&gt;(Microsoft.AspNetCore.Http.HttpContext, string, T?).self').   
  
#### Returns
[T](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetValue_T_(Microsoft_AspNetCore_Http_HttpContext_string_T_)_T 'TetraPak.AspNet.HttpContextHelper.GetValue&lt;T&gt;(Microsoft.AspNetCore.Http.HttpContext, string, T?).T')  
The requested value if carried by the [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext');  
otherwise the [useDefault](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetValue_T_(Microsoft_AspNetCore_Http_HttpContext_string_T_)_useDefault 'TetraPak.AspNet.HttpContextHelper.GetValue&lt;T&gt;(Microsoft.AspNetCore.Http.HttpContext, string, T?).useDefault') value.  
  
<a name='TetraPak_AspNet_HttpContextHelper_IsEndpointProtected(Microsoft_AspNetCore_Http_HttpContext)'></a>
## HttpContextHelper.IsEndpointProtected(HttpContext) Method
Examines the resolved endpoint of the context (if any) and returns a value indicating whether  
it is protected (decorated with   
```csharp
public static bool IsEndpointProtected(this Microsoft.AspNetCore.Http.HttpContext self);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_IsEndpointProtected(Microsoft_AspNetCore_Http_HttpContext)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The extended [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if an endpoint is resolved and protected.   
            
  
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_object__System_Threading_CancellationToken)'></a>
## HttpContextHelper.RespondAsync(HttpContext, HttpStatusCode, object?, CancellationToken) Method
Writes a HTTP response.  
```csharp
public static System.Threading.Tasks.Task RespondAsync(this Microsoft.AspNetCore.Http.HttpContext context, System.Net.HttpStatusCode statusCode, object? content=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_object__System_Threading_CancellationToken)_context'></a>
`context` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
  
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_object__System_Threading_CancellationToken)_statusCode'></a>
`statusCode` [System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode')  
The status code to be returned.  
  
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_object__System_Threading_CancellationToken)_content'></a>
`content` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
(optional)<br/>  
Content to be returned (objects will be JSON serialized).  
  
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_object__System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
(optional)<br/>  
A cancellation token.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_string__string__System_Threading_CancellationToken)'></a>
## HttpContextHelper.RespondAsync(HttpContext, HttpStatusCode, string?, string?, CancellationToken) Method
Writes a HTTP response.  
```csharp
public static System.Threading.Tasks.Task RespondAsync(this Microsoft.AspNetCore.Http.HttpContext context, System.Net.HttpStatusCode statusCode, string? content=null, string? contentType=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_string__string__System_Threading_CancellationToken)_context'></a>
`context` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
  
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_string__string__System_Threading_CancellationToken)_statusCode'></a>
`statusCode` [System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode')  
The status code to be returned.  
  
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_string__string__System_Threading_CancellationToken)_content'></a>
`content` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Content to be returned.  
  
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_string__string__System_Threading_CancellationToken)_contentType'></a>
`contentType` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A content MIME type tp be returned.  
  
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_string__string__System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
(optional)<br/>  
A cancellation token.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_HttpContextHelper_SetValue(Microsoft_AspNetCore_Http_HttpContext_string_object)'></a>
## HttpContextHelper.SetValue(HttpContext, string, object) Method
Sets a value to the [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
```csharp
public static void SetValue(this Microsoft.AspNetCore.Http.HttpContext self, string key, object value);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_SetValue(Microsoft_AspNetCore_Http_HttpContext_string_object)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
  
<a name='TetraPak_AspNet_HttpContextHelper_SetValue(Microsoft_AspNetCore_Http_HttpContext_string_object)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the value to be set.  
  
<a name='TetraPak_AspNet_HttpContextHelper_SetValue(Microsoft_AspNetCore_Http_HttpContext_string_object)_value'></a>
`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The value to be set.  
  
  
