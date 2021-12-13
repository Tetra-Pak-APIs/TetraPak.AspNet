#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## TraceRequestOptions Class
Used when request bodies gets dumped to the logger (at log level [Microsoft.Extensions.Logging.LogLevel.Trace](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Trace 'Microsoft.Extensions.Logging.LogLevel.Trace')).  
```csharp
public class TraceRequestOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TraceRequestOptions  
### Constructors
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_TraceRequestOptions(string_)'></a>
## TraceRequestOptions.TraceRequestOptions(string?) Constructor
Initializes the [TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions') with default values.    
```csharp
public TraceRequestOptions(string? messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_TraceRequestOptions(string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
  
### Properties
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_AsyncBodyFactory'></a>
## TraceRequestOptions.AsyncBodyFactory Property
Assign this to construct custom body content (default = `null`).  
```csharp
public System.Func<System.Threading.Tasks.Task<string>>? AsyncBodyFactory { get; set; }
```
#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')
#### See Also
- [WithAsyncBodyFactory(Func&lt;Task&lt;string&gt;&gt;?)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithAsyncBodyFactory(System_Func_System_Threading_Tasks_Task_string___) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithAsyncBodyFactory(System.Func&lt;System.Threading.Tasks.Task&lt;string&gt;&gt;?)')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_AsyncDecorationHandler'></a>
## TraceRequestOptions.AsyncDecorationHandler Property
A callback handler, invoked after the request message has been serialized to  
a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') but before the result is propagated to the logger provider.  
Use this to decorate the result with custom content.  
```csharp
internal System.Func<System.Text.StringBuilder,System.Threading.Tasks.Task<System.Text.StringBuilder>>? AsyncDecorationHandler { get; set; }
```
#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')
#### See Also
- [WithDecorator(Func&lt;StringBuilder,Task&lt;StringBuilder&gt;&gt;)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithDecorator(System_Func_System_Text_StringBuilder_System_Threading_Tasks_Task_System_Text_StringBuilder__) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithDecorator(System.Func&lt;System.Text.StringBuilder,System.Threading.Tasks.Task&lt;System.Text.StringBuilder&gt;&gt;)')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_BaseAddress'></a>
## TraceRequestOptions.BaseAddress Property
A base address used for the traced request message. This should be passed if  
the request message's URI ([System.Net.Http.HttpRequestMessage.RequestUri](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage.RequestUri 'System.Net.Http.HttpRequestMessage.RequestUri')) is a relative path.  
If `null` the request message's URI is expected to be an absolute URI (which may throw an  
exception).  
```csharp
public System.Uri? BaseAddress { get; set; }
```
#### Property Value
[System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_BufferSize'></a>
## TraceRequestOptions.BufferSize Property
The buffer size. Set for reading large bodies.  
Please note that the setter enforces minimum value 128.   
```csharp
public int BufferSize { get; set; }
```
#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_ContentLengthAsyncThreshold'></a>
## TraceRequestOptions.ContentLengthAsyncThreshold Property
Gets or sets a value that is used when tracing large requests. Requests that exceeds this value  
in content length will automatically be traced in a background thread to reduce the performance hit.  
```csharp
public uint ContentLengthAsyncThreshold { get; set; }
```
#### Property Value
[System.UInt32](https://docs.microsoft.com/en-us/dotnet/api/System.UInt32 'System.UInt32')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_DefaultContentLengthAsyncThreshold'></a>
## TraceRequestOptions.DefaultContentLengthAsyncThreshold Property
(static property)<br/>  
Gets or sets a default value used for the [ContentLengthAsyncThreshold](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_ContentLengthAsyncThreshold 'TetraPak.AspNet.Debugging.TraceRequestOptions.ContentLengthAsyncThreshold')  
property's initial value.  
```csharp
public static uint DefaultContentLengthAsyncThreshold { get; set; }
```
#### Property Value
[System.UInt32](https://docs.microsoft.com/en-us/dotnet/api/System.UInt32 'System.UInt32')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_DefaultForceTraceBody'></a>
## TraceRequestOptions.DefaultForceTraceBody Property
The default value for [ForceTraceBody](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_ForceTraceBody 'TetraPak.AspNet.Debugging.TraceRequestOptions.ForceTraceBody').  
```csharp
public static bool DefaultForceTraceBody { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_DefaultHeaders'></a>
## TraceRequestOptions.DefaultHeaders Property
Gets or sets a collection of default request headers to be passed, unless overridden  
by [System.Net.Http.HttpRequestMessage.Headers](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage.Headers 'System.Net.Http.HttpRequestMessage.Headers').  
```csharp
public System.Net.Http.Headers.HttpRequestHeaders? DefaultHeaders { get; set; }
```
#### Property Value
[System.Net.Http.Headers.HttpRequestHeaders](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.Headers.HttpRequestHeaders 'System.Net.Http.Headers.HttpRequestHeaders')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_Detail'></a>
## TraceRequestOptions.Detail Property
Gets or sets a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') to be used as a "detail" in textual representations of the traffic.  
```csharp
public string? Detail { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
#### See Also
- [WithDetail(string)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithDetail(string) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithDetail(string)')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_Direction'></a>
## TraceRequestOptions.Direction Property
(optional; default=[Unknown](TetraPak_AspNet_Debugging_HttpDirection.md#TetraPak_AspNet_Debugging_HttpDirection_Unknown 'TetraPak.AspNet.Debugging.HttpDirection.Unknown'))<br/>  
Gets or sets   
```csharp
public TetraPak.AspNet.Debugging.HttpDirection Direction { get; set; }
```
#### Property Value
[HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection')
#### See Also
- [WithDirection(HttpDirection, string?)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, string?)')
- [WithDirection(HttpDirection, object?)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, object?)')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_ForceTraceBody'></a>
## TraceRequestOptions.ForceTraceBody Property
(default=[DefaultForceTraceBody](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_DefaultForceTraceBody 'TetraPak.AspNet.Debugging.TraceRequestOptions.DefaultForceTraceBody'))<br/>  
Gets or sets a value that forces the tracing of the request/response body  
```csharp
public bool ForceTraceBody { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_Initiator'></a>
## TraceRequestOptions.Initiator Property
(optional)<br/>  
Gets or sets a request initiator (eg. "actor").  
```csharp
public string? Initiator { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
#### See Also
- [WithInitiator(string, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithInitiator(string, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
- [WithInitiator(object, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithInitiator(object, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_MaxSize'></a>
## TraceRequestOptions.MaxSize Property
A maximum length. Set this value to truncate when tracing very large bodies such as media or binaries.  
```csharp
public long MaxSize { get; set; }
```
#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')
### Remarks
This value should be a equally divisible by [BufferSize](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_BufferSize 'TetraPak.AspNet.Debugging.TraceRequestOptions.BufferSize') for efficiency.  
The setter automatically rounds (`value` / [BufferSize](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_BufferSize 'TetraPak.AspNet.Debugging.TraceRequestOptions.BufferSize'))  
and multiplies with [BufferSize](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_BufferSize 'TetraPak.AspNet.Debugging.TraceRequestOptions.BufferSize').  
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_MessageId'></a>
## TraceRequestOptions.MessageId Property
Gets or sets a unique string value for tracking a request/response (mainly for diagnostics purposes).  
```csharp
public string? MessageId { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
### Methods
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_Default(string_)'></a>
## TraceRequestOptions.Default(string?) Method
Gets default [TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')
```csharp
public static TetraPak.AspNet.Debugging.TraceRequestOptions Default(string? messageId);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_Default(string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithAsyncBodyFactory(System_Func_System_Threading_Tasks_Task_string___)'></a>
## TraceRequestOptions.WithAsyncBodyFactory(Func&lt;Task&lt;string&gt;&gt;?) Method
(fluent API)<br/>  
Assigns the [AsyncBodyFactory](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_AsyncBodyFactory 'TetraPak.AspNet.Debugging.TraceRequestOptions.AsyncBodyFactory') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceRequestOptions WithAsyncBodyFactory(System.Func<System.Threading.Tasks.Task<string>>? factory);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithAsyncBodyFactory(System_Func_System_Threading_Tasks_Task_string___)_factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
  
#### Returns
[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithBaseAddress(System_Uri)'></a>
## TraceRequestOptions.WithBaseAddress(Uri) Method
(fluent API)<br/>  
Assigns the [BaseAddress](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_BaseAddress 'TetraPak.AspNet.Debugging.TraceRequestOptions.BaseAddress') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceRequestOptions WithBaseAddress(System.Uri baseAddress);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithBaseAddress(System_Uri)_baseAddress'></a>
`baseAddress` [System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')  
  
#### Returns
[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDecorator(System_Func_System_Text_StringBuilder_System_Threading_Tasks_Task_System_Text_StringBuilder__)'></a>
## TraceRequestOptions.WithDecorator(Func&lt;StringBuilder,Task&lt;StringBuilder&gt;&gt;) Method
(fluent API)<br/>  
Assigns the [AsyncDecorationHandler](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_AsyncDecorationHandler 'TetraPak.AspNet.Debugging.TraceRequestOptions.AsyncDecorationHandler') decorator and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceRequestOptions WithDecorator(System.Func<System.Text.StringBuilder,System.Threading.Tasks.Task<System.Text.StringBuilder>> decorator);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDecorator(System_Func_System_Text_StringBuilder_System_Threading_Tasks_Task_System_Text_StringBuilder__)_decorator'></a>
`decorator` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
  
#### Returns
[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDefaultHeaders(System_Net_Http_Headers_HttpRequestHeaders)'></a>
## TraceRequestOptions.WithDefaultHeaders(HttpRequestHeaders) Method
(fluent API)<br/>  
Assigns the [DefaultHeaders](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_DefaultHeaders 'TetraPak.AspNet.Debugging.TraceRequestOptions.DefaultHeaders') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceRequestOptions WithDefaultHeaders(System.Net.Http.Headers.HttpRequestHeaders headers);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDefaultHeaders(System_Net_Http_Headers_HttpRequestHeaders)_headers'></a>
`headers` [System.Net.Http.Headers.HttpRequestHeaders](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.Headers.HttpRequestHeaders 'System.Net.Http.Headers.HttpRequestHeaders')  
  
#### Returns
[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDetail(string)'></a>
## TraceRequestOptions.WithDetail(string) Method
(fluent API)<br/>  
Assigns the [Detail](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Detail 'TetraPak.AspNet.Debugging.TraceRequestOptions.Detail') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceRequestOptions WithDetail(string value);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDetail(string)_value'></a>
`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
#### See Also
- [Detail](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Detail 'TetraPak.AspNet.Debugging.TraceRequestOptions.Detail')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_)'></a>
## TraceRequestOptions.WithDirection(HttpDirection, object?) Method
(fluent API)<br/>  
Assigns the [Direction](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Direction 'TetraPak.AspNet.Debugging.TraceRequestOptions.Direction') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceRequestOptions WithDirection(TetraPak.AspNet.Debugging.HttpDirection value, object? initiator);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_)_value'></a>
`value` [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection')  
The [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection') value.  
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_)_initiator'></a>
`initiator` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
(optional)<br/>  
Assign this value to also invoke [WithInitiator(object, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithInitiator(object, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)').  
  
#### Returns
[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
#### See Also
- [Direction](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Direction 'TetraPak.AspNet.Debugging.TraceRequestOptions.Direction')
- [WithInitiator(string, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithInitiator(string, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
- [WithInitiator(object, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithInitiator(object, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_)'></a>
## TraceRequestOptions.WithDirection(HttpDirection, string?) Method
(fluent API)<br/>  
Assigns the [Direction](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Direction 'TetraPak.AspNet.Debugging.TraceRequestOptions.Direction') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceRequestOptions WithDirection(TetraPak.AspNet.Debugging.HttpDirection value, string? initiator);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_)_value'></a>
`value` [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection')  
The [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection') value.  
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_)_initiator'></a>
`initiator` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Assign this value to also invoke [WithInitiator(string, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithInitiator(string, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)').  
  
#### Returns
[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
#### See Also
- [Direction](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Direction 'TetraPak.AspNet.Debugging.TraceRequestOptions.Direction')
- [WithInitiator(string, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithInitiator(string, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
- [WithInitiator(object, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithInitiator(object, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection)'></a>
## TraceRequestOptions.WithDirection(HttpDirection) Method
(fluent API)<br/>  
Assigns the [Direction](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Direction 'TetraPak.AspNet.Debugging.TraceRequestOptions.Direction') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceRequestOptions WithDirection(TetraPak.AspNet.Debugging.HttpDirection value);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection)_value'></a>
`value` [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection')  
The [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection') value.  
  
#### Returns
[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
#### See Also
- [Direction](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Direction 'TetraPak.AspNet.Debugging.TraceRequestOptions.Direction')
- [WithInitiator(string, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithInitiator(string, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
- [WithInitiator(object, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithInitiator(object, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_)'></a>
## TraceRequestOptions.WithInitiator(object, Nullable&lt;HttpDirection&gt;) Method
(fluent API)<br/>  
Assigns the [Direction](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Direction 'TetraPak.AspNet.Debugging.TraceRequestOptions.Direction') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceRequestOptions WithInitiator(object initiator, System.Nullable<TetraPak.AspNet.Debugging.HttpDirection> direction);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_)_initiator'></a>
`initiator` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The [Initiator](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Initiator 'TetraPak.AspNet.Debugging.TraceRequestOptions.Initiator') value.  
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_)_direction'></a>
`direction` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Assign this value to also invoke [WithDirection(HttpDirection, object?)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, object?)').  
  
#### Returns
[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
#### See Also
- [Initiator](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Initiator 'TetraPak.AspNet.Debugging.TraceRequestOptions.Initiator')
- [WithDirection(HttpDirection, string?)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, string?)')
- [WithDirection(HttpDirection, object?)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, object?)')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(object)'></a>
## TraceRequestOptions.WithInitiator(object) Method
(fluent API)<br/>  
Assigns the [Direction](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Direction 'TetraPak.AspNet.Debugging.TraceRequestOptions.Direction') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceRequestOptions WithInitiator(object initiator);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(object)_initiator'></a>
`initiator` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The [Initiator](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Initiator 'TetraPak.AspNet.Debugging.TraceRequestOptions.Initiator') value.  
  
#### Returns
[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
#### See Also
- [Initiator](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Initiator 'TetraPak.AspNet.Debugging.TraceRequestOptions.Initiator')
- [WithDirection(HttpDirection, string?)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, string?)')
- [WithDirection(HttpDirection, object?)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, object?)')
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_)'></a>
## TraceRequestOptions.WithInitiator(string, Nullable&lt;HttpDirection&gt;) Method
(fluent API)<br/>  
Assigns the [Direction](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Direction 'TetraPak.AspNet.Debugging.TraceRequestOptions.Direction') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceRequestOptions WithInitiator(string value, System.Nullable<TetraPak.AspNet.Debugging.HttpDirection> direction);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_)_value'></a>
`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [Initiator](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Initiator 'TetraPak.AspNet.Debugging.TraceRequestOptions.Initiator') value.  
  
<a name='TetraPak_AspNet_Debugging_TraceRequestOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_)_direction'></a>
`direction` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Assign this value to also invoke [WithDirection(HttpDirection, string?)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, string?)').  
  
#### Returns
[TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions')  
#### See Also
- [Initiator](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_Initiator 'TetraPak.AspNet.Debugging.TraceRequestOptions.Initiator')
- [WithDirection(HttpDirection, string?)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, string?)')
- [WithDirection(HttpDirection, object?)](TetraPak_AspNet_Debugging_TraceRequestOptions.md#TetraPak_AspNet_Debugging_TraceRequestOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_) 'TetraPak.AspNet.Debugging.TraceRequestOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, object?)')
  
