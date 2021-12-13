#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## HttpResponseMessageHelper Class
Provides convenient extension methods for [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')s.  
```csharp
public static class HttpResponseMessageHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpResponseMessageHelper  
### Methods
<a name='TetraPak_AspNet_HttpResponseMessageHelper_ToOutcomeAsync(System_Net_Http_HttpResponseMessage_string_)'></a>
## HttpResponseMessageHelper.ToOutcomeAsync(HttpResponseMessage, string?) Method
Produces an [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') object from a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage').  
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpResponseMessage>> ToOutcomeAsync(this System.Net.Http.HttpResponseMessage self, string? messageId);
```
#### Parameters
<a name='TetraPak_AspNet_HttpResponseMessageHelper_ToOutcomeAsync(System_Net_Http_HttpResponseMessage_string_)_self'></a>
`self` [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')  
The response message.  
  
<a name='TetraPak_AspNet_HttpResponseMessageHelper_ToOutcomeAsync(System_Net_Http_HttpResponseMessage_string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A unique string value for tracking a request/response (mainly for diagnostics purposes).  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') and, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
