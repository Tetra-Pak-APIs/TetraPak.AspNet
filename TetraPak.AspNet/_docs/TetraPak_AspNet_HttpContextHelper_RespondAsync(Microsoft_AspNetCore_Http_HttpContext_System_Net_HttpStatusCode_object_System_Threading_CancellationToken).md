#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[HttpContextHelper](TetraPak_AspNet_HttpContextHelper.md 'TetraPak.AspNet.HttpContextHelper')
## HttpContextHelper.RespondAsync(HttpContext, HttpStatusCode, object, CancellationToken) Method
Writes a HTTP response.  
```csharp
public static System.Threading.Tasks.Task RespondAsync(this Microsoft.AspNetCore.Http.HttpContext context, System.Net.HttpStatusCode statusCode, object content=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_object_System_Threading_CancellationToken)_context'></a>
`context` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
The [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
  
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_object_System_Threading_CancellationToken)_statusCode'></a>
`statusCode` [System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode')  
The status code to be returned.  
  
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_object_System_Threading_CancellationToken)_content'></a>
`content` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
(optional)<br />  
Content to be returned (objects will be JSON serialized).  
  
<a name='TetraPak_AspNet_HttpContextHelper_RespondAsync(Microsoft_AspNetCore_Http_HttpContext_System_Net_HttpStatusCode_object_System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
(optional)<br />  
A cancellation token.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
