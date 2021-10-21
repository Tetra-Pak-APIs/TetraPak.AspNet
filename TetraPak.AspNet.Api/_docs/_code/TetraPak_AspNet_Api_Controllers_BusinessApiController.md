#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Controllers](TetraPak_AspNet_Api_Controllers.md 'TetraPak.AspNet.Api.Controllers')
## BusinessApiController Class
Business controller to provide convenient Tetra Pak integration.  
Most of the properties and methods found in this class are also available  
as extension methods of [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') so deriving from this class  
is mainly a matter of style and convenience.   
```csharp
public class BusinessApiController : Microsoft.AspNetCore.Mvc.ControllerBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') &#129106; BusinessApiController  
### Constructors
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_BusinessApiController(TetraPak_AspNet_TetraPakConfig)'></a>
## BusinessApiController.BusinessApiController(TetraPakConfig) Constructor
Initializes the [BusinessApiController](TetraPak_AspNet_Api_Controllers_BusinessApiController.md 'TetraPak.AspNet.Api.Controllers.BusinessApiController').  
```csharp
public BusinessApiController(TetraPak.AspNet.TetraPakConfig tetraPakConfig);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_BusinessApiController(TetraPak_AspNet_TetraPakConfig)_tetraPakConfig'></a>
`tetraPakConfig` [TetraPak.AspNet.TetraPakConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig 'TetraPak.AspNet.TetraPakConfig')  
The Tetra Pak integration configuration.  
  
  
### Properties
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_AmbientData'></a>
## BusinessApiController.AmbientData Property
Gets the ambient data object.   
```csharp
protected TetraPak.AspNet.AmbientData? AmbientData { get; }
```
#### Property Value
[TetraPak.AspNet.AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AmbientData 'TetraPak.AspNet.AmbientData')
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_Logger'></a>
## BusinessApiController.Logger Property
Gets a logger provider.  
```csharp
protected Microsoft.Extensions.Logging.ILogger? Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_MessageId'></a>
## BusinessApiController.MessageId Property
Gets a unique string value for tracking a request/response (mainly for diagnostics purposes).  
```csharp
public string? MessageId { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_TetraPakConfig'></a>
## BusinessApiController.TetraPakConfig Property
Gets the Tetra Pak integration configuration.  
```csharp
protected TetraPak.AspNet.TetraPakConfig? TetraPakConfig { get; }
```
#### Property Value
[TetraPak.AspNet.TetraPakConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig 'TetraPak.AspNet.TetraPakConfig')
  
### Methods
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_GetAccessTokenAsync()'></a>
## BusinessApiController.GetAccessTokenAsync() Method
Gets the request access token.   
```csharp
protected System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_Ok(object_)'></a>
## BusinessApiController.Ok(object?) Method
Overrides the [Microsoft.AspNetCore.Mvc.ControllerBase.Ok](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase.Ok 'Microsoft.AspNetCore.Mvc.ControllerBase.Ok') method to instead invoke the  
[RespondOk(ControllerBase, object?, int, ReadChunk?)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase_object__int_TetraPak_ReadChunk_) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondOk(Microsoft.AspNetCore.Mvc.ControllerBase, object?, int, TetraPak.ReadChunk?)')  
method.  
```csharp
public override Microsoft.AspNetCore.Mvc.OkObjectResult Ok(object? data);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_Ok(object_)_data'></a>
`data` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The data to be sent in the response.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.OkObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.OkObjectResult 'Microsoft.AspNetCore.Mvc.OkObjectResult')  
An [Microsoft.AspNetCore.Mvc.OkObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.OkObjectResult 'Microsoft.AspNetCore.Mvc.OkObjectResult').  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_OnRespondError(System_Net_HttpStatusCode_System_Exception)'></a>
## BusinessApiController.OnRespondError(HttpStatusCode, Exception) Method
[virtual method]<br/>  
Invoked automatically by other methods to respond with an error.  
The default implementation simply invokes [RespondError(Exception)](TetraPak_AspNet_Api_Controllers_BusinessApiController.md#TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondError(System_Exception) 'TetraPak.AspNet.Api.Controllers.BusinessApiController.RespondError(System.Exception)').    
```csharp
protected virtual Microsoft.AspNetCore.Mvc.ActionResult OnRespondError(System.Net.HttpStatusCode status, System.Exception error);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_OnRespondError(System_Net_HttpStatusCode_System_Exception)_status'></a>
`status` [System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode')  
The [System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode') to be returned to client.  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_OnRespondError(System_Net_HttpStatusCode_System_Exception)_error'></a>
`error` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
The causing exception.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult').  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondAsync_T_(TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)'></a>
## BusinessApiController.RespondAsync&lt;T&gt;(Outcome&lt;T&gt;, int, ReadChunk?, ResponseDelegate&lt;T&gt;?) Method
Please see [RespondAsync&lt;T&gt;(ControllerBase, Outcome&lt;T&gt;, int, ReadChunk?, ResponseDelegate&lt;T&gt;?)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondAsync_T_(Microsoft_AspNetCore_Mvc_ControllerBase_TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondAsync&lt;T&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, TetraPak.Outcome&lt;T&gt;, int, TetraPak.ReadChunk?, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;?)')
```csharp
protected System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult> RespondAsync<T>(TetraPak.Outcome<T> outcome, int totalCount=-1, TetraPak.ReadChunk? chunk=null, TetraPak.AspNet.Api.Controllers.ResponseDelegate<T>? responseDelegate=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondAsync_T_(TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondAsync_T_(TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_outcome'></a>
`outcome` [TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[T](TetraPak_AspNet_Api_Controllers_BusinessApiController.md#TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondAsync_T_(TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_T 'TetraPak.AspNet.Api.Controllers.BusinessApiController.RespondAsync&lt;T&gt;(TetraPak.Outcome&lt;T&gt;, int, TetraPak.ReadChunk?, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;?).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondAsync_T_(TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_totalCount'></a>
`totalCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondAsync_T_(TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_chunk'></a>
`chunk` [TetraPak.ReadChunk](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ReadChunk 'TetraPak.ReadChunk')  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondAsync_T_(TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_responseDelegate'></a>
`responseDelegate` [TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;](TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_(object).md 'TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;(object)')[T](TetraPak_AspNet_Api_Controllers_BusinessApiController.md#TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondAsync_T_(TetraPak_Outcome_T__int_TetraPak_ReadChunk__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T__)_T 'TetraPak.AspNet.Api.Controllers.BusinessApiController.RespondAsync&lt;T&gt;(TetraPak.Outcome&lt;T&gt;, int, TetraPak.ReadChunk?, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;?).T')[&gt;](TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_(object).md 'TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;(object)')  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondError(System_Exception)'></a>
## BusinessApiController.RespondError(Exception) Method
```csharp
protected Microsoft.AspNetCore.Mvc.ActionResult RespondError(System.Exception error);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondError(System_Exception)_error'></a>
`error` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
  
#### Returns
[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondErrorExpectedQueryParameter(string_string_)'></a>
## BusinessApiController.RespondErrorExpectedQueryParameter(string, string?) Method
Responds with standard error format reflecting an issue with query parameters.   
```csharp
protected Microsoft.AspNetCore.Mvc.ActionResult RespondErrorExpectedQueryParameter(string queryParameterName, string? example=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondErrorExpectedQueryParameter(string_string_)_queryParameterName'></a>
`queryParameterName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the query parameter causing the issue.  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondErrorExpectedQueryParameter(string_string_)_example'></a>
`example` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
An example for expected parameter use/format.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult').  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondInternalServerError(System_Exception)'></a>
## BusinessApiController.RespondInternalServerError(Exception) Method
Responds with standard error format reflecting a unexpected/unhandled technical issue.   
```csharp
protected Microsoft.AspNetCore.Mvc.ActionResult RespondInternalServerError(System.Exception error);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondInternalServerError(System_Exception)_error'></a>
`error` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
The exception causing the issue.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult').  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondOk_T_(TetraPak_EnumOutcome_T__int)'></a>
## BusinessApiController.RespondOk&lt;T&gt;(EnumOutcome&lt;T&gt;, int) Method
Responds with standard format, reflecting a successful request.  
This method just wraps the [RespondOk(ControllerBase, object?, int, ReadChunk?)](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions_RespondOk(Microsoft_AspNetCore_Mvc_ControllerBase_object__int_TetraPak_ReadChunk_) 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions.RespondOk(Microsoft.AspNetCore.Mvc.ControllerBase, object?, int, TetraPak.ReadChunk?)').   
```csharp
protected Microsoft.AspNetCore.Mvc.OkObjectResult RespondOk<T>(TetraPak.EnumOutcome<T> outcome, int totalCount=-1);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondOk_T_(TetraPak_EnumOutcome_T__int)_T'></a>
`T`  
The type of requested items.  
  
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondOk_T_(TetraPak_EnumOutcome_T__int)_outcome'></a>
`outcome` [TetraPak.EnumOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1 'TetraPak.EnumOutcome`1')[T](TetraPak_AspNet_Api_Controllers_BusinessApiController.md#TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondOk_T_(TetraPak_EnumOutcome_T__int)_T 'TetraPak.AspNet.Api.Controllers.BusinessApiController.RespondOk&lt;T&gt;(TetraPak.EnumOutcome&lt;T&gt;, int).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1 'TetraPak.EnumOutcome`1')  
The outcome, carrying a collection of requested items, to be sent to client.  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondOk_T_(TetraPak_EnumOutcome_T__int)_totalCount'></a>
`totalCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
(optional; default=[number of items in [outcome](TetraPak_AspNet_Api_Controllers_BusinessApiController.md#TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondOk_T_(TetraPak_EnumOutcome_T__int)_outcome 'TetraPak.AspNet.Api.Controllers.BusinessApiController.RespondOk&lt;T&gt;(TetraPak.EnumOutcome&lt;T&gt;, int).outcome')])<br/>  
The total number of items available.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.OkObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.OkObjectResult 'Microsoft.AspNetCore.Mvc.OkObjectResult')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a collection of items or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondUnauthorizedError(System_Exception)'></a>
## BusinessApiController.RespondUnauthorizedError(Exception) Method
Responds with standard error format reflecting an unauthorized request issue.   
```csharp
protected Microsoft.AspNetCore.Mvc.ActionResult RespondUnauthorizedError(System.Exception error);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_BusinessApiController_RespondUnauthorizedError(System_Exception)_error'></a>
`error` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
The exception causing the issue.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult').  
  
