#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.DataTransfers](TetraPak_AspNet_DataTransfers.md 'TetraPak.AspNet.DataTransfers')
## ControllerHelper Class
Convenient method to help out with typical controller-related scenarios.  
```csharp
public static class ControllerHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ControllerHelper  
### Methods
<a name='TetraPak_AspNet_DataTransfers_ControllerHelper_DefaultGetAction_TController_()'></a>
## ControllerHelper.DefaultGetAction&lt;TController&gt;() Method
Resolves the a default action for a specified controller type.  
```csharp
public static System.Reflection.MethodInfo? DefaultGetAction<TController>()
    where TController : Microsoft.AspNetCore.Mvc.ControllerBase;
```
#### Type parameters
<a name='TetraPak_AspNet_DataTransfers_ControllerHelper_DefaultGetAction_TController_()_TController'></a>
`TController`  
The controller type.  
  
#### Returns
[System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')  
A [System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo') reflecting the default action method if one could be resolved;  
otherwise `null`.   
  
<a name='TetraPak_AspNet_DataTransfers_ControllerHelper_GetControllerName(System_Type)'></a>
## ControllerHelper.GetControllerName(Type) Method
Resolves and returns the path identifier for a specified controller type, as per standard ASP.NET  
controller naming conventions (ei. stripping away any "Controller" suffix from the type name).  
```csharp
public static string GetControllerName(this System.Type controllerType);
```
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_ControllerHelper_GetControllerName(System_Type)_controllerType'></a>
`controllerType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
