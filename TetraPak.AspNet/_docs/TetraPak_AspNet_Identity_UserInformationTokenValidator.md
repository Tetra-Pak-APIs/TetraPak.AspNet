#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Identity](TetraPak_AspNet_Identity.md 'TetraPak.AspNet.Identity')
## UserInformationTokenValidator Class
To be inherited and used for custom token validation purposes by a [UserInformationProvider](TetraPak_AspNet_Identity_UserInformationProvider.md 'TetraPak.AspNet.Identity.UserInformationProvider').  
```csharp
public abstract class UserInformationTokenValidator
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; UserInformationTokenValidator  

| Properties | |
| :--- | :--- |
| [AuthConfig](TetraPak_AspNet_Identity_UserInformationTokenValidator_AuthConfig.md 'TetraPak.AspNet.Identity.UserInformationTokenValidator.AuthConfig') | Gets the auth configuration.<br/> |
| [Logger](TetraPak_AspNet_Identity_UserInformationTokenValidator_Logger.md 'TetraPak.AspNet.Identity.UserInformationTokenValidator.Logger') | Gets a log provider.<br/> |

| Methods | |
| :--- | :--- |
| [ValidateAccessTokenAsync(string, bool)](TetraPak_AspNet_Identity_UserInformationTokenValidator_ValidateAccessTokenAsync(string_bool).md 'TetraPak.AspNet.Identity.UserInformationTokenValidator.ValidateAccessTokenAsync(string, bool)') | Called by the [UserInformationProvider](TetraPak_AspNet_Identity_UserInformationProvider.md 'TetraPak.AspNet.Identity.UserInformationProvider') for custom access token validation/processing.<br/>One good example could be performing automatic token exchange for accessing user information services. <br/> |
