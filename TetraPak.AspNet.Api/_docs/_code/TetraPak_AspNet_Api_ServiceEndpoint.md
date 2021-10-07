#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## ServiceEndpoint Class
```csharp
public class ServiceEndpoint :
TetraPak.IStringValue,
TetraPak.AspNet.Auth.IServiceAuthConfig,
TetraPak.AspNet.Auth.IAccessTokenProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ServiceEndpoint  

Derived  
&#8627; [ServiceInvalidEndpoint](TetraPak_AspNet_Api_ServiceInvalidEndpoint.md 'TetraPak.AspNet.Api.ServiceInvalidEndpoint')  

Implements [TetraPak.IStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.IStringValue 'TetraPak.IStringValue'), [TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig'), [TetraPak.AspNet.Auth.IAccessTokenProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IAccessTokenProvider 'TetraPak.AspNet.Auth.IAccessTokenProvider')  
### Constructors
<a name='TetraPak_AspNet_Api_ServiceEndpoint_ServiceEndpoint(string)'></a>
## ServiceEndpoint.ServiceEndpoint(string) Constructor
Initializes the value.  
```csharp
public ServiceEndpoint(string stringValue);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_ServiceEndpoint(string)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The new value's string representation (will automatically be parsed).  
  
#### Exceptions
[System.FormatException](https://docs.microsoft.com/en-us/dotnet/api/System.FormatException 'System.FormatException')  
The [stringValue](TetraPak_AspNet_Api_ServiceEndpoint.md#TetraPak_AspNet_Api_ServiceEndpoint_ServiceEndpoint(string)_stringValue 'TetraPak.AspNet.Api.ServiceEndpoint.ServiceEndpoint(string).stringValue') string representation was incorrectly formed.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_ServiceEndpoint(TetraPak_AspNet_AmbientData)'></a>
## ServiceEndpoint.ServiceEndpoint(AmbientData) Constructor
Initializes an [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')
```csharp
protected ServiceEndpoint(TetraPak.AspNet.AmbientData ambientData);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_ServiceEndpoint(TetraPak_AspNet_AmbientData)_ambientData'></a>
`ambientData` [TetraPak.AspNet.AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AmbientData 'TetraPak.AspNet.AmbientData')  
Provides ambient data and configuration.  
  
  
### Properties
<a name='TetraPak_AspNet_Api_ServiceEndpoint_AmbientData'></a>
## ServiceEndpoint.AmbientData Property
Gets an object to provide access to ambient data.  
```csharp
public TetraPak.AspNet.AmbientData AmbientData { get; set; }
```
#### Property Value
[TetraPak.AspNet.AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AmbientData 'TetraPak.AspNet.AmbientData')

Implements [AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData 'TetraPak.AspNet.Auth.IServiceAuthConfig.AmbientData')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_ConfigPath'></a>
## ServiceEndpoint.ConfigPath Property
Gets the configuration path.  
```csharp
public TetraPak.Configuration.ConfigPath? ConfigPath { get; }
```
#### Property Value
[TetraPak.Configuration.ConfigPath](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigPath 'TetraPak.Configuration.ConfigPath')

Implements [ConfigPath](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.ConfigPath 'TetraPak.AspNet.Auth.IServiceAuthConfig.ConfigPath')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GrantType'></a>
## ServiceEndpoint.GrantType Property
Specifies the grant type (a.k.a. OAuth "flow") used at this configuration level.  
```csharp
public TetraPak.AspNet.Auth.GrantType GrantType { get; set; }
```
#### Property Value
[TetraPak.AspNet.Auth.GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.GrantType 'TetraPak.AspNet.Auth.GrantType')
#### Exceptions
[TetraPak.AspNet.ConfigurationException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.ConfigurationException 'TetraPak.AspNet.ConfigurationException')  
The configured (textual) value could not be parsed into a [TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType 'TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType') (enum) value.   

Implements [GrantType](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType 'TetraPak.AspNet.Auth.IServiceAuthConfig.GrantType')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_HttpContext'></a>
## ServiceEndpoint.HttpContext Property
Gets the current [HttpContext](TetraPak_AspNet_Api_ServiceEndpoint.md#TetraPak_AspNet_Api_ServiceEndpoint_HttpContext 'TetraPak.AspNet.Api.ServiceEndpoint.HttpContext') instance.  
```csharp
public Microsoft.AspNetCore.Http.HttpContext HttpContext { get; }
```
#### Property Value
[Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_Logger'></a>
## ServiceEndpoint.Logger Property
Gets a logging provider.  
```csharp
public Microsoft.Extensions.Logging.ILogger Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_Name'></a>
## ServiceEndpoint.Name Property
Gets the name of the service endpoint URL (as specified in the configuration).  
```csharp
public string Name { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_Parent'></a>
## ServiceEndpoint.Parent Property
Gets the service declaring the endpoint (a [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') object).  
```csharp
protected TetraPak.AspNet.Api.ServiceEndpoints? Parent { get; set; }
```
#### Property Value
[ServiceEndpoints](TetraPak_AspNet_Api_ServiceEndpoints.md 'TetraPak.AspNet.Api.ServiceEndpoints')
  
### Methods
<a name='TetraPak_AspNet_Api_ServiceEndpoint_Equals(object_)'></a>
## ServiceEndpoint.Equals(object?) Method
Determines whether the specified object is equal to the current version.  
```csharp
public override bool Equals(object? obj);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_Equals(object_)_obj'></a>
`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
An object to compare to this value.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the specified object is equal to the current version; otherwise `false`.  
            
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_Equals(TetraPak_AspNet_Api_ServiceEndpoint_)'></a>
## ServiceEndpoint.Equals(ServiceEndpoint?) Method
Determines whether the specified value is equal to the current value.  
```csharp
public bool Equals(TetraPak.AspNet.Api.ServiceEndpoint? other);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_Equals(TetraPak_AspNet_Api_ServiceEndpoint_)_other'></a>
`other` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
A [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') value to compare to this value.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [other](TetraPak_AspNet_Api_ServiceEndpoint.md#TetraPak_AspNet_Api_ServiceEndpoint_Equals(TetraPak_AspNet_Api_ServiceEndpoint_)_other 'TetraPak.AspNet.Api.ServiceEndpoint.Equals(TetraPak.AspNet.Api.ServiceEndpoint?).other') is equal to the current value; otherwise `false`.  
            
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetAccessTokenAsync(bool)'></a>
## ServiceEndpoint.GetAccessTokenAsync(bool) Method
Gets an access token from the request context.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(bool forceStandardHeader=false);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetAccessTokenAsync(bool)_forceStandardHeader'></a>
`forceStandardHeader` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set the configured (see [TetraPak.AspNet.TetraPakConfig.AuthorizationHeader](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig.AuthorizationHeader 'TetraPak.AspNet.TetraPakConfig.AuthorizationHeader')) authorization  
header is ignored in favour of the HTTP standard [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization') header.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetAccessTokenAsync(bool)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IAccessTokenProvider.GetAccessTokenAsync#TetraPak_AspNet_Auth_IAccessTokenProvider_GetAccessTokenAsync_System_Boolean_ 'TetraPak.AspNet.Auth.IAccessTokenProvider.GetAccessTokenAsync(System.Boolean)')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpoint.GetClientIdAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client id.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<string>> GetClientIdAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetClientIdAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetClientIdAsync(AuthContext, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientIdAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientIdAsync_TetraPak_AspNet_AuthContext,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientIdAsync(TetraPak.AspNet.AuthContext,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpoint.GetClientSecretAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a client secret.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<string>> GetClientSecretAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetClientSecretAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetClientSecretAsync(AuthContext, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientSecretAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetClientSecretAsync_TetraPak_AspNet_AuthContext,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetClientSecretAsync(TetraPak.AspNet.AuthContext,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetHashCode()'></a>
## ServiceEndpoint.GetHashCode() Method
Serves as the default hash function.  
```csharp
public override int GetHashCode();
```
#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current value.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)'></a>
## ServiceEndpoint.GetScopeAsync(AuthContext, MultiStringValue?, Nullable&lt;CancellationToken&gt;) Method
Gets a scope to be requested for authorization while, optionally, specifying a default scope.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> GetScopeAsync(TetraPak.AspNet.AuthContext authContext, TetraPak.MultiStringValue? useDefault=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_useDefault'></a>
`useDefault` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
(optional)<br/>  
Specifies a default value to be returned if scope cannot be resolved.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_GetScopeAsync(TetraPak_AspNet_AuthContext_TetraPak_MultiStringValue__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetScopeAsync(AuthContext, MultiStringValue?, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetScopeAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetScopeAsync_TetraPak_AspNet_AuthContext,TetraPak_MultiStringValue,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetScopeAsync(TetraPak.AspNet.AuthContext,TetraPak.MultiStringValue,System.Nullable{System.Threading.CancellationToken})')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_IsAuthIdentifier(string)'></a>
## ServiceEndpoint.IsAuthIdentifier(string) Method
Examines a string and returns a value to indicate whether the value identifies  
an attribute used for auth configuration. This is to ensure there is no risk of confusing  
services or endpoints with such attributes.   
```csharp
public bool IsAuthIdentifier(string identifier);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_IsAuthIdentifier(string)_identifier'></a>
`identifier` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The identifier being examined.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [identifier](TetraPak_AspNet_Api_ServiceEndpoint.md#TetraPak_AspNet_Api_ServiceEndpoint_IsAuthIdentifier(string)_identifier 'TetraPak.AspNet.Api.ServiceEndpoint.IsAuthIdentifier(string).identifier') matches an auth configuration attribute; otherwise `false`.   
            

Implements [IsAuthIdentifier(string)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.IsAuthIdentifier#TetraPak_AspNet_Auth_IServiceAuthConfig_IsAuthIdentifier_System_String_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.IsAuthIdentifier(System.String)')  
### Remarks
Examples of auth identifiers: "`ConfigPath`", "`GrantType`",  
"`ClientId`", "`ClientSecret`", "`Scope`".  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_ToString()'></a>
## ServiceEndpoint.ToString() Method
Returns a string that represents the current object.
```csharp
public override string? ToString();
```
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A string that represents the current object.
  
### Operators
<a name='TetraPak_AspNet_Api_ServiceEndpoint_op_Equality(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_Api_ServiceEndpoint_)'></a>
## ServiceEndpoint.operator ==(ServiceEndpoint, ServiceEndpoint?) Operator
Comparison operator overload.  
```csharp
public static bool operator ==(TetraPak.AspNet.Api.ServiceEndpoint left, TetraPak.AspNet.Api.ServiceEndpoint? right);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_op_Equality(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_Api_ServiceEndpoint_)_left'></a>
`left` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_op_Equality(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_Api_ServiceEndpoint_)_right'></a>
`right` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_op_Implicitstring_(TetraPak_AspNet_Api_ServiceEndpoint_)'></a>
## ServiceEndpoint.implicit operator string?(ServiceEndpoint?) Operator
Implicitly converts a [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') value into its [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') representation.  
```csharp
public static string? implicit operator string?(TetraPak.AspNet.Api.ServiceEndpoint? value);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_op_Implicitstring_(TetraPak_AspNet_Api_ServiceEndpoint_)_value'></a>
`value` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
A [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') value to be implicitly converted into its [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') representation.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') representation of [value](TetraPak_AspNet_Api_ServiceEndpoint.md#TetraPak_AspNet_Api_ServiceEndpoint_op_Implicitstring_(TetraPak_AspNet_Api_ServiceEndpoint_)_value 'TetraPak.AspNet.Api.ServiceEndpoint.op_Implicit string?(TetraPak.AspNet.Api.ServiceEndpoint?).value').  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_op_ImplicitTetraPak_AspNet_Api_ServiceEndpoint(string)'></a>
## ServiceEndpoint.implicit operator ServiceEndpoint(string) Operator
Implicitly converts a string literal into a [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint').  
```csharp
public static TetraPak.AspNet.Api.ServiceEndpoint implicit operator ServiceEndpoint(string stringValue);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_op_ImplicitTetraPak_AspNet_Api_ServiceEndpoint(string)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A string representation of the [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') value.  
  
#### Returns
[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
A [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') value.  
#### Exceptions
[System.FormatException](https://docs.microsoft.com/en-us/dotnet/api/System.FormatException 'System.FormatException')  
The [stringValue](TetraPak_AspNet_Api_ServiceEndpoint.md#TetraPak_AspNet_Api_ServiceEndpoint_op_ImplicitTetraPak_AspNet_Api_ServiceEndpoint(string)_stringValue 'TetraPak.AspNet.Api.ServiceEndpoint.op_Implicit TetraPak.AspNet.Api.ServiceEndpoint(string).stringValue') string representation was incorrectly formed.  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_op_Inequality(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_Api_ServiceEndpoint_)'></a>
## ServiceEndpoint.operator !=(ServiceEndpoint, ServiceEndpoint?) Operator
Comparison operator overload.  
```csharp
public static bool operator !=(TetraPak.AspNet.Api.ServiceEndpoint left, TetraPak.AspNet.Api.ServiceEndpoint? right);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceEndpoint_op_Inequality(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_Api_ServiceEndpoint_)_left'></a>
`left` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
  
<a name='TetraPak_AspNet_Api_ServiceEndpoint_op_Inequality(TetraPak_AspNet_Api_ServiceEndpoint_TetraPak_AspNet_Api_ServiceEndpoint_)_right'></a>
`right` [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
