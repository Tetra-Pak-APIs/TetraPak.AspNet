#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## RoutingHelper Class
Convenient extension methods for working with controllers and endpoints.   
```csharp
public static class RoutingHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RoutingHelper  
### Methods
<a name='TetraPak_AspNet_RoutingHelper_IsAuthorizationRequired(Microsoft_AspNetCore_Http_Endpoint_)'></a>
## RoutingHelper.IsAuthorizationRequired(Endpoint?) Method
Examines an endpoint and returns a value indicating whether it requires authorization.  
```csharp
public static bool IsAuthorizationRequired(this Microsoft.AspNetCore.Http.Endpoint? self);
```
#### Parameters
<a name='TetraPak_AspNet_RoutingHelper_IsAuthorizationRequired(Microsoft_AspNetCore_Http_Endpoint_)_self'></a>
`self` [Microsoft.AspNetCore.Http.Endpoint](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.Endpoint 'Microsoft.AspNetCore.Http.Endpoint')  
The [Microsoft.AspNetCore.Http.Endpoint](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.Endpoint 'Microsoft.AspNetCore.Http.Endpoint') (can be `null`).    
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the endpoint is assigned and requires authorization; otherwise `false`.  
            
  
<a name='TetraPak_AspNet_RoutingHelper_IsAuthorizationRequired(System_Reflection_MethodInfo__bool)'></a>
## RoutingHelper.IsAuthorizationRequired(MethodInfo?, bool) Method
Examines a method and returns a value indicating whether it requires authorization.  
```csharp
public static bool IsAuthorizationRequired(this System.Reflection.MethodInfo? self, bool fallbackToDeclaringType=true);
```
#### Parameters
<a name='TetraPak_AspNet_RoutingHelper_IsAuthorizationRequired(System_Reflection_MethodInfo__bool)_self'></a>
`self` [System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')  
The [System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo') (can be `null`).    
  
<a name='TetraPak_AspNet_RoutingHelper_IsAuthorizationRequired(System_Reflection_MethodInfo__bool)_fallbackToDeclaringType'></a>
`fallbackToDeclaringType` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to automatically fall back to the method's declaring type  
if the requested value cannot be resolved from the method itself.   
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the method is assigned and requires authorization; otherwise `false`.  
            
  
<a name='TetraPak_AspNet_RoutingHelper_IsAuthorizationRequired(System_Type__bool)'></a>
## RoutingHelper.IsAuthorizationRequired(Type?, bool) Method
Examines a [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') and returns a value indicating whether it requires authorization.  
```csharp
public static bool IsAuthorizationRequired(this System.Type? self, bool fallbackToDeclaringType=true);
```
#### Parameters
<a name='TetraPak_AspNet_RoutingHelper_IsAuthorizationRequired(System_Type__bool)_self'></a>
`self` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')  
The [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') (can be `null`).    
  
<a name='TetraPak_AspNet_RoutingHelper_IsAuthorizationRequired(System_Type__bool)_fallbackToDeclaringType'></a>
`fallbackToDeclaringType` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to automatically fall back to the type's declaring type  
if the requested value cannot be resolved from the type itself.   
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the type is assigned and requires authorization; otherwise `false`.  
            
  
