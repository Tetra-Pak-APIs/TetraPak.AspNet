#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## DictionaryTransformationOptions Class
Used to specify how to transform into an entity into a [System.Collections.Generic.IDictionary&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2').  
```csharp
public class DictionaryTransformationOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DictionaryTransformationOptions  
### Properties
<a name='TetraPak_AspNet_DictionaryTransformationOptions_Default'></a>
## DictionaryTransformationOptions.Default Property
Gets a default [DictionaryTransformationOptions](TetraPak_AspNet_DictionaryTransformationOptions.md 'TetraPak.AspNet.DictionaryTransformationOptions') object.  
```csharp
public static TetraPak.AspNet.DictionaryTransformationOptions Default { get; }
```
#### Property Value
[DictionaryTransformationOptions](TetraPak_AspNet_DictionaryTransformationOptions.md 'TetraPak.AspNet.DictionaryTransformationOptions')
  
<a name='TetraPak_AspNet_DictionaryTransformationOptions_IgnoreNullValues'></a>
## DictionaryTransformationOptions.IgnoreNullValues Property
Gets os sets a value that   
specifies whether to skip `null` values.  
```csharp
public bool IgnoreNullValues { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_DictionaryTransformationOptions_KeyFormat'></a>
## DictionaryTransformationOptions.KeyFormat Property
Gets os sets a value that   
specifies the format to be used for value keys (eg. camelCase, kebab-case etc.).  
```csharp
public TetraPak.DynamicEntities.KeyTransformationFormat KeyFormat { get; set; }
```
#### Property Value
[TetraPak.DynamicEntities.KeyTransformationFormat](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.KeyTransformationFormat 'TetraPak.DynamicEntities.KeyTransformationFormat')
  
<a name='TetraPak_AspNet_DictionaryTransformationOptions_TransformChildren'></a>
## DictionaryTransformationOptions.TransformChildren Property
```csharp
public bool TransformChildren { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
#### See Also
- [ToDictionary(object, DictionaryTransformationOptions?)](TetraPak_AspNet_ApiErrorResponseHelper.md#TetraPak_AspNet_ApiErrorResponseHelper_ToDictionary(object_TetraPak_AspNet_DictionaryTransformationOptions_) 'TetraPak.AspNet.ApiErrorResponseHelper.ToDictionary(object, TetraPak.AspNet.DictionaryTransformationOptions?)')
