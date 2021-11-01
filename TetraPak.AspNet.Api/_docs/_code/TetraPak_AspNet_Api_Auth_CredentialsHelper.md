#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## CredentialsHelper Class
```csharp
public static class CredentialsHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CredentialsHelper  
### Methods
<a name='TetraPak_AspNet_Api_Auth_CredentialsHelper_IsValidFor(TetraPak_Credentials__TetraPak_AspNet_Auth_GrantType)'></a>
## CredentialsHelper.IsValidFor(Credentials?, GrantType) Method
Examines [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials') and returns a value indicating whether they can be  
used for a specified [TetraPak.AspNet.Auth.GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.GrantType 'TetraPak.AspNet.Auth.GrantType').  
```csharp
public static bool IsValidFor(this TetraPak.Credentials? credentials, TetraPak.AspNet.Auth.GrantType grantType);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_CredentialsHelper_IsValidFor(TetraPak_Credentials__TetraPak_AspNet_Auth_GrantType)_credentials'></a>
`credentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
The extended [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials').  
  
<a name='TetraPak_AspNet_Api_Auth_CredentialsHelper_IsValidFor(TetraPak_Credentials__TetraPak_AspNet_Auth_GrantType)_grantType'></a>
`grantType` [TetraPak.AspNet.Auth.GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.GrantType 'TetraPak.AspNet.Auth.GrantType')  
The specified grant type.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the credentials are valid for the specified grant type;  
              otherwise `false`.  
            
  
