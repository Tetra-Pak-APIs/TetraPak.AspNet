#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## HttpContextHelper Class
Provides extension and convenience method for [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
```csharp
public static class HttpContextHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpContextHelper  
### Methods
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpContext)'></a>
## HttpContextHelper.GetAccessToken(HttpContext) Method
Returns the request access token, or `null` if unavailable.   
```csharp
public static TetraPak.ActorToken? GetAccessToken(this Microsoft.AspNetCore.Http.HttpContext self);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpContext)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
  
#### Returns
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
An [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') instance representing the request's access token if one can be obtained;  
otherwise `null`.  
#### See Also
- [GetAccessToken(HttpRequest)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpRequest) 'TetraPak.AspNet.HttpContextHelper.GetAccessToken(Microsoft.AspNetCore.Http.HttpRequest)')
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpRequest)'></a>
## HttpContextHelper.GetAccessToken(HttpRequest) Method
Returns the request access token, or `null` if unavailable.   
```csharp
public static TetraPak.ActorToken? GetAccessToken(this Microsoft.AspNetCore.Http.HttpRequest self);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpRequest)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
  
#### Returns
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
An [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') instance representing the request's access token if one can be obtained;  
otherwise `null`.  
#### See Also
- [GetAccessToken(HttpContext)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpContext) 'TetraPak.AspNet.HttpContextHelper.GetAccessToken(Microsoft.AspNetCore.Http.HttpContext)')
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpContext__bool)'></a>
## HttpContextHelper.GetAccessTokenAsync(HttpContext?, bool) Method
Tries obtaining an access token from the request.   
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(this Microsoft.AspNetCore.Http.HttpContext? self, bool forceStandardHeader=false);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpContext__bool)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpContext__bool)_forceStandardHeader'></a>
`forceStandardHeader` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set the configured (see [AuthorizationHeader](TetraPak_AspNet_TetraPakConfig.md#TetraPak_AspNet_TetraPakConfig_AuthorizationHeader 'TetraPak.AspNet.TetraPakConfig.AuthorizationHeader')) authorization  
header is ignored in favour of the HTTP standard [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization') header.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') instance indicating success/failure. On success the outcome  
holds the access token in its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value') property. On failure the outcome   
declares the problem via its [TetraPak.Outcome.Exception](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome.Exception 'TetraPak.Outcome.Exception') property.   
#### See Also
- [GetAccessToken(HttpContext)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpContext) 'TetraPak.AspNet.HttpContextHelper.GetAccessToken(Microsoft.AspNetCore.Http.HttpContext)')
  
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpRequest)'></a>
## HttpContextHelper.GetAccessTokenAsync(HttpRequest) Method
Tries obtaining an access token from the request.   
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(this Microsoft.AspNetCore.Http.HttpRequest self);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetAccessTokenAsync(Microsoft_AspNetCore_Http_HttpRequest)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') instance indicating success/failure. On success the outcome  
holds the access token in its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value') property. On failure the outcome   
declares the problem via its [TetraPak.Outcome.Exception](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome.Exception 'TetraPak.Outcome.Exception') property.   
#### See Also
- [GetAccessToken(HttpRequest)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetAccessToken(Microsoft_AspNetCore_Http_HttpRequest) 'TetraPak.AspNet.HttpContextHelper.GetAccessToken(Microsoft.AspNetCore.Http.HttpRequest)')
  
<a name='TetraPak_AspNet_HttpContextHelper_GetActorTokensAsync(Microsoft_AspNetCore_Http_HttpContext_)'></a>
## HttpContextHelper.GetActorTokensAsync(HttpContext?) Method
Gets all tokens from an [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
```csharp
public static System.Threading.Tasks.Task<TetraPak.EnumOutcome<TetraPak.ActorToken>> GetActorTokensAsync(this Microsoft.AspNetCore.Http.HttpContext? self);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetActorTokensAsync(Microsoft_AspNetCore_Http_HttpContext_)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.EnumOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1 'TetraPak.EnumOutcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1 'TetraPak.EnumOutcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetDiagnosticsLevel(Microsoft_AspNetCore_Http_HttpRequest_Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_Diagnostics_ServiceDiagnosticsLevel)'></a>
## HttpContextHelper.GetDiagnosticsLevel(HttpRequest, ILogger?, ServiceDiagnosticsLevel) Method
Gets a telemetry level from the request (if any).  
```csharp
public static TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel GetDiagnosticsLevel(this Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.Extensions.Logging.ILogger? logger, TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel useDefault=TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel.None);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetDiagnosticsLevel(Microsoft_AspNetCore_Http_HttpRequest_Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_Diagnostics_ServiceDiagnosticsLevel)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetDiagnosticsLevel(Microsoft_AspNetCore_Http_HttpRequest_Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_Diagnostics_ServiceDiagnosticsLevel)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
A logger provider.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetDiagnosticsLevel(Microsoft_AspNetCore_Http_HttpRequest_Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_Diagnostics_ServiceDiagnosticsLevel)_useDefault'></a>
`useDefault` [TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel 'TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel')  
A default telemetry level to be returned when no level was specified, or when  
the specified telemetry level could not be successfully parsed.    
  
#### Returns
[TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel 'TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel')  
A [TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel 'TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel') value.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakConfig_)'></a>
## HttpContextHelper.GetIdentityToken(HttpContext, TetraPakConfig?) Method
Returns the request identity token, or `null` if unavailable.  
```csharp
public static TetraPak.ActorToken? GetIdentityToken(this Microsoft.AspNetCore.Http.HttpContext self, TetraPak.AspNet.TetraPakConfig? config=null);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakConfig_)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The request [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext') object.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakConfig_)_config'></a>
`config` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
(optional)<br/>  
The Tetra Pak integration configuration object. When passed the method will look  
for the identity token in the header specified by [AuthorizationHeader](TetraPak_AspNet_TetraPakConfig.md#TetraPak_AspNet_TetraPakConfig_AuthorizationHeader 'TetraPak.AspNet.TetraPakConfig.AuthorizationHeader').  
If not the identity token is assumed to be carried by the header named as [IdToken](TetraPak_AspNet_AmbientData_Keys.md#TetraPak_AspNet_AmbientData_Keys_IdToken 'TetraPak.AspNet.AmbientData.Keys.IdToken').  
  
#### Returns
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
An [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') object representing the request's identity token if one can be obtained;  
otherwise `null`.  
#### See Also
- [GetIdentityToken(HttpRequest, TetraPakConfig)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakConfig) 'TetraPak.AspNet.HttpContextHelper.GetIdentityToken(Microsoft.AspNetCore.Http.HttpRequest, TetraPak.AspNet.TetraPakConfig)')
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakConfig)'></a>
## HttpContextHelper.GetIdentityToken(HttpRequest, TetraPakConfig) Method
Returns the request access token, or `null` if unavailable.   
```csharp
public static TetraPak.ActorToken? GetIdentityToken(this Microsoft.AspNetCore.Http.HttpRequest self, TetraPak.AspNet.TetraPakConfig config);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakConfig)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakConfig)_config'></a>
`config` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
  
#### Returns
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
An [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') instance representing the request's access token if one can be obtained;  
otherwise `null`.  
#### See Also
- [GetIdentityToken(HttpContext, TetraPakConfig?)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetIdentityToken(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakConfig_) 'TetraPak.AspNet.HttpContextHelper.GetIdentityToken(Microsoft.AspNetCore.Http.HttpContext, TetraPak.AspNet.TetraPakConfig?)')
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakConfig_)'></a>
## HttpContextHelper.GetIdentityTokenAsync(HttpContext, TetraPakConfig?) Method
Asynchronously returns the request identity token, or `null` if unavailable.  
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetIdentityTokenAsync(this Microsoft.AspNetCore.Http.HttpContext self, TetraPak.AspNet.TetraPakConfig? authConfig=null);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakConfig_)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The request [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext') object.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetIdentityTokenAsync(Microsoft_AspNetCore_Http_HttpContext_TetraPak_AspNet_TetraPakConfig_)_authConfig'></a>
`authConfig` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
(optional)<br/>  
The Tetra Pak integration configuration object. When passed the method will look  
for the identity token in the header specified by [AuthorizationHeader](TetraPak_AspNet_TetraPakConfig.md#TetraPak_AspNet_TetraPakConfig_AuthorizationHeader 'TetraPak.AspNet.TetraPakConfig.AuthorizationHeader').  
If not the identity token is assumed to be carried by the header named as [IdToken](TetraPak_AspNet_AmbientData_Keys.md#TetraPak_AspNet_AmbientData_Keys_IdToken 'TetraPak.AspNet.AmbientData.Keys.IdToken').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') object representing the request's identity token if one can be obtained;  
otherwise `null`.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetItemValue(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_HttpRequestElement_string)'></a>
## HttpContextHelper.GetItemValue(HttpRequest, HttpRequestElement, string) Method
Obtains a value from a specified [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest') element (such as headers or query).   
```csharp
public static string? GetItemValue(this Microsoft.AspNetCore.Http.HttpRequest request, TetraPak.AspNet.HttpRequestElement element, string key);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetItemValue(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_HttpRequestElement_string)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The extended [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetItemValue(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_HttpRequestElement_string)_element'></a>
`element` [HttpRequestElement](TetraPak_AspNet_HttpRequestElement.md 'TetraPak.AspNet.HttpRequestElement')  
The element to obtain the value from.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetItemValue(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_HttpRequestElement_string)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the requested value.   
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The requested value (a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')) if found by the [element](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_GetItemValue(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_HttpRequestElement_string)_element 'TetraPak.AspNet.HttpContextHelper.GetItemValue(Microsoft.AspNetCore.Http.HttpRequest, TetraPak.AspNet.HttpRequestElement, string).element');  
otherwise `null`.    
  
<a name='TetraPak_AspNet_HttpContextHelper_GetMessageId(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakConfig__bool)'></a>
## HttpContextHelper.GetMessageId(HttpRequest, TetraPakConfig?, bool) Method
Gets a standardized value used for referencing a unique request.   
```csharp
public static string? GetMessageId(this Microsoft.AspNetCore.Http.HttpRequest request, TetraPak.AspNet.TetraPakConfig? tetraPakConfig, bool enforce=false);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetMessageId(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakConfig__bool)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetMessageId(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakConfig__bool)_tetraPakConfig'></a>
`tetraPakConfig` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
Carries the Tetra Pak authorization configuration.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetMessageId(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_TetraPakConfig__bool)_enforce'></a>
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
            
  
<a name='TetraPak_AspNet_HttpContextHelper_IsMatch(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_HttpComparison_System_StringComparison)'></a>
## HttpContextHelper.IsMatch(HttpRequest, HttpComparison, StringComparison) Method
Examines a [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest') applying a criteria ([HttpComparison](TetraPak_AspNet_HttpComparison.md 'TetraPak.AspNet.HttpComparison'))  
and returns a value to indicate whether it is a match.   
```csharp
public static bool IsMatch(this Microsoft.AspNetCore.Http.HttpRequest request, TetraPak.AspNet.HttpComparison criteria, System.StringComparison comparison=System.StringComparison.InvariantCulture);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_IsMatch(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_HttpComparison_System_StringComparison)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The extended [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
  
<a name='TetraPak_AspNet_HttpContextHelper_IsMatch(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_HttpComparison_System_StringComparison)_criteria'></a>
`criteria` [HttpComparison](TetraPak_AspNet_HttpComparison.md 'TetraPak.AspNet.HttpComparison')  
Specifies the criteria.  
  
<a name='TetraPak_AspNet_HttpContextHelper_IsMatch(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_HttpComparison_System_StringComparison)_comparison'></a>
`comparison` [System.StringComparison](https://docs.microsoft.com/en-us/dotnet/api/System.StringComparison 'System.StringComparison')  
Specifies how to compare [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')s.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [criteria](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_IsMatch(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_HttpComparison_System_StringComparison)_criteria 'TetraPak.AspNet.HttpContextHelper.IsMatch(Microsoft.AspNetCore.Http.HttpRequest, TetraPak.AspNet.HttpComparison, System.StringComparison).criteria') results in a match; otherwise `false`.  
            
#### See Also
- [IsMatch(HttpComparison, HttpRequest, StringComparison)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_IsMatch(TetraPak_AspNet_HttpComparison_Microsoft_AspNetCore_Http_HttpRequest_System_StringComparison) 'TetraPak.AspNet.HttpContextHelper.IsMatch(TetraPak.AspNet.HttpComparison, Microsoft.AspNetCore.Http.HttpRequest, System.StringComparison)')
  
<a name='TetraPak_AspNet_HttpContextHelper_IsMatch(TetraPak_AspNet_HttpComparison_Microsoft_AspNetCore_Http_HttpRequest_System_StringComparison)'></a>
## HttpContextHelper.IsMatch(HttpComparison, HttpRequest, StringComparison) Method
Applies a criteria to a [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
and returns a value to indicate whether it is a match.  
```csharp
public static bool IsMatch(this TetraPak.AspNet.HttpComparison criteria, Microsoft.AspNetCore.Http.HttpRequest request, System.StringComparison comparison=System.StringComparison.InvariantCulture);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_IsMatch(TetraPak_AspNet_HttpComparison_Microsoft_AspNetCore_Http_HttpRequest_System_StringComparison)_criteria'></a>
`criteria` [HttpComparison](TetraPak_AspNet_HttpComparison.md 'TetraPak.AspNet.HttpComparison')  
The extended [HttpComparison](TetraPak_AspNet_HttpComparison.md 'TetraPak.AspNet.HttpComparison') criteria.  
  
<a name='TetraPak_AspNet_HttpContextHelper_IsMatch(TetraPak_AspNet_HttpComparison_Microsoft_AspNetCore_Http_HttpRequest_System_StringComparison)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
  
<a name='TetraPak_AspNet_HttpContextHelper_IsMatch(TetraPak_AspNet_HttpComparison_Microsoft_AspNetCore_Http_HttpRequest_System_StringComparison)_comparison'></a>
`comparison` [System.StringComparison](https://docs.microsoft.com/en-us/dotnet/api/System.StringComparison 'System.StringComparison')  
Specifies how to compare [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')s.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [criteria](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_IsMatch(TetraPak_AspNet_HttpComparison_Microsoft_AspNetCore_Http_HttpRequest_System_StringComparison)_criteria 'TetraPak.AspNet.HttpContextHelper.IsMatch(TetraPak.AspNet.HttpComparison, Microsoft.AspNetCore.Http.HttpRequest, System.StringComparison).criteria') results in a match; otherwise `false`.  
            
#### See Also
- [IsMatch(HttpRequest, HttpComparison, StringComparison)](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_IsMatch(Microsoft_AspNetCore_Http_HttpRequest_TetraPak_AspNet_HttpComparison_System_StringComparison) 'TetraPak.AspNet.HttpContextHelper.IsMatch(Microsoft.AspNetCore.Http.HttpRequest, TetraPak.AspNet.HttpComparison, System.StringComparison)')
  
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
  
  
<a name='TetraPak_AspNet_HttpContextHelper_ToHttpMethod(string)'></a>
## HttpContextHelper.ToHttpMethod(string) Method
Casts the [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') representation of a HTTP method into a [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod').   
```csharp
public static Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod ToHttpMethod(this string stringVerb);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_ToHttpMethod(string)_stringVerb'></a>
`stringVerb` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The textual HTTP method (verb) string representation.  
  
#### Returns
[Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')  
A [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod') value.  
#### Exceptions
[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
The [stringVerb](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ToHttpMethod(string)_stringVerb 'TetraPak.AspNet.HttpContextHelper.ToHttpMethod(string).stringVerb') value is not a recognized HTTP method.  
  
<a name='TetraPak_AspNet_HttpContextHelper_ToStringVerb(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod)'></a>
## HttpContextHelper.ToStringVerb(HttpMethod) Method
Casts a [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod') enum value into its equivalent [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value.  
```csharp
public static string ToStringVerb(this Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod httpMethod);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_ToStringVerb(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod)_httpMethod'></a>
`httpMethod` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')  
The [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod') value to be cast.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value.  
#### Exceptions
[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
The [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod') is not recognized.  
  
<a name='TetraPak_AspNet_HttpContextHelper_ToStringVerbs(System_Collections_Generic_IEnumerable_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_)'></a>
## HttpContextHelper.ToStringVerbs(IEnumerable&lt;HttpMethod&gt;) Method
Casts a collection of [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod') enum values into a collection of  
equivalent [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') values.  
```csharp
public static string[] ToStringVerbs(this System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod> methods);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_ToStringVerbs(System_Collections_Generic_IEnumerable_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_)_methods'></a>
`methods` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The enum values to be cast into [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')s.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
An array of [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String').  
  
<a name='TetraPak_AspNet_HttpContextHelper_ValidateHttpMethod(string__bool)'></a>
## HttpContextHelper.ValidateHttpMethod(string?, bool) Method
Validates a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') as a HTTP method (verb) and throws a [System.FormatException](https://docs.microsoft.com/en-us/dotnet/api/System.FormatException 'System.FormatException')  
if it is not recognised.    
```csharp
public static string ValidateHttpMethod(string? value, bool allowNull=true);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_ValidateHttpMethod(string__bool)_value'></a>
`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') to be validated.  
  
<a name='TetraPak_AspNet_HttpContextHelper_ValidateHttpMethod(string__bool)_allowNull'></a>
`allowNull` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether the exception is also thrown when [value](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ValidateHttpMethod(string__bool)_value 'TetraPak.AspNet.HttpContextHelper.ValidateHttpMethod(string?, bool).value') is `null`.   
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [value](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ValidateHttpMethod(string__bool)_value 'TetraPak.AspNet.HttpContextHelper.ValidateHttpMethod(string?, bool).value') (can be `null` if [allowNull](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ValidateHttpMethod(string__bool)_allowNull 'TetraPak.AspNet.HttpContextHelper.ValidateHttpMethod(string?, bool).allowNull') is set).  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[value](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ValidateHttpMethod(string__bool)_value 'TetraPak.AspNet.HttpContextHelper.ValidateHttpMethod(string?, bool).value') was unassigned (`null`) and [allowNull](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ValidateHttpMethod(string__bool)_allowNull 'TetraPak.AspNet.HttpContextHelper.ValidateHttpMethod(string?, bool).allowNull') was not set.  
            
[System.FormatException](https://docs.microsoft.com/en-us/dotnet/api/System.FormatException 'System.FormatException')  
[value](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ValidateHttpMethod(string__bool)_value 'TetraPak.AspNet.HttpContextHelper.ValidateHttpMethod(string?, bool).value') was not recognized as a HTTP method.  
            
  
<a name='TetraPak_AspNet_HttpContextHelper_ValidateHttpMethods(TetraPak_MultiStringValue__bool)'></a>
## HttpContextHelper.ValidateHttpMethods(MultiStringValue?, bool) Method
Validates the items of a [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue') as HTTP methods (verbs)  
and returns them (on success) or throws a [System.FormatException](https://docs.microsoft.com/en-us/dotnet/api/System.FormatException 'System.FormatException') (on failure).    
```csharp
public static TetraPak.MultiStringValue? ValidateHttpMethods(TetraPak.MultiStringValue? value, bool allowNull=true);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_ValidateHttpMethods(TetraPak_MultiStringValue__bool)_value'></a>
`value` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
The [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue') to be validated.  
  
<a name='TetraPak_AspNet_HttpContextHelper_ValidateHttpMethods(TetraPak_MultiStringValue__bool)_allowNull'></a>
`allowNull` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether the exception is also thrown when [value](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ValidateHttpMethods(TetraPak_MultiStringValue__bool)_value 'TetraPak.AspNet.HttpContextHelper.ValidateHttpMethods(TetraPak.MultiStringValue?, bool).value') is `null`.   
  
#### Returns
[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
The [value](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ValidateHttpMethods(TetraPak_MultiStringValue__bool)_value 'TetraPak.AspNet.HttpContextHelper.ValidateHttpMethods(TetraPak.MultiStringValue?, bool).value') (can be `null` if [allowNull](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ValidateHttpMethods(TetraPak_MultiStringValue__bool)_allowNull 'TetraPak.AspNet.HttpContextHelper.ValidateHttpMethods(TetraPak.MultiStringValue?, bool).allowNull') is set).  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[value](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ValidateHttpMethods(TetraPak_MultiStringValue__bool)_value 'TetraPak.AspNet.HttpContextHelper.ValidateHttpMethods(TetraPak.MultiStringValue?, bool).value') was unassigned (`null`) and [allowNull](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ValidateHttpMethods(TetraPak_MultiStringValue__bool)_allowNull 'TetraPak.AspNet.HttpContextHelper.ValidateHttpMethods(TetraPak.MultiStringValue?, bool).allowNull') was not set.  
            
[System.FormatException](https://docs.microsoft.com/en-us/dotnet/api/System.FormatException 'System.FormatException')  
[value](TetraPak_AspNet_HttpContextHelper.md#TetraPak_AspNet_HttpContextHelper_ValidateHttpMethods(TetraPak_MultiStringValue__bool)_value 'TetraPak.AspNet.HttpContextHelper.ValidateHttpMethods(TetraPak.MultiStringValue?, bool).value') was not recognized as a HTTP method.  
            
  
