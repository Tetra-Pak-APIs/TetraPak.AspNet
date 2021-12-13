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
  
