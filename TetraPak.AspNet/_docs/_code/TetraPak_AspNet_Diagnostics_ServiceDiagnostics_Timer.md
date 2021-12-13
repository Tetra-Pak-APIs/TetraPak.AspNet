#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Diagnostics](TetraPak_AspNet_Diagnostics.md 'TetraPak.AspNet.Diagnostics').[ServiceDiagnostics](TetraPak_AspNet_Diagnostics_ServiceDiagnostics.md 'TetraPak.AspNet.Diagnostics.ServiceDiagnostics')
## ServiceDiagnostics.Timer Class
A service diagnostics timer.  
```csharp
public class ServiceDiagnostics.Timer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Timer  
### Properties
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_Timer_Ended'></a>
## ServiceDiagnostics.Timer.Ended Property
Gets the timer end time (ticks).  
```csharp
public System.Nullable<long> Ended { get; set; }
```
#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
  
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_Timer_Started'></a>
## ServiceDiagnostics.Timer.Started Property
Gets the timer start time (ticks).  
```csharp
public long Started { get; }
```
#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')
  
### Methods
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_Timer_ElapsedMs(bool)'></a>
## ServiceDiagnostics.Timer.ElapsedMs(bool) Method
Returns the elapsed time and, optionally, stops the timer.   
```csharp
public long ElapsedMs(bool stop=true);
```
#### Parameters
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_Timer_ElapsedMs(bool)_stop'></a>
`stop` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to also stop the timer (if the timer was already stopped the request is ignored).  
  
#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
The number of ticks that has elapsed since the timer was started until now (or it ended, when stopped).  
  
