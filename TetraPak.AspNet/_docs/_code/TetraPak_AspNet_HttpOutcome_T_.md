#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## HttpOutcome&lt;T&gt; Class
Represents the outcome of a HTTP request.  
```csharp
public class HttpOutcome<T> : TetraPak.Outcome<T>
```
#### Type parameters
<a name='TetraPak_AspNet_HttpOutcome_T__T'></a>
`T`  
The [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') of data requested.  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.Outcome](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome 'TetraPak.Outcome') &#129106; [TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') &#129106; HttpOutcome&lt;T&gt;  
### Constructors
<a name='TetraPak_AspNet_HttpOutcome_T__HttpOutcome(bool_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_T_System_Exception_)'></a>
## HttpOutcome&lt;T&gt;.HttpOutcome(bool, HttpMethod, T, Exception?) Constructor
Initializes the [HttpOutcome&lt;T&gt;](TetraPak_AspNet_HttpOutcome_T_.md 'TetraPak.AspNet.HttpOutcome&lt;T&gt;') object.  
```csharp
protected HttpOutcome(bool result, Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod method, T value, System.Exception? exception=null);
```
#### Parameters
<a name='TetraPak_AspNet_HttpOutcome_T__HttpOutcome(bool_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_T_System_Exception_)_result'></a>
`result` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Initializes the outcome result (success/failure).  
  
<a name='TetraPak_AspNet_HttpOutcome_T__HttpOutcome(bool_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_T_System_Exception_)_method'></a>
`method` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')  
Initializes the [Method](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__Method 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.Method').  
  
<a name='TetraPak_AspNet_HttpOutcome_T__HttpOutcome(bool_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_T_System_Exception_)_value'></a>
`value` [T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T')  
Initializes the [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value').  
  
<a name='TetraPak_AspNet_HttpOutcome_T__HttpOutcome(bool_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_T_System_Exception_)_exception'></a>
`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
Initializes the [Outcome<T>.Exception](https://docs.microsoft.com/en-us/dotnet/api/Outcome<T>.Exception 'Outcome<T>.Exception').  
  
  
### Properties
<a name='TetraPak_AspNet_HttpOutcome_T__Method'></a>
## HttpOutcome&lt;T&gt;.Method Property
Gets the HTTP request method used.  
```csharp
public Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod Method { get; }
```
#### Property Value
[Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')
  
### Methods
<a name='TetraPak_AspNet_HttpOutcome_T__Fail(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_System_Exception_T)'></a>
## HttpOutcome&lt;T&gt;.Fail(HttpMethod, Exception, T) Method
Creates and returns a failed outcome that carries an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') as well as a value.  
```csharp
public static TetraPak.AspNet.HttpOutcome<T> Fail(Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod method, System.Exception exception, T value);
```
#### Parameters
<a name='TetraPak_AspNet_HttpOutcome_T__Fail(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_System_Exception_T)_method'></a>
`method` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')  
The HTTP request method used.  
  
<a name='TetraPak_AspNet_HttpOutcome_T__Fail(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_System_Exception_T)_exception'></a>
`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
Assigns [Outcome<T>.Exception](https://docs.microsoft.com/en-us/dotnet/api/Outcome<T>.Exception 'Outcome<T>.Exception').  
  
<a name='TetraPak_AspNet_HttpOutcome_T__Fail(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_System_Exception_T)_value'></a>
`value` [T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T')  
Assigns [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value').  
  
#### Returns
[TetraPak.AspNet.HttpOutcome&lt;](TetraPak_AspNet_HttpOutcome_T_.md 'TetraPak.AspNet.HttpOutcome&lt;T&gt;')[T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T')[&gt;](TetraPak_AspNet_HttpOutcome_T_.md 'TetraPak.AspNet.HttpOutcome&lt;T&gt;')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate failure.  
  
<a name='TetraPak_AspNet_HttpOutcome_T__Fail(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_System_Exception)'></a>
## HttpOutcome&lt;T&gt;.Fail(HttpMethod, Exception) Method
Creates and returns a failed outcome that carries an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
```csharp
public static TetraPak.AspNet.HttpOutcome<T> Fail(Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod method, System.Exception exception);
```
#### Parameters
<a name='TetraPak_AspNet_HttpOutcome_T__Fail(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_System_Exception)_method'></a>
`method` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')  
The HTTP request method used.  
  
<a name='TetraPak_AspNet_HttpOutcome_T__Fail(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_System_Exception)_exception'></a>
`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
Assigns the [Outcome<T>.Exception](https://docs.microsoft.com/en-us/dotnet/api/Outcome<T>.Exception 'Outcome<T>.Exception').  
  
#### Returns
[TetraPak.AspNet.HttpOutcome&lt;](TetraPak_AspNet_HttpOutcome_T_.md 'TetraPak.AspNet.HttpOutcome&lt;T&gt;')[T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T')[&gt;](TetraPak_AspNet_HttpOutcome_T_.md 'TetraPak.AspNet.HttpOutcome&lt;T&gt;')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate failure.  
  
<a name='TetraPak_AspNet_HttpOutcome_T__Fail(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_T)'></a>
## HttpOutcome&lt;T&gt;.Fail(HttpMethod, T) Method
Creates and returns a failed outcome that also carries a specified value of type  
[T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T').  
```csharp
public static TetraPak.AspNet.HttpOutcome<T> Fail(Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod method, T value);
```
#### Parameters
<a name='TetraPak_AspNet_HttpOutcome_T__Fail(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_T)_method'></a>
`method` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')  
The HTTP request method used.  
  
<a name='TetraPak_AspNet_HttpOutcome_T__Fail(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_T)_value'></a>
`value` [T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T')  
Assigns [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value').  
  
#### Returns
[TetraPak.AspNet.HttpOutcome&lt;](TetraPak_AspNet_HttpOutcome_T_.md 'TetraPak.AspNet.HttpOutcome&lt;T&gt;')[T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T')[&gt;](TetraPak_AspNet_HttpOutcome_T_.md 'TetraPak.AspNet.HttpOutcome&lt;T&gt;')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate failure.  
  
<a name='TetraPak_AspNet_HttpOutcome_T__Fail(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod)'></a>
## HttpOutcome&lt;T&gt;.Fail(HttpMethod) Method
Creates and returns a failed outcome.  
```csharp
public static TetraPak.AspNet.HttpOutcome<T> Fail(Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod method);
```
#### Parameters
<a name='TetraPak_AspNet_HttpOutcome_T__Fail(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod)_method'></a>
`method` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')  
  
#### Returns
[TetraPak.AspNet.HttpOutcome&lt;](TetraPak_AspNet_HttpOutcome_T_.md 'TetraPak.AspNet.HttpOutcome&lt;T&gt;')[T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T')[&gt;](TetraPak_AspNet_HttpOutcome_T_.md 'TetraPak.AspNet.HttpOutcome&lt;T&gt;')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate failure and also carry a default  
value of type [T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T').  
  
<a name='TetraPak_AspNet_HttpOutcome_T__Success(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_T)'></a>
## HttpOutcome&lt;T&gt;.Success(HttpMethod, T) Method
Creates and returns a successful outcome with a requested value.  
```csharp
public static TetraPak.AspNet.HttpOutcome<T> Success(Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod method, T value);
```
#### Parameters
<a name='TetraPak_AspNet_HttpOutcome_T__Success(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_T)_method'></a>
`method` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')  
The HTTP request method used.  
  
<a name='TetraPak_AspNet_HttpOutcome_T__Success(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod_T)_value'></a>
`value` [T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T')  
The value to be carried by the outcome.  
  
#### Returns
[TetraPak.AspNet.HttpOutcome&lt;](TetraPak_AspNet_HttpOutcome_T_.md 'TetraPak.AspNet.HttpOutcome&lt;T&gt;')[T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T')[&gt;](TetraPak_AspNet_HttpOutcome_T_.md 'TetraPak.AspNet.HttpOutcome&lt;T&gt;')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success and also carry  
a value of type [T](TetraPak_AspNet_HttpOutcome_T_.md#TetraPak_AspNet_HttpOutcome_T__T 'TetraPak.AspNet.HttpOutcome&lt;T&gt;.T').  
  
