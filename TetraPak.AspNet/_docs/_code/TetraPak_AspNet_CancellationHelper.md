#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## CancellationHelper Class
Convenient methods for dealing with aborted/canceled HTTP requests.  
```csharp
public static class CancellationHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CancellationHelper  
### Methods
<a name='TetraPak_AspNet_CancellationHelper_IsRequestCancelled(Microsoft_AspNetCore_Http_HttpContext_)'></a>
## CancellationHelper.IsRequestCancelled(HttpContext?) Method
Returns a value indicating whether the current request/response roundtrip was aborted/cancelled.   
```csharp
public static bool IsRequestCancelled(this Microsoft.AspNetCore.Http.HttpContext? self);
```
#### Parameters
<a name='TetraPak_AspNet_CancellationHelper_IsRequestCancelled(Microsoft_AspNetCore_Http_HttpContext_)_self'></a>
`self` [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
<a name='TetraPak_AspNet_CancellationHelper_IsRequestCancelled(Microsoft_AspNetCore_Mvc_ControllerBase)'></a>
## CancellationHelper.IsRequestCancelled(ControllerBase) Method
Returns a value indicating whether the current request/response roundtrip was aborted/cancelled.   
```csharp
public static bool IsRequestCancelled(this Microsoft.AspNetCore.Mvc.ControllerBase self);
```
#### Parameters
<a name='TetraPak_AspNet_CancellationHelper_IsRequestCancelled(Microsoft_AspNetCore_Mvc_ControllerBase)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
<a name='TetraPak_AspNet_CancellationHelper_IsRequestCancelled(System_Nullable_System_Threading_CancellationToken_)'></a>
## CancellationHelper.IsRequestCancelled(Nullable&lt;CancellationToken&gt;) Method
Returns a value indicating whether the current request/response roundtrip was aborted/cancelled.   
```csharp
public static bool IsRequestCancelled(this System.Nullable<System.Threading.CancellationToken> self);
```
#### Parameters
<a name='TetraPak_AspNet_CancellationHelper_IsRequestCancelled(System_Nullable_System_Threading_CancellationToken_)_self'></a>
`self` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
<a name='TetraPak_AspNet_CancellationHelper_RespondCancelled(Microsoft_AspNetCore_Mvc_ControllerBase)'></a>
## CancellationHelper.RespondCancelled(ControllerBase) Method
```csharp
public static Microsoft.AspNetCore.Mvc.ActionResult RespondCancelled(this Microsoft.AspNetCore.Mvc.ControllerBase self);
```
#### Parameters
<a name='TetraPak_AspNet_CancellationHelper_RespondCancelled(Microsoft_AspNetCore_Mvc_ControllerBase)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
  
#### Returns
[Microsoft.AspNetCore.Mvc.ActionResult](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ActionResult 'Microsoft.AspNetCore.Mvc.ActionResult')  
  
