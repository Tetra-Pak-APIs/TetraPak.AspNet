#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Controllers](TetraPak_AspNet_Api_Controllers.md 'TetraPak.AspNet.Api.Controllers')
## ControllerBaseExtensions Class
Convenient extension methods for [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase').  
```csharp
public static class ControllerBaseExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ControllerBaseExtensions  
### Methods
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_GetAccessTokenAsync(Microsoft_AspNetCore_Mvc_ControllerBase)'></a>
## ControllerBaseExtensions.GetAccessTokenAsync(ControllerBase) Method
Obtains a security token from the request.   
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(this Microsoft.AspNetCore.Mvc.ControllerBase self);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_GetAccessTokenAsync(Microsoft_AspNetCore_Mvc_ControllerBase)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_GetMessageId(Microsoft_AspNetCore_Mvc_ControllerBase)'></a>
## ControllerBaseExtensions.GetMessageId(ControllerBase) Method
Gets a unique string value for tracking a request/response (mainly for diagnostics purposes).  
```csharp
public static string? GetMessageId(this Microsoft.AspNetCore.Mvc.ControllerBase self);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_GetMessageId(Microsoft_AspNetCore_Mvc_ControllerBase)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_GetTetraPakConfig(Microsoft_AspNetCore_Mvc_ControllerBase)'></a>
## ControllerBaseExtensions.GetTetraPakConfig(ControllerBase) Method
Obtains the Tetra Pak (API) configuration object.  
```csharp
public static TetraPak.AspNet.TetraPakConfig? GetTetraPakConfig(this Microsoft.AspNetCore.Mvc.ControllerBase self);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_GetTetraPakConfig(Microsoft_AspNetCore_Mvc_ControllerBase)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
#### Returns
[TetraPak.AspNet.TetraPakConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig 'TetraPak.AspNet.TetraPakConfig')  
A Tetra Pak (API) configuration object.  
#### Exceptions
[TetraPak.AspNet.ConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ConfigurationException 'TetraPak.AspNet.ConfigurationException')  
The Tetra Pak (API) configuration object could not be obtained  
#### See Also
- [TryGetTetraPakApiConfig(ControllerBase, TetraPakApiConfig?)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_TryGetTetraPakApiConfig(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_AspNet_Api_Auth_TetraPakApiConfig_) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.TryGetTetraPakApiConfig(Microsoft.AspNetCore.Mvc.ControllerBase, TetraPak.AspNet.Api.Auth.TetraPakApiConfig?)')
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_InternalServerError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception)'></a>
## ControllerBaseExtensions.InternalServerError(ControllerBase, Exception) Method
Constructs and returns an [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') with status code 500  
([System.Net.HttpStatusCode.InternalServerError](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode.InternalServerError 'System.Net.HttpStatusCode.InternalServerError')) to reflect an internal/unexpected error in the service.  
```csharp
public static Microsoft.AspNetCore.Mvc.ActionResult InternalServerError(this Microsoft.AspNetCore.Mvc.ControllerBase self, System.Exception error);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_InternalServerError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_InternalServerError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception)_error'></a>
`error` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
The exception to be reflected.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') object.  
#### See Also
- [RespondError(ControllerBase, Exception)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondError(Microsoft.AspNetCore.Mvc.ControllerBase, System.Exception)')
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogDebug(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)'></a>
## ControllerBaseExtensions.LogDebug(ControllerBase, string, string?) Method
Safely submits a message to the logs with log level [Microsoft.Extensions.Logging.LogLevel.Debug](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Debug 'Microsoft.Extensions.Logging.LogLevel.Debug').   
```csharp
public static void LogDebug(this Microsoft.AspNetCore.Mvc.ControllerBase self, string message, string? messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogDebug(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogDebug(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The message to be logged.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogDebug(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A unique string value for tracking a request/response (mainly for diagnostics purposes).  
  
### Remarks
If no logging is configured the call will simply be ignored.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception_string__string_)'></a>
## ControllerBaseExtensions.LogError(ControllerBase, Exception, string?, string?) Method
Safely submits an exception (and, optionally, a message) to the logs with log level [Microsoft.Extensions.Logging.LogLevel.Error](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Error 'Microsoft.Extensions.Logging.LogLevel.Error').   
```csharp
public static void LogError(this Microsoft.AspNetCore.Mvc.ControllerBase self, System.Exception exception, string? message=null, string? messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception_string__string_)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception_string__string_)_exception'></a>
`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
The exception to be logged.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception_string__string_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The message to be logged.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception_string__string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A unique string value for tracking a request/response (mainly for diagnostics purposes).  
  
### Remarks
If no logging is configured the call will simply be ignored.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogInformation(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)'></a>
## ControllerBaseExtensions.LogInformation(ControllerBase, string, string?) Method
Safely submits a message to the logs with log level [Microsoft.Extensions.Logging.LogLevel.Information](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Information 'Microsoft.Extensions.Logging.LogLevel.Information').   
```csharp
public static void LogInformation(this Microsoft.AspNetCore.Mvc.ControllerBase self, string message, string? messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogInformation(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogInformation(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The message to be logged.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogInformation(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A unique string value for tracking a request/response (mainly for diagnostics purposes).  
  
### Remarks
If no logging is configured the call will simply be ignored.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogTrace(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)'></a>
## ControllerBaseExtensions.LogTrace(ControllerBase, string, string?) Method
Safely submits a message to the logs with log level [Microsoft.Extensions.Logging.LogLevel.Trace](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Trace 'Microsoft.Extensions.Logging.LogLevel.Trace').   
```csharp
public static void LogTrace(this Microsoft.AspNetCore.Mvc.ControllerBase self, string message, string? messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogTrace(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogTrace(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The message to be logged.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogTrace(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A unique string value for tracking a request/response (mainly for diagnostics purposes).  
  
### Remarks
If no logging is configured the call will simply be ignored.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogWarning(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)'></a>
## ControllerBaseExtensions.LogWarning(ControllerBase, string, string?) Method
Safely submits a message to the logs with log level [Microsoft.Extensions.Logging.LogLevel.Warning](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Warning 'Microsoft.Extensions.Logging.LogLevel.Warning').   
```csharp
public static void LogWarning(this Microsoft.AspNetCore.Mvc.ControllerBase self, string message, string? messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogWarning(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogWarning(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The message to be logged.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_LogWarning(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A unique string value for tracking a request/response (mainly for diagnostics purposes).  
  
### Remarks
If no logging is configured the call will simply be ignored.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)'></a>
## ControllerBaseExtensions.RespondAsync&lt;T&gt;(ControllerBase, Outcome&lt;T&gt;, int, ReadChunk?, ResponseDelegate&lt;T&gt;?) Method
Constructs and returns a response from an [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') object (see remarks).   
```csharp
public static System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult> RespondAsync<T>(this Microsoft.AspNetCore.Mvc.ControllerBase self, TetraPak.Outcome<T> outcome, int totalCount=-1, TetraPak.ReadChunk? chunk=null, TetraPak.AspNet.Api.Controllers.ResponseDelegate<T>? responseDelegate=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_T'></a>
`T`  
The [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') of data carried by the [outcome](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_outcome 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondAsync&lt;T&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, TetraPak.Outcome&lt;T&gt;, int, TetraPak.ReadChunk?, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;?).outcome').  
  
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_outcome'></a>
`outcome` [TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[T](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_T 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondAsync&lt;T&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, TetraPak.Outcome&lt;T&gt;, int, TetraPak.ReadChunk?, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')  
The outcome object to be reflected.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_totalCount'></a>
`totalCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
(optional)<br/>  
The total number of items available from service.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_chunk'></a>
`chunk` [TetraPak.ReadChunk](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ReadChunk 'TetraPak.ReadChunk')  
(optional)<br/>  
A [TetraPak.ReadChunk](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ReadChunk 'TetraPak.ReadChunk') object specifying the data requested.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_responseDelegate'></a>
`responseDelegate` [TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;](TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_(object).md 'TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;(object)')[T](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_T 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondAsync&lt;T&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, TetraPak.Outcome&lt;T&gt;, int, TetraPak.ReadChunk?, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;?).T')[&gt;](TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_(object).md 'TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;(object)')  
(optional)<br/>  
A delegate tobe called for custom (successful) [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') construction.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') object.  
### Remarks
This method automatically resolves whether the outcome is a success or failure and constructs  
a well-formed response, as per Tetra Pak API recommendations, from it. Relying on this method  
for constructing responses will relieve you from having to write the corresponding boiler plate  
code yourself. Also, should Tetra Pak recommendations change you can simply upgrade the SDK  
tp stay current.   




  
If the [outcome](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_outcome 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondAsync&lt;T&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, TetraPak.Outcome&lt;T&gt;, int, TetraPak.ReadChunk?, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;?).outcome') is unsuccessful the [RespondError(ControllerBase, Exception)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondError(Microsoft.AspNetCore.Mvc.ControllerBase, System.Exception)')  
method will automatically be invoked.  




  
A successful outcome will either delegate the construction to [responseDelegate](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_responseDelegate 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondAsync&lt;T&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, TetraPak.Outcome&lt;T&gt;, int, TetraPak.ReadChunk?, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;?).responseDelegate')  
(when assigned) or dispatch the construction to a suitable "Ok" method (see the "see also" links).   




  
If the [outcome](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_outcome 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondAsync&lt;T&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, TetraPak.Outcome&lt;T&gt;, int, TetraPak.ReadChunk?, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;?).outcome')'s value ([TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value')) is  
an [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') object, the value will automatically be serialized to JSON  
to be included in the response.    
#### See Also
- [RespondOk(ControllerBase, object?, int, ReadChunk?)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase_object__int_TetraPak_ReadChunk_) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondOk(Microsoft.AspNetCore.Mvc.ControllerBase, object?, int, TetraPak.ReadChunk?)')
- [RespondOk(ControllerBase, object?, int, ReadChunk?)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase_object__int_TetraPak_ReadChunk_) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondOk(Microsoft.AspNetCore.Mvc.ControllerBase, object?, int, TetraPak.ReadChunk?)')
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception)'></a>
## ControllerBaseExtensions.RespondError(ControllerBase, Exception) Method
Constructs and returns an [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') to reflect an error.  
Please see remarks.  
```csharp
public static Microsoft.AspNetCore.Mvc.ActionResult RespondError(this Microsoft.AspNetCore.Mvc.ControllerBase self, System.Exception error);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception)_error'></a>
`error` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
The exception to be reflected.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') object.  
### Remarks
This method will automatically look for an HTTP status code in the [error](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception)_error 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondError(Microsoft.AspNetCore.Mvc.ControllerBase, System.Exception).error').  
If none can be resolved the [InternalServerError(ControllerBase, Exception)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_InternalServerError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.InternalServerError(Microsoft.AspNetCore.Mvc.ControllerBase, System.Exception)') method is invoked, to  
produce a generic status code of 500 ([System.Net.HttpStatusCode.InternalServerError](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode.InternalServerError 'System.Net.HttpStatusCode.InternalServerError')).  
#### See Also
- [RespondError(ControllerBase, HttpStatusCode, Exception)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Net_HttpStatusCode_System_Exception) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondError(Microsoft.AspNetCore.Mvc.ControllerBase, System.Net.HttpStatusCode, System.Exception)')
- [InternalServerError(ControllerBase, Exception)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_InternalServerError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.InternalServerError(Microsoft.AspNetCore.Mvc.ControllerBase, System.Exception)')
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Net_HttpStatusCode_System_Exception)'></a>
## ControllerBaseExtensions.RespondError(ControllerBase, HttpStatusCode, Exception) Method
Constructs and returns an [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') to reflect an error with a specified HTTP status code.  
```csharp
public static Microsoft.AspNetCore.Mvc.ActionResult RespondError(this Microsoft.AspNetCore.Mvc.ControllerBase self, System.Net.HttpStatusCode status, System.Exception error);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Net_HttpStatusCode_System_Exception)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Net_HttpStatusCode_System_Exception)_status'></a>
`status` [System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode')  
The HTTP status code to be returned in response.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Net_HttpStatusCode_System_Exception)_error'></a>
`error` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
The exception to be reflected.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') object.  
#### See Also
- [RespondError(ControllerBase, Exception)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondError(Microsoft.AspNetCore.Mvc.ControllerBase, System.Exception)')
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondErrorExpectedQueryParameter(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)'></a>
## ControllerBaseExtensions.RespondErrorExpectedQueryParameter(ControllerBase, string, string?) Method
Constructs and returns an [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') to reflect an issue with a missing query parameter.  
```csharp
public static Microsoft.AspNetCore.Mvc.ActionResult RespondErrorExpectedQueryParameter(this Microsoft.AspNetCore.Mvc.ControllerBase self, string queryParameterName, string? example=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondErrorExpectedQueryParameter(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondErrorExpectedQueryParameter(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_queryParameterName'></a>
`queryParameterName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the expected (missing) query parameter.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondErrorExpectedQueryParameter(Microsoft_AspNetCore_Mvc_ControllerBase_string_string_)_example'></a>
`example` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A descriptive example, to assist developer in correcting the problem.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase_object__int_TetraPak_ReadChunk_)'></a>
## ControllerBaseExtensions.RespondOk(ControllerBase, object?, int, ReadChunk?) Method
Creates an [Microsoft.AspNetCore.Mvc.OkObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.OkObjectResult 'Microsoft.AspNetCore.Mvc.OkObjectResult') object that produces an Status 200 OK response.  
```csharp
public static Microsoft.AspNetCore.Mvc.OkObjectResult RespondOk(this Microsoft.AspNetCore.Mvc.ControllerBase self, object? data, int totalCount=-1, TetraPak.ReadChunk? chunk=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase_object__int_TetraPak_ReadChunk_)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase_object__int_TetraPak_ReadChunk_)_data'></a>
`data` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The data to be sent back in response (`null` is allowed).   
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase_object__int_TetraPak_ReadChunk_)_totalCount'></a>
`totalCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
(optional)<br/>  
The total number of items available from service.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase_object__int_TetraPak_ReadChunk_)_chunk'></a>
`chunk` [TetraPak.ReadChunk](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ReadChunk 'TetraPak.ReadChunk')  
(optional)<br/>  
A [TetraPak.ReadChunk](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ReadChunk 'TetraPak.ReadChunk') object specifying the data requested.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.OkObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.OkObjectResult 'Microsoft.AspNetCore.Mvc.OkObjectResult')  
An [Microsoft.AspNetCore.Mvc.OkObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.OkObjectResult 'Microsoft.AspNetCore.Mvc.OkObjectResult') object.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[data](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase_object__int_TetraPak_ReadChunk_)_data 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondOk(Microsoft.AspNetCore.Mvc.ControllerBase, object?, int, TetraPak.ReadChunk?).data') was unassigned.  
            
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase)'></a>
## ControllerBaseExtensions.RespondOk(ControllerBase) Method
Constructs and returns an empty 'OK' (HTTP status code 200) response.  
```csharp
public static Microsoft.AspNetCore.Mvc.OkObjectResult RespondOk(this Microsoft.AspNetCore.Mvc.ControllerBase self);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.OkObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.OkObjectResult 'Microsoft.AspNetCore.Mvc.OkObjectResult')  
An [Microsoft.AspNetCore.Mvc.ObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ObjectResult 'Microsoft.AspNetCore.Mvc.ObjectResult') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_EnumOutcome_T__int)'></a>
## ControllerBaseExtensions.RespondOk&lt;T&gt;(ControllerBase, EnumOutcome&lt;T&gt;, int) Method
Constructs and returns an 'OK' (HTTP status code 200) response from an [TetraPak.EnumOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1 'TetraPak.EnumOutcome`1') object.   
```csharp
public static Microsoft.AspNetCore.Mvc.OkObjectResult RespondOk<T>(this Microsoft.AspNetCore.Mvc.ControllerBase self, TetraPak.EnumOutcome<T> outcome, int totalCount=-1);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_EnumOutcome_T__int)_T'></a>
`T`  
The type of data items in response.  
  
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_EnumOutcome_T__int)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_EnumOutcome_T__int)_outcome'></a>
`outcome` [TetraPak.EnumOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1 'TetraPak.EnumOutcome`1')[T](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_EnumOutcome_T__int)_T 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondOk&lt;T&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, TetraPak.EnumOutcome&lt;T&gt;, int).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1 'TetraPak.EnumOutcome`1')  
The [TetraPak.EnumOutcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1 'TetraPak.EnumOutcome`1') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_EnumOutcome_T__int)_totalCount'></a>
`totalCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
(optional; default=[read from [TetraPak.EnumOutcome&lt;&gt;.Count](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1.Count 'TetraPak.EnumOutcome`1.Count')])<br/>  
Specifies a (custom) total count value. Use when the value from [outcome](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_EnumOutcome_T__int)_outcome 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondOk&lt;T&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, TetraPak.EnumOutcome&lt;T&gt;, int).outcome') is incorrect.    
  
#### Returns
[Microsoft.AspNetCore.Mvc.OkObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.OkObjectResult 'Microsoft.AspNetCore.Mvc.OkObjectResult')  
An [Microsoft.AspNetCore.Mvc.ObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ObjectResult 'Microsoft.AspNetCore.Mvc.ObjectResult') object.  
#### See Also
- [TetraPak.AspNet.ApiDataResponse&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ApiDataResponse-1 'TetraPak.AspNet.ApiDataResponse`1')
- [RespondOk(ControllerBase, object?, int, ReadChunk?)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase_object__int_TetraPak_ReadChunk_) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondOk(Microsoft.AspNetCore.Mvc.ControllerBase, object?, int, TetraPak.ReadChunk?)')
- [RespondOk(ControllerBase, object?, int, ReadChunk?)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase_object__int_TetraPak_ReadChunk_) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondOk(Microsoft.AspNetCore.Mvc.ControllerBase, object?, int, TetraPak.ReadChunk?)')
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_Service(Microsoft_AspNetCore_Mvc_ControllerBase_string_)'></a>
## ControllerBaseExtensions.Service(ControllerBase, string?) Method
Gets a backend service.  
```csharp
public static TetraPak.AspNet.Api.IBackendService Service(this Microsoft.AspNetCore.Mvc.ControllerBase self, string? serviceName=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_Service(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_Service(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_serviceName'></a>
`serviceName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional; default=[see remarks])<br/>  
Identifies the service.   
  
#### Returns
[IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService')  
An object implementing the [IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService') contract.  
#### Exceptions
[TetraPak.AspNet.ConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ConfigurationException 'TetraPak.AspNet.ConfigurationException')  
The backend service could not be resolved.  
Please ensure you haven't misspelled it in service configuration.   
### Remarks
When the [serviceName](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_Service(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_serviceName 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.Service(Microsoft.AspNetCore.Mvc.ControllerBase, string?).serviceName') is omitted it will instead be resolved from naming convention,  
based on the controller's type. As an example; calling this method from a controller of type  
`WeatherServiceController` will assume the requested backend service name is "WeatherService".     
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_Service_TBackendService_(Microsoft_AspNetCore_Mvc_ControllerBase_string_)'></a>
## ControllerBaseExtensions.Service&lt;TBackendService&gt;(ControllerBase, string?) Method
Gets a backend service of a specified [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') (implementing [IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService')).  
```csharp
public static TBackendService Service<TBackendService>(this Microsoft.AspNetCore.Mvc.ControllerBase self, string? serviceName=null)
    where TBackendService : TetraPak.AspNet.Api.IBackendService;
```
#### Type parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_Service_TBackendService_(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_TBackendService'></a>
`TBackendService`  
The [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') of backend service to be obtained  
(type must implement [IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService') contract).  
  
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_Service_TBackendService_(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_Service_TBackendService_(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_serviceName'></a>
`serviceName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional; default=[see remarks])<br/>  
Identifies the service.   
  
#### Returns
[TBackendService](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_Service_TBackendService_(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_TBackendService 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.Service&lt;TBackendService&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, string?).TBackendService')  
A backend service object of type [TBackendService](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_Service_TBackendService_(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_TBackendService 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.Service&lt;TBackendService&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, string?).TBackendService').  
#### Exceptions
[TetraPak.AspNet.ConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ConfigurationException 'TetraPak.AspNet.ConfigurationException')  
The backend service could not be resolved.  
Please ensure you haven't misspelled it in service configuration.   
### Remarks
Use this method to obtain a backend service with its own custom implementation  
of the [ServiceEndpoints](TetraPak_AspNet_Api_ServiceEndpoints.md 'TetraPak.AspNet.Api.ServiceEndpoints') interface.  




  
When the [serviceName](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_Service_TBackendService_(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_serviceName 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.Service&lt;TBackendService&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, string?).serviceName') is omitted it will instead be resolved from naming convention,  
based on the controller's type. As an example; calling this method from a controller of type  
`WeatherServiceController` will assume the requested backend service name is "WeatherService".     
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_TryGetTetraPakApiConfig(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_AspNet_Api_Auth_TetraPakApiConfig_)'></a>
## ControllerBaseExtensions.TryGetTetraPakApiConfig(ControllerBase, TetraPakApiConfig?) Method
Attempts obtaining the Tetra Pak (API) configuration object.  
```csharp
public static bool TryGetTetraPakApiConfig(this Microsoft.AspNetCore.Mvc.ControllerBase self, out TetraPak.AspNet.Api.Auth.TetraPakApiConfig? config);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_TryGetTetraPakApiConfig(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_AspNet_Api_Auth_TetraPakApiConfig_)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_TryGetTetraPakApiConfig(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_AspNet_Api_Auth_TetraPakApiConfig_)_config'></a>
`config` [TetraPakApiConfig](TetraPak_AspNet_Api_Auth_TetraPakApiConfig.md 'TetraPak.AspNet.Api.Auth.TetraPakApiConfig')  
Passes back the Tetra Pak (API) configuration object (on success).  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the Tetra Pak (API) configuration object could be obtained; otherwise `false`.  
            
#### See Also
- [GetTetraPakConfig(ControllerBase)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_GetTetraPakConfig(Microsoft_AspNetCore_Mvc_ControllerBase) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.GetTetraPakConfig(Microsoft.AspNetCore.Mvc.ControllerBase)')
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_UnauthorizedError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception)'></a>
## ControllerBaseExtensions.UnauthorizedError(ControllerBase, Exception) Method
Constructs and returns an [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') to reflect an unauthorized request.  
```csharp
public static Microsoft.AspNetCore.Mvc.ActionResult UnauthorizedError(this Microsoft.AspNetCore.Mvc.ControllerBase self, System.Exception error);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_UnauthorizedError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') object.  
  
<a name='TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_UnauthorizedError(Microsoft_AspNetCore_Mvc_ControllerBase_System_Exception)_error'></a>
`error` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
The exception to be reflected.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') object.  
  
