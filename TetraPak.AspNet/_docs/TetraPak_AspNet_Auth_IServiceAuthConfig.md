#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## IServiceAuthConfig Interface
Classes implementing this contract can provide information needed fot authorization purposes.   
```csharp
public interface IServiceAuthConfig
```

Derived  
&#8627; [TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')  

| Properties | |
| :--- | :--- |
| [ClientId](TetraPak_AspNet_Auth_IServiceAuthConfig_ClientId.md 'TetraPak.AspNet.Auth.IServiceAuthConfig.ClientId') | Gets the client id.<br/> |
| [ClientSecret](TetraPak_AspNet_Auth_IServiceAuthConfig_ClientSecret.md 'TetraPak.AspNet.Auth.IServiceAuthConfig.ClientSecret') | Gets a client secret.<br/> |
| [ConfigPath](TetraPak_AspNet_Auth_IServiceAuthConfig_ConfigPath.md 'TetraPak.AspNet.Auth.IServiceAuthConfig.ConfigPath') | Gets the configuration path.<br/> |
| [Configuration](TetraPak_AspNet_Auth_IServiceAuthConfig_Configuration.md 'TetraPak.AspNet.Auth.IServiceAuthConfig.Configuration') | Gets the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') instance used to populate the properties.<br/> |
| [GrantType](TetraPak_AspNet_Auth_IServiceAuthConfig_GrantType.md 'TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType') | Specifies the grant type (OAuth) or authorization mechanism. <br/> |
| [Scope](TetraPak_AspNet_Auth_IServiceAuthConfig_Scope.md 'TetraPak.AspNet.Auth.IServiceAuthConfig.Scope') | Gets a scope to be requested for authorization.<br/> |
