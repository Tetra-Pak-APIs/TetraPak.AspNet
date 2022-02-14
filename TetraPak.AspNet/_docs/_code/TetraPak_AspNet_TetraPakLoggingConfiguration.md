#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakLoggingConfiguration Class
Represents the   
```csharp
public class TetraPakLoggingConfiguration : TetraPak.Configuration.ConfigurationSection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') &#129106; TetraPakLoggingConfiguration  
### Constructors
<a name='TetraPak_AspNet_TetraPakLoggingConfiguration_TetraPakLoggingConfiguration(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger__string_)'></a>
## TetraPakLoggingConfiguration.TetraPakLoggingConfiguration(IConfiguration, ILogger?, string?) Constructor
Initializes the code API.   
```csharp
public TetraPakLoggingConfiguration(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger? logger, string? sectionIdentifier=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakLoggingConfiguration_TetraPakLoggingConfiguration(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger__string_)_configuration'></a>
`configuration` [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')  
The [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') object.  
  
<a name='TetraPak_AspNet_TetraPakLoggingConfiguration_TetraPakLoggingConfiguration(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger__string_)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
A logger provider.  
  
<a name='TetraPak_AspNet_TetraPakLoggingConfiguration_TetraPakLoggingConfiguration(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger__string_)_sectionIdentifier'></a>
`sectionIdentifier` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional; default=[DefaultSectionIdentifier](TetraPak_AspNet_TetraPakLoggingConfiguration.md#TetraPak_AspNet_TetraPakLoggingConfiguration_DefaultSectionIdentifier 'TetraPak.AspNet.TetraPakLoggingConfiguration.DefaultSectionIdentifier'))<br/>  
Specifies the section identifier for the code API.   
  
  
### Properties
<a name='TetraPak_AspNet_TetraPakLoggingConfiguration_DefaultSectionIdentifier'></a>
## TetraPakLoggingConfiguration.DefaultSectionIdentifier Property
Gets or sets the default configuration section identifier  
recognized by [TetraPakLoggingConfiguration](TetraPak_AspNet_TetraPakLoggingConfiguration.md 'TetraPak.AspNet.TetraPakLoggingConfiguration').  
```csharp
public static string DefaultSectionIdentifier { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_TetraPakLoggingConfiguration_TraceBodyMaxSize'></a>
## TetraPakLoggingConfiguration.TraceBodyMaxSize Property
A maximum length. Set this value to truncate when tracing very large bodies such as media or binaries.  
```csharp
public long TraceBodyMaxSize { get; set; }
```
#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')
### Remarks
This value should be a equally divisible by [TraceRequestBodyBufferSize](TetraPak_AspNet_TetraPakLoggingConfiguration.md#TetraPak_AspNet_TetraPakLoggingConfiguration_TraceRequestBodyBufferSize 'TetraPak.AspNet.TetraPakLoggingConfiguration.TraceRequestBodyBufferSize') for efficiency.  
The setter automatically rounds (`value` / [TraceRequestBodyBufferSize](TetraPak_AspNet_TetraPakLoggingConfiguration.md#TetraPak_AspNet_TetraPakLoggingConfiguration_TraceRequestBodyBufferSize 'TetraPak.AspNet.TetraPakLoggingConfiguration.TraceRequestBodyBufferSize'))  
and multiplies with [TraceRequestBodyBufferSize](TetraPak_AspNet_TetraPakLoggingConfiguration.md#TetraPak_AspNet_TetraPakLoggingConfiguration_TraceRequestBodyBufferSize 'TetraPak.AspNet.TetraPakLoggingConfiguration.TraceRequestBodyBufferSize').  
  
<a name='TetraPak_AspNet_TetraPakLoggingConfiguration_TraceRequestBodyBufferSize'></a>
## TetraPakLoggingConfiguration.TraceRequestBodyBufferSize Property
The buffer size for tracing request body.  
Please note that the setter enforces minimum value 128.   
```csharp
public int TraceRequestBodyBufferSize { get; set; }
```
#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
  
### Methods
<a name='TetraPak_AspNet_TetraPakLoggingConfiguration_GetTraceBodyOptions(TetraPak_AspNet_TetraPakConfig_Microsoft_AspNetCore_Http_HttpContext)'></a>
## TetraPakLoggingConfiguration.GetTraceBodyOptions(TetraPakConfig, HttpContext) Method
Constructs and returns a [TraceHttpRequestOptions](TetraPak_AspNet_Debugging_TraceHttpRequestOptions.md 'TetraPak.AspNet.Debugging.TraceHttpRequestOptions') object from the configuration.  
This can be used with the [WebLoggerHelper](TetraPak_AspNet_Debugging_WebLoggerHelper.md 'TetraPak.AspNet.Debugging.WebLoggerHelper')'s tracing methods.  
```csharp
public TetraPak.AspNet.Debugging.TraceHttpRequestOptions? GetTraceBodyOptions(TetraPak.AspNet.TetraPakConfig tetraPakConfig, Microsoft.AspNetCore.Http.HttpContext httpContext);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakLoggingConfiguration_GetTraceBodyOptions(TetraPak_AspNet_TetraPakConfig_Microsoft_AspNetCore_Http_HttpContext)_tetraPakConfig'></a>
`tetraPakConfig` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
  
<a name='TetraPak_AspNet_TetraPakLoggingConfiguration_GetTraceBodyOptions(TetraPak_AspNet_TetraPakConfig_Microsoft_AspNetCore_Http_HttpContext)_httpContext'></a>
`httpContext` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
  
#### Returns
[TraceHttpRequestOptions](TetraPak_AspNet_Debugging_TraceHttpRequestOptions.md 'TetraPak.AspNet.Debugging.TraceHttpRequestOptions')  
A [TraceHttpRequestOptions](TetraPak_AspNet_Debugging_TraceHttpRequestOptions.md 'TetraPak.AspNet.Debugging.TraceHttpRequestOptions') if [TraceBodyMaxSize](TetraPak_AspNet_TetraPakLoggingConfiguration.md#TetraPak_AspNet_TetraPakLoggingConfiguration_TraceBodyMaxSize 'TetraPak.AspNet.TetraPakLoggingConfiguration.TraceBodyMaxSize') is assigned  
and greater then zero (0); otherwise `null`.  
  
