#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakConfigHelper Class
```csharp
public static class TetraPakConfigHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakConfigHelper  
### Methods
<a name='TetraPak_AspNet_TetraPakConfigHelper_UseTetraPakDiagnostics(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment)'></a>
## TetraPakConfigHelper.UseTetraPakDiagnostics(IApplicationBuilder, IWebHostEnvironment) Method
Enabled various types of diagnostics features, such as timers and trackable message ids.  
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseTetraPakDiagnostics(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakConfigHelper_UseTetraPakDiagnostics(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
  
<a name='TetraPak_AspNet_TetraPakConfigHelper_UseTetraPakDiagnostics(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment)_env'></a>
`env` [Microsoft.AspNetCore.Hosting.IWebHostEnvironment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Hosting.IWebHostEnvironment 'Microsoft.AspNetCore.Hosting.IWebHostEnvironment')  
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
  
<a name='TetraPak_AspNet_TetraPakConfigHelper_UseTetraPakMessageId(Microsoft_AspNetCore_Builder_IApplicationBuilder)'></a>
## TetraPakConfigHelper.UseTetraPakMessageId(IApplicationBuilder) Method
Enforces the use of a message id for all request/response round trips.  
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseTetraPakMessageId(this Microsoft.AspNetCore.Builder.IApplicationBuilder app);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakConfigHelper_UseTetraPakMessageId(Microsoft_AspNetCore_Builder_IApplicationBuilder)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
  
