#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth').[TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')
## TetraPakAuthConfig.AuthorizationHeader Property
Gets or sets the name of the header used to obtain the token to be used for authorizing the actor.  
The default value is [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization')).  
```csharp
public string AuthorizationHeader { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
An invalid/empty value was assigned.  
#### See Also
- [IsCustomAuthorizationHeader](TetraPak_AspNet_Auth_TetraPakAuthConfig_IsCustomAuthorizationHeader.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig.IsCustomAuthorizationHeader')
