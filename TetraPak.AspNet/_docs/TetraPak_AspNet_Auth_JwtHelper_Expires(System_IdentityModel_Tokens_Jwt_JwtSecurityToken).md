#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth').[JwtHelper](TetraPak_AspNet_Auth_JwtHelper.md 'TetraPak.AspNet.Auth.JwtHelper')
## JwtHelper.Expires(JwtSecurityToken) Method
Gets the expiration time for a [System.IdentityModel.Tokens.Jwt.JwtSecurityToken](https://docs.microsoft.com/en-us/dotnet/api/System.IdentityModel.Tokens.Jwt.JwtSecurityToken 'System.IdentityModel.Tokens.Jwt.JwtSecurityToken').   
```csharp
public static System.Nullable<System.DateTime> Expires(this System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwt);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_JwtHelper_Expires(System_IdentityModel_Tokens_Jwt_JwtSecurityToken)_jwt'></a>
`jwt` [System.IdentityModel.Tokens.Jwt.JwtSecurityToken](https://docs.microsoft.com/en-us/dotnet/api/System.IdentityModel.Tokens.Jwt.JwtSecurityToken 'System.IdentityModel.Tokens.Jwt.JwtSecurityToken')  
The [System.IdentityModel.Tokens.Jwt.JwtSecurityToken](https://docs.microsoft.com/en-us/dotnet/api/System.IdentityModel.Tokens.Jwt.JwtSecurityToken 'System.IdentityModel.Tokens.Jwt.JwtSecurityToken').  
  
#### Returns
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
A [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime') value if the [jwt](TetraPak_AspNet_Auth_JwtHelper_Expires(System_IdentityModel_Tokens_Jwt_JwtSecurityToken).md#TetraPak_AspNet_Auth_JwtHelper_Expires(System_IdentityModel_Tokens_Jwt_JwtSecurityToken)_jwt 'TetraPak.AspNet.Auth.JwtHelper.Expires(System.IdentityModel.Tokens.Jwt.JwtSecurityToken).jwt') contains an "exp" claim;  
otherwise `null`.   
