#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## WebLoggerHelper Class
Contains convenience/extension methods to assist with logging.   
```csharp
public static class WebLoggerHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WebLoggerHelper  
### Properties
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceThreshold'></a>
## WebLoggerHelper.TraceThreshold Property
Gets or sets a threshold value used when tracing HTTP traffic. When traffic size  
exceeds this value the tracing will automatically be delegated to a background thread.   
```csharp
public static int TraceThreshold { get; set; }
```
#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
  
### Methods
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_DebugAssembliesInUseAsync(Microsoft_Extensions_Logging_ILogger)'></a>
## WebLoggerHelper.DebugAssembliesInUseAsync(ILogger) Method
Logs all assemblies currently in use by the process.  
```csharp
public static System.Threading.Tasks.Task DebugAssembliesInUseAsync(this Microsoft.Extensions.Logging.ILogger logger);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_DebugAssembliesInUseAsync(Microsoft_Extensions_Logging_ILogger)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_GetRawBodyStringAsync(System_IO_Stream__System_Text_Encoding_TetraPak_AspNet_Debugging_TraceRequestOptions_)'></a>
## WebLoggerHelper.GetRawBodyStringAsync(Stream?, Encoding, TraceRequestOptions?) Method
Attempts building and returning a textual representation of a [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').   
```csharp
public static System.Threading.Tasks.Task<string> GetRawBodyStringAsync(this System.IO.Stream? stream, System.Text.Encoding encoding, TetraPak.AspNet.Debugging.TraceRequestOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_GetRawBodyStringAsync(System_IO_Stream__System_Text_Encoding_TetraPak_AspNet_Debugging_TraceRequestOptions_)_stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') to be textually represented.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_GetRawBodyStringAsync(System_IO_Stream__System_Text_Encoding_TetraPak_AspNet_Debugging_TraceRequestOptions_)_encoding'></a>
`encoding` [System.Text.Encoding](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Encoding 'System.Text.Encoding')  
The character [System.Text.Encoding](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Encoding 'System.Text.Encoding') to be used.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_GetRawBodyStringAsync(System_IO_Stream__System_Text_Encoding_TetraPak_AspNet_Debugging_TraceRequestOptions_)_options'></a>
`options` [TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
(optional)<br/>  
Options for how tracing is conducted.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_LogTetraPakConfigAsync(Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_TetraPakConfig__Microsoft_Extensions_Logging_LogLevel_bool)'></a>
## WebLoggerHelper.LogTetraPakConfigAsync(ILogger?, TetraPakConfig?, LogLevel, bool) Method
Builds and a state dump from a [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig') object and writes it to the logger.   
```csharp
public static System.Threading.Tasks.Task LogTetraPakConfigAsync(this Microsoft.Extensions.Logging.ILogger? logger, TetraPak.AspNet.TetraPakConfig? tetraPakConfig, Microsoft.Extensions.Logging.LogLevel logLevel=Microsoft.Extensions.Logging.LogLevel.Trace, bool justOnce=true);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_LogTetraPakConfigAsync(Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_TetraPakConfig__Microsoft_Extensions_Logging_LogLevel_bool)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The extended logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_LogTetraPakConfigAsync(Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_TetraPakConfig__Microsoft_Extensions_Logging_LogLevel_bool)_tetraPakConfig'></a>
`tetraPakConfig` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
The [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig') object to be state dumped to the logger.   
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_LogTetraPakConfigAsync(Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_TetraPakConfig__Microsoft_Extensions_Logging_LogLevel_bool)_logLevel'></a>
`logLevel` [Microsoft.Extensions.Logging.LogLevel](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel 'Microsoft.Extensions.Logging.LogLevel')  
(optional; default=[Microsoft.Extensions.Logging.LogLevel.Trace](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Trace 'Microsoft.Extensions.Logging.LogLevel.Trace'))<br/>  
A (custom) log level for the state dump information.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_LogTetraPakConfigAsync(Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_TetraPakConfig__Microsoft_Extensions_Logging_LogLevel_bool)_justOnce'></a>
`justOnce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
When set the state dump will only be performed once.  
The state dump will be ignored if invoked again and this value was set previously (and now).    
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_ToKeyValuePairs(System_Collections_Generic_IDictionary_string_Microsoft_Extensions_Primitives_StringValues_)'></a>
## WebLoggerHelper.ToKeyValuePairs(IDictionary&lt;string,StringValues&gt;) Method
Converts a dictionary of [Microsoft.Extensions.Primitives.StringValues](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Primitives.StringValues 'Microsoft.Extensions.Primitives.StringValues') (such as [Microsoft.AspNetCore.Http.IHeaderDictionary](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.IHeaderDictionary 'Microsoft.AspNetCore.Http.IHeaderDictionary'))  
into a collection of key-value pairs with values as [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1').  
```csharp
public static System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string,System.Collections.Generic.IEnumerable<string>>> ToKeyValuePairs(this System.Collections.Generic.IDictionary<string,Microsoft.Extensions.Primitives.StringValues> dict);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_ToKeyValuePairs(System_Collections_Generic_IDictionary_string_Microsoft_Extensions_Primitives_StringValues_)_dict'></a>
`dict` [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[Microsoft.Extensions.Primitives.StringValues](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Primitives.StringValues 'Microsoft.Extensions.Primitives.StringValues')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
The dictionary to be converted.  
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') collection.  
### Remarks
This method is used internally to convert the various classes representing HTTP requests or responses  
into an [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest') or   
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_ToKeyValuePairs(System_Collections_Specialized_NameValueCollection)'></a>
## WebLoggerHelper.ToKeyValuePairs(NameValueCollection) Method
Converts a dictionary of [Microsoft.Extensions.Primitives.StringValues](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Primitives.StringValues 'Microsoft.Extensions.Primitives.StringValues') (such as [Microsoft.AspNetCore.Http.IHeaderDictionary](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.IHeaderDictionary 'Microsoft.AspNetCore.Http.IHeaderDictionary'))  
into a collection of key-value pairs with values as [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1').  
```csharp
public static System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string,System.Collections.Generic.IEnumerable<string>>> ToKeyValuePairs(this System.Collections.Specialized.NameValueCollection collection);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_ToKeyValuePairs(System_Collections_Specialized_NameValueCollection)_collection'></a>
`collection` [System.Collections.Specialized.NameValueCollection](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Specialized.NameValueCollection 'System.Collections.Specialized.NameValueCollection')  
The collection to be converted.  
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') collection.  
### Remarks
This method is used internally to convert the various classes representing HTTP requests or responses  
into an [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest') or   
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_ToStringBuilderAsync(TetraPak_AspNet_Debugging_AbstractHttpRequest_System_Text_StringBuilder_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)'></a>
## WebLoggerHelper.ToStringBuilderAsync(AbstractHttpRequest, StringBuilder, Func&lt;TraceRequestOptions&gt;?) Method
Builds a textual representation of the [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest').  
```csharp
public static System.Threading.Tasks.Task<System.Text.StringBuilder> ToStringBuilderAsync(this TetraPak.AspNet.Debugging.AbstractHttpRequest request, System.Text.StringBuilder stringBuilder, System.Func<TetraPak.AspNet.Debugging.TraceRequestOptions>? optionsFactory=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_ToStringBuilderAsync(TetraPak_AspNet_Debugging_AbstractHttpRequest_System_Text_StringBuilder_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_request'></a>
`request` [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')  
The [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest') to be textually represented.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_ToStringBuilderAsync(TetraPak_AspNet_Debugging_AbstractHttpRequest_System_Text_StringBuilder_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_stringBuilder'></a>
`stringBuilder` [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')  
The [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder') to be used.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_ToStringBuilderAsync(TetraPak_AspNet_Debugging_AbstractHttpRequest_System_Text_StringBuilder_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory'></a>
`optionsFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br/>  
Provides [TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions') specifying how to build the textual representation  
of the [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder') that contains the textual representation  
of the [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest').  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_ToStringBuilderAsync(TetraPak_AspNet_Debugging_AbstractHttpResponse_System_Text_StringBuilder_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)'></a>
## WebLoggerHelper.ToStringBuilderAsync(AbstractHttpResponse, StringBuilder, Func&lt;TraceRequestOptions&gt;?) Method
Builds a textual representation of the [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse').  
```csharp
public static System.Threading.Tasks.Task<System.Text.StringBuilder> ToStringBuilderAsync(this TetraPak.AspNet.Debugging.AbstractHttpResponse response, System.Text.StringBuilder stringBuilder, System.Func<TetraPak.AspNet.Debugging.TraceRequestOptions>? optionsFactory=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_ToStringBuilderAsync(TetraPak_AspNet_Debugging_AbstractHttpResponse_System_Text_StringBuilder_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_response'></a>
`response` [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse')  
The [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse') to be textually represented.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_ToStringBuilderAsync(TetraPak_AspNet_Debugging_AbstractHttpResponse_System_Text_StringBuilder_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_stringBuilder'></a>
`stringBuilder` [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')  
The [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder') to be used.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_ToStringBuilderAsync(TetraPak_AspNet_Debugging_AbstractHttpResponse_System_Text_StringBuilder_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory'></a>
`optionsFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br/>  
Provides [TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions') specifying how to build the textual representation  
of the [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder') that contains the textual representation  
of the [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse').  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, HttpRequest, Func&lt;TraceRequestOptions&gt;?) Method
Traces a [System.Net.HttpWebRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpWebRequest 'System.Net.HttpWebRequest') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, Microsoft.AspNetCore.Http.HttpRequest request, System.Func<TetraPak.AspNet.Debugging.TraceRequestOptions>? optionsFactory=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The request to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory'></a>
`optionsFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br/>  
Invoked to obtain options for how tracing is conducted.   
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__TetraPak_AspNet_Debugging_AbstractHttpRequest__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, HttpResponse?, AbstractHttpRequest?, Func&lt;TraceRequestOptions&gt;?) Method
Traces a [Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, Microsoft.AspNetCore.Http.HttpResponse? response, TetraPak.AspNet.Debugging.AbstractHttpRequest? request=null, System.Func<TetraPak.AspNet.Debugging.TraceRequestOptions>? optionsFactory=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__TetraPak_AspNet_Debugging_AbstractHttpRequest__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__TetraPak_AspNet_Debugging_AbstractHttpRequest__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_response'></a>
`response` [Microsoft.AspNetCore.Http.HttpResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpResponse 'Microsoft.AspNetCore.Http.HttpResponse')  
The response to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__TetraPak_AspNet_Debugging_AbstractHttpRequest__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_request'></a>
`request` [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')  
(optional)<br/>  
A request (resulting in the response).   
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__Microsoft_AspNetCore_Http_HttpResponse__TetraPak_AspNet_Debugging_AbstractHttpRequest__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory'></a>
`optionsFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br/>  
Invoked to obtain options for how tracing is conducted.   
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpRequestMessage_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, HttpRequestMessage, Func&lt;TraceRequestOptions&gt;?) Method
Traces a [System.Net.HttpWebRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpWebRequest 'System.Net.HttpWebRequest') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, System.Net.Http.HttpRequestMessage request, System.Func<TetraPak.AspNet.Debugging.TraceRequestOptions>? optionsFactory=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpRequestMessage_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpRequestMessage_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_request'></a>
`request` [System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage')  
The request message to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpRequestMessage_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory'></a>
`optionsFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br/>  
Invoked to obtain options for how tracing is conducted.   
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[request](TetraPak_AspNet_Debugging_WebLoggerHelper.md#TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpRequestMessage_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_request 'TetraPak.AspNet.Debugging.WebLoggerHelper.TraceAsync(Microsoft.Extensions.Logging.ILogger?, System.Net.Http.HttpRequestMessage, System.Func&lt;TetraPak.AspNet.Debugging.TraceRequestOptions&gt;?).request')'s URI is relative but [BaseAddress](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_BaseAddress 'TetraPak.AspNet.Debugging.TraceRequestOptions.BaseAddress')  
              is `null` in the [TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions') provided by [optionsFactory](TetraPak_AspNet_Debugging_WebLoggerHelper.md#TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpRequestMessage_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory 'TetraPak.AspNet.Debugging.WebLoggerHelper.TraceAsync(Microsoft.Extensions.Logging.ILogger?, System.Net.Http.HttpRequestMessage, System.Func&lt;TetraPak.AspNet.Debugging.TraceRequestOptions&gt;?).optionsFactory').  
            
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpResponseMessage__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, HttpResponseMessage?, Func&lt;TraceRequestOptions&gt;?) Method
Traces a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, System.Net.Http.HttpResponseMessage? response, System.Func<TetraPak.AspNet.Debugging.TraceRequestOptions>? optionsFactory=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpResponseMessage__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpResponseMessage__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_response'></a>
`response` [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')  
The response to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_Http_HttpResponseMessage__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory'></a>
`optionsFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br/>  
Invoked to obtain options for how tracing is conducted.   
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_HttpWebRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, HttpWebRequest, Func&lt;TraceRequestOptions&gt;?) Method
Traces a [System.Net.HttpWebRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpWebRequest 'System.Net.HttpWebRequest') in the logs.   
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, System.Net.HttpWebRequest request, System.Func<TetraPak.AspNet.Debugging.TraceRequestOptions>? optionsFactory);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_HttpWebRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_HttpWebRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_request'></a>
`request` [System.Net.HttpWebRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpWebRequest 'System.Net.HttpWebRequest')  
The request to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_HttpWebRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory'></a>
`optionsFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br/>  
Specifies how tracing of request bodies is conducted.   
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__TetraPak_AspNet_Debugging_AbstractHttpRequest__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, WebResponse?, AbstractHttpRequest?, Func&lt;TraceRequestOptions&gt;?) Method
Traces a [System.Net.WebResponse](https://docs.microsoft.com/en-us/dotnet/api/System.Net.WebResponse 'System.Net.WebResponse') in the logs.  
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, System.Net.WebResponse? response, TetraPak.AspNet.Debugging.AbstractHttpRequest? request, System.Func<TetraPak.AspNet.Debugging.TraceRequestOptions>? optionsFactory=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__TetraPak_AspNet_Debugging_AbstractHttpRequest__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__TetraPak_AspNet_Debugging_AbstractHttpRequest__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_response'></a>
`response` [System.Net.WebResponse](https://docs.microsoft.com/en-us/dotnet/api/System.Net.WebResponse 'System.Net.WebResponse')  
The response to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__TetraPak_AspNet_Debugging_AbstractHttpRequest__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_request'></a>
`request` [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')  
(optional)<br/>  
A request (resulting in the response).   
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__System_Net_WebResponse__TetraPak_AspNet_Debugging_AbstractHttpRequest__System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory'></a>
`optionsFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br/>  
Invoked to obtain options for how tracing is conducted.   
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_Debugging_AbstractHttpRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)'></a>
## WebLoggerHelper.TraceAsync(ILogger?, AbstractHttpRequest, Func&lt;TraceRequestOptions&gt;?) Method
Builds a textual representation of an [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest') and logs it at   
log level [Microsoft.Extensions.Logging.LogLevel.Trace](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Trace 'Microsoft.Extensions.Logging.LogLevel.Trace')
```csharp
public static System.Threading.Tasks.Task TraceAsync(this Microsoft.Extensions.Logging.ILogger? logger, TetraPak.AspNet.Debugging.AbstractHttpRequest request, System.Func<TetraPak.AspNet.Debugging.TraceRequestOptions>? optionsFactory);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_Debugging_AbstractHttpRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_Debugging_AbstractHttpRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_request'></a>
`request` [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')  
The request to be traced.  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_TraceAsync(Microsoft_Extensions_Logging_ILogger__TetraPak_AspNet_Debugging_AbstractHttpRequest_System_Func_TetraPak_AspNet_Debugging_TraceRequestOptions__)_optionsFactory'></a>
`optionsFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
(optional)<br/>  
Invoked to obtain options for how tracing is conducted.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
  
<a name='TetraPak_AspNet_Debugging_WebLoggerHelper_UseTetraPakTraceRequestAsync(Microsoft_AspNetCore_Builder_IApplicationBuilder)'></a>
## WebLoggerHelper.UseTetraPakTraceRequestAsync(IApplicationBuilder) Method
(fluent API)<br/>  
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
  
