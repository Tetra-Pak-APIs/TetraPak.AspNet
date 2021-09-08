#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## JwtBearerAssertionConfig Class
This code API enables access and manipulation for the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') (appsettings.json)  
sub section "JwtBearerAssertion";  
```csharp
public class JwtBearerAssertionConfig : TetraPak.Configuration.ConfigurationSection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') &#129106; JwtBearerAssertionConfig  
### Constructors
<a name='TetraPak_AspNet_Auth_JwtBearerAssertionConfig_JwtBearerAssertionConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger__string_)'></a>
## JwtBearerAssertionConfig.JwtBearerAssertionConfig(IConfiguration, ILogger?, string?) Constructor
Initializes the code API.   
```csharp
public JwtBearerAssertionConfig(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger? logger, string? sectionIdentifier=null);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_JwtBearerAssertionConfig_JwtBearerAssertionConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger__string_)_configuration'></a>
`configuration` [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')  
The [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') object.  
  
<a name='TetraPak_AspNet_Auth_JwtBearerAssertionConfig_JwtBearerAssertionConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger__string_)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
A logger provider.  
  
<a name='TetraPak_AspNet_Auth_JwtBearerAssertionConfig_JwtBearerAssertionConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger__string_)_sectionIdentifier'></a>
`sectionIdentifier` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional; default=[DefaultSectionIdentifier](TetraPak_AspNet_Auth_JwtBearerAssertionConfig.md#TetraPak_AspNet_Auth_JwtBearerAssertionConfig_DefaultSectionIdentifier 'TetraPak.AspNet.Auth.JwtBearerAssertionConfig.DefaultSectionIdentifier'))<br />  
Specifies the section identifier for the code API.   
  
  
### Properties
<a name='TetraPak_AspNet_Auth_JwtBearerAssertionConfig_Audience'></a>
## JwtBearerAssertionConfig.Audience Property
Gets or sets the required JWT audience ("aud").  
```csharp
public string? Audience { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Auth_JwtBearerAssertionConfig_DefaultSectionIdentifier'></a>
## JwtBearerAssertionConfig.DefaultSectionIdentifier Property
Gets or sets the default configuration section identifier  
recognized by [JwtBearerAssertionConfig](TetraPak_AspNet_Auth_JwtBearerAssertionConfig.md 'TetraPak.AspNet.Auth.JwtBearerAssertionConfig').  
```csharp
public static string DefaultSectionIdentifier { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Auth_JwtBearerAssertionConfig_DevProxy'></a>
## JwtBearerAssertionConfig.DevProxy Property
Specifies the proxy (a.k.a. "sidecar") protecting the API. The value can be the full  
URL to the proxy's "development token endpoint" or just the proxy name.  
```csharp
public string? DevProxy { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Auth_JwtBearerAssertionConfig_Issuer'></a>
## JwtBearerAssertionConfig.Issuer Property
Gets or sets the required JWT issuer ("iss").  
```csharp
public string? Issuer { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Auth_JwtBearerAssertionConfig_ValidateLifetime'></a>
## JwtBearerAssertionConfig.ValidateLifetime Property
Gets or sets a value specifying whether to validate the JWT lifetime.  
```csharp
public bool ValidateLifetime { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
