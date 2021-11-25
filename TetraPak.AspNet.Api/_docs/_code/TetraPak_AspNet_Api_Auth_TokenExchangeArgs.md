#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TokenExchangeArgs Class
Provides the options to be used for a token exchange process (see [ExchangeAccessTokenAsync(Credentials, ActorToken, CancellationToken)](TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService.md#TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_System_Threading_CancellationToken) 'TetraPak.AspNet.Api.Auth.ITokenExchangeGrantService.ExchangeAccessTokenAsync(TetraPak.Credentials, TetraPak.ActorToken, System.Threading.CancellationToken)')).  
See https://tools.ietf.org/id/draft-ietf-oauth-token-exchange-19.html for more details,  
```csharp
public class TokenExchangeArgs
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TokenExchangeArgs  
### Properties
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeArgs_ActorToken'></a>
## TokenExchangeArgs.ActorToken Property
(optional)<br/>  
Gets the a security token that represents the identity of the acting party. Typically, this will  
be the party that is authorized to use the requested security token and act on behalf of the subject.  
```csharp
public string ActorToken { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeArgs_ActorTokenType'></a>
## TokenExchangeArgs.ActorTokenType Property
(optional)<br/>  
Gets the an identifier that indicates the type of the security token in the  
[ActorToken](TetraPak_AspNet_Api_Auth_TokenExchangeArgs.md#TetraPak_AspNet_Api_Auth_TokenExchangeArgs_ActorToken 'TetraPak.AspNet.Api.Auth.TokenExchangeArgs.ActorToken') parameter. This is REQUIRED when the [ActorToken](TetraPak_AspNet_Api_Auth_TokenExchangeArgs.md#TetraPak_AspNet_Api_Auth_TokenExchangeArgs_ActorToken 'TetraPak.AspNet.Api.Auth.TokenExchangeArgs.ActorToken') parameter is set  
but MUST NOT be included otherwise.  
```csharp
public string ActorTokenType { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeArgs_Audience'></a>
## TokenExchangeArgs.Audience Property
(optional)<br/>  
Gets or sets the logical name of the target service where the client intends to use the  
requested security token. See   
```csharp
public string Audience { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeArgs_Credentials'></a>
## TokenExchangeArgs.Credentials Property
Gets the credentials to be used for token exchange (typically a [TetraPak.BasicAuthCredentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.BasicAuthCredentials 'TetraPak.BasicAuthCredentials')  
with client id/client secret.   
```csharp
public TetraPak.Credentials Credentials { get; set; }
```
#### Property Value
[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeArgs_RequestedTokenType'></a>
## TokenExchangeArgs.RequestedTokenType Property
(optional)<br/>  
An identifier, as described in Section 3 of [RFC6749], for the type of the requested security token.  
If the requested type is unspecified, the issued token type is at the discretion of the authorization  
server and may be dictated by knowledge of the requirements of the service or resource indicated by the  
resource or audience parameter.  
```csharp
public string RequestedTokenType { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeArgs_Resource'></a>
## TokenExchangeArgs.Resource Property
(optional)<br/>  
A URI that indicates the target service or resource where the client intends to use the  
requested security token.  
```csharp
public System.Uri Resource { get; set; }
```
#### Property Value
[System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeArgs_Scope'></a>
## TokenExchangeArgs.Scope Property
(optional)<br/>  
A list of case-sensitive strings, as defined in Section 3.3 of [RFC6749], that allow the client to  
specify the desired scope of the requested security token in the context of the service or resource  
where the token will be used. The values and associated semantics of scope are service specific and  
expected to be described in the relevant service documentation.  
```csharp
public System.Collections.Generic.IEnumerable<string> Scope { get; set; }
```
#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeArgs_SubjectToken'></a>
## TokenExchangeArgs.SubjectToken Property
Gets the subject token to be exchanged.  
```csharp
public TetraPak.ActorToken SubjectToken { get; set; }
```
#### Property Value
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')
  
<a name='TetraPak_AspNet_Api_Auth_TokenExchangeArgs_SubjectTokenType'></a>
## TokenExchangeArgs.SubjectTokenType Property
Gets the subject token type.  
```csharp
public string SubjectTokenType { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
