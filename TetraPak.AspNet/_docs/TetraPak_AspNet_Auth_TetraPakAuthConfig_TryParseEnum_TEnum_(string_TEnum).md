#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth').[TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig')
## TetraPakAuthConfig.TryParseEnum&lt;TEnum&gt;(string, TEnum) Method
Converts the string representation of the name or numeric value of one or more enumerated constants  
to an equivalent enumerated object. The return value indicates whether the conversion succeeded.  
```csharp
public static bool TryParseEnum<TEnum>(string stringValue, out TEnum value)
    where TEnum : struct;
```
#### Type parameters
<a name='TetraPak_AspNet_Auth_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum)_TEnum'></a>
`TEnum`  
The enumeration type to which to convert value.  
  
#### Parameters
<a name='TetraPak_AspNet_Auth_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The case-insensitive string representation of the enumeration name or underlying value to convert.  
  
<a name='TetraPak_AspNet_Auth_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum)_value'></a>
`value` [TEnum](TetraPak_AspNet_Auth_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum).md#TetraPak_AspNet_Auth_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum)_TEnum 'TetraPak.AspNet.Auth.TetraPakAuthConfig.TryParseEnum&lt;TEnum&gt;(string, TEnum).TEnum')  
When this method returns, result contains an object of type [TEnum](TetraPak_AspNet_Auth_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum).md#TetraPak_AspNet_Auth_TetraPakAuthConfig_TryParseEnum_TEnum_(string_TEnum)_TEnum 'TetraPak.AspNet.Auth.TetraPakAuthConfig.TryParseEnum&lt;TEnum&gt;(string, TEnum).TEnum') whose  
value is represented by value if the parse operation succeeds.  
If the parse operation fails, result contains the default value of the underlying type of TEnum.  
Note that this value need not be a member of the TEnum enumeration.  
This parameter is passed uninitialized.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the value parameter was converted successfully; otherwise, `false`.  
            
