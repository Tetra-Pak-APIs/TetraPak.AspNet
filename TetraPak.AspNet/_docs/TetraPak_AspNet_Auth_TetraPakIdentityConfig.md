#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## TetraPakIdentityConfig Class
Describes how to populate the ambient [ClaimsPrincipal.Identity.](https://docs.microsoft.com/en-us/dotnet/api/ClaimsPrincipal.Identity. 'ClaimsPrincipal.Identity.') value  
available through [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').  
```csharp
public class TetraPakIdentityConfig : TetraPak.Configuration.ConfigurationSection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') &#129106; TetraPakIdentityConfig  

| Constructors | |
| :--- | :--- |
| [TetraPakIdentityConfig(IConfiguration, ILogger, string)](TetraPak_AspNet_Auth_TetraPakIdentityConfig_TetraPakIdentityConfig(Microsoft_Extensions_Configuration_IConfiguration_Microsoft_Extensions_Logging_ILogger_string).md 'TetraPak.AspNet.Auth.TetraPakIdentityConfig.TetraPakIdentityConfig(Microsoft.Extensions.Configuration.IConfiguration, Microsoft.Extensions.Logging.ILogger, string)') | Initializes the [TetraPakIdentityConfig](TetraPak_AspNet_Auth_TetraPakIdentityConfig.md 'TetraPak.AspNet.Auth.TetraPakIdentityConfig').<br/> |

| Properties | |
| :--- | :--- |
| [Scope](TetraPak_AspNet_Auth_TetraPakIdentityConfig_Scope.md 'TetraPak.AspNet.Auth.TetraPakIdentityConfig.Scope') | Gets a configured scope to be requested to obtain identity claims (or default scope when omitted). <br/> |
| [Source](TetraPak_AspNet_Auth_TetraPakIdentityConfig_Source.md 'TetraPak.AspNet.Auth.TetraPakIdentityConfig.Source') | Specifies the source for identity claims.<br/> |
