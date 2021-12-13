#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## DebugHelper Class
Provides convenient extension methods to be used for debugging/diagnostics purposes.  
```csharp
public static class DebugHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DebugHelper  
### Methods
<a name='TetraPak_AspNet_Debugging_DebugHelper_UseAssembliesUsedDebugging(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_Extensions_Logging_LogLevel)'></a>
## DebugHelper.UseAssembliesUsedDebugging(IApplicationBuilder, LogLevel) Method
Injects middleware that logs all assemblies currently linked to the app domain.   
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseAssembliesUsedDebugging(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.Extensions.Logging.LogLevel logLevel=Microsoft.Extensions.Logging.LogLevel.Debug);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_DebugHelper_UseAssembliesUsedDebugging(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_Extensions_Logging_LogLevel)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
An [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
  
<a name='TetraPak_AspNet_Debugging_DebugHelper_UseAssembliesUsedDebugging(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_Extensions_Logging_LogLevel)_logLevel'></a>
`logLevel` [Microsoft.Extensions.Logging.LogLevel](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel 'Microsoft.Extensions.Logging.LogLevel')  
(optional; default=[Microsoft.Extensions.Logging.LogLevel.Debug](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Debug 'Microsoft.Extensions.Logging.LogLevel.Debug'))<br/>  
Specifies the log level used when sending the information to the log provider.  
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
  
<a name='TetraPak_AspNet_Debugging_DebugHelper_UseRoutingDebugging(Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Action_TetraPak_AspNet_Debugging_RouteDebuggingOptions__)'></a>
## DebugHelper.UseRoutingDebugging(IApplicationBuilder, Action&lt;RouteDebuggingOptions&gt;?) Method
Adds route debugging information to all configured channels  
(such as the console and/or the logging framework).  
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseRoutingDebugging(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, System.Action<TetraPak.AspNet.Debugging.RouteDebuggingOptions>? optionsFactory=null);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_DebugHelper_UseRoutingDebugging(Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Action_TetraPak_AspNet_Debugging_RouteDebuggingOptions__)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
An [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
  
<a name='TetraPak_AspNet_Debugging_DebugHelper_UseRoutingDebugging(Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Action_TetraPak_AspNet_Debugging_RouteDebuggingOptions__)_optionsFactory'></a>
`optionsFactory` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[RouteDebuggingOptions](TetraPak_AspNet_Debugging_RouteDebuggingOptions.md 'TetraPak.AspNet.Debugging.RouteDebuggingOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')  
(optional)<br/>  
A delegate to customize [RouteDebuggingOptions](TetraPak_AspNet_Debugging_RouteDebuggingOptions.md 'TetraPak.AspNet.Debugging.RouteDebuggingOptions') used for debugging routing.  
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
#### See Also
- [RouteDebuggingOptions](TetraPak_AspNet_Debugging_RouteDebuggingOptions.md 'TetraPak.AspNet.Debugging.RouteDebuggingOptions')
  
