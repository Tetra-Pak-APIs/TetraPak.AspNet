#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ServiceScope Enum
Can be used to specify a scope when configuring (DI) services.   
```csharp
public enum ServiceScope

```
#### Fields
<a name='TetraPak_AspNet_ServiceScope_Scoped'></a>
`Scoped` 1  
Specifies a scoped service (instantiated once per request/response roundtrip).   
  
<a name='TetraPak_AspNet_ServiceScope_Singleton'></a>
`Singleton` 0  
Specifies a singleton service (initiated once and used globally).  
  
<a name='TetraPak_AspNet_ServiceScope_Transient'></a>
`Transient` 2  
Specifies a transient service (instantiated every time requested by the service locator).  
  
<a name='TetraPak_AspNet_ServiceScope_Unspecified'></a>
`Unspecified` 3  
Service scope is unspecified.  
  
