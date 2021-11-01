#### [TetraPak.AspNet.Api](index.md 'index')
## TetraPak.AspNet.Api.Controllers Namespace

| Classes | |
| :--- | :--- |
| [BusinessApiController](TetraPak_AspNet_Api_Controllers_BusinessApiController.md 'TetraPak.AspNet.Api.Controllers.BusinessApiController') | Business controller to provide convenient Tetra Pak integration.<br/>Most of the properties and methods found in this class are also available<br/>as extension methods of [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') so deriving from this class<br/>is mainly a matter of style and convenience. <br/> |
| [ControllerBaseExtensions](TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md 'TetraPak.AspNet.Api.Controllers.ControllerBaseExtensions') | Convenient extension methods for [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase').<br/> |
| [HttpOkResponsePolicyHelper](TetraPak_AspNet_Api_Controllers_HttpOkResponsePolicyHelper.md 'TetraPak.AspNet.Api.Controllers.HttpOkResponsePolicyHelper') | Adds a convenient extension method for registering a custom [IHttpOkResponsePolicy](TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy.md 'TetraPak.AspNet.Api.Controllers.IHttpOkResponsePolicy').<br/> |
| [TetraPakHttpOkResponsePolicy](TetraPak_AspNet_Api_Controllers_TetraPakHttpOkResponsePolicy.md 'TetraPak.AspNet.Api.Controllers.TetraPakHttpOkResponsePolicy') | The Tetra Pak default HTTP response policy. <br/> |

| Interfaces | |
| :--- | :--- |
| [IHttpOkResponsePolicy](TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy.md 'TetraPak.AspNet.Api.Controllers.IHttpOkResponsePolicy') | Classes implementing this interface can be used internally to enforce a custom policy<br/>for successful HTTP response, such as setting the correct ("success") HTTP status code (200-299).  <br/> |

| Enums | |
| :--- | :--- |
| [HttpOkStatusCode](TetraPak_AspNet_Api_Controllers_HttpOkStatusCode.md 'TetraPak.AspNet.Api.Controllers.HttpOkStatusCode') | Contains the values of successful status codes defined for HTTP.<br/> |

| Delegates | |
| :--- | :--- |
| [ResponseDelegate&lt;T&gt;(object)](TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_(object).md 'TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;(object)') | This type of delegate can be used to customize a response,<br/>before it is being transformed to the recommended Tetra Pak format and sent to the client.<br/> |
