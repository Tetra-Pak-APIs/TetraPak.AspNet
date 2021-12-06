#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## WebLoggerHelper Class
Contains convenience/extension methods to assist with logging.   
```csharp
public static class WebLoggerHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WebLoggerHelper  
### Methods
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_DebugAssembliesInUse(Microsoft_Extensions_DependencyInjection_IServiceCollection_bool)'></a>
## WebLoggerHelper.DebugAssembliesInUse(IServiceCollection, bool) Method
Logs all assemblies currently in use by the process. This method is intended to be called  
at a very early stage, where DI hasn't yet been fully set up, such as from the Program class  
in a web application.  
```csharp
public static void DebugAssembliesInUse(this Microsoft.Extensions.DependencyInjection.IServiceCollection c, bool justOnce=true);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_DebugAssembliesInUse(Microsoft_Extensions_DependencyInjection_IServiceCollection_bool)_c'></a>
`c` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
A [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection'), used to set up DI.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_DebugAssembliesInUse(Microsoft_Extensions_DependencyInjection_IServiceCollection_bool)_justOnce'></a>
`justOnce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to ignore logging if this method has already been invoked once by the process.  
This is to help avoiding littering the log files with the same information multiple times.  
  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_DebugAssembliesInUse(Microsoft_Extensions_Logging_ILogger_bool)'></a>
## WebLoggerHelper.DebugAssembliesInUse(ILogger, bool) Method
Logs all assemblies currently in use by the process.  
```csharp
public static void DebugAssembliesInUse(this Microsoft.Extensions.Logging.ILogger logger, bool justOnce=true);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_DebugAssembliesInUse(Microsoft_Extensions_Logging_ILogger_bool)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
A logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_DebugAssembliesInUse(Microsoft_Extensions_Logging_ILogger_bool)_justOnce'></a>
`justOnce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to ignore logging if this method has already been invoked once by the process.  
This is to help avoiding littering the log files with the same information multiple times.  
  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_GetRawBodyStringAsync(System_Net_Http_HttpRequestMessage_System_Text_Encoding_TetraPak_AspNet_Debugging_TraceRequestOptions_)'></a>
## WebLoggerHelper.GetRawBodyStringAsync(HttpRequestMessage, Encoding, TraceRequestOptions?) Method
Retrieves the [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest') body as a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String').    
```csharp
public static System.Threading.Tasks.Task<string> GetRawBodyStringAsync(this System.Net.Http.HttpRequestMessage request, System.Text.Encoding encoding, TetraPak.AspNet.Debugging.TraceRequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_GetRawBodyStringAsync(System_Net_Http_HttpRequestMessage_System_Text_Encoding_TetraPak_AspNet_Debugging_TraceRequestOptions_)_request'></a>
`request` [System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage')  
The extended [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_GetRawBodyStringAsync(System_Net_Http_HttpRequestMessage_System_Text_Encoding_TetraPak_AspNet_Debugging_TraceRequestOptions_)_encoding'></a>
`encoding` [System.Text.Encoding](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Encoding 'System.Text.Encoding')  
The character encoding to use.   
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_GetRawBodyStringAsync(System_Net_Http_HttpRequestMessage_System_Text_Encoding_TetraPak_AspNet_Debugging_TraceRequestOptions_)_options'></a>
`options` [TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
(optional)<br/>  
Specifies how tracing of request bodies is conducted.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The (raw) textual representation of the request body as a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String').   
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_LogTetraPakConfigAsync(Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_TetraPakConfig_Microsoft_Extensions_Logging_LogLevel_bool)'></a>
## WebLoggerHelper.LogTetraPakConfigAsync(ILogger, TetraPakConfig, LogLevel, bool) Method
Builds and a state dump from a [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig') object and writes it to the logger.   
```csharp
public static System.Threading.Tasks.Task LogTetraPakConfigAsync(this Microsoft.Extensions.Logging.ILogger logger, TetraPak.AspNet.TetraPakConfig tetraPakConfig, Microsoft.Extensions.Logging.LogLevel logLevel=Microsoft.Extensions.Logging.LogLevel.Trace, bool justOnce=true);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_LogTetraPakConfigAsync(Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_TetraPakConfig_Microsoft_Extensions_Logging_LogLevel_bool)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The extended logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_LogTetraPakConfigAsync(Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_TetraPakConfig_Microsoft_Extensions_Logging_LogLevel_bool)_tetraPakConfig'></a>
`tetraPakConfig` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
The [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig') object to be state dumped to the logger.   
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_LogTetraPakConfigAsync(Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_TetraPakConfig_Microsoft_Extensions_Logging_LogLevel_bool)_logLevel'></a>
`logLevel` [Microsoft.Extensions.Logging.LogLevel](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel 'Microsoft.Extensions.Logging.LogLevel')  
(optional; default=[Microsoft.Extensions.Logging.LogLevel.Trace](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Trace 'Microsoft.Extensions.Logging.LogLevel.Trace'))<br/>  
A (custom) log level for the state dump information.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_LogTetraPakConfigAsync(Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_TetraPakConfig_Microsoft_Extensions_Logging_LogLevel_bool)_justOnce'></a>
`justOnce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
When set the state dump will only be performed once.  
The state dump will be ignored if invoked again and this value was set previously (and now).    
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__string__System_Nullable_bool_)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, HttpResponse?, string?, Nullable&lt;bool&gt;) Method
Traces a [Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, Microsoft.AspNetCore.Http.HttpResponse? response, string? messageId, System.Nullable<bool> includeBody=false);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__string__System_Nullable_bool_)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__string__System_Nullable_bool_)_response'></a>
`response` [Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse')  
The response to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__string__System_Nullable_bool_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__string__System_Nullable_bool_)_includeBody'></a>
`includeBody` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional; default=`false`)<br/>  
Specifies whether to also include the response body.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
#### See Also
- [TraceAsync(ILogger?,HttpResponse?,Func<HttpResponse?,Task<string>>?)](https://docs.microsoft.com/en-us/dotnet/api/TraceAsync#TraceAsync_ILogger?,HttpResponse?,Func<HttpResponse?,Task<string>>?_ 'TraceAsync(ILogger?,HttpResponse?,Func<HttpResponse?,Task<string>>?)')
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, HttpResponse?, Func&lt;TraceRequestOptions&gt;?) Method
Traces a [Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, Microsoft.AspNetCore.Http.HttpResponse? response, System.Func<TetraPak.AspNet.Debugging.TraceRequestOptions>? optionsFactory=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_response'></a>
`response` [Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse')  
The response to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory'></a>
`optionsFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
#### See Also
- [TraceAsync(Microsoft.Extensions.Logging.ILogger?,HttpResponse?,bool?)](https://docs.microsoft.com/en-us/dotnet/api/TraceAsync#TraceAsync_Microsoft_Extensions_Logging_ILogger?,HttpResponse?,bool?_ 'TraceAsync(Microsoft.Extensions.Logging.ILogger?,HttpResponse?,bool?)')
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__System_Func_System_Net_WebResponse__System_Threading_Tasks_Task_string___)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, WebResponse?, Func&lt;WebResponse?,Task&lt;string&gt;&gt;?) Method
Traces a [System.Net.WebResponse](https://docs.microsoft.com/en-us/dotnet/api/System.Net.WebResponse 'System.Net.WebResponse') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, System.Net.WebResponse? response, System.Func<System.Net.WebResponse?,System.Threading.Tasks.Task<string>>? bodyHandler=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__System_Func_System_Net_WebResponse__System_Threading_Tasks_Task_string___)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__System_Func_System_Net_WebResponse__System_Threading_Tasks_Task_string___)_response'></a>
`response` [System.Net.WebResponse](https://docs.microsoft.com/en-us/dotnet/api/System.Net.WebResponse 'System.Net.WebResponse')  
The response to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__System_Func_System_Net_WebResponse__System_Threading_Tasks_Task_string___)_bodyHandler'></a>
`bodyHandler` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Net.WebResponse](https://docs.microsoft.com/en-us/dotnet/api/System.Net.WebResponse 'System.Net.WebResponse')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
(optional)<br/>  
A handler that provides a content (body) to be traced.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
#### See Also
- [TraceAsync(ILogger?, WebResponse?, Func&lt;WebResponse?,Task&lt;string&gt;&gt;?)](TetraPak_AspNet_Debugging_WebLoggerHelper.md#TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__System_Func_System_Net_WebResponse__System_Threading_Tasks_Task_string___) 'TetraPak.AspNet.Debugging.WebLoggerHelper.TraceAsync(Microsoft.Extensions.Logging.ILogger?, System.Net.WebResponse?, System.Func&lt;System.Net.WebResponse?,System.Threading.Tasks.Task&lt;string&gt;&gt;?)')
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__System_Nullable_bool_)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, WebResponse?, Nullable&lt;bool&gt;) Method
Traces a [System.Net.WebResponse](https://docs.microsoft.com/en-us/dotnet/api/System.Net.WebResponse 'System.Net.WebResponse') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, System.Net.WebResponse? response, System.Nullable<bool> includeBody=false);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__System_Nullable_bool_)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__System_Nullable_bool_)_response'></a>
`response` [System.Net.WebResponse](https://docs.microsoft.com/en-us/dotnet/api/System.Net.WebResponse 'System.Net.WebResponse')  
The response to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__System_Nullable_bool_)_includeBody'></a>
`includeBody` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional; default=`false`)<br/>  
Specifies whether to also include the response body.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
#### See Also
- [TraceAsync(ILogger?,HttpResponse?,Func<HttpResponse?,Task<string>>?)](https://docs.microsoft.com/en-us/dotnet/api/TraceAsync#TraceAsync_ILogger?,HttpResponse?,Func<HttpResponse?,Task<string>>?_ 'TraceAsync(ILogger?,HttpResponse?,Func<HttpResponse?,Task<string>>?)')
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceHttpRequestAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)'></a>
## WebLoggerHelper.TraceHttpRequestAsync(ILogger?, HttpRequest, Func&lt;TraceRequestOptions&gt;?) Method
Traces a [System.Net.HttpWebRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpWebRequest 'System.Net.HttpWebRequest') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceHttpRequestAsync(this Microsoft.Extensions.Logging.ILogger? logger, Microsoft.AspNetCore.Http.HttpRequest request, System.Func<TetraPak.AspNet.Debugging.TraceRequestOptions>? optionsFactory=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceHttpRequestAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceHttpRequestAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The request to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceHttpRequestAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory'></a>
`optionsFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br/>  
Specifies how tracing of request bodies is conducted.   
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceHttpRequestMessageAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpRequestMessage_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)'></a>
## WebLoggerHelper.TraceHttpRequestMessageAsync(ILogger?, HttpRequestMessage, Func&lt;TraceRequestOptions&gt;?) Method
Traces a [System.Net.HttpWebRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpWebRequest 'System.Net.HttpWebRequest') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceHttpRequestMessageAsync(this Microsoft.Extensions.Logging.ILogger? logger, System.Net.Http.HttpRequestMessage requestMessage, System.Func<TetraPak.AspNet.Debugging.TraceRequestOptions>? optionsFactory=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceHttpRequestMessageAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpRequestMessage_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceHttpRequestMessageAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpRequestMessage_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_requestMessage'></a>
`requestMessage` [System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage')  
The request message to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceHttpRequestMessageAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpRequestMessage_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory'></a>
`optionsFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
baseAddress is `null` but the [requestMessage](TetraPak_AspNet_Debugging_WebLoggerHelper.md#TetraPak_AspNet_Debugging_WebLoggerHelper_TraceHttpRequestMessageAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpRequestMessage_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_requestMessage 'TetraPak.AspNet.Debugging.WebLoggerHelper.TraceHttpRequestMessageAsync(Microsoft.Extensions.Logging.ILogger?, System.Net.Http.HttpRequestMessage, System.Func&lt;TetraPak.AspNet.Debugging.TraceRequestOptions&gt;?).requestMessage')'s  
              URI is relative.  
            
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceWebRequestAsync(Microsoft_Extensions_Logging_ILogger__System_Net_HttpWebRequest_System_Func_string__)'></a>
## WebLoggerHelper.TraceWebRequestAsync(ILogger?, HttpWebRequest, Func&lt;string&gt;?) Method
Traces a [System.Net.HttpWebRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpWebRequest 'System.Net.HttpWebRequest') in the logs. obsolete  
```csharp
public static System.Threading.Tasks.Task TraceWebRequestAsync(this Microsoft.Extensions.Logging.ILogger? logger, System.Net.HttpWebRequest request, System.Func<string>? bodyHandler=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceWebRequestAsync(Microsoft_Extensions_Logging_ILogger__System_Net_HttpWebRequest_System_Func_string__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceWebRequestAsync(Microsoft_Extensions_Logging_ILogger__System_Net_HttpWebRequest_System_Func_string__)_request'></a>
`request` [System.Net.HttpWebRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpWebRequest 'System.Net.HttpWebRequest')  
The request to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceWebRequestAsync(Microsoft_Extensions_Logging_ILogger__System_Net_HttpWebRequest_System_Func_string__)_bodyHandler'></a>
`bodyHandler` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br/>  
A handler that provides a content (body) to be traced.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_UseTetraPakTraceRequestAsync(Microsoft_AspNetCore_Builder_IApplicationBuilder)'></a>
## WebLoggerHelper.UseTetraPakTraceRequestAsync(IApplicationBuilder) Method
Injects middleware that traces all requests to the logger provider  
when [Microsoft.Extensions.Logging.LogLevel.Trace](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Trace 'Microsoft.Extensions.Logging.LogLevel.Trace') is set.  
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseTetraPakTraceRequestAsync(this Microsoft.AspNetCore.Builder.IApplicationBuilder app);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_UseTetraPakTraceRequestAsync(Microsoft_AspNetCore_Builder_IApplicationBuilder)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The extended application builder.   
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
  
