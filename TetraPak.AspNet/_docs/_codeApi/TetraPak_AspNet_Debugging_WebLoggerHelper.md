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
(optional; default=`true`)<br />  
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
(optional; default=`true`)<br />  
Specifies whether to ignore logging if this method has already been invoked once by the process.  
This is to help avoiding littering the log files with the same information multiple times.  
  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_GetLowestLogLevel(Microsoft_Extensions_Logging_ILogger)'></a>
## WebLoggerHelper.GetLowestLogLevel(ILogger) Method
Gets the lowest [Microsoft.Extensions.Logging.LogLevel](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel 'Microsoft.Extensions.Logging.LogLevel') defined for the logger provider.   
```csharp
public static Microsoft.Extensions.Logging.LogLevel GetLowestLogLevel(this Microsoft.Extensions.Logging.ILogger logger);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_GetLowestLogLevel(Microsoft_Extensions_Logging_ILogger)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
#### Returns
[Microsoft.Extensions.Logging.LogLevel](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel 'Microsoft.Extensions.Logging.LogLevel')  
A [Microsoft.Extensions.Logging.LogLevel](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel 'Microsoft.Extensions.Logging.LogLevel') value.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpRequest_System_Func_string__)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, HttpRequest, Func&lt;string&gt;?) Method
Traces a [System.Net.HttpWebRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpWebRequest 'System.Net.HttpWebRequest') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, Microsoft.AspNetCore.Http.HttpRequest request, System.Func<string>? bodyHandler=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpRequest_System_Func_string__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpRequest_System_Func_string__)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The request to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpRequest_System_Func_string__)_bodyHandler'></a>
`bodyHandler` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br />  
A request body to be traced.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Func_Microsoft_AspNetCore_Http_HttpResponse__System_Threading_Tasks_Task_string___)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, HttpResponse?, Func&lt;HttpResponse?,Task&lt;string&gt;&gt;?) Method
Traces a [Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, Microsoft.AspNetCore.Http.HttpResponse? response, System.Func<Microsoft.AspNetCore.Http.HttpResponse?,System.Threading.Tasks.Task<string>>? bodyHandler=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Func_Microsoft_AspNetCore_Http_HttpResponse__System_Threading_Tasks_Task_string___)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Func_Microsoft_AspNetCore_Http_HttpResponse__System_Threading_Tasks_Task_string___)_response'></a>
`response` [Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse')  
The response to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Func_Microsoft_AspNetCore_Http_HttpResponse__System_Threading_Tasks_Task_string___)_bodyHandler'></a>
`bodyHandler` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
(optional)<br />  
A handler that provides a content (body) to be traced.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
#### See Also
- [TraceAsync(ILogger?, HttpResponse?, Nullable&lt;bool&gt;)](TetraPak_AspNet_Debugging_WebLoggerHelper.md#TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Nullable_bool_) 'TetraPak.AspNet.Debugging.WebLoggerHelper.TraceAsync(Microsoft.Extensions.Logging.ILogger?, Microsoft.AspNetCore.Http.HttpResponse?, System.Nullable&lt;bool&gt;)')
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Nullable_bool_)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, HttpResponse?, Nullable&lt;bool&gt;) Method
Traces a [Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, Microsoft.AspNetCore.Http.HttpResponse? response, System.Nullable<bool> includeBody=false);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Nullable_bool_)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Nullable_bool_)_response'></a>
`response` [Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse')  
The response to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Nullable_bool_)_includeBody'></a>
`includeBody` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional; default=`false`)<br />  
Specifies whether to also include the response body.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
#### See Also
- [TraceAsync(ILogger?, HttpResponse?, Func&lt;HttpResponse?,Task&lt;string&gt;&gt;?)](TetraPak_AspNet_Debugging_WebLoggerHelper.md#TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Func_Microsoft_AspNetCore_Http_HttpResponse__System_Threading_Tasks_Task_string___) 'TetraPak.AspNet.Debugging.WebLoggerHelper.TraceAsync(Microsoft.Extensions.Logging.ILogger?, Microsoft.AspNetCore.Http.HttpResponse?, System.Func&lt;Microsoft.AspNetCore.Http.HttpResponse?,System.Threading.Tasks.Task&lt;string&gt;&gt;?)')
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_HttpWebRequest_System_Func_string__)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, HttpWebRequest, Func&lt;string&gt;?) Method
Traces a [System.Net.HttpWebRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpWebRequest 'System.Net.HttpWebRequest') in the logs.  
```csharp
public static void TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, System.Net.HttpWebRequest request, System.Func<string>? bodyHandler=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_HttpWebRequest_System_Func_string__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_HttpWebRequest_System_Func_string__)_request'></a>
`request` [System.Net.HttpWebRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpWebRequest 'System.Net.HttpWebRequest')  
The request to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_HttpWebRequest_System_Func_string__)_bodyHandler'></a>
`bodyHandler` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br />  
A handler that provides a content (body) to be traced.  
  
  
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
(optional)<br />  
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
(optional; default=`false`)<br />  
Specifies whether to also include the response body.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
#### See Also
- [TraceAsync(ILogger?, HttpResponse?, Func&lt;HttpResponse?,Task&lt;string&gt;&gt;?)](TetraPak_AspNet_Debugging_WebLoggerHelper.md#TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__System_Func_Microsoft_AspNetCore_Http_HttpResponse__System_Threading_Tasks_Task_string___) 'TetraPak.AspNet.Debugging.WebLoggerHelper.TraceAsync(Microsoft.Extensions.Logging.ILogger?, Microsoft.AspNetCore.Http.HttpResponse?, System.Func&lt;Microsoft.AspNetCore.Http.HttpResponse?,System.Threading.Tasks.Task&lt;string&gt;&gt;?)')
  
