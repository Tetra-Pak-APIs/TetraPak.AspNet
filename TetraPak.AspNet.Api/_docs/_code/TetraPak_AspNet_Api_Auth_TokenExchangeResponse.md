#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TokenExchangeResponse Class
Represents the response from a successful token exchange request (see [ITokenExchangeGrantService.ExchangeAsync](https://docs.microsoft.com/en-us/dotnet/api/ITokenExchangeGrantService.ExchangeAsync 'ITokenExchangeGrantService.ExchangeAsync')).  
```csharp
public class TokenExchangeResponse
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TokenExchangeResponse  
### Properties
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeResponse_AccessToken'></a>
## TokenExchangeResponse.AccessToken Property
Gets the security token issued by the authorization server in response to the token exchange request.  
```csharp
public string AccessToken { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeResponse_ExpiresIn'></a>
## TokenExchangeResponse.ExpiresIn Property
(optional, recommended)<br/>  
The validity lifetime, in seconds, of the token issued by the authorization server.  
```csharp
public string ExpiresIn { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeResponse_IssuedTokenType'></a>
## TokenExchangeResponse.IssuedTokenType Property
Gets an identifier for the representation of the issued security token.  
```csharp
public string IssuedTokenType { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeResponse_RefreshToken'></a>
## TokenExchangeResponse.RefreshToken Property
(optional)<br/>  
A refresh token.  
```csharp
public string RefreshToken { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeResponse_Scope'></a>
## TokenExchangeResponse.Scope Property
(optional)<br/>  
The scope of the issued security token.  
```csharp
public string Scope { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeResponse_TokenType'></a>
## TokenExchangeResponse.TokenType Property
A case-insensitive value specifying the method of using the access token issued, as specified in Section 7.1 of [RFC6749].  
```csharp
public string TokenType { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
