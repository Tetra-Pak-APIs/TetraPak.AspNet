#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Controllers](TetraPak_AspNet_Api_Controllers.md 'TetraPak.AspNet.Api.Controllers')
## TetraPakApiController Class
```csharp
public class TetraPakApiController : Microsoft.AspNetCore.Mvc.ControllerBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase') &#129106; TetraPakApiController  
### Properties
<a name='TetraPak_AspNet_Api_Controllers_TetraPakApiController_MessageId'></a>
## TetraPakApiController.MessageId Property
Gets a message id for the request.   
```csharp
public string MessageId { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
### Methods
<a name='TetraPak_AspNet_Api_Controllers_TetraPakApiController_RespondAsync_T_(TetraPak_Outcome_T__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_)'></a>
## TetraPakApiController.RespondAsync&lt;T&gt;(Outcome&lt;T&gt;, ResponseDelegate&lt;T&gt;) Method
Transforms an [TetraPak.Outcome](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome 'TetraPak.Outcome') to an [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') response,  
including errors, in a format adhering to Tetra Pak's business API guidelines.   
```csharp
protected System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult> RespondAsync<T>(TetraPak.Outcome<T> outcome, TetraPak.AspNet.Api.Controllers.ResponseDelegate<T> responseDelegate=null);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_Controllers_TetraPakApiController_RespondAsync_T_(TetraPak_Outcome_T__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_)_T'></a>
`T`  
The type of value expected by the [outcome](TetraPak_AspNet_Api_Controllers_TetraPakApiController.md#TetraPak_AspNet_Api_Controllers_TetraPakApiController_RespondAsync_T_(TetraPak_Outcome_T__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_)_outcome 'TetraPak.AspNet.Api.Controllers.TetraPakApiController.RespondAsync&lt;T&gt;(TetraPak.Outcome&lt;T&gt;, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;).outcome').  
  
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_TetraPakApiController_RespondAsync_T_(TetraPak_Outcome_T__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_)_outcome'></a>
`outcome` [TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[T](TetraPak_AspNet_Api_Controllers_TetraPakApiController.md#TetraPak_AspNet_Api_Controllers_TetraPakApiController_RespondAsync_T_(TetraPak_Outcome_T__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_)_T 'TetraPak.AspNet.Api.Controllers.TetraPakApiController.RespondAsync&lt;T&gt;(TetraPak.Outcome&lt;T&gt;, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')  
The outcome to be transformed into an [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult').   
  
<a name='TetraPak_AspNet_Api_Controllers_TetraPakApiController_RespondAsync_T_(TetraPak_Outcome_T__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_)_responseDelegate'></a>
`responseDelegate` [TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Controllers.ResponseDelegate-1 'TetraPak.AspNet.Api.Controllers.ResponseDelegate`1')[T](TetraPak_AspNet_Api_Controllers_TetraPakApiController.md#TetraPak_AspNet_Api_Controllers_TetraPakApiController_RespondAsync_T_(TetraPak_Outcome_T__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_)_T 'TetraPak.AspNet.Api.Controllers.TetraPakApiController.RespondAsync&lt;T&gt;(TetraPak.Outcome&lt;T&gt;, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Controllers.ResponseDelegate-1 'TetraPak.AspNet.Api.Controllers.ResponseDelegate`1')  
(optional)<br />  
A [TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Controllers.ResponseDelegate-1 'TetraPak.AspNet.Api.Controllers.ResponseDelegate`1') to be called before transforming the value/error into a  
correctly formed [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') response (see remarks).  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult') instance.  
### Remarks
The [responseDelegate](TetraPak_AspNet_Api_Controllers_TetraPakApiController.md#TetraPak_AspNet_Api_Controllers_TetraPakApiController_RespondAsync_T_(TetraPak_Outcome_T__TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_)_responseDelegate 'TetraPak.AspNet.Api.Controllers.TetraPakApiController.RespondAsync&lt;T&gt;(TetraPak.Outcome&lt;T&gt;, TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;).responseDelegate') should be expected to handle these three types of values,  
passed in via its "data" parameter:  
<list>
  <item>
    <term>
                object
                </term>
    <description>
                Any value carried by the <paramref name="outcome" /> when the outcome type is not a <see cref="T:System.Net.Http.HttpResponseMessage" />. 
                </description>
  </item>
  <item>
    <term>
      <see cref="T:System.Net.Http.HttpResponseMessage" />
    </term>
    <description>
                The raw response message carried by the <paramref name="outcome" />. The delegate is responsible for
                downloading the response message content and transform it into  
                </description>
  </item>
</list>
  
