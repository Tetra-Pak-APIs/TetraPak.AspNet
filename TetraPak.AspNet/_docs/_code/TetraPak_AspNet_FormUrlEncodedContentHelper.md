#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## FormUrlEncodedContentHelper Class
Provides convenience for dealing with [System.Net.Http.FormUrlEncodedContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.FormUrlEncodedContent 'System.Net.Http.FormUrlEncodedContent') objects.  
```csharp
public static class FormUrlEncodedContentHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FormUrlEncodedContentHelper  
### Methods
<a name='TetraPak_AspNet_FormUrlEncodedContentHelper_ReadAsDictionaryAsync(System_Net_Http_FormUrlEncodedContent_System_Threading_CancellationToken)'></a>
## FormUrlEncodedContentHelper.ReadAsDictionaryAsync(FormUrlEncodedContent, CancellationToken) Method
Transforms a [System.Net.Http.FormUrlEncodedContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.FormUrlEncodedContent 'System.Net.Http.FormUrlEncodedContent') object to a dictionary.  
```csharp
public static System.Threading.Tasks.Task<System.Collections.Generic.IDictionary<string,string>> ReadAsDictionaryAsync(this System.Net.Http.FormUrlEncodedContent self, System.Threading.CancellationToken cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_FormUrlEncodedContentHelper_ReadAsDictionaryAsync(System_Net_Http_FormUrlEncodedContent_System_Threading_CancellationToken)_self'></a>
`self` [System.Net.Http.FormUrlEncodedContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.FormUrlEncodedContent 'System.Net.Http.FormUrlEncodedContent')  
A [System.Net.Http.FormUrlEncodedContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.FormUrlEncodedContent 'System.Net.Http.FormUrlEncodedContent') object.  
  
<a name='TetraPak_AspNet_FormUrlEncodedContentHelper_ReadAsDictionaryAsync(System_Net_Http_FormUrlEncodedContent_System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken'), allowing the asynchronous operation to be cancelled.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Collections.Generic.IDictionary&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2').  
  
<a name='TetraPak_AspNet_FormUrlEncodedContentHelper_ReadAsDictionaryAsync(System_Net_Http_FormUrlEncodedContent)'></a>
## FormUrlEncodedContentHelper.ReadAsDictionaryAsync(FormUrlEncodedContent) Method
Transforms a [System.Net.Http.FormUrlEncodedContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.FormUrlEncodedContent 'System.Net.Http.FormUrlEncodedContent') object to a dictionary.  
```csharp
public static System.Threading.Tasks.Task<System.Collections.Generic.IDictionary<string,string>> ReadAsDictionaryAsync(this System.Net.Http.FormUrlEncodedContent self);
```
#### Parameters
<a name='TetraPak_AspNet_FormUrlEncodedContentHelper_ReadAsDictionaryAsync(System_Net_Http_FormUrlEncodedContent)_self'></a>
`self` [System.Net.Http.FormUrlEncodedContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.FormUrlEncodedContent 'System.Net.Http.FormUrlEncodedContent')  
A [System.Net.Http.FormUrlEncodedContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.FormUrlEncodedContent 'System.Net.Http.FormUrlEncodedContent') object.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Collections.Generic.IDictionary&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2').  
  
