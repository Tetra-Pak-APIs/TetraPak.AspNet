#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## TraceHttpResponseOptions Class
Used to control how HTTP response gets represented (for tracing).  
```csharp
public class TraceHttpResponseOptions : TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [AbstractTraceHttpMessageOptions](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions') &#129106; TraceHttpResponseOptions  
### Methods
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_Default(string_)'></a>
## TraceHttpResponseOptions.Default(string?) Method
Gets default [TraceHttpRequestOptions](TetraPak_AspNet_Debugging_TraceHttpRequestOptions.md 'TetraPak.AspNet.Debugging.TraceHttpRequestOptions')
```csharp
public static TetraPak.AspNet.Debugging.TraceHttpResponseOptions Default(string? messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_Default(string_)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithAsyncBodyFactory(System_Func_System_Threading_Tasks_Task_string___)'></a>
## TraceHttpResponseOptions.WithAsyncBodyFactory(Func&lt;Task&lt;string&gt;&gt;?) Method
(fluent API)<br/>  
Assigns the [AsyncBodyFactory](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_AsyncBodyFactory 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.AsyncBodyFactory') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpResponseOptions WithAsyncBodyFactory(System.Func<System.Threading.Tasks.Task<string>>? factory);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithAsyncBodyFactory(System_Func_System_Threading_Tasks_Task_string___)_factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithBaseAddress(System_Uri)'></a>
## TraceHttpResponseOptions.WithBaseAddress(Uri) Method
(fluent API)<br/>  
Assigns the [BaseAddress](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_BaseAddress 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.BaseAddress') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpResponseOptions WithBaseAddress(System.Uri baseAddress);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithBaseAddress(System_Uri)_baseAddress'></a>
`baseAddress` [System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')  
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDecorator(System_Func_System_Text_StringBuilder_System_Threading_Tasks_Task_System_Text_StringBuilder__)'></a>
## TraceHttpResponseOptions.WithDecorator(Func&lt;StringBuilder,Task&lt;StringBuilder&gt;&gt;) Method
(fluent API)<br/>  
Assigns the [AsyncDecorationHandler](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_AsyncDecorationHandler 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.AsyncDecorationHandler')  
decorator and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpResponseOptions WithDecorator(System.Func<System.Text.StringBuilder,System.Threading.Tasks.Task<System.Text.StringBuilder>> decorator);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDecorator(System_Func_System_Text_StringBuilder_System_Threading_Tasks_Task_System_Text_StringBuilder__)_decorator'></a>
`decorator` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDefaultHeaders(System_Net_Http_Headers_HttpRequestHeaders)'></a>
## TraceHttpResponseOptions.WithDefaultHeaders(HttpRequestHeaders) Method
(fluent API)<br/>  
Assigns the [DefaultHeaders](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_DefaultHeaders 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.DefaultHeaders') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpResponseOptions WithDefaultHeaders(System.Net.Http.Headers.HttpRequestHeaders headers);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDefaultHeaders(System_Net_Http_Headers_HttpRequestHeaders)_headers'></a>
`headers` [System.Net.Http.Headers.HttpRequestHeaders](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.Headers.HttpRequestHeaders 'System.Net.Http.Headers.HttpRequestHeaders')  
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDetail(string)'></a>
## TraceHttpResponseOptions.WithDetail(string) Method
(fluent API)<br/>  
Assigns the [Detail](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Detail 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Detail') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpResponseOptions WithDetail(string value);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDetail(string)_value'></a>
`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
#### See Also
- [Detail](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Detail 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Detail')
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection)'></a>
## TraceHttpResponseOptions.WithDirection(HttpDirection) Method
(fluent API)<br/>  
Assigns the [Direction](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Direction 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Direction') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpResponseOptions WithDirection(TetraPak.AspNet.Debugging.HttpDirection value);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection)_value'></a>
`value` [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection')  
The [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection') value.  
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
#### See Also
- [Direction](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Direction 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Direction')
- [WithInitiator(string, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithInitiator(string, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
- [WithInitiator(object, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithInitiator(object, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_)'></a>
## TraceHttpResponseOptions.WithDirection(HttpDirection, object?) Method
(fluent API)<br/>  
Assigns the [Direction](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Direction 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Direction') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpResponseOptions WithDirection(TetraPak.AspNet.Debugging.HttpDirection value, object? initiator);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_)_value'></a>
`value` [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection')  
The [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection') value.  
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_)_initiator'></a>
`initiator` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
(optional)<br/>  
Assign this value to also invoke [WithInitiator(object, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithInitiator(object, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)').  
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
#### See Also
- [Direction](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Direction 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Direction')
- [WithInitiator(string, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithInitiator(string, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
- [WithInitiator(object, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithInitiator(object, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_)'></a>
## TraceHttpResponseOptions.WithDirection(HttpDirection, string?) Method
(fluent API)<br/>  
Assigns the [Direction](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Direction 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Direction') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpResponseOptions WithDirection(TetraPak.AspNet.Debugging.HttpDirection value, string? initiator);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_)_value'></a>
`value` [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection')  
The [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection') value.  
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_)_initiator'></a>
`initiator` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Assign this value to also invoke [WithInitiator(string, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithInitiator(string, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)').  
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
#### See Also
- [Direction](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Direction 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Direction')
- [WithInitiator(string, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithInitiator(string, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
- [WithInitiator(object, Nullable&lt;HttpDirection&gt;)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithInitiator(object, System.Nullable&lt;TetraPak.AspNet.Debugging.HttpDirection&gt;)')
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(object)'></a>
## TraceHttpResponseOptions.WithInitiator(object) Method
(fluent API)<br/>  
Assigns the [Direction](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Direction 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Direction') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpResponseOptions WithInitiator(object initiator);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(object)_initiator'></a>
`initiator` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The [Initiator](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Initiator 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Initiator') value.  
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
#### See Also
- [Initiator](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Initiator 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Initiator')
- [WithDirection(HttpDirection, string?)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, string?)')
- [WithDirection(HttpDirection, object?)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, object?)')
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_)'></a>
## TraceHttpResponseOptions.WithInitiator(object, Nullable&lt;HttpDirection&gt;) Method
(fluent API)<br/>  
Assigns the [Direction](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Direction 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Direction') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpResponseOptions WithInitiator(object initiator, System.Nullable<TetraPak.AspNet.Debugging.HttpDirection> direction);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_)_initiator'></a>
`initiator` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The [Initiator](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Initiator 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Initiator') value.  
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(object_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_)_direction'></a>
`direction` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Assign this value to also invoke [WithDirection(HttpDirection, object?)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, object?)').  
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
#### See Also
- [Initiator](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Initiator 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Initiator')
- [WithDirection(HttpDirection, string?)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, string?)')
- [WithDirection(HttpDirection, object?)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, object?)')
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_)'></a>
## TraceHttpResponseOptions.WithInitiator(string, Nullable&lt;HttpDirection&gt;) Method
(fluent API)<br/>  
Assigns the [Direction](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Direction 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Direction') property and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpResponseOptions WithInitiator(string value, System.Nullable<TetraPak.AspNet.Debugging.HttpDirection> direction);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_)_value'></a>
`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [Initiator](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Initiator 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Initiator') value.  
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithInitiator(string_System_Nullable_TetraPak_AspNet_Debugging_HttpDirection_)_direction'></a>
`direction` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Assign this value to also invoke [WithDirection(HttpDirection, string?)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, string?)').  
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
#### See Also
- [Initiator](TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions.md#TetraPak_AspNet_Debugging_AbstractTraceHttpMessageOptions_Initiator 'TetraPak.AspNet.Debugging.AbstractTraceHttpMessageOptions.Initiator')
- [WithDirection(HttpDirection, string?)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_string_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, string?)')
- [WithDirection(HttpDirection, object?)](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md#TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithDirection(TetraPak_AspNet_Debugging_HttpDirection_object_) 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions.WithDirection(TetraPak.AspNet.Debugging.HttpDirection, object?)')
  
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithRequestUri(bool)'></a>
## TraceHttpResponseOptions.WithRequestUri(bool) Method
(fluent api)<br/>  
Assigns the [TraceHttpRequestOptions.HideRequestUri](https://docs.microsoft.com/en-us/dotnet/api/TraceHttpRequestOptions.HideRequestUri 'TraceHttpRequestOptions.HideRequestUri') and returns `this`.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpResponseOptions WithRequestUri(bool value=true);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_TraceHttpResponseOptions_WithRequestUri(bool)_value'></a>
`value` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Assigns the [TraceHttpRequestOptions.HideRequestUri](https://docs.microsoft.com/en-us/dotnet/api/TraceHttpRequestOptions.HideRequestUri 'TraceHttpRequestOptions.HideRequestUri') to the negated assigned value  
(pass `false` to actually hide the [GenericHttpRequest.Uri](https://docs.microsoft.com/en-us/dotnet/api/GenericHttpRequest.Uri 'GenericHttpRequest.Uri')).     
  
#### Returns
[TraceHttpResponseOptions](TetraPak_AspNet_Debugging_TraceHttpResponseOptions.md 'TetraPak.AspNet.Debugging.TraceHttpResponseOptions')  
  
