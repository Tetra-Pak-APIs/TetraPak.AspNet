#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth').[TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')
## TetraPakAuthConfig.TetraPakAuthConfig(IConfiguration, ILogger&lt;TetraPakAuthConfig&gt;, bool, string, ITetraPakAuthConfigDelegate) Constructor
Initializes a Tetra Pak authorization configuration instance.   
```csharp
public TetraPakAuthConfig(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger<TetraPak.AspNet.Auth.TetraPakAuthConfig> logger, bool loadDiscoveryDocument=false, string sectionIdentifier=null, TetraPak.AspNet.Auth.ITetraPakAuthConfigDelegate configDelegate=null);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_TetraPakAuthConfig_TetraPakAuthConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_Auth_TetraPakAuthConfig__bool_string_TetraPak_AspNet_Auth_ITetraPakAuthConfigDelegate)_configuration'></a>
`configuration` [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')  
A [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') instance.  
  
<a name='TetraPak_AspNet_Auth_TetraPakAuthConfig_TetraPakAuthConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_Auth_TetraPakAuthConfig__bool_string_TetraPak_AspNet_Auth_ITetraPakAuthConfigDelegate)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger-1 'Microsoft.Extensions.Logging.ILogger`1')[TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger-1 'Microsoft.Extensions.Logging.ILogger`1')  
A [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger').  
  
<a name='TetraPak_AspNet_Auth_TetraPakAuthConfig_TetraPakAuthConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_Auth_TetraPakAuthConfig__bool_string_TetraPak_AspNet_Auth_ITetraPakAuthConfigDelegate)_loadDiscoveryDocument'></a>
`loadDiscoveryDocument` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default = `false`)<br />  
Specifies whether to automatically load the (remote) discovery document.  
#### See Also
- [GetDiscoveryDocumentAsync()](TetraPak_AspNet_Auth_TetraPakAuthConfig_GetDiscoveryDocumentAsync().md 'TetraPak.AspNet.Auth.TetraPakAuthConfig.GetDiscoveryDocumentAsync()')
  
<a name='TetraPak_AspNet_Auth_TetraPakAuthConfig_TetraPakAuthConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_Auth_TetraPakAuthConfig__bool_string_TetraPak_AspNet_Auth_ITetraPakAuthConfigDelegate)_sectionIdentifier'></a>
`sectionIdentifier` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional; default=[TetraPak.AspNet.Auth.TetraPakAuthConfig.SectionIdentifier](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.TetraPakAuthConfig.SectionIdentifier 'TetraPak.AspNet.Auth.TetraPakAuthConfig.SectionIdentifier'))<br />  
A custom configuration section identifier.   
  
<a name='TetraPak_AspNet_Auth_TetraPakAuthConfig_TetraPakAuthConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_Auth_TetraPakAuthConfig__bool_string_TetraPak_AspNet_Auth_ITetraPakAuthConfigDelegate)_configDelegate'></a>
`configDelegate` [ITetraPakAuthConfigDelegate](TetraPak_AspNet_Auth_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.Auth.ITetraPakAuthConfigDelegate')  
(optional)<br />  
A delegate instance for custom configuration behavior.  
  
#### See Also
- [GetDiscoveryDocumentAsync()](TetraPak_AspNet_Auth_TetraPakAuthConfig_GetDiscoveryDocumentAsync().md 'TetraPak.AspNet.Auth.TetraPakAuthConfig.GetDiscoveryDocumentAsync()')
