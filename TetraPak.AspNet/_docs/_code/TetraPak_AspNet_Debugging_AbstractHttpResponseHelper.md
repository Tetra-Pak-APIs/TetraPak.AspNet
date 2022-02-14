#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## AbstractHttpResponseHelper Class
Convenient methods for working with [GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse')s.  
```csharp
public static class AbstractHttpResponseHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AbstractHttpResponseHelper  
### Methods
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToGenericHttpResponse(System_Net_WebResponse_TetraPak_AspNet_Debugging_GenericHttpRequest_)'></a>
## AbstractHttpResponseHelper.ToGenericHttpResponse(WebResponse, GenericHttpRequest?) Method
Constructs and returns a [GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse') representation of a  
[Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
```csharp
public static TetraPak.AspNet.Debugging.GenericHttpResponse ToGenericHttpResponse(this System.Net.WebResponse response, TetraPak.AspNet.Debugging.GenericHttpRequest? request=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToGenericHttpResponse(System_Net_WebResponse_TetraPak_AspNet_Debugging_GenericHttpRequest_)_response'></a>
`response` [System.Net.WebResponse](https://docs.microsoft.com/en-us/dotnet/api/System.Net.WebResponse 'System.Net.WebResponse')  
The response to be represented as a [GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse').  
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToGenericHttpResponse(System_Net_WebResponse_TetraPak_AspNet_Debugging_GenericHttpRequest_)_request'></a>
`request` [GenericHttpRequest](TetraPak_AspNet_Debugging_GenericHttpRequest.md 'TetraPak.AspNet.Debugging.GenericHttpRequest')  
(optional)<br/>  
A request (resulting in the response).   
  
#### Returns
[GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse')  
A [GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToGenericHttpResponseAsync(Microsoft_AspNetCore_Http_HttpResponse_TetraPak_AspNet_Debugging_GenericHttpRequest_)'></a>
## AbstractHttpResponseHelper.ToGenericHttpResponseAsync(HttpResponse, GenericHttpRequest?) Method
Constructs and returns a [GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse') representation of a  
[Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.Debugging.GenericHttpResponse> ToGenericHttpResponseAsync(this Microsoft.AspNetCore.Http.HttpResponse response, TetraPak.AspNet.Debugging.GenericHttpRequest? request);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToGenericHttpResponseAsync(Microsoft_AspNetCore_Http_HttpResponse_TetraPak_AspNet_Debugging_GenericHttpRequest_)_response'></a>
`response` [Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse')  
The response to be represented as a [GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse').  
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToGenericHttpResponseAsync(Microsoft_AspNetCore_Http_HttpResponse_TetraPak_AspNet_Debugging_GenericHttpRequest_)_request'></a>
`request` [GenericHttpRequest](TetraPak_AspNet_Debugging_GenericHttpRequest.md 'TetraPak.AspNet.Debugging.GenericHttpRequest')  
(optional)<br/>  
A request (resulting in the response).   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToGenericHttpResponseAsync(System_Net_Http_HttpResponseMessage_string_)'></a>
## AbstractHttpResponseHelper.ToGenericHttpResponseAsync(HttpResponseMessage, string?) Method
Constructs and returns a [GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse') representation of a  
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage').  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.Debugging.GenericHttpResponse> ToGenericHttpResponseAsync(this System.Net.Http.HttpResponseMessage response, string? messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToGenericHttpResponseAsync(System_Net_Http_HttpResponseMessage_string_)_response'></a>
`response` [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')  
The response to be represented as a [GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse').  
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToGenericHttpResponseAsync(System_Net_Http_HttpResponseMessage_string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A unique string value for tracking a request/response (mainly for diagnostics purposes).  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse')
  
