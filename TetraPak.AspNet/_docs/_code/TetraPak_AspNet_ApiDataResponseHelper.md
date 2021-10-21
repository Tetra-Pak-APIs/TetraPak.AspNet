#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ApiDataResponseHelper Class
```csharp
public static class ApiDataResponseHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiDataResponseHelper  
### Methods
<a name='TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_System_Collections_Generic_IEnumerable_T_)'></a>
## ApiDataResponseHelper.TryAsApiDataResponse&lt;T&gt;(object, IEnumerable&lt;T&gt;) Method
Examines an object and returns a value to indicate is is a [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;')  
of a specified data type.  
```csharp
public static bool TryAsApiDataResponse<T>(this object obj, out System.Collections.Generic.IEnumerable<T> data);
```
#### Type parameters
<a name='TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_System_Collections_Generic_IEnumerable_T_)_T'></a>
`T`  
The expected ApiDataResponse data type.  
  
#### Parameters
<a name='TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_System_Collections_Generic_IEnumerable_T_)_obj'></a>
`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The object being examined.  
  
<a name='TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_System_Collections_Generic_IEnumerable_T_)_data'></a>
`data` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](TetraPak_AspNet_ApiDataResponseHelper.md#TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_System_Collections_Generic_IEnumerable_T_)_T 'TetraPak.AspNet.ApiDataResponseHelper.TryAsApiDataResponse&lt;T&gt;(object, System.Collections.Generic.IEnumerable&lt;T&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
On success; passed back the data items carried by the [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;').  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [obj](TetraPak_AspNet_ApiDataResponseHelper.md#TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_System_Collections_Generic_IEnumerable_T_)_obj 'TetraPak.AspNet.ApiDataResponseHelper.TryAsApiDataResponse&lt;T&gt;(object, System.Collections.Generic.IEnumerable&lt;T&gt;).obj') is a [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;') of [T](TetraPak_AspNet_ApiDataResponseHelper.md#TetraPak_AspNet_ApiDataResponseHelper_TryAsApiDataResponse_T_(object_System_Collections_Generic_IEnumerable_T_)_T 'TetraPak.AspNet.ApiDataResponseHelper.TryAsApiDataResponse&lt;T&gt;(object, System.Collections.Generic.IEnumerable&lt;T&gt;).T');  
              otherwise `false`.  
            
  
