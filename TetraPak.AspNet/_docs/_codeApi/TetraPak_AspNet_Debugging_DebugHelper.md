#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## DebugHelper Class
```csharp
public static class DebugHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DebugHelper  
### Methods
<a name='TetraPak_AspNet_Debugging_DebugHelper_UseRoutingDebugging(Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Action_TetraPak_AspNet_Debugging_RouteDebuggingOptions_)'></a>
## DebugHelper.UseRoutingDebugging(IApplicationBuilder, Action&lt;RouteDebuggingOptions&gt;) Method
Adds route debugging information to all configured channels  
(such as the console and/or the logging framework).  
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseRoutingDebugging(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, System.Action<TetraPak.AspNet.Debugging.RouteDebuggingOptions> onSetOptions=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_DebugHelper_UseRoutingDebugging(Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Action_TetraPak_AspNet_Debugging_RouteDebuggingOptions_)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
An [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
  
<a name='TetraPak_AspNet_Debugging_DebugHelper_UseRoutingDebugging(Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Action_TetraPak_AspNet_Debugging_RouteDebuggingOptions_)_onSetOptions'></a>
`onSetOptions` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[RouteDebuggingOptions](TetraPak_AspNet_Debugging_RouteDebuggingOptions.md 'TetraPak.AspNet.Debugging.RouteDebuggingOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')  
(optional)<br />  
A delegate to customize [RouteDebuggingOptions](TetraPak_AspNet_Debugging_RouteDebuggingOptions.md 'TetraPak.AspNet.Debugging.RouteDebuggingOptions') used for debugging routing.  
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
#### See Also
- [RouteDebuggingOptions](TetraPak_AspNet_Debugging_RouteDebuggingOptions.md 'TetraPak.AspNet.Debugging.RouteDebuggingOptions')
  
