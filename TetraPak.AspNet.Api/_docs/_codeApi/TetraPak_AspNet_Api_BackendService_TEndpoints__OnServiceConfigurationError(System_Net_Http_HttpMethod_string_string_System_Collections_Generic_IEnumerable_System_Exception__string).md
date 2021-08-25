#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api').[BackendService&lt;TEndpoints&gt;](TetraPak_AspNet_Api_BackendService_TEndpoints_.md 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;')
## BackendService&lt;TEndpoints&gt;.OnServiceConfigurationError(HttpMethod, string, string, IEnumerable&lt;Exception&gt;, string) Method
Called by an internal method when it discovers a configuration issue,  
allowing for a consistent response to all such issues.  
```csharp
protected virtual TetraPak.Outcome<System.Net.Http.HttpResponseMessage> OnServiceConfigurationError(System.Net.Http.HttpMethod method, string path, string queryParameters, System.Collections.Generic.IEnumerable<System.Exception> issues, string messageId);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpMethod_string_string_System_Collections_Generic_IEnumerable_System_Exception__string)_method'></a>
`method` [System.Net.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMethod 'System.Net.Http.HttpMethod')  
The request HTTP method.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpMethod_string_string_System_Collections_Generic_IEnumerable_System_Exception__string)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The request path.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpMethod_string_string_System_Collections_Generic_IEnumerable_System_Exception__string)_queryParameters'></a>
`queryParameters` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Any request query parameters.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpMethod_string_string_System_Collections_Generic_IEnumerable_System_Exception__string)_issues'></a>
`issues` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of issues found.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__OnServiceConfigurationError(System_Net_Http_HttpMethod_string_string_System_Collections_Generic_IEnumerable_System_Exception__string)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<bt />  
A unique string value to be used for referencing/diagnostics purposes.  
  
#### Returns
[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')  
