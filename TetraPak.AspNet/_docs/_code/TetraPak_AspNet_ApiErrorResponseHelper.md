#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ApiErrorResponseHelper Class
Provides convenient methods for dealing with standard Tetra Pak error responses.   
```csharp
public static class ApiErrorResponseHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiErrorResponseHelper  
### Methods
<a name='TetraPak_AspNet_ApiErrorResponseHelper_ToDictionary(object_TetraPak_AspNet_DictionaryTransformationOptions_)'></a>
## ApiErrorResponseHelper.ToDictionary(object, DictionaryTransformationOptions?) Method
Transforms an object's properties and values into a dictionary.  
```csharp
public static System.Collections.Generic.IDictionary<string,object> ToDictionary(this object self, TetraPak.AspNet.DictionaryTransformationOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_ApiErrorResponseHelper_ToDictionary(object_TetraPak_AspNet_DictionaryTransformationOptions_)_self'></a>
`self` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The object being transformed into a dictionary.  
  
<a name='TetraPak_AspNet_ApiErrorResponseHelper_ToDictionary(object_TetraPak_AspNet_DictionaryTransformationOptions_)_options'></a>
`options` [TetraPak.AspNet.DictionaryTransformationOptions](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.DictionaryTransformationOptions 'TetraPak.AspNet.DictionaryTransformationOptions')  
(optional; default = [TetraPak.AspNet.DictionaryTransformationOptions.Default](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.DictionaryTransformationOptions.Default 'TetraPak.AspNet.DictionaryTransformationOptions.Default')  
Options to control the transformation.  
  
#### Returns
[System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
A [System.Collections.Generic.IDictionary&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2') object.  
  
