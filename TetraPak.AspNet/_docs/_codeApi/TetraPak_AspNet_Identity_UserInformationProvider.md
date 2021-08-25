#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Identity](TetraPak_AspNet_Identity.md 'TetraPak.AspNet.Identity')
## UserInformationProvider Class
Enables user information obtained from Tetra Pak's user information service.  
```csharp
public class UserInformationProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; UserInformationProvider  
### Constructors
<a name='TetraPak_AspNet_Identity_UserInformationProvider_UserInformationProvider(TetraPak_AspNet_AmbientData_TetraPak_Caching_ITimeLimitedRepositories)'></a>
## UserInformationProvider.UserInformationProvider(AmbientData, ITimeLimitedRepositories) Constructor
Initializes the [UserInformationProvider](TetraPak_AspNet_Identity_UserInformationProvider.md 'TetraPak.AspNet.Identity.UserInformationProvider').  
```csharp
public UserInformationProvider(TetraPak.AspNet.AmbientData ambientData, TetraPak.Caching.ITimeLimitedRepositories cache=null);
```
#### Parameters
<a name='TetraPak_AspNet_Identity_UserInformationProvider_UserInformationProvider(TetraPak_AspNet_AmbientData_TetraPak_Caching_ITimeLimitedRepositories)_ambientData'></a>
`ambientData` [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')  
Provides ambient data and configuration.  
  
<a name='TetraPak_AspNet_Identity_UserInformationProvider_UserInformationProvider(TetraPak_AspNet_AmbientData_TetraPak_Caching_ITimeLimitedRepositories)_cache'></a>
`cache` [TetraPak.Caching.ITimeLimitedRepositories](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Caching.ITimeLimitedRepositories 'TetraPak.Caching.ITimeLimitedRepositories')  
(optional)<br />  
A caching service to be used for caching user information.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[ambientData](TetraPak_AspNet_Identity_UserInformationProvider.md#TetraPak_AspNet_Identity_UserInformationProvider_UserInformationProvider(TetraPak_AspNet_AmbientData_TetraPak_Caching_ITimeLimitedRepositories)_ambientData 'TetraPak.AspNet.Identity.UserInformationProvider.UserInformationProvider(TetraPak.AspNet.AmbientData, TetraPak.Caching.ITimeLimitedRepositories).ambientData') was unassigned.  
            
  
### Methods
<a name='TetraPak_AspNet_Identity_UserInformationProvider_GetUserInformationAsync(string_bool)'></a>
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
  
