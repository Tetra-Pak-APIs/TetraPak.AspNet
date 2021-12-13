#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## AbstractHttpRequest Class
An abstract representation of a HTTP request (note: the class itself is not `abstract`).  
```csharp
public class AbstractHttpRequest
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AbstractHttpRequest  

Derived  
&#8627; [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse')  
### Properties
<a name='TetraPak_AspNet_Debugging_AbstractHttpRequest_Content'></a>
## AbstractHttpRequest.Content Property
Gets or sets a content (a.k.a. body).  
```csharp
public System.IO.Stream? Content { get; set; }
```
#### Property Value
[System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpRequest_Headers'></a>
## AbstractHttpRequest.Headers Property
Gets or sets the headers collection.  
```csharp
public System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string,System.Collections.Generic.IEnumerable<string>>> Headers { get; set; }
```
#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpRequest_Method'></a>
## AbstractHttpRequest.Method Property
Gets or sets a request HTTP method.  
```csharp
public string Method { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Debugging_AbstractHttpRequest_Uri'></a>
## AbstractHttpRequest.Uri Property
Gets or sets a request URI.  
```csharp
public System.Uri? Uri { get; set; }
```
#### Property Value
[System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')
  
