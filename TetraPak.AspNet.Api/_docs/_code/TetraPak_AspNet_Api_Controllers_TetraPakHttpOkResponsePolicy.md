#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Controllers](TetraPak_AspNet_Api_Controllers.md 'TetraPak.AspNet.Api.Controllers')
## TetraPakHttpOkResponsePolicy Class
The Tetra Pak default HTTP response policy.   
```csharp
public class TetraPakHttpOkResponsePolicy :
TetraPak.AspNet.Api.Controllers.IHttpOkResponsePolicy
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakHttpOkResponsePolicy  

Implements [IHttpOkResponsePolicy](TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy.md 'TetraPak.AspNet.Api.Controllers.IHttpOkResponsePolicy')  
### Properties
<a name='TetraPak_AspNet_Api_Controllers_TetraPakHttpOkResponsePolicy_ForceCreatedLocationInBody'></a>
## TetraPakHttpOkResponsePolicy.ForceCreatedLocationInBody Property
Gets or sets a value that specifies whether a "Created" (single) resource will be  
reflected in response body (not in the "Locator" header). The default is `false`,  
to comply with standard HTTP/REST principles.  
```csharp
public bool ForceCreatedLocationInBody { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
### Methods
<a name='TetraPak_AspNet_Api_Controllers_TetraPakHttpOkResponsePolicy_ApplyHttpResponsePolicy(Microsoft_AspNetCore_Http_HttpContext_Microsoft_AspNetCore_Mvc_OkObjectResult)'></a>
## TetraPakHttpOkResponsePolicy.ApplyHttpResponsePolicy(HttpContext, OkObjectResult) Method
Invoked automatically to allow setting the correct HTTP status code for a response.   
```csharp
public Microsoft.AspNetCore.Mvc.OkObjectResult ApplyHttpResponsePolicy(Microsoft.AspNetCore.Http.HttpContext context, Microsoft.AspNetCore.Mvc.OkObjectResult response);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_TetraPakHttpOkResponsePolicy_ApplyHttpResponsePolicy(Microsoft_AspNetCore_Http_HttpContext_Microsoft_AspNetCore_Mvc_OkObjectResult)_context'></a>
`context` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The HTTP request/response context.  
  
<a name='TetraPak_AspNet_Api_Controllers_TetraPakHttpOkResponsePolicy_ApplyHttpResponsePolicy(Microsoft_AspNetCore_Http_HttpContext_Microsoft_AspNetCore_Mvc_OkObjectResult)_response'></a>
`response` [Microsoft.AspNetCore.Mvc.OkObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.OkObjectResult 'Microsoft.AspNetCore.Mvc.OkObjectResult')  
The HTTP result whose [Microsoft.AspNetCore.Mvc.ObjectResult.StatusCode](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ObjectResult.StatusCode 'Microsoft.AspNetCore.Mvc.ObjectResult.StatusCode') should be set.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.OkObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.OkObjectResult 'Microsoft.AspNetCore.Mvc.OkObjectResult')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') (typically the [response](TetraPak_AspNet_Api_Controllers_TetraPakHttpOkResponsePolicy.md#TetraPak_AspNet_Api_Controllers_TetraPakHttpOkResponsePolicy_ApplyHttpResponsePolicy(Microsoft_AspNetCore_Http_HttpContext_Microsoft_AspNetCore_Mvc_OkObjectResult)_response 'TetraPak.AspNet.Api.Controllers.TetraPakHttpOkResponsePolicy.ApplyHttpResponsePolicy(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Mvc.OkObjectResult).response')).  

Implements [ApplyHttpResponsePolicy(HttpContext, OkObjectResult)](TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy.md#TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy_ApplyHttpResponsePolicy(Microsoft_AspNetCore_Http_HttpContext_Microsoft_AspNetCore_Mvc_OkObjectResult) 'TetraPak.AspNet.Api.Controllers.IHttpOkResponsePolicy.ApplyHttpResponsePolicy(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Mvc.OkObjectResult)')  
  
