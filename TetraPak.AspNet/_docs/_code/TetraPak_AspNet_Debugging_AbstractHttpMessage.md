#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## AbstractHttpMessage Class
An abstract representation of a HTTP request.  
```csharp
public abstract class AbstractHttpMessage
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AbstractHttpMessage  

Derived  
&#8627; [GenericHttpRequest](TetraPak_AspNet_Debugging_GenericHttpRequest.md 'TetraPak.AspNet.Debugging.GenericHttpRequest')  
&#8627; [GenericHttpResponse](TetraPak_AspNet_Debugging_GenericHttpResponse.md 'TetraPak.AspNet.Debugging.GenericHttpResponse')  
### Properties
<a name='TetraPak_AspNet_Debugging_AbstractHttpMessage_Content'></a>
## AbstractHttpMessage.Content Property
Gets or sets a content (a.k.a. body).  
```csharp
public System.IO.Stream? Content { get; set; }
```
#### Property Value
[System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpMessage_Headers'></a>
## AbstractHttpMessage.Headers Property
Gets or sets the headers collection.  
```csharp
public System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string,System.Collections.Generic.IEnumerable<string>>> Headers { get; set; }
```
#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpMessage_MessageId'></a>
## AbstractHttpMessage.MessageId Property
(optional)<br/>  
A unique string value for tracking a request/response (mainly for diagnostics purposes).  
```csharp
public string? MessageId { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpMessage_Method'></a>
## AbstractHttpMessage.Method Property
Gets or sets a request HTTP method.  
```csharp
public string Method { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpMessage_Uri'></a>
## AbstractHttpMessage.Uri Property
Gets or sets a request URI.  
```csharp
public System.Uri? Uri { get; set; }
```
#### Property Value
[System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')
  
