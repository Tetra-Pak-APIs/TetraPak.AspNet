#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ITetraPakClaimsTransformation Interface
Classes implementing this code contract can be used as (custom) "claims transformers".    
```csharp
public interface ITetraPakClaimsTransformation
```

Derived  
&#8627; [ClaimsTransformationFactory](TetraPak_AspNet_ClaimsTransformationFactory.md 'TetraPak.AspNet.ClaimsTransformationFactory')  
&#8627; [TetraPakClaimsTransformation](TetraPak_AspNet_TetraPakClaimsTransformation.md 'TetraPak.AspNet.TetraPakClaimsTransformation')  
### Methods
<a name='TetraPak_AspNet_ITetraPakClaimsTransformation_TransformAsync(System_Security_Claims_ClaimsPrincipal_System_Nullable_System_Threading_CancellationToken_)'></a>
## ITetraPakClaimsTransformation.TransformAsync(ClaimsPrincipal, Nullable&lt;CancellationToken&gt;) Method
Provides a central transformation point to change the specified principal.   
```csharp
System.Threading.Tasks.Task<System.Security.Claims.ClaimsPrincipal> TransformAsync(System.Security.Claims.ClaimsPrincipal principal, System.Nullable<System.Threading.CancellationToken> cancellationToken);
```
#### Parameters
<a name='TetraPak_AspNet_ITetraPakClaimsTransformation_TransformAsync(System_Security_Claims_ClaimsPrincipal_System_Nullable_System_Threading_CancellationToken_)_principal'></a>
`principal` [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal')  
The [System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') to transform.  
  
<a name='TetraPak_AspNet_ITetraPakClaimsTransformation_TransformAsync(System_Security_Claims_ClaimsPrincipal_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
Allows cancelling the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Security.Claims.ClaimsPrincipal](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The transformed principal.  
  
#### See Also
- [AddTetraPakCustomClaimsTransformation&lt;T&gt;(IServiceCollection, Nullable&lt;ServiceScope&gt;)](TetraPak_AspNet_TetraPakClaimsTransformationHelper.md#TetraPak_AspNet_TetraPakClaimsTransformationHelper_AddTetraPakCustomClaimsTransformation_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Nullable_TetraPak_AspNet_ServiceScope_) 'TetraPak.AspNet.TetraPakClaimsTransformationHelper.AddTetraPakCustomClaimsTransformation&lt;T&gt;(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Nullable&lt;TetraPak.AspNet.ServiceScope&gt;)')
