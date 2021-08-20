#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Identity](TetraPak_AspNet_Identity.md 'TetraPak.AspNet.Identity').[UserInformationTokenValidator](TetraPak_AspNet_Identity_UserInformationTokenValidator.md 'TetraPak.AspNet.Identity.UserInformationTokenValidator')
## UserInformationTokenValidator.ValidateAccessTokenAsync(string, bool) Method
Called by the [UserInformationProvider](TetraPak_AspNet_Identity_UserInformationProvider.md 'TetraPak.AspNet.Identity.UserInformationProvider') for custom access token validation/processing.  
One good example could be performing automatic token exchange for accessing user information services.   
```csharp
public abstract System.Threading.Tasks.Task<TetraPak.Outcome<string>> ValidateAccessTokenAsync(string accessToken, bool isCached);
```
#### Parameters
<a name='TetraPak_AspNet_Identity_UserInformationTokenValidator_ValidateAccessTokenAsync(string_bool)_accessToken'></a>
`accessToken` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The access token to be validated/processed.  
  
<a name='TetraPak_AspNet_Identity_UserInformationTokenValidator_ValidateAccessTokenAsync(string_bool)_isCached'></a>
`isCached` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Specifies whether the access token was cached by the [UserInformationProvider](TetraPak_AspNet_Identity_UserInformationProvider.md 'TetraPak.AspNet.Identity.UserInformationProvider').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value to indicate successful validation/processing,  
and to carry the access token to be used.  
