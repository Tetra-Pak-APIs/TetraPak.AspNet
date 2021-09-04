#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakIdentityConfig Class
Describes how to populate the ambient [System.Security.Claims.ClaimsPrincipal.Identity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal.Identity 'System.Security.Claims.ClaimsPrincipal.Identity') value  
available through [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
```csharp
public class TetraPakIdentityConfig : TetraPak.Configuration.ConfigurationSection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') &#129106; TetraPakIdentityConfig  
### Constructors
<a name='TetraPak_AspNet_TetraPakIdentityConfig_TetraPakIdentityConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger_string)'></a>
## TetraPakIdentityConfig.TetraPakIdentityConfig(IConfiguration, ILogger, string) Constructor
Initializes the [TetraPakIdentityConfig](TetraPak_AspNet_TetraPakIdentityConfig.md 'TetraPak.AspNet.TetraPakIdentityConfig').  
```csharp
public TetraPakIdentityConfig(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger, string sectionIdentifier=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakIdentityConfig_TetraPakIdentityConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger_string)_configuration'></a>
`configuration` [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')  
The [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') instance.  
  
<a name='TetraPak_AspNet_TetraPakIdentityConfig_TetraPakIdentityConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger_string)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
A [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger') instance.  
  
<a name='TetraPak_AspNet_TetraPakIdentityConfig_TetraPakIdentityConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger_string)_sectionIdentifier'></a>
`sectionIdentifier` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional; default=[SectionIdentifier](TetraPak_AspNet_TetraPakIdentityConfig.md#TetraPak_AspNet_TetraPakIdentityConfig_SectionIdentifier 'TetraPak.AspNet.TetraPakIdentityConfig.SectionIdentifier'))<br />  
A custom configuration section identifier.   
  
  
### Properties
<a name='TetraPak_AspNet_TetraPakIdentityConfig_Scope'></a>
## TetraPakIdentityConfig.Scope Property
Gets a configured scope to be requested to obtain identity claims (or default scope when omitted).   
```csharp
public string[] Scope { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')
  
<a name='TetraPak_AspNet_TetraPakIdentityConfig_SectionIdentifier'></a>
## TetraPakIdentityConfig.SectionIdentifier Property
Gets the configuration section name.  
```csharp
public override string SectionIdentifier { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_TetraPakIdentityConfig_Source'></a>
## TetraPakIdentityConfig.Source Property
Specifies the source for identity claims.  
```csharp
public TetraPak.AspNet.Auth.TetraPakIdentitySource Source { get; set; }
```
#### Property Value
[TetraPakIdentitySource](TetraPak_AspNet_Auth_TetraPakIdentitySource.md 'TetraPak.AspNet.Auth.TetraPakIdentitySource')
  
