#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakAuthConfig Class
Provides a code API to the main Tetra Pak section in the configuration.    
```csharp
public class TetraPakAuthConfig : TetraPak.Configuration.ConfigurationSection,
TetraPak.AspNet.Auth.IServiceAuthConfig
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') &#129106; TetraPakAuthConfig  

Implements [IServiceAuthConfig](TetraPak_AspNet_Auth_IServiceAuthConfig.md 'TetraPak.AspNet.Auth.IServiceAuthConfig')  
### Constructors
<a name='TetraPak_AspNet_TetraPakAuthConfig_TetraPakAuthConfig(System_IServiceProvider)'></a>
## TetraPakAuthConfig.TetraPakAuthConfig(IServiceProvider) Constructor
Initializes a Tetra Pak authorization configuration instance.   
```csharp
public TetraPakAuthConfig(System.IServiceProvider serviceProvider);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_TetraPakAuthConfig(System_IServiceProvider)_serviceProvider'></a>
`serviceProvider` [System.IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/System.IServiceProvider 'System.IServiceProvider')  
A service locator.  
  
  
### Properties
<a name='TetraPak_AspNet_TetraPakAuthConfig_AmbientData'></a>
## TetraPakAuthConfig.AmbientData Property
Gets an [AmbientData](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_AmbientData 'TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData') object.  
```csharp
public TetraPak.AspNet.AmbientData AmbientData { get; }
```
#### Property Value
[AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')

Implements [AmbientData](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_AmbientData 'TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_AuthDomain'></a>
## TetraPakAuthConfig.AuthDomain Property
Gets the domain element of the authority URI.  
```csharp
public string AuthDomain { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_AuthorityUrl'></a>
## TetraPakAuthConfig.AuthorityUrl Property
Gets the resource locator for the authority.  
```csharp
public string? AuthorityUrl { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_AuthorizationHeader'></a>
## TetraPakAuthConfig.AuthorizationHeader Property
Gets or sets the name of the header used to obtain the token to be used for authorizing the actor.  
The default value is [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization')).  
```csharp
public string AuthorizationHeader { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
An invalid/empty value was assigned.  
#### See Also
- [IsCustomAuthorizationHeader](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_IsCustomAuthorizationHeader 'TetraPak.AspNet.TetraPakAuthConfig.IsCustomAuthorizationHeader')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_Cache'></a>
## TetraPakAuthConfig.Cache Property
Gets a time limited repository to be used for caching (if available).  
```csharp
public TetraPak.Caching.ITimeLimitedRepositories? Cache { get; }
```
#### Property Value
[TetraPak.Caching.ITimeLimitedRepositories](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Caching.ITimeLimitedRepositories 'TetraPak.Caching.ITimeLimitedRepositories')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_Caching'></a>
## TetraPakAuthConfig.Caching Property
Configuration section specifying caching strategies.   
```csharp
public TetraPak.Caching.SimpleCacheConfig Caching { get; }
```
#### Property Value
[TetraPak.Caching.SimpleCacheConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Caching.SimpleCacheConfig 'TetraPak.Caching.SimpleCacheConfig')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_CallbackPath'></a>
## TetraPakAuthConfig.CallbackPath Property
Gets a configured callback path, or the default one ([TetraPak.AspNet.TetraPakAuthConfig.DefaultCallbackPath](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakAuthConfig.DefaultCallbackPath 'TetraPak.AspNet.TetraPakAuthConfig.DefaultCallbackPath')).    
```csharp
public string? CallbackPath { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_ClientId'></a>
## TetraPakAuthConfig.ClientId Property
Gets a configured client id at this configuration level.  
```csharp
public virtual string ClientId { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_ClientSecret'></a>
## TetraPakAuthConfig.ClientSecret Property
Gets a configured client secret at this configuration level.  
```csharp
public virtual string? ClientSecret { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
#### See Also
- [GetClientSecretAsync(AuthContext, Nullable&lt;CancellationToken&gt;)](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.TetraPakAuthConfig.GetClientSecretAsync(TetraPak.AspNet.AuthContext, System.Nullable&lt;System.Threading.CancellationToken&gt;)')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_ConfigDelegate'></a>
## TetraPakAuthConfig.ConfigDelegate Property
Gets a configuration delegate.  
```csharp
protected TetraPak.AspNet.ITetraPakAuthConfigDelegate? ConfigDelegate { get; }
```
#### Property Value
[ITetraPakAuthConfigDelegate](TetraPak_AspNet_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.ITetraPakAuthConfigDelegate')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_Configuration'></a>
## TetraPakAuthConfig.Configuration Property
Gets the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') used to populate this object.  
```csharp
public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
```
#### Property Value
[Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')

Implements [Configuration](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_Configuration 'TetraPak.AspNet.Auth.IServiceAuthConfig.Configuration')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_DefaultCachingLifetime'></a>
## TetraPakAuthConfig.DefaultCachingLifetime Property
Gets or sets a [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan') value specifying the default lifetime of cached auth data.  
This value is only consumed by the auth framework when [IsCachingAllowed](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_IsCachingAllowed 'TetraPak.AspNet.TetraPakAuthConfig.IsCachingAllowed') is set.   
```csharp
public System.TimeSpan DefaultCachingLifetime { get; set; }
```
#### Property Value
[System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')
#### See Also
- [IsCachingAllowed](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_IsCachingAllowed 'TetraPak.AspNet.TetraPakAuthConfig.IsCachingAllowed')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_DefaultSectionIdentifier'></a>
## TetraPakAuthConfig.DefaultSectionIdentifier Property
The default root configuration section name for Tetra Pak configuration.   
```csharp
public static string DefaultSectionIdentifier { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_DiscoveryDocumentUrl'></a>
## TetraPakAuthConfig.DiscoveryDocumentUrl Property
Gets the resource locator for the well-known OIDC discovery document.  
```csharp
public string DiscoveryDocumentUrl { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_EnableDiagnostics'></a>
## TetraPakAuthConfig.EnableDiagnostics Property
Gets or sets a value specifying whether to enable service diagnostics.  
```csharp
public bool EnableDiagnostics { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_Environment'></a>
## TetraPakAuthConfig.Environment Property
Gets the current runtime environment (DEV, TEST, PROD ...).  
The value is a [TetraPak.AspNet.TetraPakAuthConfig.resolveRuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakAuthConfig.resolveRuntimeEnvironment 'TetraPak.AspNet.TetraPakAuthConfig.resolveRuntimeEnvironment') enum value.   
```csharp
public TetraPak.RuntimeEnvironment Environment { get; }
```
#### Property Value
[TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_GrantType'></a>
## TetraPakAuthConfig.GrantType Property
Specifies the grant type (a.k.a. OAuth "flow") used at this configuration level.  
```csharp
public virtual TetraPak.AspNet.Auth.GrantType GrantType { get; set; }
```
#### Property Value
[GrantType](TetraPak_AspNet_Auth_GrantType.md 'TetraPak.AspNet.Auth.GrantType')
#### Exceptions
[ConfigurationException](TetraPak_AspNet_ConfigurationException.md 'TetraPak.AspNet.ConfigurationException')  
The configured (textual) value could not be parsed into a [GrantType](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_GrantType 'TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType') (enum) value.   

Implements [GrantType](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_GrantType 'TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_IdentitySource'></a>
## TetraPakAuthConfig.IdentitySource Property
Specifies the source for identity claims (see [TetraPakIdentitySource](TetraPak_AspNet_Auth_TetraPakIdentitySource.md 'TetraPak.AspNet.Auth.TetraPakIdentitySource')),  
such as [RemoteService](TetraPak_AspNet_Auth_TetraPakIdentitySource.md#TetraPak_AspNet_Auth_TetraPakIdentitySource_RemoteService 'TetraPak.AspNet.Auth.TetraPakIdentitySource.RemoteService') or [IdToken](TetraPak_AspNet_Auth_TetraPakIdentitySource.md#TetraPak_AspNet_Auth_TetraPakIdentitySource_IdToken 'TetraPak.AspNet.Auth.TetraPakIdentitySource.IdToken')).  
```csharp
public TetraPak.AspNet.Auth.TetraPakIdentitySource IdentitySource { get; set; }
```
#### Property Value
[TetraPakIdentitySource](TetraPak_AspNet_Auth_TetraPakIdentitySource.md 'TetraPak.AspNet.Auth.TetraPakIdentitySource')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_IdentityTokenHeader'></a>
## TetraPakAuthConfig.IdentityTokenHeader Property
Gets or sets the name of the header used to obtain the token to be used for authorizing the actor.  
The default value is [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization')).  
```csharp
public string? IdentityTokenHeader { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
An invalid/empty value was assigned.  
#### See Also
- [IsCustomAuthorizationHeader](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_IsCustomAuthorizationHeader 'TetraPak.AspNet.TetraPakAuthConfig.IsCustomAuthorizationHeader')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_IsAuthDomainAssigned'></a>
## TetraPakAuthConfig.IsAuthDomainAssigned Property
Indicates whether the authority domain has been assigned (intended mainly for testing purposes).  
```csharp
internal bool IsAuthDomainAssigned { get; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_IsCachingAllowed'></a>
## TetraPakAuthConfig.IsCachingAllowed Property
Gets or sets a [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean') value specifying whether auth data (such as tokens or identity)  
can be automatically cached.  
```csharp
public bool IsCachingAllowed { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
#### See Also
- [DefaultCachingLifetime](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_DefaultCachingLifetime 'TetraPak.AspNet.TetraPakAuthConfig.DefaultCachingLifetime')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_IsCustomAuthorizationHeader'></a>
## TetraPakAuthConfig.IsCustomAuthorizationHeader Property
Gets a value indicating whether the configured authorization header is a custom one  
(default is [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization')).  
```csharp
public bool IsCustomAuthorizationHeader { get; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
#### See Also
- [AuthorizationHeader](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_AuthorizationHeader 'TetraPak.AspNet.TetraPakAuthConfig.AuthorizationHeader')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_IsDevelopment'></a>
## TetraPakAuthConfig.IsDevelopment Property
Gets a value indicating whether the host is run in a development environment.    
```csharp
public static bool IsDevelopment { get; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_IsMessageIdEnabled'></a>
## TetraPakAuthConfig.IsMessageIdEnabled Property
Gets or sets a value to enable/disable the automatic use of a unique id to track  
a specific request/response. This value is `true` by default.  
```csharp
public bool IsMessageIdEnabled { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Remarks
<a href="https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/blob/master/README.md#message-id">  
              You can read more about the message id concept here.  
              </a>
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_IsPkceUsed'></a>
## TetraPakAuthConfig.IsPkceUsed Property
Gets or sets a value specifying whether PKCE is to be used where applicable.  
```csharp
public bool IsPkceUsed { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_JwtBearerAssertion'></a>
## TetraPakAuthConfig.JwtBearerAssertion Property
Gets configuration for how to validate JWT tokens.    
```csharp
public TetraPak.AspNet.Auth.JwtBearerAssertionConfig JwtBearerAssertion { get; }
```
#### Property Value
[JwtBearerAssertionConfig](TetraPak_AspNet_Auth_JwtBearerAssertionConfig.md 'TetraPak.AspNet.Auth.JwtBearerAssertionConfig')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_ParentConfig'></a>
## TetraPakAuthConfig.ParentConfig Property
Gets a declaring configuration (when this configuration is a sub configuration).  
```csharp
public TetraPak.AspNet.Auth.IServiceAuthConfig ParentConfig { get; }
```
#### Property Value
[IServiceAuthConfig](TetraPak_AspNet_Auth_IServiceAuthConfig.md 'TetraPak.AspNet.Auth.IServiceAuthConfig')

Implements [ParentConfig](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_ParentConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig.ParentConfig')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_RefreshThreshold'></a>
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
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_RequestMessageIdHeader'></a>
## TetraPakAuthConfig.RequestMessageIdHeader Property
Gets or sets the name of the header used to obtain the request message id.  
The default value is [RequestMessageId](TetraPak_AspNet_AmbientData_Keys.md#TetraPak_AspNet_AmbientData_Keys_RequestMessageId 'TetraPak.AspNet.AmbientData.Keys.RequestMessageId')).  
```csharp
public string? RequestMessageIdHeader { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
An invalid/empty value was assigned.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_RuntimeEnvironment'></a>
## TetraPakAuthConfig.RuntimeEnvironment Property
Gets the current runtime environment name.  
```csharp
public static string RuntimeEnvironment { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_Scope'></a>
## TetraPakAuthConfig.Scope Property
Gets or sets a scope of identity claims, a this configuration level,  
to be requested while authenticating the identity. When omitted a default scope will be used.   
```csharp
public TetraPak.MultiStringValue Scope { get; set; }
```
#### Property Value
[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')
#### See Also
- [GetScopeAsync(AuthContext, MultiStringValue?, Nullable&lt;CancellationToken&gt;)](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.TetraPakAuthConfig.GetScopeAsync(TetraPak.AspNet.AuthContext, TetraPak.MultiStringValue?, System.Nullable&lt;System.Threading.CancellationToken&gt;)')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_TokenIssuerUrl'></a>
## TetraPakAuthConfig.TokenIssuerUrl Property
Gets the resource locator for the token issuer endpoint.    
```csharp
public string TokenIssuerUrl { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_UserInformationUrl'></a>
## TetraPakAuthConfig.UserInformationUrl Property
Gets the resource locator for the user information query endpoint.   
```csharp
public string UserInformationUrl { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
### Methods
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetAuthorityUrlAsync()'></a>
## TetraPakAuthConfig.GetAuthorityUrlAsync() Method
An alternative method of getting the authority URL from the discovery document, allowing for  
the document to be refreshed online.  
```csharp
public System.Threading.Tasks.Task<string?> GetAuthorityUrlAsync();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The authority resource locator.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakAuthConfig.GetClientIdAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client id.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<string>> GetClientIdAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetClientIdAsync(AuthContext, Nullable<CancellationToken>)](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientIdAsync(TetraPak.AspNet.AuthContext, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakAuthConfig.GetClientSecretAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client secret.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<string>> GetClientSecretAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetClientSecretAsync(AuthContext, Nullable<CancellationToken>)](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientSecretAsync(TetraPak.AspNet.AuthContext, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetConfiguredValue(string)'></a>
## TetraPakAuthConfig.GetConfiguredValue(string) Method
Gets a "raw" configured value, as it is specified within the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') sources,  
unaffected by delegates or other internal types of logic.  
```csharp
public string? GetConfiguredValue(string key);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetConfiguredValue(string)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the requested value.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') when a value is configured; otherwise `null`.  

Implements [GetConfiguredValue(string)](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_GetConfiguredValue(string) 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetConfiguredValue(string)')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetDiscoveryDocumentAsync()'></a>
## TetraPakAuthConfig.GetDiscoveryDocumentAsync() Method
Gets the "well known" OIDC discovery document. The document will be downloaded and cached as needed.    
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.OpenIdConnect.DiscoveryDocument>> GetDiscoveryDocumentAsync();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument').  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakAuthConfig.GetScopeAsync(AuthContext, MultiStringValue?, Nullable&lt;CancellationToken&gt;) Method
Gets a scope to be requested for authorization while, optionally, specifying a default scope.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> GetScopeAsync(TetraPak.AspNet.AuthContext authContext, TetraPak.MultiStringValue? useDefault=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_useDefault'></a>
`useDefault` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
(optional)<br/>  
Specifies a default value to be returned if scope cannot be resolved.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetScopeAsync(AuthContext, MultiStringValue?, Nullable<CancellationToken>)](TetraPak_AspNet_Auth_IServiceAuthConfig.md#TetraPak_AspNet_Auth_IServiceAuthConfig_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetScopeAsync(TetraPak.AspNet.AuthContext, TetraPak.MultiStringValue?, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetTokenIssuerUrlAsync()'></a>
## TetraPakAuthConfig.GetTokenIssuerUrlAsync() Method
An alternative method of getting the token issuer endpoint URL from the discovery document, allowing for  
the document to be refreshed online.  
```csharp
public System.Threading.Tasks.Task<string?> GetTokenIssuerUrlAsync();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The token issuer endpoint resource locator.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_GetUserInformationUrlAsync()'></a>
## TetraPakAuthConfig.GetUserInformationUrlAsync() Method
An alternative method of getting the user information URL from the discovery document, allowing for  
the document to be refreshed online.  
```csharp
public System.Threading.Tasks.Task<string?> GetUserInformationUrlAsync();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The user information resource locator.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_OnGetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakAuthConfig.OnGetClientIdAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client id.  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<string>> OnGetClientIdAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_OnGetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_OnGetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Enables operation cancellation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_OnGetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakAuthConfig.OnGetClientSecretAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client secret.  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<string>> OnGetClientSecretAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_OnGetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_OnGetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Enables operation cancellation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_OnGetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakAuthConfig.OnGetScopeAsync(AuthContext, MultiStringValue?, Nullable&lt;CancellationToken&gt;) Method
Gets a auth scope.  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> OnGetScopeAsync(TetraPak.AspNet.AuthContext authContext, TetraPak.MultiStringValue? useDefault=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_OnGetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_OnGetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_useDefault'></a>
`useDefault` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
(optional)<br/>  
Specifies a default value to be returned if scope cannot be resolved.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_OnGetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_OnResolveRuntimeEnvironment(string)'></a>
## TetraPakAuthConfig.OnResolveRuntimeEnvironment(string) Method
Invoked from ctor to resolve the runtime environment.  
```csharp
protected virtual TetraPak.RuntimeEnvironment OnResolveRuntimeEnvironment(string configuredValue);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_OnResolveRuntimeEnvironment(string)_configuredValue'></a>
`configuredValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The configured [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value to be resolved.  
  
#### Returns
[TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment')  
A resolved [TetraPak.RuntimeEnvironment](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.RuntimeEnvironment 'TetraPak.RuntimeEnvironment') value.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_ParseEnum_TEnum_(string_TEnum)'></a>
## TetraPakAuthConfig.ParseEnum&lt;TEnum&gt;(string, TEnum) Method
Parses a configured [System.Enum](https://docs.microsoft.com/en-us/dotnet/api/System.Enum 'System.Enum') value and returns the result.  
```csharp
public static TEnum ParseEnum<TEnum>(string stringValue, TEnum useDefault=default(TEnum))
    where TEnum : struct;
```
#### Type parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_ParseEnum_TEnum_(string_TEnum)_TEnum'></a>
`TEnum`  
The ([System.Enum](https://docs.microsoft.com/en-us/dotnet/api/System.Enum 'System.Enum')) value to be expected.  
  
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_ParseEnum_TEnum_(string_TEnum)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value found in the configuration.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_ParseEnum_TEnum_(string_TEnum)_useDefault'></a>
`useDefault` [TEnum](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_ParseEnum_TEnum_(string_TEnum)_TEnum 'TetraPak.AspNet.TetraPakAuthConfig.ParseEnum&lt;TEnum&gt;(string, TEnum).TEnum')  
A default value to be used when [stringValue](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_ParseEnum_TEnum_(string_TEnum)_stringValue 'TetraPak.AspNet.TetraPakAuthConfig.ParseEnum&lt;TEnum&gt;(string, TEnum).stringValue') is unassigned  
or cannot be successfully parsed.   
  
#### Returns
[TEnum](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_ParseEnum_TEnum_(string_TEnum)_TEnum 'TetraPak.AspNet.TetraPakAuthConfig.ParseEnum&lt;TEnum&gt;(string, TEnum).TEnum')  
The [System.Enum](https://docs.microsoft.com/en-us/dotnet/api/System.Enum 'System.Enum') value represented by the [stringValue](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_ParseEnum_TEnum_(string_TEnum)_stringValue 'TetraPak.AspNet.TetraPakAuthConfig.ParseEnum&lt;TEnum&gt;(string, TEnum).stringValue'),  
or [useDefault](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_ParseEnum_TEnum_(string_TEnum)_useDefault 'TetraPak.AspNet.TetraPakAuthConfig.ParseEnum&lt;TEnum&gt;(string, TEnum).useDefault') if [stringValue](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_ParseEnum_TEnum_(string_TEnum)_stringValue 'TetraPak.AspNet.TetraPakAuthConfig.ParseEnum&lt;TEnum&gt;(string, TEnum).stringValue') was unassigned or  
could not be successfully parsed.   
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum)'></a>
## TetraPakAuthConfig.TryParseEnum&lt;TEnum&gt;(string, TEnum) Method
Converts the string representation of the name or numeric value of one or more enumerated constants  
to an equivalent enumerated object. The return value indicates whether the conversion succeeded.  
```csharp
public static bool TryParseEnum<TEnum>(string stringValue, out TEnum value)
    where TEnum : struct;
```
#### Type parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum)_TEnum'></a>
`TEnum`  
The enumeration type to which to convert value.  
  
#### Parameters
<a name='TetraPak_AspNet_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The case-insensitive string representation of the enumeration name or underlying value to convert.  
  
<a name='TetraPak_AspNet_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum)_value'></a>
`value` [TEnum](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum)_TEnum 'TetraPak.AspNet.TetraPakAuthConfig.TryParseEnum&lt;TEnum&gt;(string, TEnum).TEnum')  
When this method returns, result contains an object of type [TEnum](TetraPak_AspNet_TetraPakAuthConfig.md#TetraPak_AspNet_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum)_TEnum 'TetraPak.AspNet.TetraPakAuthConfig.TryParseEnum&lt;TEnum&gt;(string, TEnum).TEnum') whose  
value is represented by value if the parse operation succeeds.  
If the parse operation fails, result contains the default value of the underlying type of TEnum.  
Note that this value need not be a member of the TEnum enumeration.  
This parameter is passed uninitialized.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the value parameter was converted successfully; otherwise, `false`.  
            
  
#### See Also
- [ITetraPakAuthConfigDelegate](TetraPak_AspNet_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.ITetraPakAuthConfigDelegate')
