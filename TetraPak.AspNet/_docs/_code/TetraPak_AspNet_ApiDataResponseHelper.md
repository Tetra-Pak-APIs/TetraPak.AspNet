#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ApiDataResponseHelper Class
Convenient methods for dealing with HTTP response use cases.   
```csharp
public static class ApiDataResponseHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiDataResponseHelper  
### Methods
<a name='TetraPak_AspNet_ApiDataResponseHelper_IsApiDataResponse(TetraPak_DynamicEntities_DynamicEntity_object_)'></a>
## ApiDataResponseHelper.IsApiDataResponse(DynamicEntity, object?) Method
Examines the [TetraPak.DynamicEntities.DynamicEntity](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicEntity 'TetraPak.DynamicEntities.DynamicEntity') and returns a value to indicate that it  
reflects a [ApiDataResponse](TetraPak_AspNet_ApiDataResponse.md 'TetraPak.AspNet.ApiDataResponse').  
```csharp
public static bool IsApiDataResponse(this TetraPak.DynamicEntities.DynamicEntity dynamicEntity, out object? dataResponse);
```
#### Parameters
<a name='TetraPak_AspNet_ApiDataResponseHelper_IsApiDataResponse(TetraPak_DynamicEntities_DynamicEntity_object_)_dynamicEntity'></a>
`dynamicEntity` [TetraPak.DynamicEntities.DynamicEntity](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicEntity 'TetraPak.DynamicEntities.DynamicEntity')  
The [TetraPak.DynamicEntities.DynamicEntity](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicEntity 'TetraPak.DynamicEntities.DynamicEntity') to be examined.  
  
<a name='TetraPak_AspNet_ApiDataResponseHelper_IsApiDataResponse(TetraPak_DynamicEntities_DynamicEntity_object_)_dataResponse'></a>
`dataResponse` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
Passed back the API response data (payload) if [dynamicEntity](TetraPak_AspNet_ApiDataResponseHelper.md#TetraPak_AspNet_ApiDataResponseHelper_IsApiDataResponse(TetraPak_DynamicEntities_DynamicEntity_object_)_dynamicEntity 'TetraPak.AspNet.ApiDataResponseHelper.IsApiDataResponse(TetraPak.DynamicEntities.DynamicEntity, object?).dynamicEntity') is  
found to be a [ApiDataResponse](TetraPak_AspNet_ApiDataResponse.md 'TetraPak.AspNet.ApiDataResponse'); otherwise `null`.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [dynamicEntity](TetraPak_AspNet_ApiDataResponseHelper.md#TetraPak_AspNet_ApiDataResponseHelper_IsApiDataResponse(TetraPak_DynamicEntities_DynamicEntity_object_)_dynamicEntity 'TetraPak.AspNet.ApiDataResponseHelper.IsApiDataResponse(TetraPak.DynamicEntities.DynamicEntity, object?).dynamicEntity') is an [ApiDataResponse](TetraPak_AspNet_ApiDataResponse.md 'TetraPak.AspNet.ApiDataResponse');  
              otherwise `false`.  
            
  
<a name='TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_TetraPak_AspNet_ApiDataResponse_T__)'></a>
## ApiDataResponseHelper.TryAsApiDataResponse&lt;T&gt;(object, ApiDataResponse&lt;T&gt;?) Method
Examines an object and returns a value to indicate is is a [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;')  
of a specified data type.  
```csharp
public static bool TryAsApiDataResponse<T>(this object obj, out TetraPak.AspNet.ApiDataResponse<T>? dataResponse);
```
#### Type parameters
<a name='TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_TetraPak_AspNet_ApiDataResponse_T__)_T'></a>
`T`  
The expected ApiDataResponse data type.  
  
#### Parameters
<a name='TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_TetraPak_AspNet_ApiDataResponse_T__)_obj'></a>
`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The object being examined.  
  
<a name='TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_TetraPak_AspNet_ApiDataResponse_T__)_dataResponse'></a>
`dataResponse` [TetraPak.AspNet.ApiDataResponse&lt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;')[T](TetraPak_AspNet_ApiDataResponseHelper.md#TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_TetraPak_AspNet_ApiDataResponse_T__)_T 'TetraPak.AspNet.ApiDataResponseHelper.TryAsApiDataResponse&lt;T&gt;(object, TetraPak.AspNet.ApiDataResponse&lt;T&gt;?).T')[&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;')  
On success; passed back the object as an [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;').  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [obj](TetraPak_AspNet_ApiDataResponseHelper.md#TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_TetraPak_AspNet_ApiDataResponse_T__)_obj 'TetraPak.AspNet.ApiDataResponseHelper.TryAsApiDataResponse&lt;T&gt;(object, TetraPak.AspNet.ApiDataResponse&lt;T&gt;?).obj') is a [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;') of [T](TetraPak_AspNet_ApiDataResponseHelper.md#TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_TetraPak_AspNet_ApiDataResponse_T__)_T 'TetraPak.AspNet.ApiDataResponseHelper.TryAsApiDataResponse&lt;T&gt;(object, TetraPak.AspNet.ApiDataResponse&lt;T&gt;?).T');  
              otherwise `false`.  
            
  
