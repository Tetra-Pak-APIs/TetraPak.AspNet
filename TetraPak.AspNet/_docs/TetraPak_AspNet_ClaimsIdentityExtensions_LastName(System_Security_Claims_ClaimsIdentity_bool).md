#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[ClaimsIdentityExtensions](TetraPak_AspNet_ClaimsIdentityExtensions.md 'TetraPak.AspNet.ClaimsIdentityExtensions')
## ClaimsIdentityExtensions.LastName(ClaimsIdentity, bool) Method
Gets the last name claim, if present.  
```csharp
public static string LastName(this System.Security.Claims.ClaimsIdentity self, bool trimStringQualifiers=true);
```
#### Parameters
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_LastName(System_Security_Claims_ClaimsIdentity_bool)_self'></a>
`self` [System.Security.Claims.ClaimsIdentity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsIdentity 'System.Security.Claims.ClaimsIdentity')  
The extended [System.Security.Claims.ClaimsIdentity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsIdentity 'System.Security.Claims.ClaimsIdentity') instance.  
  
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_LastName(System_Security_Claims_ClaimsIdentity_bool)_trimStringQualifiers'></a>
`trimStringQualifiers` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br />  
Specifies whether to trim the claim from any string qualifiers.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The last name claim when supported.  
