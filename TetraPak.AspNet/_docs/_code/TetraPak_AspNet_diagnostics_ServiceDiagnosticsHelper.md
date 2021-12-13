#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.diagnostics](TetraPak_AspNet_diagnostics.md 'TetraPak.AspNet.diagnostics')
## ServiceDiagnosticsHelper Class
```csharp
public static class ServiceDiagnosticsHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ServiceDiagnosticsHelper  
### Methods
<a name='TetraPak_AspNet_diagnostics_ServiceDiagnosticsHelper_GetDiagnostics(Microsoft_AspNetCore_Http_HttpContext)'></a>
## ServiceDiagnosticsHelper.GetDiagnostics(HttpContext) Method
Returns a [ServiceDiagnostics](TetraPak_AspNet_Diagnostics_ServiceDiagnostics.md 'TetraPak.AspNet.Diagnostics.ServiceDiagnostics') object if available; otherwise `null`.   
```csharp
public static TetraPak.AspNet.Diagnostics.ServiceDiagnostics? GetDiagnostics(this Microsoft.AspNetCore.Http.HttpContext self);
```
#### Parameters
<a name='TetraPak_AspNet_diagnostics_ServiceDiagnosticsHelper_GetDiagnostics(Microsoft_AspNetCore_Http_HttpContext)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
  
#### Returns
[ServiceDiagnostics](TetraPak_AspNet_Diagnostics_ServiceDiagnostics.md 'TetraPak.AspNet.Diagnostics.ServiceDiagnostics')  
  
