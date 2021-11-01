#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Controllers](TetraPak_AspNet_Api_Controllers.md 'TetraPak.AspNet.Api.Controllers')
## HttpOkResponsePolicyHelper Class
Adds a convenient extension method for registering a custom [IHttpOkResponsePolicy](TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy.md 'TetraPak.AspNet.Api.Controllers.IHttpOkResponsePolicy').  
```csharp
public static class HttpOkResponsePolicyHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpOkResponsePolicyHelper  
### Methods
<a name='TetraPak_AspNet_Api_Controllers_HttpOkResponsePolicyHelper_AddHttpOkResponsePolicy(Microsoft_Extensions_DependencyInjection_IServiceCollection_TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy)'></a>
## HttpOkResponsePolicyHelper.AddHttpOkResponsePolicy(IServiceCollection, IHttpOkResponsePolicy) Method
Adds a custom [IHttpOkResponsePolicy](TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy.md 'TetraPak.AspNet.Api.Controllers.IHttpOkResponsePolicy'), to be used when automatically resolving a  
successful response HTTP status code.  
Pass `null` to restore the default resolution policy.   
```csharp
public static void AddHttpOkResponsePolicy(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection, TetraPak.AspNet.Api.Controllers.IHttpOkResponsePolicy resolver);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_HttpOkResponsePolicyHelper_AddHttpOkResponsePolicy(Microsoft_Extensions_DependencyInjection_IServiceCollection_TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy)_collection'></a>
`collection` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The DI service collection.  
  
<a name='TetraPak_AspNet_Api_Controllers_HttpOkResponsePolicyHelper_AddHttpOkResponsePolicy(Microsoft_Extensions_DependencyInjection_IServiceCollection_TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy)_resolver'></a>
`resolver` [IHttpOkResponsePolicy](TetraPak_AspNet_Api_Controllers_IHttpOkResponsePolicy.md 'TetraPak.AspNet.Api.Controllers.IHttpOkResponsePolicy')  
The custom HTTP status code resolver.  
Pass `null` to restore the default resolution policy.  
  
#### See Also
- [Auto](TetraPak_AspNet_Api_Controllers_HttpOkStatusCode.md#TetraPak_AspNet_Api_Controllers_HttpOkStatusCode_Auto 'TetraPak.AspNet.Api.Controllers.HttpOkStatusCode.Auto')
  
