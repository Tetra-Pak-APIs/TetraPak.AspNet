#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## IClientCredentialsProvider Interface
Implementors of this contract can be used for obtaining client credentials,  
typically for token exchange, or similar flows where such credentials are needed.  
```csharp
public interface IClientCredentialsProvider
```

Derived  
&#8627; [ConfiguredClientCredentialsProvider](TetraPak_AspNet_Auth_ConfiguredClientCredentialsProvider.md 'TetraPak.AspNet.Auth.ConfiguredClientCredentialsProvider')  
### Methods
<a name='TetraPak_AspNet_Auth_IClientCredentialsProvider_GetClientCredentialsAsync()'></a>
## IClientCredentialsProvider.GetClientCredentialsAsync() Method
Obtains and returns client credentials.  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.Credentials>> GetClientCredentialsAsync();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
