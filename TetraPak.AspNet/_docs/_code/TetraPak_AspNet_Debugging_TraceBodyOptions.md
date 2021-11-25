#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## TraceBodyOptions Class
Used when request bodies gets dumped to the logger (at log level [Microsoft.Extensions.Logging.LogLevel.Trace](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Trace 'Microsoft.Extensions.Logging.LogLevel.Trace')).  
```csharp
public class TraceBodyOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TraceBodyOptions  
### Constructors
<a name='TetraPak_AspNet_Debugging_TraceBodyOptions_TraceBodyOptions()'></a>
## TraceBodyOptions.TraceBodyOptions() Constructor
Initializes the [TraceBodyOptions](TetraPak_AspNet_Debugging_TraceBodyOptions.md 'TetraPak.AspNet.Debugging.TraceBodyOptions') with default values.    
```csharp
public TraceBodyOptions();
```
  
### Properties
<a name='TetraPak_AspNet_Debugging_TraceBodyOptions_BufferSize'></a>
## TraceBodyOptions.BufferSize Property
The buffer size. Set for reading large bodies.  
Please note that the setter enforces minimum value 128.   
```csharp
public int BufferSize { get; set; }
```
#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
  
<a name='TetraPak_AspNet_Debugging_TraceBodyOptions_ContentLengthAsyncThreshold'></a>
## TraceBodyOptions.ContentLengthAsyncThreshold Property
Gets or sets a value that is used when tracing large requests. Requests that exceeds this value  
in content length will automatically be traced in a background thread to reduce the performance hit.  
```csharp
public uint ContentLengthAsyncThreshold { get; set; }
```
#### Property Value
[System.UInt32](https://docs.microsoft.com/en-us/dotnet/api/System.UInt32 'System.UInt32')
  
<a name='TetraPak_AspNet_Debugging_TraceBodyOptions_Default'></a>
## TraceBodyOptions.Default Property
Gets default [TraceBodyOptions](TetraPak_AspNet_Debugging_TraceBodyOptions.md 'TetraPak.AspNet.Debugging.TraceBodyOptions')
```csharp
public static TetraPak.AspNet.Debugging.TraceBodyOptions Default { get; }
```
#### Property Value
[TraceBodyOptions](TetraPak_AspNet_Debugging_TraceBodyOptions.md 'TetraPak.AspNet.Debugging.TraceBodyOptions')
  
<a name='TetraPak_AspNet_Debugging_TraceBodyOptions_DefaultContentLengthAsyncThreshold'></a>
## TraceBodyOptions.DefaultContentLengthAsyncThreshold Property
(static property)<br/>  
Gets or sets a default value used for the [ContentLengthAsyncThreshold](TetraPak_AspNet_Debugging_TraceBodyOptions.md#TetraPak_AspNet_Debugging_TraceBodyOptions_ContentLengthAsyncThreshold 'TetraPak.AspNet.Debugging.TraceBodyOptions.ContentLengthAsyncThreshold')  
property's initial value.  
```csharp
public static uint DefaultContentLengthAsyncThreshold { get; set; }
```
#### Property Value
[System.UInt32](https://docs.microsoft.com/en-us/dotnet/api/System.UInt32 'System.UInt32')
  
<a name='TetraPak_AspNet_Debugging_TraceBodyOptions_MaxSize'></a>
## TraceBodyOptions.MaxSize Property
A maximum length. Set this value to truncate when tracing very large bodies such as media or binaries.  
```csharp
public long MaxSize { get; set; }
```
#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')
### Remarks
This value should be a equally divisible by [BufferSize](TetraPak_AspNet_Debugging_TraceBodyOptions.md#TetraPak_AspNet_Debugging_TraceBodyOptions_BufferSize 'TetraPak.AspNet.Debugging.TraceBodyOptions.BufferSize') for efficiency.  
The setter automatically rounds (`value` / [BufferSize](TetraPak_AspNet_Debugging_TraceBodyOptions.md#TetraPak_AspNet_Debugging_TraceBodyOptions_BufferSize 'TetraPak.AspNet.Debugging.TraceBodyOptions.BufferSize'))  
and multiplies with [BufferSize](TetraPak_AspNet_Debugging_TraceBodyOptions.md#TetraPak_AspNet_Debugging_TraceBodyOptions_BufferSize 'TetraPak.AspNet.Debugging.TraceBodyOptions.BufferSize').  
  
