#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Controllers](TetraPak_AspNet_Api_Controllers.md 'TetraPak.AspNet.Api.Controllers')
## ResponseDelegate&lt;T&gt;(object) Delegate
This type of delegate can be used to customize a response,  
before it is being transformed to the recommended Tetra Pak format and sent to the client.  
```csharp
public delegate System.Threading.Tasks.Task<TetraPak.Outcome<T>> ResponseDelegate<T>(object data);
```
#### Type parameters
<a name='TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_(object)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_(object)_data'></a>
`data` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[T](TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_(object).md#TetraPak_AspNet_Api_Controllers_ResponseDelegate_T_(object)_T 'TetraPak.AspNet.Api.Controllers.ResponseDelegate&lt;T&gt;(object).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
