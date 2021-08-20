#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth').[TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')
## TetraPakAuthConfig.DefaultCachingLifetime Property
Gets or sets a [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan') value specifying the default lifetime of cached auth data.  
This value is only consumed by the auth framework when [IsCachingAllowed](TetraPak_AspNet_Auth_TetraPakAuthConfig_IsCachingAllowed.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig.IsCachingAllowed') is set.   
```csharp
public System.TimeSpan DefaultCachingLifetime { get; set; }
```
#### Property Value
[System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')
#### See Also
- [IsCachingAllowed](TetraPak_AspNet_Auth_TetraPakAuthConfig_IsCachingAllowed.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig.IsCachingAllowed')
