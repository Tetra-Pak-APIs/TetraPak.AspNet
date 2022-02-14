#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Identity](TetraPak_AspNet_Identity.md 'TetraPak.AspNet.Identity')
## UserInformationProvider Class
Enables user information obtained from Tetra Pak's user information service.  
```csharp
public class UserInformationProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; UserInformationProvider  
### Constructors
<a name='TetraPak_AspNet_Identity_UserInformationProvider_UserInformationProvider(TetraPak_AspNet_AmbientData_TetraPak_AspNet_IHttpClientProvider_TetraPak_Caching_ITimeLimitedRepositories_)'></a>
## UserInformationProvider.UserInformationProvider(AmbientData, IHttpClientProvider, ITimeLimitedRepositories?) Constructor
Initializes the [UserInformationProvider](TetraPak_AspNet_Identity_UserInformationProvider.md 'TetraPak.AspNet.Identity.UserInformationProvider').  
```csharp
public UserInformationProvider(TetraPak.AspNet.AmbientData ambientData, TetraPak.AspNet.IHttpClientProvider httpClientProvider, TetraPak.Caching.ITimeLimitedRepositories? cache=null);
```
#### Parameters
<a name='TetraPak_AspNet_Identity_UserInformationProvider_UserInformationProvider(TetraPak_AspNet_AmbientData_TetraPak_AspNet_IHttpClientProvider_TetraPak_Caching_ITimeLimitedRepositories_)_ambientData'></a>
`ambientData` [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')  
Provides ambient data and configuration.  
  
<a name='TetraPak_AspNet_Identity_UserInformationProvider_UserInformationProvider(TetraPak_AspNet_AmbientData_TetraPak_AspNet_IHttpClientProvider_TetraPak_Caching_ITimeLimitedRepositories_)_httpClientProvider'></a>
`httpClientProvider` [IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider')  
A HttpClient factory.  
  
<a name='TetraPak_AspNet_Identity_UserInformationProvider_UserInformationProvider(TetraPak_AspNet_AmbientData_TetraPak_AspNet_IHttpClientProvider_TetraPak_Caching_ITimeLimitedRepositories_)_cache'></a>
`cache` [TetraPak.Caching.ITimeLimitedRepositories](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Caching.ITimeLimitedRepositories 'TetraPak.Caching.ITimeLimitedRepositories')  
(optional)<br/>  
A caching service to be used for caching user information.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[ambientData](TetraPak_AspNet_Identity_UserInformationProvider.md#TetraPak_AspNet_Identity_UserInformationProvider_UserInformationProvider(TetraPak_AspNet_AmbientData_TetraPak_AspNet_IHttpClientProvider_TetraPak_Caching_ITimeLimitedRepositories_)_ambientData 'TetraPak.AspNet.Identity.UserInformationProvider.UserInformationProvider(TetraPak.AspNet.AmbientData, TetraPak.AspNet.IHttpClientProvider, TetraPak.Caching.ITimeLimitedRepositories?).ambientData') was unassigned.  
            
  
### Methods
<a name='TetraPak_AspNet_Identity_UserInformationProvider_GetUserInformationAsync(TetraPak_ActorToken_System_Nullable_System_Threading_CancellationToken__string__bool)'></a>
## UserInformationProvider.GetUserInformationAsync(ActorToken, Nullable&lt;CancellationToken&gt;, string?, bool) Method
Obtains (and, optionally, caches) user information.   
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Identity.UserInformation>> GetUserInformationAsync(TetraPak.ActorToken accessToken, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, string? messageId=null, bool cached=true);
```
#### Parameters
<a name='TetraPak_AspNet_Identity_UserInformationProvider_GetUserInformationAsync(TetraPak_ActorToken_System_Nullable_System_Threading_CancellationToken__string__bool)_accessToken'></a>
`accessToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
An access token, authenticating the requesting actor.   
  
<a name='TetraPak_AspNet_Identity_UserInformationProvider_GetUserInformationAsync(TetraPak_ActorToken_System_Nullable_System_Threading_CancellationToken__string__bool)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Enables cancellation of the operation.  
  
<a name='TetraPak_AspNet_Identity_UserInformationProvider_GetUserInformationAsync(TetraPak_ActorToken_System_Nullable_System_Threading_CancellationToken__string__bool)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A unique string value for tracking a request/response (mainly for diagnostics purposes).  
  
<a name='TetraPak_AspNet_Identity_UserInformationProvider_GetUserInformationAsync(TetraPak_ActorToken_System_Nullable_System_Threading_CancellationToken__string__bool)_cached'></a>
`cached` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
When set, the value will cache the downloaded result (and fetch it from the internal cache if present).   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[UserInformation](TetraPak_AspNet_Identity_UserInformation.md 'TetraPak.AspNet.Identity.UserInformation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [UserInformation](TetraPak_AspNet_Identity_UserInformation.md 'TetraPak.AspNet.Identity.UserInformation') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
