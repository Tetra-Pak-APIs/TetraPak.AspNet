#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakConfigHelper Class
Provides convenient helper methods for Tetra Pak configuration scenarios.   
```csharp
public static class TetraPakConfigHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakConfigHelper  
### Methods
<a name='TetraPak_AspNet_TetraPakConfigHelper_AddTetraPakConfigDelegate_TDelegate_(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakConfigHelper.AddTetraPakConfigDelegate&lt;TDelegate&gt;(IServiceCollection) Method
Configures a custom configuration delegate, to be used by [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig').   
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakConfigDelegate<TDelegate>(this Microsoft.Extensions.DependencyInjection.IServiceCollection self)
    where TDelegate : class, TetraPak.AspNet.ITetraPakConfigDelegate;
```
#### Type parameters
<a name='TetraPak_AspNet_TetraPakConfigHelper_AddTetraPakConfigDelegate_TDelegate_(Microsoft_Extensions_DependencyInjection_IServiceCollection)_TDelegate'></a>
`TDelegate`  
The delegate type (must be a reference type that implements [ITetraPakConfigDelegate](TetraPak_AspNet_ITetraPakConfigDelegate.md 'TetraPak.AspNet.ITetraPakConfigDelegate')).  
  
#### Parameters
<a name='TetraPak_AspNet_TetraPakConfigHelper_AddTetraPakConfigDelegate_TDelegate_(Microsoft_Extensions_DependencyInjection_IServiceCollection)_self'></a>
`self` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
<a name='TetraPak_AspNet_TetraPakConfigHelper_AddTetraPakConfiguration_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakConfigHelper.AddTetraPakConfiguration&lt;T&gt;(IServiceCollection) Method
Adds a specific implementation for the Tetra Pak configuration API as a (DI) service.   
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakConfiguration<T>(this Microsoft.Extensions.DependencyInjection.IServiceCollection c)
    where T : TetraPak.AspNet.TetraPakConfig;
```
#### Type parameters
<a name='TetraPak_AspNet_TetraPakConfigHelper_AddTetraPakConfiguration_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection)_T'></a>
`T`  
The type implementing the Tetra Pak integration configuration code API  
(must derive from [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')).    
  
#### Parameters
<a name='TetraPak_AspNet_TetraPakConfigHelper_AddTetraPakConfiguration_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection)_c'></a>
`c` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The service collection.  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The service collection.  
  
<a name='TetraPak_AspNet_TetraPakConfigHelper_AddTetraPakConfiguration(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakConfigHelper.AddTetraPakConfiguration(IServiceCollection) Method
Adds the Tetra Pak configuration code API as a (DI) service.   
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakConfiguration(this Microsoft.Extensions.DependencyInjection.IServiceCollection c);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakConfigHelper_AddTetraPakConfiguration(Microsoft_Extensions_DependencyInjection_IServiceCollection)_c'></a>
`c` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The service collection.  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The service collection.  
  
<a name='TetraPak_AspNet_TetraPakConfigHelper_UseTetraPakDiagnostics(Microsoft_AspNetCore_Builder_IApplicationBuilder)'></a>
## TetraPakConfigHelper.UseTetraPakDiagnostics(IApplicationBuilder) Method
Enabled various types of diagnostics features, such as timers and trackable message ids.  
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseTetraPakDiagnostics(this Microsoft.AspNetCore.Builder.IApplicationBuilder app);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakConfigHelper_UseTetraPakDiagnostics(Microsoft_AspNetCore_Builder_IApplicationBuilder)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') object.  
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') object.  
  
<a name='TetraPak_AspNet_TetraPakConfigHelper_UseTetraPakMessageId(Microsoft_AspNetCore_Builder_IApplicationBuilder)'></a>
## TetraPakConfigHelper.UseTetraPakMessageId(IApplicationBuilder) Method
Enforces the use of a message id for all request/response round trips.  
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseTetraPakMessageId(this Microsoft.AspNetCore.Builder.IApplicationBuilder app);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakConfigHelper_UseTetraPakMessageId(Microsoft_AspNetCore_Builder_IApplicationBuilder)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
  
