#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ResourceNotFoundException Class
Represents an issue where a requested resource was not found.  
```csharp
public class ResourceNotFoundException : TetraPak.AspNet.HttpException
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') &#129106; [TetraPak.AspNet.HttpException](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.HttpException 'TetraPak.AspNet.HttpException') &#129106; ResourceNotFoundException  
### Constructors
<a name='TetraPak_AspNet_ResourceNotFoundException_ResourceNotFoundException(string_System_Exception_)'></a>
## ResourceNotFoundException.ResourceNotFoundException(string, Exception?) Constructor
Initializes a new instance of the [ResourceNotFoundException](TetraPak_AspNet_ResourceNotFoundException.md 'TetraPak.AspNet.ResourceNotFoundException') class with a specified  
error message and (optionally) a reference to the inner exception that is the cause of this exception.  
```csharp
public ResourceNotFoundException(string message, System.Exception? inner=null);
```
#### Parameters
<a name='TetraPak_AspNet_ResourceNotFoundException_ResourceNotFoundException(string_System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The error message that explains the reason for the exception.  
  
<a name='TetraPak_AspNet_ResourceNotFoundException_ResourceNotFoundException(string_System_Exception_)_inner'></a>
`inner` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
  
