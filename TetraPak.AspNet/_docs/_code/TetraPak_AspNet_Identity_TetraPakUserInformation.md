#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Identity](TetraPak_AspNet_Identity.md 'TetraPak.AspNet.Identity')
## TetraPakUserInformation Class
Provides easy access to Tetra Pak's user information services.   
```csharp
public class TetraPakUserInformation
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakUserInformation  
### Constructors
<a name='TetraPak_AspNet_Identity_TetraPakUserInformation_TetraPakUserInformation(TetraPak_AspNet_TetraPakConfig)'></a>
## TetraPakUserInformation.TetraPakUserInformation(TetraPakConfig) Constructor
Initializes the [TetraPakUserInformation](TetraPak_AspNet_Identity_TetraPakUserInformation.md 'TetraPak.AspNet.Identity.TetraPakUserInformation') object.  
```csharp
public TetraPakUserInformation(TetraPak.AspNet.TetraPakConfig config);
```
#### Parameters
<a name='TetraPak_AspNet_Identity_TetraPakUserInformation_TetraPakUserInformation(TetraPak_AspNet_TetraPakConfig)_config'></a>
`config` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
The Tetra Pak integration configuration.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[config](TetraPak_AspNet_Identity_TetraPakUserInformation.md#TetraPak_AspNet_Identity_TetraPakUserInformation_TetraPakUserInformation(TetraPak_AspNet_TetraPakConfig)_config 'TetraPak.AspNet.Identity.TetraPakUserInformation.TetraPakUserInformation(TetraPak.AspNet.TetraPakConfig).config') was unassigned.  
            
  
### Properties
<a name='TetraPak_AspNet_Identity_TetraPakUserInformation_AmbientData'></a>
## TetraPakUserInformation.AmbientData Property
Gets the ambient data object.  
```csharp
public TetraPak.AspNet.AmbientData AmbientData { get; }
```
#### Property Value
[AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')
  
<a name='TetraPak_AspNet_Identity_TetraPakUserInformation_Logger'></a>
## TetraPakUserInformation.Logger Property
Gets a logging provider.  
```csharp
public Microsoft.Extensions.Logging.ILogger Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
### Methods
<a name='TetraPak_AspNet_Identity_TetraPakUserInformation_GetUserInformationAsync(TetraPak_ActorToken)'></a>
## TetraPakUserInformation.GetUserInformationAsync(ActorToken) Method
Obtains and returns user information from the Tetra Pak Auth Services.   
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Identity.UserInformation>> GetUserInformationAsync(TetraPak.ActorToken accessToken);
```
#### Parameters
<a name='TetraPak_AspNet_Identity_TetraPakUserInformation_GetUserInformationAsync(TetraPak_ActorToken)_accessToken'></a>
`accessToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
The request access token.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[UserInformation](TetraPak_AspNet_Identity_UserInformation.md 'TetraPak.AspNet.Identity.UserInformation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [UserInformation](TetraPak_AspNet_Identity_UserInformation.md 'TetraPak.AspNet.Identity.UserInformation') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
