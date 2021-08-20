#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[HttpContextHelper](TetraPak_AspNet_HttpContextHelper.md 'TetraPak.AspNet.HttpContextHelper')
## HttpContextHelper.GetDiagnosticsLevel(HttpRequest, ILogger, ServiceDiagnosticsLevel) Method
Gets a telemetry level from the request (if any).  
```csharp
public static TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel GetDiagnosticsLevel(this Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.Extensions.Logging.ILogger logger, TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel useDefault=TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel.None);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetDiagnosticsLevel(Microsoft_AspNetCore_Http_HttpRequest_Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_Diagnostics_ServiceDiagnosticsLevel)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest').  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetDiagnosticsLevel(Microsoft_AspNetCore_Http_HttpRequest_Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_Diagnostics_ServiceDiagnosticsLevel)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
A logger provider.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetDiagnosticsLevel(Microsoft_AspNetCore_Http_HttpRequest_Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_Diagnostics_ServiceDiagnosticsLevel)_useDefault'></a>
`useDefault` [TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel 'TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel')  
A default telemetry level to be returned when no level was specified, or when  
the specified telemetry level could not be successfully parsed.    
  
#### Returns
[TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel 'TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel')  
A [TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel 'TetraPak.AspNet.Diagnostics.ServiceDiagnosticsLevel') value.  
