#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.DevelopmentTools](TetraPak_AspNet_Api_DevelopmentTools.md 'TetraPak.AspNet.Api.DevelopmentTools')
## DevProxyHelper Class
Provides helper methods for using a local (desktop) development proxy (sidecar).  
```csharp
public static class DevProxyHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DevProxyHelper  
### Methods
<a name='TetraPak_AspNet_Api_DevelopmentTools_DevProxyHelper_UseLocalDevProxy(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment_string_TetraPak_AspNet_HttpComparison_)'></a>
## DevProxyHelper.UseLocalDevProxy(IApplicationBuilder, IWebHostEnvironment, string, HttpComparison?) Method
Enables the behavior of a local "development proxy" (a.k.a. "sidecar").  
Please note that the proxy will only be enabled when the host  
is running in a "Development" runtime environment.   
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseLocalDevProxy(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env, string proxyUrl, TetraPak.AspNet.HttpComparison? isMutedWhen=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_DevelopmentTools_DevProxyHelper_UseLocalDevProxy(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment_string_TetraPak_AspNet_HttpComparison_)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The application builder instance.  
  
<a name='TetraPak_AspNet_Api_DevelopmentTools_DevProxyHelper_UseLocalDevProxy(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment_string_TetraPak_AspNet_HttpComparison_)_env'></a>
`env` [Microsoft.AspNetCore.Hosting.IWebHostEnvironment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Hosting.IWebHostEnvironment 'Microsoft.AspNetCore.Hosting.IWebHostEnvironment')  
The wwb host environment.  
  
<a name='TetraPak_AspNet_Api_DevelopmentTools_DevProxyHelper_UseLocalDevProxy(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment_string_TetraPak_AspNet_HttpComparison_)_proxyUrl'></a>
`proxyUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The URL for the (actual) proxy to be emulated locally.  
  
<a name='TetraPak_AspNet_Api_DevelopmentTools_DevProxyHelper_UseLocalDevProxy(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment_string_TetraPak_AspNet_HttpComparison_)_isMutedWhen'></a>
`isMutedWhen` [TetraPak.AspNet.HttpComparison](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpComparison 'TetraPak.AspNet.HttpComparison')  
(optional)<br/>  
Specified a [TetraPak.AspNet.HttpComparison](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpComparison 'TetraPak.AspNet.HttpComparison') criteria that, when `true`, mutes the  
DevProxy, allowing the request to just pass through to the API.  
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [app](TetraPak_AspNet_Api_DevelopmentTools_DevProxyHelper.md#TetraPak_AspNet_Api_DevelopmentTools_DevProxyHelper_UseLocalDevProxy(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment_string_TetraPak_AspNet_HttpComparison_)_app 'TetraPak.AspNet.Api.DevelopmentTools.DevProxyHelper.UseLocalDevProxy(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Hosting.IWebHostEnvironment, string, TetraPak.AspNet.HttpComparison?).app') instance.  
  
