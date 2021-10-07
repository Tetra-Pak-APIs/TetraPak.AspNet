#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## ConfigureJwtBearerOptions Class
This code API can be used to access/manipulate the JWT Bearer authentication configuration,  
represented by the configuration sub section identified by  
[JwtBearerAssertionConfig.SectionIdentifier](https://docs.microsoft.com/en-us/dotnet/api/JwtBearerAssertionConfig.SectionIdentifier 'JwtBearerAssertionConfig.SectionIdentifier').   
```csharp
public class ConfigureJwtBearerOptions :
Microsoft.Extensions.Options.IConfigureNamedOptions<Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions>,
Microsoft.Extensions.Options.IConfigureOptions<Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ConfigureJwtBearerOptions  

Implements [Microsoft.Extensions.Options.IConfigureNamedOptions&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Options.IConfigureNamedOptions-1 'Microsoft.Extensions.Options.IConfigureNamedOptions`1')[Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions 'Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Options.IConfigureNamedOptions-1 'Microsoft.Extensions.Options.IConfigureNamedOptions`1'), [Microsoft.Extensions.Options.IConfigureOptions&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Options.IConfigureOptions-1 'Microsoft.Extensions.Options.IConfigureOptions`1')[Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions 'Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Options.IConfigureOptions-1 'Microsoft.Extensions.Options.IConfigureOptions`1')  
### Constructors
<a name='TetraPak_AspNet_Api_Auth_ConfigureJwtBearerOptions_ConfigureJwtBearerOptions(System_IServiceProvider_TetraPak_AspNet_Api_Auth_HostProvider_Microsoft_AspNetCore_Hosting_IWebHostEnvironment_TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)'></a>
## ConfigureJwtBearerOptions.ConfigureJwtBearerOptions(IServiceProvider, HostProvider, IWebHostEnvironment, JwBearerAssertionOptions?) Constructor
Initializes the [ConfigureJwtBearerOptions](TetraPak_AspNet_Api_Auth_ConfigureJwtBearerOptions.md 'TetraPak.AspNet.Api.Auth.ConfigureJwtBearerOptions').  
```csharp
public ConfigureJwtBearerOptions(System.IServiceProvider provider, TetraPak.AspNet.Api.Auth.HostProvider hostProvider, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostEnvironment, TetraPak.AspNet.Api.Auth.JwBearerAssertionOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_ConfigureJwtBearerOptions_ConfigureJwtBearerOptions(System_IServiceProvider_TetraPak_AspNet_Api_Auth_HostProvider_Microsoft_AspNetCore_Hosting_IWebHostEnvironment_TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_provider'></a>
`provider` [System.IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/System.IServiceProvider 'System.IServiceProvider')  
A service locator.  
  
<a name='TetraPak_AspNet_Api_Auth_ConfigureJwtBearerOptions_ConfigureJwtBearerOptions(System_IServiceProvider_TetraPak_AspNet_Api_Auth_HostProvider_Microsoft_AspNetCore_Hosting_IWebHostEnvironment_TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_hostProvider'></a>
`hostProvider` [TetraPak.AspNet.Api.Auth.HostProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.HostProvider 'TetraPak.AspNet.Api.Auth.HostProvider')  
Provides access to the host name.  
  
<a name='TetraPak_AspNet_Api_Auth_ConfigureJwtBearerOptions_ConfigureJwtBearerOptions(System_IServiceProvider_TetraPak_AspNet_Api_Auth_HostProvider_Microsoft_AspNetCore_Hosting_IWebHostEnvironment_TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_hostEnvironment'></a>
`hostEnvironment` [Microsoft.AspNetCore.Hosting.IWebHostEnvironment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Hosting.IWebHostEnvironment 'Microsoft.AspNetCore.Hosting.IWebHostEnvironment')  
The host environment information.  
  
<a name='TetraPak_AspNet_Api_Auth_ConfigureJwtBearerOptions_ConfigureJwtBearerOptions(System_IServiceProvider_TetraPak_AspNet_Api_Auth_HostProvider_Microsoft_AspNetCore_Hosting_IWebHostEnvironment_TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_options'></a>
`options` [JwBearerAssertionOptions](TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions.md 'TetraPak.AspNet.Api.Auth.JwBearerAssertionOptions')  
(optional; default=service located instance)<br/>  
JWT Bearer Assertion options.  
  
  
### Properties
<a name='TetraPak_AspNet_Api_Auth_ConfigureJwtBearerOptions_Config'></a>
## ConfigureJwtBearerOptions.Config Property
Provides access to the Tetra Pak configuration.  
```csharp
public TetraPak.AspNet.Api.Auth.TetraPakApiConfig Config { get; }
```
#### Property Value
[TetraPakApiConfig](TetraPak_AspNet_Api_Auth_TetraPakApiConfig.md 'TetraPak.AspNet.Api.Auth.TetraPakApiConfig')
  
<a name='TetraPak_AspNet_Api_Auth_ConfigureJwtBearerOptions_Logger'></a>
## ConfigureJwtBearerOptions.Logger Property
Gets a logger provider.   
```csharp
public Microsoft.Extensions.Logging.ILogger? Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
