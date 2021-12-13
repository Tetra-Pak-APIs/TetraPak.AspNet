#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## RouteDebugArgs Class
Arguments used when invoking a custom routing debugger handler ([RouteDebugHandler(RouteDebugArgs)](TetraPak_AspNet_Debugging_RouteDebugHandler(TetraPak_AspNet_Debugging_RouteDebugArgs).md 'TetraPak.AspNet.Debugging.RouteDebugHandler(TetraPak.AspNet.Debugging.RouteDebugArgs)')).  
```csharp
public class RouteDebugArgs
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RouteDebugArgs  
### Properties
<a name='TetraPak_AspNet_Debugging_RouteDebugArgs_Endpoint'></a>
## RouteDebugArgs.Endpoint Property
Rets the resolved routing [Endpoint](TetraPak_AspNet_Debugging_RouteDebugArgs.md#TetraPak_AspNet_Debugging_RouteDebugArgs_Endpoint 'TetraPak.AspNet.Debugging.RouteDebugArgs.Endpoint').  
```csharp
public Microsoft.AspNetCore.Http.Endpoint? Endpoint { get; }
```
#### Property Value
[Microsoft.AspNetCore.Http.Endpoint](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.Endpoint 'Microsoft.AspNetCore.Http.Endpoint')
  
<a name='TetraPak_AspNet_Debugging_RouteDebugArgs_IsHandled'></a>
## RouteDebugArgs.IsHandled Property
Gets or sets a value that specifies that operation is complete  
and that no further actions are to be taken.   
```csharp
public bool IsHandled { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_Debugging_RouteDebugArgs_LogLevel'></a>
## RouteDebugArgs.LogLevel Property
Specifies the [LogLevel](TetraPak_AspNet_Debugging_RouteDebugArgs.md#TetraPak_AspNet_Debugging_RouteDebugArgs_LogLevel 'TetraPak.AspNet.Debugging.RouteDebugArgs.LogLevel') used for logging routing information.  
```csharp
public Microsoft.Extensions.Logging.LogLevel LogLevel { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.LogLevel](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel 'Microsoft.Extensions.Logging.LogLevel')
  
