#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## AuthContext Class
Used to describe an auth request context.  
```csharp
public class AuthContext
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AuthContext  
### Constructors
<a name='TetraPak_AspNet_AuthContext_AuthContext(TetraPak_AspNet_Auth_GrantType_TetraPak_AspNet_Auth_IServiceAuthConfig)'></a>
## AuthContext.AuthContext(GrantType, IServiceAuthConfig) Constructor
Initializes the [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext').  
```csharp
public AuthContext(TetraPak.AspNet.Auth.GrantType grantType, TetraPak.AspNet.Auth.IServiceAuthConfig authConfig);
```
#### Parameters
<a name='TetraPak_AspNet_AuthContext_AuthContext(TetraPak_AspNet_Auth_GrantType_TetraPak_AspNet_Auth_IServiceAuthConfig)_grantType'></a>
`grantType` [GrantType](TetraPak_AspNet_Auth_GrantType.md 'TetraPak.AspNet.Auth.GrantType')  
Initializes [GrantType](TetraPak_AspNet_AuthContext.md#TetraPak_AspNet_AuthContext_GrantType 'TetraPak.AspNet.AuthContext.GrantType').  
  
<a name='TetraPak_AspNet_AuthContext_AuthContext(TetraPak_AspNet_Auth_GrantType_TetraPak_AspNet_Auth_IServiceAuthConfig)_authConfig'></a>
`authConfig` [IServiceAuthConfig](TetraPak_AspNet_Auth_IServiceAuthConfig.md 'TetraPak.AspNet.Auth.IServiceAuthConfig')  
Initializes [AuthConfig](TetraPak_AspNet_AuthContext.md#TetraPak_AspNet_AuthContext_AuthConfig 'TetraPak.AspNet.AuthContext.AuthConfig').   
  
  
### Properties
<a name='TetraPak_AspNet_AuthContext_AuthConfig'></a>
## AuthContext.AuthConfig Property
Gets the [IServiceAuthConfig](TetraPak_AspNet_Auth_IServiceAuthConfig.md 'TetraPak.AspNet.Auth.IServiceAuthConfig') object.  
```csharp
public TetraPak.AspNet.Auth.IServiceAuthConfig AuthConfig { get; }
```
#### Property Value
[IServiceAuthConfig](TetraPak_AspNet_Auth_IServiceAuthConfig.md 'TetraPak.AspNet.Auth.IServiceAuthConfig')
  
<a name='TetraPak_AspNet_AuthContext_GrantType'></a>
## AuthContext.GrantType Property
Specifies the requested [GrantType](TetraPak_AspNet_AuthContext.md#TetraPak_AspNet_AuthContext_GrantType 'TetraPak.AspNet.AuthContext.GrantType').  
```csharp
public TetraPak.AspNet.Auth.GrantType GrantType { get; }
```
#### Property Value
[GrantType](TetraPak_AspNet_Auth_GrantType.md 'TetraPak.AspNet.Auth.GrantType')
  
#### See Also
- [ConfigDelegate](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_ConfigDelegate 'TetraPak.AspNet.TetraPakAuthConfig.ConfigDelegate')
