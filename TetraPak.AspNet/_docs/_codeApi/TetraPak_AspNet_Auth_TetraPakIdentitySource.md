#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## TetraPakIdentitySource Enum
Used to specify a source for obtaining identity information.    
```csharp
public enum TetraPakIdentitySource

```
#### Fields
<a name='TetraPak_AspNet_Auth_TetraPakIdentitySource_IdToken'></a>
`IdToken` 1  
Identity information is obtained from an existing identity token.  
This is the fastest method and might be sufficient in scenarios where the app doesn't need  
exhaustive user information, beyond the user's identity.  
  
<a name='TetraPak_AspNet_Auth_TetraPakIdentitySource_RemoteService'></a>
`RemoteService` 0  
Identity information is automatically requested from a (remote) service.  
This method is slower but might be necessary to obtain more detailed user information.   
  
