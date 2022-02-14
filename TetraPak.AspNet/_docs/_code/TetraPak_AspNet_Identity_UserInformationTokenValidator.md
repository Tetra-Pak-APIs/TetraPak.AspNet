#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Identity](TetraPak_AspNet_Identity.md 'TetraPak.AspNet.Identity')
## UserInformationTokenValidator Class
To be inherited and used for custom token validation purposes by a [UserInformationProvider](TetraPak_AspNet_Identity_UserInformationProvider.md 'TetraPak.AspNet.Identity.UserInformationProvider').  
```csharp
public abstract class UserInformationTokenValidator
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; UserInformationTokenValidator  
### Properties
<a name='TetraPak_AspNet_Identity_UserInformationTokenValidator_Config'></a>
## UserInformationTokenValidator.Config Property
Gets the auth configuration.  
```csharp
public TetraPak.AspNet.TetraPakConfig? Config { get; set; }
```
#### Property Value
[TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')
  
<a name='TetraPak_AspNet_Identity_UserInformationTokenValidator_Logger'></a>
## UserInformationTokenValidator.Logger Property
Gets a log provider.  
```csharp
protected Microsoft.Extensions.Logging.ILogger? Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
### Methods
<a name='TetraPak_AspNet_Identity_UserInformationTokenValidator_ValidateAccessTokenAsync(string_bool)'></a>
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
  
