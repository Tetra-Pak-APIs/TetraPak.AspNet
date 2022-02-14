#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Diagnostics](TetraPak_AspNet_Diagnostics.md 'TetraPak.AspNet.Diagnostics')
## ServiceDiagnostics Class
```csharp
public class ServiceDiagnostics :
System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>,
System.Collections.IEnumerable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ServiceDiagnostics  

Implements [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')  
### Fields
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_TimerPrefix'></a>
## ServiceDiagnostics.TimerPrefix Field
The prefix for timer values.  
```csharp
public const string TimerPrefix = tpd-time;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
#### See Also
- [GetValues(string?)](TetraPak_AspNet_Diagnostics_ServiceDiagnostics.md#TetraPak_AspNet_Diagnostics_ServiceDiagnostics_GetValues(string_) 'TetraPak.AspNet.Diagnostics.ServiceDiagnostics.GetValues(string?)')
  
### Properties
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_ElapsedMilliseconds'></a>
## ServiceDiagnostics.ElapsedMilliseconds Property
Gets the diagnosed service's elapsed time in milliseconds.  
```csharp
public long ElapsedMilliseconds { get; set; }
```
#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')
  
### Methods
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_GetElapsedMs(string__bool)'></a>
## ServiceDiagnostics.GetElapsedMs(string?, bool) Method
Returns the elapsed time and, optionally, stops the timer.   
```csharp
public System.Nullable<long> GetElapsedMs(string? key=null, bool stopTimer=true);
```
#### Parameters
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_GetElapsedMs(string__bool)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the diagnostics source.   
  
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_GetElapsedMs(string__bool)_stopTimer'></a>
`stopTimer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to also stop the timer (if the timer was already stopped the request is ignored).  
  
#### Returns
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
The number of ticks that has elapsed since the timer was started until now (or it ended, when stopped).  
  
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_GetEnumerator()'></a>
## ServiceDiagnostics.GetEnumerator() Method
Returns an enumerator that iterates through the collection.
```csharp
public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string,object>> GetEnumerator();
```
#### Returns
[System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')  
An enumerator that can be used to iterate through the collection.

Implements [GetEnumerator()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1.GetEnumerator 'System.Collections.Generic.IEnumerable`1.GetEnumerator'), [GetEnumerator()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable.GetEnumerator 'System.Collections.IEnumerable.GetEnumerator')  
  
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_GetValues(string_)'></a>
## ServiceDiagnostics.GetValues(string?) Method
Returns all values, optionally filtered with a [prefix](TetraPak_AspNet_Diagnostics_ServiceDiagnostics.md#TetraPak_AspNet_Diagnostics_ServiceDiagnostics_GetValues(string_)_prefix 'TetraPak.AspNet.Diagnostics.ServiceDiagnostics.GetValues(string?).prefix') pattern.  
```csharp
public System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string,object>> GetValues(string? prefix=null);
```
#### Parameters
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_GetValues(string_)_prefix'></a>
`prefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A prefix pattern for filtering result.  
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of [System.Collections.Generic.KeyValuePair&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2').  
  
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_StartTimer(string)'></a>
## ServiceDiagnostics.StartTimer(string) Method
Starts a timer to measure a specified source.   
```csharp
public void StartTimer(string source);
```
#### Parameters
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_StartTimer(string)_source'></a>
`source` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies a source to be timed.  
  
  
