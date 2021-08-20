#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth').[TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')
## TetraPakAuthConfig.RefreshThreshold Property
Gets or sets the threshold time (in seconds) used for calculating when it is time  
to refresh the access token when a refresh token was provided.  
```csharp
public int RefreshThreshold { get; set; }
```
#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Remarks
The refresh threshold value is specified in seconds. When a token is validated for its  
TTL (time to live) this value is subtracted from the actual expiration time to calculate  
the remaining TTL. When the TTL is zero or negative, and a refresh token is available,  
a Refresh Flow will automatically be initiated to obtain a new access token.  




  
Setting this value might be a good idea to account for response times in requests.  
The value is expected to be a positive integer.  
Negative values will automatically be converted to positive values.   
