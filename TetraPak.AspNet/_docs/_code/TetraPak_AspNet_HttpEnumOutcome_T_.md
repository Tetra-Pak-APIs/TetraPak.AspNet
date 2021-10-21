#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## HttpEnumOutcome&lt;T&gt; Class
Represents the outcome of a HTTP request.  
```csharp
public class HttpEnumOutcome<T> : TetraPak.EnumOutcome<T>
```
#### Type parameters
<a name='TetraPak_AspNet_HttpEnumOutcome_T__T'></a>
`T`  
The [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') of data requested.  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.Outcome](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome 'TetraPak.Outcome') &#129106; [TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') &#129106; [TetraPak.EnumOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1 'TetraPak.EnumOutcome`1')[T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1 'TetraPak.EnumOutcome`1') &#129106; HttpEnumOutcome&lt;T&gt;  
### Constructors
<a name='TetraPak_AspNet_HttpEnumOutcome_T__HttpEnumOutcome(bool_System_Net_Http_HttpMethod_System_Collections_Generic_IReadOnlyCollection_T__int_System_Exception_)'></a>
## HttpEnumOutcome&lt;T&gt;.HttpEnumOutcome(bool, HttpMethod, IReadOnlyCollection&lt;T&gt;, int, Exception?) Constructor
Initialises the [HttpEnumOutcome&lt;T&gt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;') object.   
```csharp
protected HttpEnumOutcome(bool result, System.Net.Http.HttpMethod method, System.Collections.Generic.IReadOnlyCollection<T> value, int totalCount, System.Exception? exception=null);
```
#### Parameters
<a name='TetraPak_AspNet_HttpEnumOutcome_T__HttpEnumOutcome(bool_System_Net_Http_HttpMethod_System_Collections_Generic_IReadOnlyCollection_T__int_System_Exception_)_result'></a>
`result` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Assigns the [TetraPak.Outcome.Result](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome.Result 'TetraPak.Outcome.Result') (success/failure) flag.  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__HttpEnumOutcome(bool_System_Net_Http_HttpMethod_System_Collections_Generic_IReadOnlyCollection_T__int_System_Exception_)_method'></a>
`method` [System.Net.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMethod 'System.Net.Http.HttpMethod')  
Initializes the [Method](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__Method 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.Method').  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__HttpEnumOutcome(bool_System_Net_Http_HttpMethod_System_Collections_Generic_IReadOnlyCollection_T__int_System_Exception_)_value'></a>
`value` [System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')  
One or more items to populate the [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value'). Pass `null` if not applicable.  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__HttpEnumOutcome(bool_System_Net_Http_HttpMethod_System_Collections_Generic_IReadOnlyCollection_T__int_System_Exception_)_totalCount'></a>
`totalCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Initializes the [TetraPak.EnumOutcome&lt;&gt;.TotalCount](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1.TotalCount 'TetraPak.EnumOutcome`1.TotalCount'). Pass zero (0) if not applicable.  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__HttpEnumOutcome(bool_System_Net_Http_HttpMethod_System_Collections_Generic_IReadOnlyCollection_T__int_System_Exception_)_exception'></a>
`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
Initializes the [TetraPak.Outcome.Exception](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome.Exception 'TetraPak.Outcome.Exception'). Pass `null` if not applicable.   
  
  
### Properties
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Method'></a>
## HttpEnumOutcome&lt;T&gt;.Method Property
Gets the HTTP request method used.  
```csharp
public string Method { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
### Methods
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Fail(System_Net_Http_HttpMethod_System_Exception)'></a>
## HttpEnumOutcome&lt;T&gt;.Fail(HttpMethod, Exception) Method
Creates and returns a failed outcome.  
```csharp
public static TetraPak.AspNet.HttpEnumOutcome<T> Fail(System.Net.Http.HttpMethod method, System.Exception exception);
```
#### Parameters
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Fail(System_Net_Http_HttpMethod_System_Exception)_method'></a>
`method` [System.Net.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMethod 'System.Net.Http.HttpMethod')  
Sets the [Method](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__Method 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.Method').  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Fail(System_Net_Http_HttpMethod_System_Exception)_exception'></a>
`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
The [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') (presumably causing the failure).  
  
#### Returns
[TetraPak.AspNet.HttpEnumOutcome&lt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;')[T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T')[&gt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;')  
An [HttpEnumOutcome&lt;T&gt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;') to indicate failure and also carry a default  
value of type [T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T').  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Fail(System_Net_Http_HttpMethod_T___System_Exception)'></a>
## HttpEnumOutcome&lt;T&gt;.Fail(HttpMethod, T[], Exception) Method
Creates and returns a failed outcome.  
```csharp
public static TetraPak.AspNet.HttpEnumOutcome<T> Fail(System.Net.Http.HttpMethod method, T[] value, System.Exception exception);
```
#### Parameters
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Fail(System_Net_Http_HttpMethod_T___System_Exception)_method'></a>
`method` [System.Net.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMethod 'System.Net.Http.HttpMethod')  
Sets the [Method](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__Method 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.Method').  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Fail(System_Net_Http_HttpMethod_T___System_Exception)_value'></a>
`value` [T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
One or more items to populate the [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value').  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Fail(System_Net_Http_HttpMethod_T___System_Exception)_exception'></a>
`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
The [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') (presumably causing the failure).  
  
#### Returns
[TetraPak.AspNet.HttpEnumOutcome&lt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;')[T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T')[&gt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;')  
An [HttpEnumOutcome&lt;T&gt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;') to indicate failure and also carry a default  
value of type [T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T').  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Fail(System_Net_Http_HttpMethod)'></a>
## HttpEnumOutcome&lt;T&gt;.Fail(HttpMethod) Method
Creates and returns a failed outcome.  
```csharp
public static TetraPak.AspNet.HttpEnumOutcome<T> Fail(System.Net.Http.HttpMethod method);
```
#### Parameters
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Fail(System_Net_Http_HttpMethod)_method'></a>
`method` [System.Net.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMethod 'System.Net.Http.HttpMethod')  
Sets the [Method](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__Method 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.Method').  
  
#### Returns
[TetraPak.AspNet.HttpEnumOutcome&lt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;')[T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T')[&gt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;')  
An [HttpEnumOutcome&lt;T&gt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;') to indicate failure and also carry a default  
value of type [T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T').  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Success(System_Net_Http_HttpMethod_System_Collections_Generic_IReadOnlyCollection_T__int)'></a>
## HttpEnumOutcome&lt;T&gt;.Success(HttpMethod, IReadOnlyCollection&lt;T&gt;, int) Method
Creates and returns a successful outcome with a requested value.  
```csharp
public static TetraPak.AspNet.HttpEnumOutcome<T> Success(System.Net.Http.HttpMethod method, System.Collections.Generic.IReadOnlyCollection<T> value, int totalCount=0);
```
#### Parameters
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Success(System_Net_Http_HttpMethod_System_Collections_Generic_IReadOnlyCollection_T__int)_method'></a>
`method` [System.Net.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMethod 'System.Net.Http.HttpMethod')  
The HTTP request method used.  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Success(System_Net_Http_HttpMethod_System_Collections_Generic_IReadOnlyCollection_T__int)_value'></a>
`value` [System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')  
The value to be carried by the outcome.  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Success(System_Net_Http_HttpMethod_System_Collections_Generic_IReadOnlyCollection_T__int)_totalCount'></a>
`totalCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The total amount of items available from source.  
  
#### Returns
[TetraPak.AspNet.HttpEnumOutcome&lt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;')[T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T')[&gt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;')  
An [HttpEnumOutcome&lt;T&gt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;') to indicate success and also carry  
a value of type [T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T').  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Success(System_Net_Http_HttpMethod_T_int)'></a>
## HttpEnumOutcome&lt;T&gt;.Success(HttpMethod, T, int) Method
Creates and returns a successful outcome with a requested value.  
```csharp
public static TetraPak.AspNet.HttpEnumOutcome<T> Success(System.Net.Http.HttpMethod method, T singleValue, int totalCount=0);
```
#### Parameters
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Success(System_Net_Http_HttpMethod_T_int)_method'></a>
`method` [System.Net.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMethod 'System.Net.Http.HttpMethod')  
The HTTP request method used.  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Success(System_Net_Http_HttpMethod_T_int)_singleValue'></a>
`singleValue` [T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T')  
The value to be carried by the outcome.  
  
<a name='TetraPak_AspNet_HttpEnumOutcome_T__Success(System_Net_Http_HttpMethod_T_int)_totalCount'></a>
`totalCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The total amount of items available from source.  
  
#### Returns
[TetraPak.AspNet.HttpEnumOutcome&lt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;')[T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T')[&gt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;')  
An [HttpEnumOutcome&lt;T&gt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;') to indicate success and also carry  
a value of type [T](TetraPak_AspNet_HttpEnumOutcome_T_.md#TetraPak_AspNet_HttpEnumOutcome_T__T 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;.T').  
  
