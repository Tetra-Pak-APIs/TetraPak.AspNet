#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## AmbientData Class
Provides ambient data to an ASP.NET Core/5+ project throughout a request/response roundtrip.  
```csharp
public class AmbientData :
TetraPak.AspNet.IMessageIdProvider,
TetraPak.AspNet.Auth.IAccessTokenProvider,
TetraPak.AspNet.Auth.IIdentityTokenProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AmbientData  

Implements [IMessageIdProvider](TetraPak_AspNet_IMessageIdProvider.md 'TetraPak.AspNet.IMessageIdProvider'), [IAccessTokenProvider](TetraPak_AspNet_Auth_IAccessTokenProvider.md 'TetraPak.AspNet.Auth.IAccessTokenProvider'), [IIdentityTokenProvider](TetraPak_AspNet_Auth_IIdentityTokenProvider.md 'TetraPak.AspNet.Auth.IIdentityTokenProvider')  
### Constructors
<a name='TetraPak_AspNet_AmbientData_AmbientData(TetraPak_AspNet_TetraPakConfig_Microsoft_AspNetCore_Http_IHttpContextAccessor)'></a>
## AmbientData.AmbientData(TetraPakConfig, IHttpContextAccessor) Constructor
Initializes the [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData') instance.  
```csharp
public AmbientData(TetraPak.AspNet.TetraPakConfig config, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor);
```
#### Parameters
<a name='TetraPak_AspNet_AmbientData_AmbientData(TetraPak_AspNet_TetraPakConfig_Microsoft_AspNetCore_Http_IHttpContextAccessor)_config'></a>
`config` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
The Tetra Pak auth configuration.  
  
<a name='TetraPak_AspNet_AmbientData_AmbientData(TetraPak_AspNet_TetraPakConfig_Microsoft_AspNetCore_Http_IHttpContextAccessor)_httpContextAccessor'></a>
`httpContextAccessor` [Microsoft.AspNetCore.Http.IHttpContextAccessor](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.IHttpContextAccessor 'Microsoft.AspNetCore.Http.IHttpContextAccessor')  
A [Microsoft.AspNetCore.Http.IHttpContextAccessor](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.IHttpContextAccessor 'Microsoft.AspNetCore.Http.IHttpContextAccessor') that is required for many of the ambient data operations.  
  
  
### Properties
<a name='TetraPak_AspNet_AmbientData_Config'></a>
## AmbientData.Config Property
Gets an auth config value.   
```csharp
public TetraPak.AspNet.TetraPakConfig Config { get; }
```
#### Property Value
[TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')
  
<a name='TetraPak_AspNet_AmbientData_HttpContext'></a>
## AmbientData.HttpContext Property
Gets the current [HttpContext](TetraPak_AspNet_AmbientData.md#TetraPak_AspNet_AmbientData_HttpContext 'TetraPak.AspNet.AmbientData.HttpContext') instance.  
```csharp
public Microsoft.AspNetCore.Http.HttpContext? HttpContext { get; }
```
#### Property Value
[Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')
  
<a name='TetraPak_AspNet_AmbientData_Logger'></a>
## AmbientData.Logger Property
Gets a logging provider.  
```csharp
public Microsoft.Extensions.Logging.ILogger? Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
<a name='TetraPak_AspNet_AmbientData_this_string_'></a>
## AmbientData.this[string] Property
Indexer to get or set an ambient value.  
```csharp
public object? this[string key] { get; set; }
```
#### Parameters
<a name='TetraPak_AspNet_AmbientData_this_string__key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the value.  
  
#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')
  
### Methods
<a name='TetraPak_AspNet_AmbientData_GetAccessTokenAsync(bool)'></a>
## AmbientData.GetAccessTokenAsync(bool) Method
Gets an access token from the request context.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetAccessTokenAsync(bool forceStandardHeader=false);
```
#### Parameters
<a name='TetraPak_AspNet_AmbientData_GetAccessTokenAsync(bool)_forceStandardHeader'></a>
`forceStandardHeader` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set the configured (see [AuthorizationHeader](TetraPak_AspNet_TetraPakConfig.md#TetraPak_AspNet_TetraPakConfig_AuthorizationHeader 'TetraPak.AspNet.TetraPakConfig.AuthorizationHeader')) authorization  
header is ignored in favour of the HTTP standard [Microsoft.Net.Http.Headers.HeaderNames.Authorization](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Net.Http.Headers.HeaderNames.Authorization 'Microsoft.Net.Http.Headers.HeaderNames.Authorization') header.   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetAccessTokenAsync(bool)](TetraPak_AspNet_Auth_IAccessTokenProvider.md#TetraPak_AspNet_Auth_IAccessTokenProvider_GetAccessTokenAsync(bool) 'TetraPak.AspNet.Auth.IAccessTokenProvider.GetAccessTokenAsync(bool)')  
  
<a name='TetraPak_AspNet_AmbientData_GetIdTokenAsync()'></a>
## AmbientData.GetIdTokenAsync() Method
Gets an identity token from the request context.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> GetIdTokenAsync();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetIdTokenAsync()](TetraPak_AspNet_Auth_IIdentityTokenProvider.md#TetraPak_AspNet_Auth_IIdentityTokenProvider_GetIdTokenAsync() 'TetraPak.AspNet.Auth.IIdentityTokenProvider.GetIdTokenAsync()')  
  
<a name='TetraPak_AspNet_AmbientData_GetMessageId(bool)'></a>
## AmbientData.GetMessageId(bool) Method
Retrieves a request message id if available.   
```csharp
public string? GetMessageId(bool enforce=false);
```
#### Parameters
<a name='TetraPak_AspNet_AmbientData_GetMessageId(bool)_enforce'></a>
`enforce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set a message id will be generated and injected into the request/response context.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value if a message id was available (or enforced); otherwise `null`.  

Implements [GetMessageId(bool)](TetraPak_AspNet_IMessageIdProvider.md#TetraPak_AspNet_IMessageIdProvider_GetMessageId(bool) 'TetraPak.AspNet.IMessageIdProvider.GetMessageId(bool)')  
  
<a name='TetraPak_AspNet_AmbientData_GetValue(string_object)'></a>
## AmbientData.GetValue(string, object) Method
Gets an ambient value.  
```csharp
public object GetValue(string key, object useDefault=null);
```
#### Parameters
<a name='TetraPak_AspNet_AmbientData_GetValue(string_object)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the value.  
  
<a name='TetraPak_AspNet_AmbientData_GetValue(string_object)_useDefault'></a>
`useDefault` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
(optional)<br/>  
A default value to be returned if the requested ambient value is not supported.    
  
#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The requested value if present; otherwise [useDefault](TetraPak_AspNet_AmbientData.md#TetraPak_AspNet_AmbientData_GetValue(string_object)_useDefault 'TetraPak.AspNet.AmbientData.GetValue(string, object).useDefault') when specified,  
otherwise `null`.  
  
<a name='TetraPak_AspNet_AmbientData_GetValue_T_(string_T)'></a>
## AmbientData.GetValue&lt;T&gt;(string, T) Method
Gets an ambient value of a specified type.  
```csharp
public T GetValue<T>(string key, T useDefault=default(T));
```
#### Type parameters
<a name='TetraPak_AspNet_AmbientData_GetValue_T_(string_T)_T'></a>
`T`  
The type of value being requested.  
  
#### Parameters
<a name='TetraPak_AspNet_AmbientData_GetValue_T_(string_T)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the value.  
  
<a name='TetraPak_AspNet_AmbientData_GetValue_T_(string_T)_useDefault'></a>
`useDefault` [T](TetraPak_AspNet_AmbientData.md#TetraPak_AspNet_AmbientData_GetValue_T_(string_T)_T 'TetraPak.AspNet.AmbientData.GetValue&lt;T&gt;(string, T).T')  
(optional)<br/>  
A default value to be returned if the requested ambient value is not supported.    
  
#### Returns
[T](TetraPak_AspNet_AmbientData.md#TetraPak_AspNet_AmbientData_GetValue_T_(string_T)_T 'TetraPak.AspNet.AmbientData.GetValue&lt;T&gt;(string, T).T')  
The requested value if present; otherwise [useDefault](TetraPak_AspNet_AmbientData.md#TetraPak_AspNet_AmbientData_GetValue_T_(string_T)_useDefault 'TetraPak.AspNet.AmbientData.GetValue&lt;T&gt;(string, T).useDefault') when specified,  
otherwise `default(T)`.  
  
<a name='TetraPak_AspNet_AmbientData_IsApiEndpoint()'></a>
## AmbientData.IsApiEndpoint() Method
Returns a value indicating whether the routed endpoint is an API endpoint (not a view).  
```csharp
public bool IsApiEndpoint();
```
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
<a name='TetraPak_AspNet_AmbientData_SetValue(string_object_)'></a>
## AmbientData.SetValue(string, object?) Method
Sets an ambient value.  
```csharp
public void SetValue(string key, object? value);
```
#### Parameters
<a name='TetraPak_AspNet_AmbientData_SetValue(string_object_)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the value to be added.  
  
<a name='TetraPak_AspNet_AmbientData_SetValue(string_object_)_value'></a>
`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The value to be added.  
  
  
