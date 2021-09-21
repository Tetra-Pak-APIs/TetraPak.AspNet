#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ClaimsIdentityExtensions Class
Convenient extension methods for obtaining typical claims from a [System.Security.Claims.ClaimsIdentity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsIdentity 'System.Security.Claims.ClaimsIdentity') value.  
```csharp
public static class ClaimsIdentityExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ClaimsIdentityExtensions  
### Methods
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_Email(System_Security_Claims_ClaimsIdentity_bool)'></a>
## ClaimsIdentityExtensions.Email(ClaimsIdentity, bool) Method
Gets the email claim, if present.  
```csharp
public static string Email(this System.Security.Claims.ClaimsIdentity self, bool trimStringQualifiers=true);
```
#### Parameters
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_Email(System_Security_Claims_ClaimsIdentity_bool)_self'></a>
`self` [System.Security.Claims.ClaimsIdentity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsIdentity 'System.Security.Claims.ClaimsIdentity')  
The extended [System.Security.Claims.ClaimsIdentity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsIdentity 'System.Security.Claims.ClaimsIdentity').  
  
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_Email(System_Security_Claims_ClaimsIdentity_bool)_trimStringQualifiers'></a>
`trimStringQualifiers` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to trim the claim from any string qualifiers.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The email claim when supported.  
  
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_FirstName(System_Security_Claims_ClaimsIdentity_bool)'></a>
## ClaimsIdentityExtensions.FirstName(ClaimsIdentity, bool) Method
Gets the first name claim, if present.  
```csharp
public static string? FirstName(this System.Security.Claims.ClaimsIdentity self, bool trimStringQualifiers=true);
```
#### Parameters
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_FirstName(System_Security_Claims_ClaimsIdentity_bool)_self'></a>
`self` [System.Security.Claims.ClaimsIdentity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsIdentity 'System.Security.Claims.ClaimsIdentity')  
The extended [System.Security.Claims.ClaimsIdentity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsIdentity 'System.Security.Claims.ClaimsIdentity') instance.  
  
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_FirstName(System_Security_Claims_ClaimsIdentity_bool)_trimStringQualifiers'></a>
`trimStringQualifiers` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to trim the claim from any string qualifiers.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The first name claim when supported.  
  
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_FirstName(System_Security_Claims_ClaimsPrincipal_bool)'></a>
## ClaimsIdentityExtensions.FirstName(ClaimsPrincipal, bool) Method
Gets the first name claim, if present.  
```csharp
public static string? FirstName(this System.Security.Claims.ClaimsPrincipal self, bool trimStringQualifiers=true);
```
#### Parameters
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_FirstName(System_Security_Claims_ClaimsPrincipal_bool)_self'></a>
`self` [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal')  
The extended [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal').  
  
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_FirstName(System_Security_Claims_ClaimsPrincipal_bool)_trimStringQualifiers'></a>
`trimStringQualifiers` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to trim the claim from any string qualifiers.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The first name claim when supported.  
  
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_LastName(System_Security_Claims_ClaimsIdentity_bool)'></a>
## ClaimsIdentityExtensions.LastName(ClaimsIdentity, bool) Method
Gets the last name claim, if present.  
```csharp
public static string? LastName(this System.Security.Claims.ClaimsIdentity self, bool trimStringQualifiers=true);
```
#### Parameters
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_LastName(System_Security_Claims_ClaimsIdentity_bool)_self'></a>
`self` [System.Security.Claims.ClaimsIdentity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsIdentity 'System.Security.Claims.ClaimsIdentity')  
The extended [System.Security.Claims.ClaimsIdentity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsIdentity 'System.Security.Claims.ClaimsIdentity').  
  
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_LastName(System_Security_Claims_ClaimsIdentity_bool)_trimStringQualifiers'></a>
`trimStringQualifiers` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to trim the claim from any string qualifiers.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The last name claim when supported.  
  
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_LastName(System_Security_Claims_ClaimsPrincipal_bool)'></a>
## ClaimsIdentityExtensions.LastName(ClaimsPrincipal, bool) Method
Gets the last name claim, if present.  
```csharp
public static string? LastName(this System.Security.Claims.ClaimsPrincipal self, bool trimStringQualifiers=true);
```
#### Parameters
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_LastName(System_Security_Claims_ClaimsPrincipal_bool)_self'></a>
`self` [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal')  
The extended [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal').  
  
<a name='TetraPak_AspNet_ClaimsIdentityExtensions_LastName(System_Security_Claims_ClaimsPrincipal_bool)_trimStringQualifiers'></a>
`trimStringQualifiers` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to trim the claim from any string qualifiers.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The last name claim when supported.  
  
