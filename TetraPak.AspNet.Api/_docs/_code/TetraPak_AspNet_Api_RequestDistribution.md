#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## RequestDistribution Enum
Used to specify the request thread distribution when performing multiple resource requests.  
```csharp
public enum RequestDistribution

```
#### Fields
<a name='TetraPak_AspNet_Api_RequestDistribution_Parallel'></a>
`Parallel` 1  
Multiple requests are made in parallel (in worker threads).  
  
<a name='TetraPak_AspNet_Api_RequestDistribution_Sequential'></a>
`Sequential` 0  
Multiple requests are made in sequence (in same thread).  
  
