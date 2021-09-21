#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## TokenRefreshResponse Class
Used to present the result from a token refresh flow response.  
```csharp
public class TokenRefreshResponse
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TokenRefreshResponse  
### Properties
<a name='TetraPak_AspNet_Auth_TokenRefreshResponse_AccessToken'></a>
## TokenRefreshResponse.AccessToken Property
Gets the new access token.  
```csharp
public string AccessToken { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Auth_TokenRefreshResponse_ExpiresInSeconds'></a>
## TokenRefreshResponse.ExpiresInSeconds Property
Gets a value indicating the new access token's lifespan.  
```csharp
public System.Nullable<int> ExpiresInSeconds { get; set; }
```
#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
  
<a name='TetraPak_AspNet_Auth_TokenRefreshResponse_IdToken'></a>
## TokenRefreshResponse.IdToken Property
Gets a provided identity token, if available.  
```csharp
public string IdToken { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Auth_TokenRefreshResponse_RefreshToken'></a>
## TokenRefreshResponse.RefreshToken Property
Gets a new refresh token, if available.  
```csharp
public string RefreshToken { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
