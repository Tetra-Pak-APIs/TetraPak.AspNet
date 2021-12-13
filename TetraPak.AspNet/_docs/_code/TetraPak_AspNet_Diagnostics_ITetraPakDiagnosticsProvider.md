#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Diagnostics](TetraPak_AspNet_Diagnostics.md 'TetraPak.AspNet.Diagnostics')
## ITetraPakDiagnosticsProvider Interface
Classes implementing this interface can be used to provide service diagnostics.  
```csharp
public interface ITetraPakDiagnosticsProvider
```

Derived  
&#8627; [TetraPakHttpClientProvider](TetraPak_AspNet_TetraPakHttpClientProvider.md 'TetraPak.AspNet.TetraPakHttpClientProvider')  
### Methods
<a name='TetraPak_AspNet_Diagnostics_ITetraPakDiagnosticsProvider_DiagnosticsStartTimer(string)'></a>
## ITetraPakDiagnosticsProvider.DiagnosticsStartTimer(string) Method
Starts a specified timer.  
```csharp
void DiagnosticsStartTimer(string timerKey);
```
#### Parameters
<a name='TetraPak_AspNet_Diagnostics_ITetraPakDiagnosticsProvider_DiagnosticsStartTimer(string)_timerKey'></a>
`timerKey` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the timer to be started.  
  
  
<a name='TetraPak_AspNet_Diagnostics_ITetraPakDiagnosticsProvider_DiagnosticsStopTimer(string)'></a>
## ITetraPakDiagnosticsProvider.DiagnosticsStopTimer(string) Method
Stops a specified timer.  
```csharp
System.Nullable<long> DiagnosticsStopTimer(string timerKey);
```
#### Parameters
<a name='TetraPak_AspNet_Diagnostics_ITetraPakDiagnosticsProvider_DiagnosticsStopTimer(string)_timerKey'></a>
`timerKey` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the timer to be stopped.  
  
#### Returns
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
  
