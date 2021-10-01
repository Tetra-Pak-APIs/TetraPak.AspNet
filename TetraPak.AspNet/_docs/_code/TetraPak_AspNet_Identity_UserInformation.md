#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Identity](TetraPak_AspNet_Identity.md 'TetraPak.AspNet.Identity')
## UserInformation Class
Represents user information claims as a dictionary.  
```csharp
public class UserInformation
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; UserInformation  
### Properties
<a name='TetraPak_AspNet_Identity_UserInformation_Keys'></a>
## UserInformation.Keys Property
The names of all keys (types of claims).  
```csharp
public string[] Keys { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')
  
### Methods
<a name='TetraPak_AspNet_Identity_UserInformation_ToDictionary()'></a>
## UserInformation.ToDictionary() Method
Returns the user information as a [System.Collections.Generic.IDictionary&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2').  
```csharp
public System.Collections.Generic.IDictionary<string,string> ToDictionary();
```
#### Returns
[System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
  
<a name='TetraPak_AspNet_Identity_UserInformation_TryGet_T_(string_T)'></a>
## UserInformation.TryGet&lt;T&gt;(string, T) Method
Tries to obtain user information value.  
```csharp
public bool TryGet<T>(string key, out T value);
```
#### Type parameters
<a name='TetraPak_AspNet_Identity_UserInformation_TryGet_T_(string_T)_T'></a>
`T`  
Specifies the type of value.  
  
#### Parameters
<a name='TetraPak_AspNet_Identity_UserInformation_TryGet_T_(string_T)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the value.  
  
<a name='TetraPak_AspNet_Identity_UserInformation_TryGet_T_(string_T)_value'></a>
`value` [T](TetraPak_AspNet_Identity_UserInformation.md#TetraPak_AspNet_Identity_UserInformation_TryGet_T_(string_T)_T 'TetraPak.AspNet.Identity.UserInformation.TryGet&lt;T&gt;(string, T).T')  
Passes back the value when fund; otherwise `null`.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if value was found; otherwise `false`.  
            
#### Exceptions
[System.InvalidCastException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidCastException 'System.InvalidCastException')  
Value was found but was not of specified type.   
  
