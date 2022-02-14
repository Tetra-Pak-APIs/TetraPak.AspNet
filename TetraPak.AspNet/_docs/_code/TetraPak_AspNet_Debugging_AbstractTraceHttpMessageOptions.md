#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## AbstractTraceHttpMessageOptions Class
```csharp
public abstract class AbstractTraceHttpMessageOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AbstractTraceHttpMessageOptions  

Derived  
&#8627; [TraceHttpRequestOptions](TetraPak_AspNet_Debugging_TraceHttpRequestOptions.md 'TetraPak.AspNet.Debugging.TraceHttpRequestOptions')  
&#8627; [TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
### Properties
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_AsyncBodyFactory'></a>
## AbstractTraceHttpMessageOptions.AsyncBodyFactory Property
Assign this to construct custom body content (default = `null`).  
```csharp
public System.Func<System.Threading.Tasks.Task<string>>? AsyncBodyFactory { get; set; }
```
#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_AsyncDecorationHandler'></a>
## AbstractTraceHttpMessageOptions.AsyncDecorationHandler Property
A callback handler, invoked after the request message has been serialized to  
a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') but before the result is propagated to the logger provider.  
Use this to decorate the result with custom content.  
```csharp
internal System.Func<System.Text.StringBuilder,System.Threading.Tasks.Task<System.Text.StringBuilder>>? AsyncDecorationHandler { get; set; }
```
#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_BaseAddress'></a>
## AbstractTraceHttpMessageOptions.BaseAddress Property
A base address used for the traced request message. This should be passed if  
the request message's URI ([System.Net.Http.HttpRequestMessage.RequestUri](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage.RequestUri 'System.Net.Http.HttpRequestMessage.RequestUri')) is a relative path.  
If `null` the request message's URI is expected to be an absolute URI (which may throw an  
exception).  
```csharp
public System.Uri? BaseAddress { get; set; }
```
#### Property Value
[System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_BufferSize'></a>
## AbstractTraceHttpMessageOptions.BufferSize Property
The buffer size. Set for reading large bodies.  
Please note that the setter enforces minimum value 128.   
```csharp
public int BufferSize { get; set; }
```
#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_ContentLengthAsyncThreshold'></a>
## AbstractTraceHttpMessageOptions.ContentLengthAsyncThreshold Property
Gets or sets a value that is used when tracing large requests. Requests that exceeds this value  
in content length will automatically be traced in a background thread to reduce the performance hit.  
```csharp
public uint ContentLengthAsyncThreshold { get; set; }
```
#### Property Value
[System.UInt32](https://docs.microsoft.com/en-us/dotnet/api/System.UInt32 'System.UInt32')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_DefaultContentLengthAsyncThreshold'></a>
## AbstractTraceHttpMessageOptions.DefaultContentLengthAsyncThreshold Property
(static property)<br/>  
Gets or sets a default value used for the [ContentLengthAsyncThreshold](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_ContentLengthAsyncThreshold 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.ContentLengthAsyncThreshold')  
property's initial value.  
```csharp
public static uint DefaultContentLengthAsyncThreshold { get; set; }
```
#### Property Value
[System.UInt32](https://docs.microsoft.com/en-us/dotnet/api/System.UInt32 'System.UInt32')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_DefaultForceTraceBody'></a>
## AbstractTraceHttpMessageOptions.DefaultForceTraceBody Property
The default value for [ForceTraceBody](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_ForceTraceBody 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.ForceTraceBody').  
```csharp
public static bool DefaultForceTraceBody { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_DefaultHeaders'></a>
## AbstractTraceHttpMessageOptions.DefaultHeaders Property
Gets or sets a collection of default request headers to be passed, unless overridden  
by [System.Net.Http.HttpRequestMessage.Headers](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage.Headers 'System.Net.Http.HttpRequestMessage.Headers').  
```csharp
public System.Net.Http.Headers.HttpRequestHeaders? DefaultHeaders { get; set; }
```
#### Property Value
[System.Net.Http.Headers.HttpRequestHeaders](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.Headers.HttpRequestHeaders 'System.Net.Http.Headers.HttpRequestHeaders')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Detail'></a>
## AbstractTraceHttpMessageOptions.Detail Property
Gets or sets a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') to be used as a "detail" in textual representations of the traffic.  
```csharp
public string? Detail { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Direction'></a>
## AbstractTraceHttpMessageOptions.Direction Property
(optional; default=[Unknown](TetraPak_AspNet_Debugging_HttpDirection.md#TetraPak_AspNet_Debugging_HttpDirection_Unknown 'TetraPak.AspNet.Debugging.HttpDirection.Unknown'))<br/>  
Gets or sets   
```csharp
public TetraPak.AspNet.Debugging.HttpDirection Direction { get; set; }
```
#### Property Value
[HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_ForceTraceBody'></a>
## AbstractTraceHttpMessageOptions.ForceTraceBody Property
(default=[DefaultForceTraceBody](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_DefaultForceTraceBody 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.DefaultForceTraceBody'))<br/>  
Gets or sets a value that forces the tracing of the request/response body  
```csharp
public bool ForceTraceBody { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_HideRequestUri'></a>
## AbstractTraceHttpMessageOptions.HideRequestUri Property
Gets or sets a value that specifies whether to hide the request URI from the trace.  
```csharp
public bool HideRequestUri { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Initiator'></a>
## AbstractTraceHttpMessageOptions.Initiator Property
(optional)<br/>  
Gets or sets a request initiator (eg. "actor").  
```csharp
public string? Initiator { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_MaxSize'></a>
## AbstractTraceHttpMessageOptions.MaxSize Property
A maximum length. Set this value to truncate when tracing very large bodies such as media or binaries.  
```csharp
public long MaxSize { get; set; }
```
#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')
### Remarks
This value should be a equally divisible by [BufferSize](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_BufferSize 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.BufferSize') for efficiency.  
The setter automatically rounds (`value` / [BufferSize](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_BufferSize 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.BufferSize'))  
and multiplies with [BufferSize](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_BufferSize 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.BufferSize').  
  
<a name='TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_MessageId'></a>
## AbstractTraceHttpMessageOptions.MessageId Property
Gets or sets a unique string value for tracking a request/response (mainly for diagnostics purposes).  
```csharp
public string? MessageId { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
