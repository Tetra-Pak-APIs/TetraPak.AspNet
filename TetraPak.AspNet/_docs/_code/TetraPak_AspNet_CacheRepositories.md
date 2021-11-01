#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## CacheRepositories Class
Provides identifiers for supported caches as well as convenient methods  
for working with caching.  
```csharp
public static class CacheRepositories
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CacheRepositories  
### Fields
<a name='TetraPak_AspNet_CacheRepositories_ClaimsPrincipals'></a>
## CacheRepositories.ClaimsPrincipals Field
Identifies the cache used for claims principals.  
```csharp
public const string ClaimsPrincipals = ClaimsPrincipals;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
### Methods
<a name='TetraPak_AspNet_CacheRepositories_AddTetraPakCaching(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## CacheRepositories.AddTetraPakCaching(IServiceCollection) Method
Adds support for Tetra Pak (configurable) caching.  
This implementation relies on the [TetraPak.Caching.SimpleCache](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Caching.SimpleCache 'TetraPak.Caching.SimpleCache') but you can provide a custom caching  
service by instead calling the [AddTetraPakCaching&lt;T&gt;(IServiceCollection, Func&lt;IServiceProvider,T&gt;)](TetraPak_AspNet_CacheRepositories.md#TetraPak_AspNet_CacheRepositories_AddTetraPakCaching_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_T_) 'TetraPak.AspNet.CacheRepositories.AddTetraPakCaching&lt;T&gt;(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func&lt;System.IServiceProvider,T&gt;)') method.    
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakCaching(this Microsoft.Extensions.DependencyInjection.IServiceCollection services);
```
#### Parameters
<a name='TetraPak_AspNet_CacheRepositories_AddTetraPakCaching(Microsoft_Extensions_DependencyInjection_IServiceCollection)_services'></a>
`services` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
#### See Also
- [AddTetraPakCaching&lt;T&gt;(IServiceCollection, Func&lt;IServiceProvider,T&gt;)](TetraPak_AspNet_CacheRepositories.md#TetraPak_AspNet_CacheRepositories_AddTetraPakCaching_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_T_) 'TetraPak.AspNet.CacheRepositories.AddTetraPakCaching&lt;T&gt;(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func&lt;System.IServiceProvider,T&gt;)')
  
<a name='TetraPak_AspNet_CacheRepositories_AddTetraPakCaching_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_T_)'></a>
## CacheRepositories.AddTetraPakCaching&lt;T&gt;(IServiceCollection, Func&lt;IServiceProvider,T&gt;) Method
Adds support for Tetra Pak (configurable) caching while specifying a caching implementation type.  
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakCaching<T>(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Func<System.IServiceProvider,T> factory)
    where T : class, TetraPak.Caching.ITimeLimitedRepositories;
```
#### Type parameters
<a name='TetraPak_AspNet_CacheRepositories_AddTetraPakCaching_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_T_)_T'></a>
`T`  
A type that implements the [TetraPak.Caching.ITimeLimitedRepositories](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Caching.ITimeLimitedRepositories 'TetraPak.Caching.ITimeLimitedRepositories') interface.   
  
#### Parameters
<a name='TetraPak_AspNet_CacheRepositories_AddTetraPakCaching_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_T_)_services'></a>
`services` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
<a name='TetraPak_AspNet_CacheRepositories_AddTetraPakCaching_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_T_)_factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/System.IServiceProvider 'System.IServiceProvider')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](TetraPak_AspNet_CacheRepositories.md#TetraPak_AspNet_CacheRepositories_AddTetraPakCaching_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_T_)_T 'TetraPak.AspNet.CacheRepositories.AddTetraPakCaching&lt;T&gt;(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func&lt;System.IServiceProvider,T&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
#### See Also
- [AddTetraPakCaching&lt;T&gt;(IServiceCollection, Func&lt;IServiceProvider,T&gt;)](TetraPak_AspNet_CacheRepositories.md#TetraPak_AspNet_CacheRepositories_AddTetraPakCaching_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_T_) 'TetraPak.AspNet.CacheRepositories.AddTetraPakCaching&lt;T&gt;(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func&lt;System.IServiceProvider,T&gt;)')
  
