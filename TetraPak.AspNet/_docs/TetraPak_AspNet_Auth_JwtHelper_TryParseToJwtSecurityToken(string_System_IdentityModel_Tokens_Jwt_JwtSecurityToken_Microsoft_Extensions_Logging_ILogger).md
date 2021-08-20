#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth').[JwtHelper](TetraPak_AspNet_Auth_JwtHelper.md 'TetraPak.AspNet.Auth.JwtHelper')
## JwtHelper.TryParseToJwtSecurityToken(string, JwtSecurityToken, ILogger) Method
Parses a JWT token and returns a [System.IdentityModel.Tokens.Jwt.JwtSecurityToken](https://docs.microsoft.com/en-us/dotnet/api/System.IdentityModel.Tokens.Jwt.JwtSecurityToken 'System.IdentityModel.Tokens.Jwt.JwtSecurityToken') from the content.  
```csharp
public static bool TryParseToJwtSecurityToken(this string s, out System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwtSecurityToken, Microsoft.Extensions.Logging.ILogger logger=null);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_JwtHelper_TryParseToJwtSecurityToken(string_System_IdentityModel_Tokens_Jwt_JwtSecurityToken_Microsoft_Extensions_Logging_ILogger)_s'></a>
`s` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='TetraPak_AspNet_Auth_JwtHelper_TryParseToJwtSecurityToken(string_System_IdentityModel_Tokens_Jwt_JwtSecurityToken_Microsoft_Extensions_Logging_ILogger)_jwtSecurityToken'></a>
`jwtSecurityToken` [System.IdentityModel.Tokens.Jwt.JwtSecurityToken](https://docs.microsoft.com/en-us/dotnet/api/System.IdentityModel.Tokens.Jwt.JwtSecurityToken 'System.IdentityModel.Tokens.Jwt.JwtSecurityToken')  
  
<a name='TetraPak_AspNet_Auth_JwtHelper_TryParseToJwtSecurityToken(string_System_IdentityModel_Tokens_Jwt_JwtSecurityToken_Microsoft_Extensions_Logging_ILogger)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
