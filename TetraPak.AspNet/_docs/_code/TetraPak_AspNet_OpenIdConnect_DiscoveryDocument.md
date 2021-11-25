#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.OpenIdConnect](TetraPak_AspNet_OpenIdConnect.md 'TetraPak.AspNet.OpenIdConnect')
## DiscoveryDocument Class
Represents the important parts of an OIDC discovery document  
(see: https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata).  
```csharp
public class DiscoveryDocument
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DiscoveryDocument  
### Fields
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_DefaultAuthorizationPath'></a>
## DiscoveryDocument.DefaultAuthorizationPath Field
The default authority endpoint for a well known open id discovery document (a.k.a 'metadata document').    
```csharp
public const string DefaultAuthorizationPath = /oauth2/authorize;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_DefaultJwksPath'></a>
## DiscoveryDocument.DefaultJwksPath Field
The default JWT keys endpoint for a well known open id discovery document (a.k.a 'metadata document').    
```csharp
public const string DefaultJwksPath = /jwks;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_DefaultPath'></a>
## DiscoveryDocument.DefaultPath Field
The default path for a well known open id discovery document (a.k.a 'metadata document').  
```csharp
public const string DefaultPath = /.well-known/openid-configuration;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_DefaultTokenPath'></a>
## DiscoveryDocument.DefaultTokenPath Field
The default token issuer endpoint for a well known open id discovery document (a.k.a 'metadata document').    
```csharp
public const string DefaultTokenPath = /oauth2/token;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_DefaultUserInfoPath'></a>
## DiscoveryDocument.DefaultUserInfoPath Field
The default user information endpoint for a well known open id discovery document (a.k.a 'metadata document').    
```csharp
public const string DefaultUserInfoPath = /idp/userinfo;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
### Properties
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_AuthorizationEndpoint'></a>
## DiscoveryDocument.AuthorizationEndpoint Property
Gets or sets the authority endpoint.  
```csharp
public string AuthorizationEndpoint { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_GrantTypesSupported'></a>
## DiscoveryDocument.GrantTypesSupported Property
Gets or sets the supported grant types.  
```csharp
public System.Collections.Generic.IEnumerable<string> GrantTypesSupported { get; set; }
```
#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_IdTokenSigningAlgValuesSupported'></a>
## DiscoveryDocument.IdTokenSigningAlgValuesSupported Property
Gets or sets a collection of hashing algorithms supported.  
```csharp
public System.Collections.Generic.IEnumerable<string> IdTokenSigningAlgValuesSupported { get; set; }
```
#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_Issuer'></a>
## DiscoveryDocument.Issuer Property
Gets or sets the token issuer URL.  
```csharp
public string Issuer { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_JwksUri'></a>
## DiscoveryDocument.JwksUri Property
Gets or sets the JWT keys endpoint.  
```csharp
public string JwksUri { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_ReadPolicy'></a>
## DiscoveryDocument.ReadPolicy Property
Gets or sets a behavior for how to load the discovery document.  
The value is a "flag" [System.Enum](https://docs.microsoft.com/en-us/dotnet/api/System.Enum 'System.Enum') value, allowing for fallbacks if one policy fails.  
```csharp
public static TetraPak.AspNet.OpenIdConnect.ReadDocumentPolicy ReadPolicy { get; set; }
```
#### Property Value
[ReadDocumentPolicy](TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy.md 'TetraPak.AspNet.OpenIdConnect.ReadDocumentPolicy')
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Attempt to set value to [Configured](TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy.md#TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy_Configured 'TetraPak.AspNet.OpenIdConnect.ReadDocumentPolicy.Configured') (this property _is_ the configured  
value and, therefore, cannot itself be set to this value).   
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_ResponseTypesSupported'></a>
## DiscoveryDocument.ResponseTypesSupported Property
Gets or sets the supported types of responses.  
```csharp
public System.Collections.Generic.IEnumerable<string> ResponseTypesSupported { get; set; }
```
#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_ScopesSupported'></a>
## DiscoveryDocument.ScopesSupported Property
Gets or sets the supported scope.  
```csharp
public System.Collections.Generic.IEnumerable<string> ScopesSupported { get; set; }
```
#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_SubjectTypesSupported'></a>
## DiscoveryDocument.SubjectTypesSupported Property
Gets or sets the supported types subject types.  
```csharp
public System.Collections.Generic.IEnumerable<string> SubjectTypesSupported { get; set; }
```
#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_TokenEndpoint'></a>
## DiscoveryDocument.TokenEndpoint Property
Gets or sets the token issuer endpoint.  
```csharp
public string TokenEndpoint { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_UserInformationEndpoint'></a>
## DiscoveryDocument.UserInformationEndpoint Property
Gets or sets the user information endpoint.  
```csharp
public string UserInformationEndpoint { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
### Methods
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_GetDefault(string_string_string_string_string)'></a>
## DiscoveryDocument.GetDefault(string, string, string, string, string) Method
Creates and returns a default [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument').  
```csharp
public static TetraPak.AspNet.OpenIdConnect.DiscoveryDocument GetDefault(string issuer, string supportedResponseType="code", string supportedSubjectTypes="openid, profile, email, groups, domain", string supportedGrantTypes="authorization_code, refresh_token, urn:ietf:params:oauth:grant-type:token-exchange", string supportedIdTokenSigningAlgValues="RS256");
```
#### Parameters
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_GetDefault(string_string_string_string_string)_issuer'></a>
`issuer` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Initializes the token issuer endpoint (URL).     
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_GetDefault(string_string_string_string_string)_supportedResponseType'></a>
`supportedResponseType` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Initializes the [ResponseTypesSupported](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md#TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_ResponseTypesSupported 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument.ResponseTypesSupported') property.  
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_GetDefault(string_string_string_string_string)_supportedSubjectTypes'></a>
`supportedSubjectTypes` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Initializes the [SubjectTypesSupported](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md#TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_SubjectTypesSupported 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument.SubjectTypesSupported') property.  
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_GetDefault(string_string_string_string_string)_supportedGrantTypes'></a>
`supportedGrantTypes` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Initializes the [GrantTypesSupported](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md#TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_GrantTypesSupported 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument.GrantTypesSupported') property.  
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_GetDefault(string_string_string_string_string)_supportedIdTokenSigningAlgValues'></a>
`supportedIdTokenSigningAlgValues` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Initializes the [IdTokenSigningAlgValuesSupported](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md#TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_IdTokenSigningAlgValuesSupported 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument.IdTokenSigningAlgValuesSupported') property.  
  
#### Returns
[DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument')  
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_GetDefault(TetraPak_AspNet_TetraPakConfig)'></a>
## DiscoveryDocument.GetDefault(TetraPakConfig) Method
Creates and returns a default [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument').  
```csharp
public static TetraPak.AspNet.OpenIdConnect.DiscoveryDocument GetDefault(TetraPak.AspNet.TetraPakConfig config);
```
#### Parameters
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_GetDefault(TetraPak_AspNet_TetraPakConfig)_config'></a>
`config` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
The Tetra Pak integration configuration.  
  
#### Returns
[DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument')  
A [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument') object.  
  
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_ReadAsync(TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs)'></a>
## DiscoveryDocument.ReadAsync(ReadDiscoveryDocumentArgs) Method
Loads and returns the [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument'), as per the requested behavior.   
```csharp
public static System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.OpenIdConnect.DiscoveryDocument>> ReadAsync(TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs args);
```
#### Parameters
<a name='TetraPak_AspNet_OpenIdConnect_DiscoveryDocument_ReadAsync(TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs)_args'></a>
`args` [ReadDiscoveryDocumentArgs](TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs.md 'TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs')  
Specifies behavior for reading the [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument').  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Required configuration was not provided; such as [MasterSourceUrl](TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs.md#TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_MasterSourceUrl 'TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs.MasterSourceUrl')  
or [TetraPakConfig](TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs.md#TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_TetraPakConfig 'TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs.TetraPakConfig').  
#### See Also
- [ReadDocumentPolicy](TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy.md 'TetraPak.AspNet.OpenIdConnect.ReadDocumentPolicy')
  
