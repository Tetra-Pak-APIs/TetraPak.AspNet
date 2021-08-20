#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[ControllerExtensions](TetraPak_AspNet_ControllerExtensions.md 'TetraPak.AspNet.ControllerExtensions')
## ControllerExtensions.TryGetTetraPakAuthConfig(Controller, TetraPakAuthConfig) Method
Attempts obtaining the [TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig') instance.  
```csharp
public static bool TryGetTetraPakAuthConfig(this Microsoft.AspNetCore.Mvc.Controller self, out TetraPak.AspNet.Auth.TetraPakAuthConfig config);
```
#### Parameters
<a name='TetraPak_AspNet_ControllerExtensions_TryGetTetraPakAuthConfig(Microsoft_AspNetCore_Mvc_Controller_TetraPak_AspNet_Auth_TetraPakAuthConfig)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.Controller](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.Controller 'Microsoft.AspNetCore.Mvc.Controller')  
The extended [Microsoft.AspNetCore.Mvc.Controller](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.Controller 'Microsoft.AspNetCore.Mvc.Controller') instance.  
  
<a name='TetraPak_AspNet_ControllerExtensions_TryGetTetraPakAuthConfig(Microsoft_AspNetCore_Mvc_Controller_TetraPak_AspNet_Auth_TetraPakAuthConfig)_config'></a>
`config` [TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')  
Passes back the [TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig') instance if successful; otherwise `null`.   
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true`
