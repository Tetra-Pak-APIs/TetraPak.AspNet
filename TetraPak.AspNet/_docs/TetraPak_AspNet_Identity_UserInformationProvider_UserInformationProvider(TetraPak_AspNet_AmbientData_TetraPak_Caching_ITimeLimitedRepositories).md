#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Identity](TetraPak_AspNet_Identity.md 'TetraPak.AspNet.Identity').[UserInformationProvider](TetraPak_AspNet_Identity_UserInformationProvider.md 'TetraPak.AspNet.Identity.UserInformationProvider')
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
[ambientData](TetraPak_AspNet_Identity_UserInformationProvider_UserInformationProvider(TetraPak_AspNet_AmbientData_TetraPak_Caching_ITimeLimitedRepositories).md#TetraPak_AspNet_Identity_UserInformationProvider_UserInformationProvider(TetraPak_AspNet_AmbientData_TetraPak_Caching_ITimeLimitedRepositories)_ambientData 'TetraPak.AspNet.Identity.UserInformationProvider.UserInformationProvider(TetraPak.AspNet.AmbientData, TetraPak.Caching.ITimeLimitedRepositories).ambientData') was unassigned.  
            
