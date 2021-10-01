#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Mapping](TetraPak_AspNet_Api_Mapping.md 'TetraPak.AspNet.Api.Mapping')
## DtoMappingStrategy Enum
```csharp
public enum DtoMappingStrategy

```
#### Fields
<a name='TetraPak_AspNet_Api_Mapping_DtoMappingStrategy_All'></a>
`All` 0  
All values are included.  
  
<a name='TetraPak_AspNet_Api_Mapping_DtoMappingStrategy_ConvertOnly'></a>
`ConvertOnly` 3  
No key --> key mapping. Assume mapping was already done and just convert.  
  
<a name='TetraPak_AspNet_Api_Mapping_DtoMappingStrategy_MappedOnly'></a>
`MappedOnly` 1  
Only values that can be found in the map are included.  
  
<a name='TetraPak_AspNet_Api_Mapping_DtoMappingStrategy_PropertiesOnly'></a>
`PropertiesOnly` 2  
Only values that can be mapped to a target property are included.  
  
