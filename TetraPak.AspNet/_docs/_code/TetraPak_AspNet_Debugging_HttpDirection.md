#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## HttpDirection Enum
Used to reflect HTTP traffic direction.  
```csharp
public enum HttpDirection

```
#### Fields
<a name='TetraPak_AspNet_Debugging_HttpDirection_Downstream'></a>
`Downstream` 2  
Represents outgoing traffic.  
#### See Also
- [Out](TetraPak_AspNet_Debugging_HttpDirection.md#TetraPak_AspNet_Debugging_HttpDirection_Out 'TetraPak.AspNet.Debugging.HttpDirection.Out')
  
<a name='TetraPak_AspNet_Debugging_HttpDirection_In'></a>
`In` 1  
Represents incoming traffic.  
#### See Also
- [Upstream](TetraPak_AspNet_Debugging_HttpDirection.md#TetraPak_AspNet_Debugging_HttpDirection_Upstream 'TetraPak.AspNet.Debugging.HttpDirection.Upstream')
  
<a name='TetraPak_AspNet_Debugging_HttpDirection_NotApplicable'></a>
`NotApplicable` 0  
The traffic direction is not applicable in the current context.  
#### See Also
- [Unknown](TetraPak_AspNet_Debugging_HttpDirection.md#TetraPak_AspNet_Debugging_HttpDirection_Unknown 'TetraPak.AspNet.Debugging.HttpDirection.Unknown')
  
<a name='TetraPak_AspNet_Debugging_HttpDirection_Out'></a>
`Out` 2  
Represents outgoing traffic.  
#### See Also
- [Downstream](TetraPak_AspNet_Debugging_HttpDirection.md#TetraPak_AspNet_Debugging_HttpDirection_Downstream 'TetraPak.AspNet.Debugging.HttpDirection.Downstream')
  
<a name='TetraPak_AspNet_Debugging_HttpDirection_Response'></a>
`Response` 3  
Represents a response to an outgoing request.  
  
<a name='TetraPak_AspNet_Debugging_HttpDirection_Unknown'></a>
`Unknown` 0  
The traffic direction is not known in the current context.  
#### See Also
- [NotApplicable](TetraPak_AspNet_Debugging_HttpDirection.md#TetraPak_AspNet_Debugging_HttpDirection_NotApplicable 'TetraPak.AspNet.Debugging.HttpDirection.NotApplicable')
  
<a name='TetraPak_AspNet_Debugging_HttpDirection_Upstream'></a>
`Upstream` 1  
Represents incoming traffic.  
#### See Also
- [In](TetraPak_AspNet_Debugging_HttpDirection.md#TetraPak_AspNet_Debugging_HttpDirection_In 'TetraPak.AspNet.Debugging.HttpDirection.In')
  
