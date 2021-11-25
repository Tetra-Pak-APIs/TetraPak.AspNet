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
  
<a name='TetraPak_AspNet_Auth_JwtHelper_IsSystemIdentityToken(string)'></a>
## JwtHelper.IsSystemIdentityToken(string) Method
Examines a string and returns a value that indicates whether it is a security token that  
represents a system identity (as opposed to an identity supported by an identity provider).  
This is often the case when the client is an autonomous service, such as a web job,  
that was authorized via a Client Credential Grant.   
```csharp
public static bool IsSystemIdentityToken(this string stringValue);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_JwtHelper_IsSystemIdentityToken(string)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the string is a token that represents a system identity; otherwise `false`.  
            
### Remarks
This information is needed by the [TetraPakJwtClaimsTransformation](TetraPak_AspNet_TetraPakJwtClaimsTransformation.md 'TetraPak.AspNet.TetraPakJwtClaimsTransformation') service so as  
to not waste time on trying to obtain identity claims from Tetra Pak's User Information services.  
#### See Also
- [IsSystemIdentityToken(ActorToken)](TetraPak_AspNet_Auth_JwtHelper.md#TetraPak_AspNet_Auth_JwtHelper_IsSystemIdentityToken(TetraPak_ActorToken) 'TetraPak.AspNet.Auth.JwtHelper.IsSystemIdentityToken(TetraPak.ActorToken)')
  
<a name='TetraPak_AspNet_Auth_JwtHelper_IsSystemIdentityToken(TetraPak_ActorToken)'></a>
## JwtHelper.IsSystemIdentityToken(ActorToken) Method
Examines a token and returns a value that indicates whether the token represents a system identity  
(as opposed to an identity supported by an identity provider). This is often the case when the  
client is an autonomous service, such as a web job, that was authorized via a Client Credential Grant.   
```csharp
public static bool IsSystemIdentityToken(this TetraPak.ActorToken actorToken);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_JwtHelper_IsSystemIdentityToken(TetraPak_ActorToken)_actorToken'></a>
`actorToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the token represents a system identity; otherwise `false`.  
            
### Remarks
This information is needed by the [TetraPakJwtClaimsTransformation](TetraPak_AspNet_TetraPakJwtClaimsTransformation.md 'TetraPak.AspNet.TetraPakJwtClaimsTransformation') service so as  
to not waste time on trying to obtain identity claims from Tetra Pak's User Information services.  
#### See Also
- [IsSystemIdentityToken(string)](TetraPak_AspNet_Auth_JwtHelper.md#TetraPak_AspNet_Auth_JwtHelper_IsSystemIdentityToken(string) 'TetraPak.AspNet.Auth.JwtHelper.IsSystemIdentityToken(string)')
  
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
  
<a name='TetraPak_AspNet_Auth_JwtHelper_TryParseToJwtSecurityToken(string__System_IdentityModel_Tokens_Jwt_JwtSecurityToken__Microsoft_Extensions_Logging_ILogger_)'></a>
## JwtHelper.TryParseToJwtSecurityToken(string?, JwtSecurityToken?, ILogger?) Method
Tries parsing a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') as a JWT token.  
```csharp
public static bool TryParseToJwtSecurityToken(this string? stringValue, out System.IdentityModel.Tokens.Jwt.JwtSecurityToken? jwtSecurityToken, Microsoft.Extensions.Logging.ILogger? logger=null);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_JwtHelper_TryParseToJwtSecurityToken(string__System_IdentityModel_Tokens_Jwt_JwtSecurityToken__Microsoft_Extensions_Logging_ILogger_)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') to be parsed.  
  
<a name='TetraPak_AspNet_Auth_JwtHelper_TryParseToJwtSecurityToken(string__System_IdentityModel_Tokens_Jwt_JwtSecurityToken__Microsoft_Extensions_Logging_ILogger_)_jwtSecurityToken'></a>
`jwtSecurityToken` [System.IdentityModel.Tokens.Jwt.JwtSecurityToken](https://docs.microsoft.com/en-us/dotnet/api/System.IdentityModel.Tokens.Jwt.JwtSecurityToken 'System.IdentityModel.Tokens.Jwt.JwtSecurityToken')  
On success; passes the [System.IdentityModel.Tokens.Jwt.JwtSecurityToken](https://docs.microsoft.com/en-us/dotnet/api/System.IdentityModel.Tokens.Jwt.JwtSecurityToken 'System.IdentityModel.Tokens.Jwt.JwtSecurityToken') (`null` on failure).   
  
<a name='TetraPak_AspNet_Auth_JwtHelper_TryParseToJwtSecurityToken(string__System_IdentityModel_Tokens_Jwt_JwtSecurityToken__Microsoft_Extensions_Logging_ILogger_)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
(optional)<br/>  
A logger provider used for diagnostics purposes.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
