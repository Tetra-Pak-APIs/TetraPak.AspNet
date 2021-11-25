#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.DataTransfers](TetraPak_AspNet_DataTransfers.md 'TetraPak.AspNet.DataTransfers')
## HateoasHelper Class
Provides convenient helper methods for working with the HATEOAS classes.  
```csharp
public static class HateoasHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HateoasHelper  
### Methods
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_BuildPath(string_string__)'></a>
## HateoasHelper.BuildPath(string, string[]) Method
Builds a generic path from a base path and resource keys.  
```csharp
public static string BuildPath(string path, params string[] keys);
```
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_BuildPath(string_string__)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The base path.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_BuildPath(string_string__)_keys'></a>
`keys` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
One or more resource keys to be added to the base path.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A textual ([System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')) path.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_BuildPath(string_string____TetraPak_AspNet_HttpQuery_)'></a>
## HateoasHelper.BuildPath(string, string[]?, HttpQuery?) Method
Builds a generic path from a base path, resource keys and and a HTTP query.  
```csharp
public static string BuildPath(string path, string[]? keys, TetraPak.AspNet.HttpQuery? query);
```
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_BuildPath(string_string____TetraPak_AspNet_HttpQuery_)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The base path.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_BuildPath(string_string____TetraPak_AspNet_HttpQuery_)_keys'></a>
`keys` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
One or more resource keys to be added to the base path.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_BuildPath(string_string____TetraPak_AspNet_HttpQuery_)_query'></a>
`query` [HttpQuery](TetraPak_AspNet_HttpQuery.md 'TetraPak.AspNet.HttpQuery')  
The HTTP query to be added to the path.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A textual ([System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')) path.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_BuildPath(string_TetraPak_AspNet_HttpQuery)'></a>
## HateoasHelper.BuildPath(string, HttpQuery) Method
Builds a generic path from a base path and HTTP a query.  
```csharp
public static string BuildPath(string path, TetraPak.AspNet.HttpQuery query);
```
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_BuildPath(string_TetraPak_AspNet_HttpQuery)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The base path.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_BuildPath(string_TetraPak_AspNet_HttpQuery)_query'></a>
`query` [HttpQuery](TetraPak_AspNet_HttpQuery.md 'TetraPak.AspNet.HttpQuery')  
The HTTP query to be added to the path.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A textual ([System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')) path.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForAction(Microsoft_AspNetCore_Mvc_ControllerBase_string_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)'></a>
## HateoasHelper.GetRelLocatorForAction(ControllerBase, string, HttpMethod[]) Method
Constructs and returns a relationship locator for a specified action.  
```csharp
public static TetraPak.AspNet.DataTransfers.DtoRelationshipLocator GetRelLocatorForAction(this Microsoft.AspNetCore.Mvc.ControllerBase self, string action, params Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod[] methods);
```
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForAction(Microsoft_AspNetCore_Mvc_ControllerBase_string_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended controller.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForAction(Microsoft_AspNetCore_Mvc_ControllerBase_string_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_action'></a>
`action` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the action method.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForAction(Microsoft_AspNetCore_Mvc_ControllerBase_string_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_methods'></a>
`methods` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
(optional)<br/>  
One or more HTTP verbs that are supported by the endpoint.  
  
#### Returns
[DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator')  
A [DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator').  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForDefaultAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase)'></a>
## HateoasHelper.GetRelLocatorForDefaultAction&lt;TController&gt;(ControllerBase) Method
Constructs and returns a relationship locator for a controller type's default action.  
```csharp
public static TetraPak.AspNet.DataTransfers.DtoRelationshipLocator GetRelLocatorForDefaultAction<TController>(this Microsoft.AspNetCore.Mvc.ControllerBase self)
    where TController : Microsoft.AspNetCore.Mvc.ControllerBase;
```
#### Type parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForDefaultAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase)_TController'></a>
`TController`  
  
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForDefaultAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended controller.  
  
#### Returns
[DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator')  
A [DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator').  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForDefaultAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)'></a>
## HateoasHelper.GetRelLocatorForDefaultAction&lt;TController&gt;(ControllerBase, HttpMethod[]) Method
Constructs and returns a relationship locator for a controller type's default action.  
```csharp
public static TetraPak.AspNet.DataTransfers.DtoRelationshipLocator GetRelLocatorForDefaultAction<TController>(this Microsoft.AspNetCore.Mvc.ControllerBase self, params Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod[] methods)
    where TController : Microsoft.AspNetCore.Mvc.ControllerBase;
```
#### Type parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForDefaultAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_TController'></a>
`TController`  
  
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForDefaultAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended controller.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForDefaultAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_methods'></a>
`methods` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
One or more HTTP verbs that are supported by the endpoint.  
  
#### Returns
[DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator')  
A [DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator').  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForSelf(Microsoft_AspNetCore_Mvc_ControllerBase_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)'></a>
## HateoasHelper.GetRelLocatorForSelf(ControllerBase, HttpMethod[]) Method
Constructs and returns a relationship locator for the current endpoint.  
```csharp
public static TetraPak.AspNet.DataTransfers.DtoRelationshipLocator GetRelLocatorForSelf(this Microsoft.AspNetCore.Mvc.ControllerBase self, params Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod[] methods);
```
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForSelf(Microsoft_AspNetCore_Mvc_ControllerBase_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended controller.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorForSelf(Microsoft_AspNetCore_Mvc_ControllerBase_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_methods'></a>
`methods` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
(optional)<br/>  
One or more HTTP verbs that are supported by the endpoint.  
  
#### Returns
[DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator')  
A [DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator').  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorsForAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_string_string__)'></a>
## HateoasHelper.GetRelLocatorsForAction&lt;TController&gt;(ControllerBase, string, string[]) Method
Constructs and returns a relationship locator for a controller action while also specifying resource keys.  
```csharp
public static TetraPak.AspNet.DataTransfers.DtoRelationshipLocator GetRelLocatorsForAction<TController>(this Microsoft.AspNetCore.Mvc.ControllerBase self, string action, params string[] keys)
    where TController : Microsoft.AspNetCore.Mvc.ControllerBase;
```
#### Type parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorsForAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_string_string__)_TController'></a>
`TController`  
  
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorsForAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_string_string__)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended controller.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorsForAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_string_string__)_action'></a>
`action` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the action method.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorsForAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_string_string__)_keys'></a>
`keys` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
One or more resource keys (ids), needed to locate the resource.  
  
#### Returns
[DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator')  
A [DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator').  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorsForAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_string_string___TetraPak_AspNet_HttpQuery__Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)'></a>
## HateoasHelper.GetRelLocatorsForAction&lt;TController&gt;(ControllerBase, string, string[], HttpQuery?, HttpMethod[]) Method
Constructs and returns a relationship locator for a controller action  
while also specifying resource keys, a HTTP query, and HTTP verbs.  
```csharp
public static TetraPak.AspNet.DataTransfers.DtoRelationshipLocator GetRelLocatorsForAction<TController>(this Microsoft.AspNetCore.Mvc.ControllerBase self, string action, string[] keys, TetraPak.AspNet.HttpQuery? query, Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod[] methods)
    where TController : Microsoft.AspNetCore.Mvc.ControllerBase;
```
#### Type parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorsForAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_string_string___TetraPak_AspNet_HttpQuery__Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_TController'></a>
`TController`  
  
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorsForAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_string_string___TetraPak_AspNet_HttpQuery__Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_self'></a>
`self` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended controller.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorsForAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_string_string___TetraPak_AspNet_HttpQuery__Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_action'></a>
`action` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the action method.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorsForAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_string_string___TetraPak_AspNet_HttpQuery__Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_keys'></a>
`keys` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
One or more resource keys (ids), needed to locate the resource.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorsForAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_string_string___TetraPak_AspNet_HttpQuery__Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_query'></a>
`query` [HttpQuery](TetraPak_AspNet_HttpQuery.md 'TetraPak.AspNet.HttpQuery')  
A HTTP query to be added to the resource locator URI.  
  
<a name='TetraPak_AspNet_DataTransfers_HateoasHelper_GetRelLocatorsForAction_TController_(Microsoft_AspNetCore_Mvc_ControllerBase_string_string___TetraPak_AspNet_HttpQuery__Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_methods'></a>
`methods` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
One or more HTTP verbs that are supported by the resource endpoint.  
  
#### Returns
[DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator')  
A [DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator').  
  
