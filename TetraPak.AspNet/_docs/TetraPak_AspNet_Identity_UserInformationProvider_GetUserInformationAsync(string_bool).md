#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Identity](TetraPak_AspNet_Identity.md 'TetraPak.AspNet.Identity').[UserInformationProvider](TetraPak_AspNet_Identity_UserInformationProvider.md 'TetraPak.AspNet.Identity.UserInformationProvider')
## UserInformationProvider.GetUserInformationAsync(string, bool) Method
Obtains (and, optionally, caches) user information.   
```csharp
public System.Threading.Tasks.Task<TetraPak.AspNet.Identity.UserInformation> GetUserInformationAsync(string accessToken, bool cached=true);
```
#### Parameters
<a name='TetraPak_AspNet_Identity_UserInformationProvider_GetUserInformationAsync(string_bool)_accessToken'></a>
`accessToken` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
An access token, authenticating the requesting actor.   
  
<a name='TetraPak_AspNet_Identity_UserInformationProvider_GetUserInformationAsync(string_bool)_cached'></a>
`cached` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br />  
When set, the value will cache the downloaded result (and fetch it from the internal cache if present).   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[UserInformation](TetraPak_AspNet_Identity_UserInformation.md 'TetraPak.AspNet.Identity.UserInformation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [UserInformation](TetraPak_AspNet_Identity_UserInformation.md 'TetraPak.AspNet.Identity.UserInformation') value.  
