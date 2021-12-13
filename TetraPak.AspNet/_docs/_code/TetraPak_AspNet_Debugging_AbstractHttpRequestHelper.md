#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## AbstractHttpRequestHelper Class
Convenient methods for working with [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')s.  
```csharp
public static class AbstractHttpRequestHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AbstractHttpRequestHelper  
### Methods
<a name='TetraPak_AspNet_Debugging_AbstractHttpRequestHelper_GetUri(Microsoft_AspNetCore_Http_HttpRequest_)'></a>
## AbstractHttpRequestHelper.GetUri(HttpRequest?) Method
Constructs and returns the textual representation of the [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')'s URI (if any).   
```csharp
public static System.Uri? GetUri(this Microsoft.AspNetCore.Http.HttpRequest? request);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_AbstractHttpRequestHelper_GetUri(Microsoft_AspNetCore_Http_HttpRequest_)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest') to obtain the URI from.  
  
#### Returns
[System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') representation of the request's URI, if any; otherwise `null`.  
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpRequestHelper_ToAbstractHttpRequestAsync(Microsoft_AspNetCore_Http_HttpRequest)'></a>
## AbstractHttpRequestHelper.ToAbstractHttpRequestAsync(HttpRequest) Method
Constructs and returns a [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest') representation of a  
[Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
```csharp
public static TetraPak.AspNet.Debugging.AbstractHttpRequest ToAbstractHttpRequestAsync(this Microsoft.AspNetCore.Http.HttpRequest request);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_AbstractHttpRequestHelper_ToAbstractHttpRequestAsync(Microsoft_AspNetCore_Http_HttpRequest)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The request to be represented as a [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest').  
  
#### Returns
[AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')  
A [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpRequestHelper_ToAbstractHttpRequestAsync(System_Net_Http_HttpRequestMessage)'></a>
## AbstractHttpRequestHelper.ToAbstractHttpRequestAsync(HttpRequestMessage) Method
Constructs and returns a [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest') representation of a  
[System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage').  
```csharp
public static System.Threading.Tasks.Task<TetraPak.AspNet.Debugging.AbstractHttpRequest> ToAbstractHttpRequestAsync(this System.Net.Http.HttpRequestMessage request);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_AbstractHttpRequestHelper_ToAbstractHttpRequestAsync(System_Net_Http_HttpRequestMessage)_request'></a>
`request` [System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage')  
The request to be represented as a [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpRequestHelper_ToAbstractHttpRequestAsync(System_Net_HttpWebRequest)'></a>
## AbstractHttpRequestHelper.ToAbstractHttpRequestAsync(HttpWebRequest) Method
Constructs and returns a [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest') representation of a  
[Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
```csharp
public static TetraPak.AspNet.Debugging.AbstractHttpRequest ToAbstractHttpRequestAsync(this System.Net.HttpWebRequest request);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_AbstractHttpRequestHelper_ToAbstractHttpRequestAsync(System_Net_HttpWebRequest)_request'></a>
`request` [System.Net.HttpWebRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpWebRequest 'System.Net.HttpWebRequest')  
The request to be represented as a [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest').  
  
#### Returns
[AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')  
A [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')
  
