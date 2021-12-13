#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## RouteDebuggingOptions Class
Used to configure route debugging.  
```csharp
public class RouteDebuggingOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RouteDebuggingOptions  
### Properties
<a name='TetraPak_AspNet_Debugging_RouteDebuggingOptions_Channels'></a>
## RouteDebuggingOptions.Channels Property
Specifies which channel(s) to be used for logging routing debugging information.  
```csharp
public TetraPak.AspNet.Debugging.RouteDebuggingChannels Channels { get; set; }
```
#### Property Value
[RouteDebuggingChannels](TetraPak_AspNet_Debugging_RouteDebuggingChannels.md 'TetraPak.AspNet.Debugging.RouteDebuggingChannels')
  
<a name='TetraPak_AspNet_Debugging_RouteDebuggingOptions_LogLevel'></a>
## RouteDebuggingOptions.LogLevel Property
Specifies the [LogLevel](TetraPak_AspNet_Debugging_RouteDebuggingOptions.md#TetraPak_AspNet_Debugging_RouteDebuggingOptions_LogLevel 'TetraPak.AspNet.Debugging.RouteDebuggingOptions.LogLevel') to be used when sending routing debug  
information to a [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger').  
```csharp
public Microsoft.Extensions.Logging.LogLevel LogLevel { get; set; }
```
#### Property Value
[Microsoft.Extensions.Logging.LogLevel](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel 'Microsoft.Extensions.Logging.LogLevel')
#### See Also
- [Logger](TetraPak_AspNet_Debugging_RouteDebuggingChannels.md#TetraPak_AspNet_Debugging_RouteDebuggingChannels_Logger 'TetraPak.AspNet.Debugging.RouteDebuggingChannels.Logger')
  
<a name='TetraPak_AspNet_Debugging_RouteDebuggingOptions_OnRouteDebug'></a>
## RouteDebuggingOptions.OnRouteDebug Property
Optional callback handler for custom routing debugging.  
```csharp
public TetraPak.AspNet.Debugging.RouteDebugHandler? OnRouteDebug { get; set; }
```
#### Property Value
[RouteDebugHandler(RouteDebugArgs)](TetraPak_AspNet_Debugging_RouteDebugHandler(TetraPak_AspNet_Debugging_RouteDebugArgs).md 'TetraPak.AspNet.Debugging.RouteDebugHandler(TetraPak.AspNet.Debugging.RouteDebugArgs)')
  
#### See Also
- [UseRoutingDebugging(IApplicationBuilder, Action&lt;RouteDebuggingOptions&gt;?)](TetraPak_AspNet_Debugging_DebugHelper.md#TetraPak_AspNet_Debugging_DebugHelper_UseRoutingDebugging(Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Action_TetraPak_AspNet_Debugging_RouteDebuggingOptions__) 'TetraPak.AspNet.Debugging.DebugHelper.UseRoutingDebugging(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Action&lt;TetraPak.AspNet.Debugging.RouteDebuggingOptions&gt;?)')
