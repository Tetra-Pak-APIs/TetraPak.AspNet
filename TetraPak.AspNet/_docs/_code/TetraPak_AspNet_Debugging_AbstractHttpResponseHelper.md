#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## AbstractHttpResponseHelper Class
Convenient methods for working with [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse')s.  
```csharp
public static class AbstractHttpResponseHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AbstractHttpResponseHelper  
### Methods
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToAbstractHttpResponse(Microsoft_AspNetCore_Http_HttpResponse_TetraPak_AspNet_Debugging_AbstractHttpRequest_)'></a>
## AbstractHttpResponseHelper.ToAbstractHttpResponse(HttpResponse, AbstractHttpRequest?) Method
Constructs and returns a [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse') representation of a  
[Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
```csharp
public static TetraPak.AspNet.Debugging.AbstractHttpResponse ToAbstractHttpResponse(this Microsoft.AspNetCore.Http.HttpResponse response, TetraPak.AspNet.Debugging.AbstractHttpRequest? request);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToAbstractHttpResponse(Microsoft_AspNetCore_Http_HttpResponse_TetraPak_AspNet_Debugging_AbstractHttpRequest_)_response'></a>
`response` [Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse')  
The response to be represented as a [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse').  
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToAbstractHttpResponse(Microsoft_AspNetCore_Http_HttpResponse_TetraPak_AspNet_Debugging_AbstractHttpRequest_)_request'></a>
`request` [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')  
(optional)<br/>  
A request (resulting in the response).   
  
#### Returns
[AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse')  
A [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToAbstractHttpResponse(System_Net_WebResponse_TetraPak_AspNet_Debugging_AbstractHttpRequest_)'></a>
## AbstractHttpResponseHelper.ToAbstractHttpResponse(WebResponse, AbstractHttpRequest?) Method
Constructs and returns a [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse') representation of a  
[Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
```csharp
public static TetraPak.AspNet.Debugging.AbstractHttpResponse ToAbstractHttpResponse(this System.Net.WebResponse response, TetraPak.AspNet.Debugging.AbstractHttpRequest? request=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToAbstractHttpResponse(System_Net_WebResponse_TetraPak_AspNet_Debugging_AbstractHttpRequest_)_response'></a>
`response` [System.Net.WebResponse](https://docs.microsoft.com/en-us/dotnet/api/System.Net.WebResponse 'System.Net.WebResponse')  
The response to be represented as a [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse').  
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToAbstractHttpResponse(System_Net_WebResponse_TetraPak_AspNet_Debugging_AbstractHttpRequest_)_request'></a>
`request` [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')  
(optional)<br/>  
A request (resulting in the response).   
  
#### Returns
[AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse')  
A [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToAbstractHttpResponseAsync(System_Net_Http_HttpResponseMessage)'></a>
## AbstractHttpResponseHelper.ToAbstractHttpResponseAsync(HttpResponseMessage) Method
Constructs and returns a [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse') representation of a  
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage').  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.Debugging.AbstractHttpResponse> ToAbstractHttpResponseAsync(this System.Net.Http.HttpResponseMessage response);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_AbstractHttpResponseHelper_ToAbstractHttpResponseAsync(System_Net_Http_HttpResponseMessage)_response'></a>
`response` [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')  
The response to be represented as a [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse')
  
