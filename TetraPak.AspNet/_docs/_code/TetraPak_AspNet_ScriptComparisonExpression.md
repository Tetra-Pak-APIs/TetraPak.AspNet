#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ScriptComparisonExpression Class
A string compatible (criteria) expression for use with HTTP requests.  
```csharp
public class ScriptComparisonExpression : TetraPak.AspNet.ScriptExpression
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.StringValueBase](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.StringValueBase 'TetraPak.StringValueBase') &#129106; [ScriptExpression](TetraPak_AspNet_ScriptExpression.md 'TetraPak.AspNet.ScriptExpression') &#129106; ScriptComparisonExpression  
### Constructors
<a name='TetraPak_AspNet_ScriptComparisonExpression_ScriptComparisonExpression(string_)'></a>
## ScriptComparisonExpression.ScriptComparisonExpression(string?) Constructor
Initializes the [ScriptComparisonExpression](TetraPak_AspNet_ScriptComparisonExpression.md 'TetraPak.AspNet.ScriptComparisonExpression').   
```csharp
public ScriptComparisonExpression(string? value);
```
#### Parameters
<a name='TetraPak_AspNet_ScriptComparisonExpression_ScriptComparisonExpression(string_)_value'></a>
`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A textual representation of a [ScriptComparisonExpression](TetraPak_AspNet_ScriptComparisonExpression.md 'TetraPak.AspNet.ScriptComparisonExpression') value.  
  
  
### Properties
<a name='TetraPak_AspNet_ScriptComparisonExpression_Element'></a>
## ScriptComparisonExpression.Element Property
Gets the element ([Headers](TetraPak_AspNet_ScriptComparisonExpression_Elements.md#TetraPak_AspNet_ScriptComparisonExpression_Elements_Headers 'TetraPak.AspNet.ScriptComparisonExpression.Elements.Headers') or [Query](TetraPak_AspNet_ScriptComparisonExpression_Elements.md#TetraPak_AspNet_ScriptComparisonExpression_Elements_Query 'TetraPak.AspNet.ScriptComparisonExpression.Elements.Query'))  
references in the operation.   
```csharp
public TetraPak.AspNet.HttpRequestElement Element { get; set; }
```
#### Property Value
[HttpRequestElement](TetraPak_AspNet_HttpRequestElement.md 'TetraPak.AspNet.HttpRequestElement')
  
<a name='TetraPak_AspNet_ScriptComparisonExpression_Key'></a>
## ScriptComparisonExpression.Key Property
Identifies an item from the specified [Element](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_Element 'TetraPak.AspNet.ScriptComparisonExpression.Element'),  
to be used for comparison with [Value](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_Value 'TetraPak.AspNet.ScriptComparisonExpression.Value').   
```csharp
public string? Key { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_ScriptComparisonExpression_Operator'></a>
## ScriptComparisonExpression.Operator Property
Specifies the comparative operator.  
```csharp
public TetraPak.AspNet.ScriptComparisonOperator Operator { get; set; }
```
#### Property Value
[ScriptComparisonOperator](TetraPak_AspNet_ScriptComparisonOperator.md 'TetraPak.AspNet.ScriptComparisonOperator')
#### See Also
- [ScriptComparisonOperator](TetraPak_AspNet_ScriptComparisonOperator.md 'TetraPak.AspNet.ScriptComparisonOperator')
  
<a name='TetraPak_AspNet_ScriptComparisonExpression_Value'></a>
## ScriptComparisonExpression.Value Property
Gets the value to be matched with the specified [Key](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_Key 'TetraPak.AspNet.ScriptComparisonExpression.Key').   
```csharp
public string? Value { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
### Methods
<a name='TetraPak_AspNet_ScriptComparisonExpression_IsMatch(Microsoft_AspNetCore_Http_HttpRequest_System_StringComparison)'></a>
## ScriptComparisonExpression.IsMatch(HttpRequest, StringComparison) Method
Executes the  specified operation and returns a value indicating a match.   
```csharp
public override bool IsMatch(Microsoft.AspNetCore.Http.HttpRequest request, System.StringComparison comparison=System.StringComparison.InvariantCulture);
```
#### Parameters
<a name='TetraPak_AspNet_ScriptComparisonExpression_IsMatch(Microsoft_AspNetCore_Http_HttpRequest_System_StringComparison)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest') to be matched by the operation.  
  
<a name='TetraPak_AspNet_ScriptComparisonExpression_IsMatch(Microsoft_AspNetCore_Http_HttpRequest_System_StringComparison)_comparison'></a>
`comparison` [System.StringComparison](https://docs.microsoft.com/en-us/dotnet/api/System.StringComparison 'System.StringComparison')  
(optional; default=[System.StringComparison.InvariantCulture](https://docs.microsoft.com/en-us/dotnet/api/System.StringComparison.InvariantCulture 'System.StringComparison.InvariantCulture'))<br/>  
Specifies how to match the [Value](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_Value 'TetraPak.AspNet.ScriptComparisonExpression.Value') ([Element](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_Element 'TetraPak.AspNet.ScriptComparisonExpression.Element') and [Key](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_Key 'TetraPak.AspNet.ScriptComparisonExpression.Key')  
are always case-insensitive.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [ItemValue(HttpRequest)](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_ItemValue(Microsoft_AspNetCore_Http_HttpRequest) 'TetraPak.AspNet.ScriptComparisonExpression.ItemValue(Microsoft.AspNetCore.Http.HttpRequest)') matches [Value](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_Value 'TetraPak.AspNet.ScriptComparisonExpression.Value');  
              otherwise `false`.  
            
  
<a name='TetraPak_AspNet_ScriptComparisonExpression_ItemValue(Microsoft_AspNetCore_Http_HttpRequest)'></a>
## ScriptComparisonExpression.ItemValue(HttpRequest) Method
Gets the item's value (identified by [Key](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_Key 'TetraPak.AspNet.ScriptComparisonExpression.Key')) from a request.  
```csharp
public string? ItemValue(Microsoft.AspNetCore.Http.HttpRequest request);
```
#### Parameters
<a name='TetraPak_AspNet_ScriptComparisonExpression_ItemValue(Microsoft_AspNetCore_Http_HttpRequest)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value if the item can be found in the specified [Element](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_Element 'TetraPak.AspNet.ScriptComparisonExpression.Element');  
otherwise `null`.  
  
<a name='TetraPak_AspNet_ScriptComparisonExpression_OnParse(string_)'></a>
## ScriptComparisonExpression.OnParse(string?) Method
Overrides base method to resolve [Element](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_Element 'TetraPak.AspNet.ScriptComparisonExpression.Element'), [Key](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_Key 'TetraPak.AspNet.ScriptComparisonExpression.Key') and [Value](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_Value 'TetraPak.AspNet.ScriptComparisonExpression.Value').  
```csharp
protected override string? OnParse(string? stringValue);
```
#### Parameters
<a name='TetraPak_AspNet_ScriptComparisonExpression_OnParse(string_)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [stringValue](TetraPak_AspNet_ScriptComparisonExpression.md#TetraPak_AspNet_ScriptComparisonExpression_OnParse(string_)_stringValue 'TetraPak.AspNet.ScriptComparisonExpression.OnParse(string?).stringValue') if parsing is successful; otherwise `null`.  
  
### Operators
<a name='TetraPak_AspNet_ScriptComparisonExpression_op_ImplicitTetraPak_AspNet_ScriptComparisonExpression(string_)'></a>
## ScriptComparisonExpression.implicit operator ScriptComparisonExpression(string?) Operator
Implicit type cast operation [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') => [ScriptComparisonExpression](TetraPak_AspNet_ScriptComparisonExpression.md 'TetraPak.AspNet.ScriptComparisonExpression').   
```csharp
public static TetraPak.AspNet.ScriptComparisonExpression implicit operator ScriptComparisonExpression(string? stringValue);
```
#### Parameters
<a name='TetraPak_AspNet_ScriptComparisonExpression_op_ImplicitTetraPak_AspNet_ScriptComparisonExpression(string_)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The textual representation of a [ScriptComparisonExpression](TetraPak_AspNet_ScriptComparisonExpression.md 'TetraPak.AspNet.ScriptComparisonExpression') value.  
  
#### Returns
[ScriptComparisonExpression](TetraPak_AspNet_ScriptComparisonExpression.md 'TetraPak.AspNet.ScriptComparisonExpression')  
  
