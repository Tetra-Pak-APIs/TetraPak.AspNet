#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## HttpRequestHelper Class
Provides convenient methods for working with HTTP request objects.  
```csharp
public static class HttpRequestHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpRequestHelper  
### Methods
<a name='TetraPak_AspNet_HttpRequestHelper_CloneAsync(System_Net_Http_HttpRequestMessage)'></a>
## HttpRequestHelper.CloneAsync(HttpRequestMessage) Method
Clones the [System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage').   
```csharp
public static System.Threading.Tasks.Task<System.Net.Http.HttpRequestMessage> CloneAsync(this System.Net.Http.HttpRequestMessage message);
```
#### Parameters
<a name='TetraPak_AspNet_HttpRequestHelper_CloneAsync(System_Net_Http_HttpRequestMessage)_message'></a>
`message` [System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage')  
The [System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage') to be cloned.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The cloned [System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage').  
  
<a name='TetraPak_AspNet_HttpRequestHelper_ResetTo_T_(System_Net_Http_Headers_HttpHeaderValueCollection_T__T__)'></a>
## HttpRequestHelper.ResetTo&lt;T&gt;(HttpHeaderValueCollection&lt;T&gt;, T[]) Method
Resets the [System.Net.Http.Headers.HttpHeaderValueCollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.Headers.HttpHeaderValueCollection-1 'System.Net.Http.Headers.HttpHeaderValueCollection`1') to a specified set of headers.  
```csharp
public static void ResetTo<T>(this System.Net.Http.Headers.HttpHeaderValueCollection<T> self, params T[] headers)
    where T : class;
```
#### Type parameters
<a name='TetraPak_AspNet_HttpRequestHelper_ResetTo_T_(System_Net_Http_Headers_HttpHeaderValueCollection_T__T__)_T'></a>
`T`  
The type of headers supported by the headers collection.  
  
#### Parameters
<a name='TetraPak_AspNet_HttpRequestHelper_ResetTo_T_(System_Net_Http_Headers_HttpHeaderValueCollection_T__T__)_self'></a>
`self` [System.Net.Http.Headers.HttpHeaderValueCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.Headers.HttpHeaderValueCollection-1 'System.Net.Http.Headers.HttpHeaderValueCollection`1')[T](TetraPak_AspNet_HttpRequestHelper.md#TetraPak_AspNet_HttpRequestHelper_ResetTo_T_(System_Net_Http_Headers_HttpHeaderValueCollection_T__T__)_T 'TetraPak.AspNet.HttpRequestHelper.ResetTo&lt;T&gt;(System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;, T[]).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.Headers.HttpHeaderValueCollection-1 'System.Net.Http.Headers.HttpHeaderValueCollection`1')  
The headers collection to be reset.  
  
<a name='TetraPak_AspNet_HttpRequestHelper_ResetTo_T_(System_Net_Http_Headers_HttpHeaderValueCollection_T__T__)_headers'></a>
`headers` [T](TetraPak_AspNet_HttpRequestHelper.md#TetraPak_AspNet_HttpRequestHelper_ResetTo_T_(System_Net_Http_Headers_HttpHeaderValueCollection_T__T__)_T 'TetraPak.AspNet.HttpRequestHelper.ResetTo&lt;T&gt;(System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;, T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The headers to be assigned.  
  
  
