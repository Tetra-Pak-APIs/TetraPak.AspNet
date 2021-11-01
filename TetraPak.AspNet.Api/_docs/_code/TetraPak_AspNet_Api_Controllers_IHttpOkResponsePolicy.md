#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Controllers](TetraPak_AspNet_Api_Controllers.md 'TetraPak.AspNet.Api.Controllers')
## IHttpOkResponsePolicy Interface
Classes implementing this interface can be used internally to enforce a custom policy  
for successful HTTP response, such as setting the correct ("success") HTTP status code (200-299).    
```csharp
public interface IHttpOkResponsePolicy
```

Derived  
&#8627; [TetraPakHttpOkResponsePolicy](TetraPak_AspNet_Api_Controllers_TetraPakHttpOkResponsePolicy.md 'TetraPak.AspNet.Api.Controllers.TetraPakHttpOkResponsePolicy')  
### Methods
<a name='TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy_ApplyHttpResponsePolicy(Microsoft_AspNetCore_Http_HttpContext_Microsoft_AspNetCore_Mvc_OkObjectResult)'></a>
## IHttpOkResponsePolicy.ApplyHttpResponsePolicy(HttpContext, OkObjectResult) Method
Invoked automatically to allow setting the correct HTTP status code for a response.   
```csharp
Microsoft.AspNetCore.Mvc.OkObjectResult ApplyHttpResponsePolicy(Microsoft.AspNetCore.Http.HttpContext context, Microsoft.AspNetCore.Mvc.OkObjectResult response);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy_ApplyHttpResponsePolicy(Microsoft_AspNetCore_Http_HttpContext_Microsoft_AspNetCore_Mvc_OkObjectResult)_context'></a>
`context` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The HTTP request/response context.  
  
<a name='TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy_ApplyHttpResponsePolicy(Microsoft_AspNetCore_Http_HttpContext_Microsoft_AspNetCore_Mvc_OkObjectResult)_response'></a>
`response` [Microsoft.AspNetCore.Mvc.OkObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.OkObjectResult 'Microsoft.AspNetCore.Mvc.OkObjectResult')  
The HTTP result whose [Microsoft.AspNetCore.Mvc.ObjectResult.StatusCode](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ObjectResult.StatusCode 'Microsoft.AspNetCore.Mvc.ObjectResult.StatusCode') should be set.  
  
#### Returns
[Microsoft.AspNetCore.Mvc.OkObjectResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.OkObjectResult 'Microsoft.AspNetCore.Mvc.OkObjectResult')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') (typically the [response](TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy.md#TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy_ApplyHttpResponsePolicy(Microsoft_AspNetCore_Http_HttpContext_Microsoft_AspNetCore_Mvc_OkObjectResult)_response 'TetraPak.AspNet.Api.Controllers.IHttpOkResponsePolicy.ApplyHttpResponsePolicy(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Mvc.OkObjectResult).response')).  
  
