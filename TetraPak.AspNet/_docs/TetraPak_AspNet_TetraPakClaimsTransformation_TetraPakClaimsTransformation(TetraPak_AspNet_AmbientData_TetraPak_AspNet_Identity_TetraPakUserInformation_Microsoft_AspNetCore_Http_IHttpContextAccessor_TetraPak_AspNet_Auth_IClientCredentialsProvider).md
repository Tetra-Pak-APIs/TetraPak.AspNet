#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[TetraPakClaimsTransformation](TetraPak_AspNet_TetraPakClaimsTransformation.md 'TetraPak.AspNet.TetraPakClaimsTransformation')
## TetraPakClaimsTransformation.TetraPakClaimsTransformation(AmbientData, TetraPakUserInformation, IHttpContextAccessor, IClientCredentialsProvider) Constructor
Initializes the [TetraPakClaimsTransformation](TetraPak_AspNet_TetraPakClaimsTransformation.md 'TetraPak.AspNet.TetraPakClaimsTransformation') instance.  
```csharp
public TetraPakClaimsTransformation(TetraPak.AspNet.AmbientData ambientData, TetraPak.AspNet.Identity.TetraPakUserInformation userInformation, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, TetraPak.AspNet.Auth.IClientCredentialsProvider clientCredentialsProvider=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_TetraPakClaimsTransformation(TetraPak_AspNet_AmbientData_TetraPak_AspNet_Identity_TetraPakUserInformation_Microsoft_AspNetCore_Http_IHttpContextAccessor_TetraPak_AspNet_Auth_IClientCredentialsProvider)_ambientData'></a>
`ambientData` [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')  
Initializes the [AmbientData](TetraPak_AspNet_TetraPakClaimsTransformation_AmbientData.md 'TetraPak.AspNet.TetraPakClaimsTransformation.AmbientData') property.  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_TetraPakClaimsTransformation(TetraPak_AspNet_AmbientData_TetraPak_AspNet_Identity_TetraPakUserInformation_Microsoft_AspNetCore_Http_IHttpContextAccessor_TetraPak_AspNet_Auth_IClientCredentialsProvider)_userInformation'></a>
`userInformation` [TetraPakUserInformation](TetraPak_AspNet_Identity_TetraPakUserInformation.md 'TetraPak.AspNet.Identity.TetraPakUserInformation')  
Used internally to obtain user information.  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_TetraPakClaimsTransformation(TetraPak_AspNet_AmbientData_TetraPak_AspNet_Identity_TetraPakUserInformation_Microsoft_AspNetCore_Http_IHttpContextAccessor_TetraPak_AspNet_Auth_IClientCredentialsProvider)_httpContextAccessor'></a>
`httpContextAccessor` [Microsoft.AspNetCore.Http.IHttpContextAccessor](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.IHttpContextAccessor 'Microsoft.AspNetCore.Http.IHttpContextAccessor')  
Used internally to get access to the current [HttpContext](TetraPak_AspNet_TetraPakClaimsTransformation_HttpContext.md 'TetraPak.AspNet.TetraPakClaimsTransformation.HttpContext') object.  
  
<a name='TetraPak_AspNet_TetraPakClaimsTransformation_TetraPakClaimsTransformation(TetraPak_AspNet_AmbientData_TetraPak_AspNet_Identity_TetraPakUserInformation_Microsoft_AspNetCore_Http_IHttpContextAccessor_TetraPak_AspNet_Auth_IClientCredentialsProvider)_clientCredentialsProvider'></a>
`clientCredentialsProvider` [TetraPak.AspNet.Auth.IClientCredentialsProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IClientCredentialsProvider 'TetraPak.AspNet.Auth.IClientCredentialsProvider')  
Used internally to obtain client credentials.  
  
