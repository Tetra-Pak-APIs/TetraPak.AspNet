#### [TetraPak.AspNet](index.md 'index')
## TetraPak.AspNet.Debugging Namespace

| Classes | |
| :--- | :--- |
| [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest') | An abstract representation of a HTTP request (note: the class itself is not `abstract`).<br/> |
| [AbstractHttpRequestHelper](TetraPak_AspNet_Debugging_AbstractHttpRequestHelper.md 'TetraPak.AspNet.Debugging.AbstractHttpRequestHelper') | Convenient methods for working with [AbstractHttpRequest](TetraPak_AspNet_Debugging_AbstractHttpRequest.md 'TetraPak.AspNet.Debugging.AbstractHttpRequest')s.<br/> |
| [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse') | An abstract representation of a HTTP request (note: the class itself is not `abstract`).<br/> |
| [AbstractHttpResponseHelper](TetraPak_AspNet_Debugging_AbstractHttpResponseHelper.md 'TetraPak.AspNet.Debugging.AbstractHttpResponseHelper') | Convenient methods for working with [AbstractHttpResponse](TetraPak_AspNet_Debugging_AbstractHttpResponse.md 'TetraPak.AspNet.Debugging.AbstractHttpResponse')s.<br/> |
| [DebugHelper](TetraPak_AspNet_Debugging_DebugHelper.md 'TetraPak.AspNet.Debugging.DebugHelper') | Provides convenient extension methods to be used for debugging/diagnostics purposes.<br/> |
| [RequestInitiators](TetraPak_AspNet_Debugging_RequestInitiators.md 'TetraPak.AspNet.Debugging.RequestInitiators') | Provides [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') constants representing various standardised request initiators.<br/> |
| [RouteDebugArgs](TetraPak_AspNet_Debugging_RouteDebugArgs.md 'TetraPak.AspNet.Debugging.RouteDebugArgs') | Arguments used when invoking a custom routing debugger handler ([RouteDebugHandler(RouteDebugArgs)](TetraPak_AspNet_Debugging_RouteDebugHandler(TetraPak_AspNet_Debugging_RouteDebugArgs).md 'TetraPak.AspNet.Debugging.RouteDebugHandler(TetraPak.AspNet.Debugging.RouteDebugArgs)')).<br/> |
| [RouteDebuggingOptions](TetraPak_AspNet_Debugging_RouteDebuggingOptions.md 'TetraPak.AspNet.Debugging.RouteDebuggingOptions') | Used to configure route debugging.<br/> |
| [TraceRequestOptions](TetraPak_AspNet_Debugging_TraceRequestOptions.md 'TetraPak.AspNet.Debugging.TraceRequestOptions') | Used when request bodies gets dumped to the logger (at log level [Microsoft.Extensions.Logging.LogLevel.Trace](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Trace 'Microsoft.Extensions.Logging.LogLevel.Trace')).<br/> |
| [WebLoggerHelper](TetraPak_AspNet_Debugging_WebLoggerHelper.md 'TetraPak.AspNet.Debugging.WebLoggerHelper') | Contains convenience/extension methods to assist with logging. <br/> |

| Enums | |
| :--- | :--- |
| [HttpDirection](TetraPak_AspNet_Debugging_HttpDirection.md 'TetraPak.AspNet.Debugging.HttpDirection') | Used to reflect HTTP traffic direction.<br/> |
| [RouteDebuggingChannels](TetraPak_AspNet_Debugging_RouteDebuggingChannels.md 'TetraPak.AspNet.Debugging.RouteDebuggingChannels') | Used to specify which channels to write route debugging to.<br/> |

| Delegates | |
| :--- | :--- |
| [RouteDebugHandler(RouteDebugArgs)](TetraPak_AspNet_Debugging_RouteDebugHandler(TetraPak_AspNet_Debugging_RouteDebugArgs).md 'TetraPak.AspNet.Debugging.RouteDebugHandler(TetraPak.AspNet.Debugging.RouteDebugArgs)') | A custom handler used for logging routing information. <br/> |
