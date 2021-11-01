#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## JwtHelper Class
Provides convenience- and extension methods to assist in the use of JavaScript Web Tokens (JWT).   
```csharp
public static class JwtHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; JwtHelper  
### Methods
<a name='TetraPak_AspNet_Auth_JwtHelper_Expires(System_IdentityModel_Tokens_Jwt_JwtSecurityToken)'></a>
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
A [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime') value if the [jwt](TetraPak_AspNet_Auth_JwtHelper.md#TetraPak_AspNet_Auth_JwtHelper_Expires(System_IdentityModel_Tokens_Jwt_JwtSecurityToken)_jwt 'TetraPak.AspNet.Auth.JwtHelper.Expires(System.IdentityModel.Tokens.Jwt.JwtSecurityToken).jwt') contains an "exp" claim;  
otherwise `null`.   
  
<a name='TetraPak_AspNet_Auth_JwtHelper_ToDebugString(System_IdentityModel_Tokens_Jwt_JwtSecurityToken)'></a>
## JwtHelper.ToDebugString(JwtSecurityToken) Method
Builds and returns a string representing a (decoded) JWT security token.  
```csharp
public static string ToDebugString(this System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwt);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_JwtHelper_ToDebugString(System_IdentityModel_Tokens_Jwt_JwtSecurityToken)_jwt'></a>
`jwt` [System.IdentityModel.Tokens.Jwt.JwtSecurityToken](https://docs.microsoft.com/en-us/dotnet/api/System.IdentityModel.Tokens.Jwt.JwtSecurityToken 'System.IdentityModel.Tokens.Jwt.JwtSecurityToken')  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='TetraPak_AspNet_Auth_JwtHelper_TryParseToJwtSecurityToken(string_System_IdentityModel_Tokens_Jwt_JwtSecurityToken_Microsoft_Extensions_Logging_ILogger)'></a>
## JwtHelper.TryParseToJwtSecurityToken(string, JwtSecurityToken, ILogger) Method
Tries parsing a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') as a JWT token.  
```csharp
public static bool TryParseToJwtSecurityToken(this string stringValue, out System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwtSecurityToken, Microsoft.Extensions.Logging.ILogger logger=null);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_JwtHelper_TryParseToJwtSecurityToken(string_System_IdentityModel_Tokens_Jwt_JwtSecurityToken_Microsoft_Extensions_Logging_ILogger)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') to be parsed.  
  
<a name='TetraPak_AspNet_Auth_JwtHelper_TryParseToJwtSecurityToken(string_System_IdentityModel_Tokens_Jwt_JwtSecurityToken_Microsoft_Extensions_Logging_ILogger)_jwtSecurityToken'></a>
`jwtSecurityToken` [System.IdentityModel.Tokens.Jwt.JwtSecurityToken](https://docs.microsoft.com/en-us/dotnet/api/System.IdentityModel.Tokens.Jwt.JwtSecurityToken 'System.IdentityModel.Tokens.Jwt.JwtSecurityToken')  
On success; passes the [System.IdentityModel.Tokens.Jwt.JwtSecurityToken](https://docs.microsoft.com/en-us/dotnet/api/System.IdentityModel.Tokens.Jwt.JwtSecurityToken 'System.IdentityModel.Tokens.Jwt.JwtSecurityToken') (`null` on failure).   
  
<a name='TetraPak_AspNet_Auth_JwtHelper_TryParseToJwtSecurityToken(string_System_IdentityModel_Tokens_Jwt_JwtSecurityToken_Microsoft_Extensions_Logging_ILogger)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
(optional)<br/>  
A logger provider used for diagnostics purposes.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
