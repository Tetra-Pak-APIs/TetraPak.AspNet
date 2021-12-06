#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.DevelopmentTools](TetraPak_AspNet_Api_DevelopmentTools.md 'TetraPak.AspNet.Api.DevelopmentTools')
## WebHostEnvironmentHelper Class
Provides helper method for examining the web hosting environment.   
```csharp
public static class WebHostEnvironmentHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WebHostEnvironmentHelper  
### Methods
<a name='TetraPak_AspNet_Api_DevelopmentTools_WebHostEnvironmentHelper_IsLocalHost(Microsoft_AspNetCore_Hosting_IWebHostEnvironment_System_Func_System_Uri_bool_)'></a>
## WebHostEnvironmentHelper.IsLocalHost(IWebHostEnvironment, Func&lt;Uri,bool&gt;) Method
Examines the bound host(s) and returns a value indicating whether they represent  
a local host (eg: https://localhost[:port]).  
```csharp
public static bool IsLocalHost(this Microsoft.AspNetCore.Hosting.IWebHostEnvironment self, System.Func<System.Uri,bool> criteria);
```
#### Parameters
<a name='TetraPak_AspNet_Api_DevelopmentTools_WebHostEnvironmentHelper_IsLocalHost(Microsoft_AspNetCore_Hosting_IWebHostEnvironment_System_Func_System_Uri_bool_)_self'></a>
`self` [Microsoft.AspNetCore.Hosting.IWebHostEnvironment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Hosting.IWebHostEnvironment 'Microsoft.AspNetCore.Hosting.IWebHostEnvironment')  
The hosting environment.  
  
<a name='TetraPak_AspNet_Api_DevelopmentTools_WebHostEnvironmentHelper_IsLocalHost(Microsoft_AspNetCore_Hosting_IWebHostEnvironment_System_Func_System_Uri_bool_)_criteria'></a>
`criteria` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
A callback method that gets interrogated for all bound host URLs. If the method returns  
a `false` value the bound hosts are not considered "local".   
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if all bound host URLs are considered "local"; otherwise `false`.  
            
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[criteria](TetraPak_AspNet_Api_DevelopmentTools_WebHostEnvironmentHelper.md#TetraPak_AspNet_Api_DevelopmentTools_WebHostEnvironmentHelper_IsLocalHost(Microsoft_AspNetCore_Hosting_IWebHostEnvironment_System_Func_System_Uri_bool_)_criteria 'TetraPak.AspNet.Api.DevelopmentTools.WebHostEnvironmentHelper.IsLocalHost(Microsoft.AspNetCore.Hosting.IWebHostEnvironment, System.Func&lt;System.Uri,bool&gt;).criteria') was unassigned (`null`).  
            
  
<a name='TetraPak_AspNet_Api_DevelopmentTools_WebHostEnvironmentHelper_IsLocalHost(Microsoft_AspNetCore_Hosting_IWebHostEnvironment_TetraPak_CollectionMatchingPolicy_Microsoft_Extensions_Logging_ILogger_)'></a>
## WebHostEnvironmentHelper.IsLocalHost(IWebHostEnvironment, CollectionMatchingPolicy, ILogger?) Method
Examines the bound host(s) and returns a value indicating whether they represent  
a local host (eg: https://localhost[:port]).  
```csharp
public static bool IsLocalHost(this Microsoft.AspNetCore.Hosting.IWebHostEnvironment self, TetraPak.CollectionMatchingPolicy policy=TetraPak.CollectionMatchingPolicy.All, Microsoft.Extensions.Logging.ILogger? logger=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_DevelopmentTools_WebHostEnvironmentHelper_IsLocalHost(Microsoft_AspNetCore_Hosting_IWebHostEnvironment_TetraPak_CollectionMatchingPolicy_Microsoft_Extensions_Logging_ILogger_)_self'></a>
`self` [Microsoft.AspNetCore.Hosting.IWebHostEnvironment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Hosting.IWebHostEnvironment 'Microsoft.AspNetCore.Hosting.IWebHostEnvironment')  
The hosting environment.  
  
<a name='TetraPak_AspNet_Api_DevelopmentTools_WebHostEnvironmentHelper_IsLocalHost(Microsoft_AspNetCore_Hosting_IWebHostEnvironment_TetraPak_CollectionMatchingPolicy_Microsoft_Extensions_Logging_ILogger_)_policy'></a>
`policy` [TetraPak.CollectionMatchingPolicy](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.CollectionMatchingPolicy 'TetraPak.CollectionMatchingPolicy')  
(optional; default=[TetraPak.CollectionMatchingPolicy.All](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.CollectionMatchingPolicy.All 'TetraPak.CollectionMatchingPolicy.All'))  
Specifies how to resolve the result (see remarks).  
  
<a name='TetraPak_AspNet_Api_DevelopmentTools_WebHostEnvironmentHelper_IsLocalHost(Microsoft_AspNetCore_Hosting_IWebHostEnvironment_TetraPak_CollectionMatchingPolicy_Microsoft_Extensions_Logging_ILogger_)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
(optional)<br/>  
A logger provider. When passed the method will log its operation.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
The result depends on the specified [policy](TetraPak_AspNet_Api_DevelopmentTools_WebHostEnvironmentHelper.md#TetraPak_AspNet_Api_DevelopmentTools_WebHostEnvironmentHelper_IsLocalHost(Microsoft_AspNetCore_Hosting_IWebHostEnvironment_TetraPak_CollectionMatchingPolicy_Microsoft_Extensions_Logging_ILogger_)_policy 'TetraPak.AspNet.Api.DevelopmentTools.WebHostEnvironmentHelper.IsLocalHost(Microsoft.AspNetCore.Hosting.IWebHostEnvironment, TetraPak.CollectionMatchingPolicy, Microsoft.Extensions.Logging.ILogger?).policy'):  
<list type="table">  
  
</term>  
on>description</description>  
>  
  
/term>  
on>  
/c> if any bound host URL contains the pattern "<c>://localhost</c>"; otherwise <c>false</c>.  
    </description>  
  
  
/term>  
on>  
/c> if all bound host URL contains the pattern "<c>://localhost</c>"; otherwise <c>false</c>.  
    </description>  
  
  
