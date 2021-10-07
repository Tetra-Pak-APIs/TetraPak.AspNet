#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## ConfiguredClientCredentialsProvider Class
Provides client credentials from the configuration framework.  
```csharp
public class ConfiguredClientCredentialsProvider :
TetraPak.AspNet.Auth.IClientCredentialsProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ConfiguredClientCredentialsProvider  

Implements [IClientCredentialsProvider](TetraPak_AspNet_Auth_IClientCredentialsProvider.md 'TetraPak.AspNet.Auth.IClientCredentialsProvider')  
### Constructors
<a name='TetraPak_AspNet_Auth_ConfiguredClientCredentialsProvider_ConfiguredClientCredentialsProvider(TetraPak_AspNet_TetraPakConfig)'></a>
## ConfiguredClientCredentialsProvider.ConfiguredClientCredentialsProvider(TetraPakConfig) Constructor
Initializes the [ConfiguredClientCredentialsProvider](TetraPak_AspNet_Auth_ConfiguredClientCredentialsProvider.md 'TetraPak.AspNet.Auth.ConfiguredClientCredentialsProvider') object.  
```csharp
public ConfiguredClientCredentialsProvider(TetraPak.AspNet.TetraPakConfig config);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_ConfiguredClientCredentialsProvider_ConfiguredClientCredentialsProvider(TetraPak_AspNet_TetraPakConfig)_config'></a>
`config` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
A [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig') object.   
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[config](TetraPak_AspNet_Auth_ConfiguredClientCredentialsProvider.md#TetraPak_AspNet_Auth_ConfiguredClientCredentialsProvider_ConfiguredClientCredentialsProvider(TetraPak_AspNet_TetraPakConfig)_config 'TetraPak.AspNet.Auth.ConfiguredClientCredentialsProvider.ConfiguredClientCredentialsProvider(TetraPak.AspNet.TetraPakConfig).config') was unassigned.  
            
  
### Methods
<a name='TetraPak_AspNet_Auth_ConfiguredClientCredentialsProvider_GetClientCredentialsAsync()'></a>
## ConfiguredClientCredentialsProvider.GetClientCredentialsAsync() Method
Obtains and returns client credentials.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.Credentials>> GetClientCredentialsAsync();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetClientCredentialsAsync()](TetraPak_AspNet_Auth_IClientCredentialsProvider.md#TetraPak_AspNet_Auth_IClientCredentialsProvider_GetClientCredentialsAsync() 'TetraPak.AspNet.Auth.IClientCredentialsProvider.GetClientCredentialsAsync()')  
  
