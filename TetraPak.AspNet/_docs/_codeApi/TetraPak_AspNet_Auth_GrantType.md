#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## GrantType Enum
used to specify an authentication method when communicating with a backend service.  
```csharp
public enum GrantType

```
#### Fields
<a name='TetraPak_AspNet_Auth_GrantType_CC'></a>
`CC` 2  
Abbreviation for [ClientCredentials](TetraPak_AspNet_Auth_GrantType.md#TetraPak_AspNet_Auth_GrantType_ClientCredentials 'TetraPak.AspNet.Auth.GrantType.ClientCredentials').  
  
<a name='TetraPak_AspNet_Auth_GrantType_ClientCredentials'></a>
`ClientCredentials` 2  
The service is authenticating itself towards the backend service through  
its own client credentials (client id and client secret).  
  
<a name='TetraPak_AspNet_Auth_GrantType_Inherited'></a>
`Inherited` 3  
The service authentication mechanism is inherited from its parent service configuration.  
  
<a name='TetraPak_AspNet_Auth_GrantType_None'></a>
`None` 0  
The service do not have to authenticate itself when consuming its backend service.  
  
<a name='TetraPak_AspNet_Auth_GrantType_TokenExchange'></a>
`TokenExchange` 1  
The service is authenticating itself towards the backend service by exchanging its  
requesting actor's credentials for it own credentials.  
  
<a name='TetraPak_AspNet_Auth_GrantType_TX'></a>
`TX` 1  
Abbreviation for [TokenExchange](TetraPak_AspNet_Auth_GrantType.md#TetraPak_AspNet_Auth_GrantType_TokenExchange 'TetraPak.AspNet.Auth.GrantType.TokenExchange').  
  
