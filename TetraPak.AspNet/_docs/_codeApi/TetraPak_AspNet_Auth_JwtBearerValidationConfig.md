#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## JwtBearerValidationConfig Class
```csharp
public class JwtBearerValidationConfig : TetraPak.Configuration.ConfigurationSection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') &#129106; JwtBearerValidationConfig  
### Properties
<a name='TetraPak_AspNet_Auth_JwtBearerValidationConfig_SectionIdentifier'></a>
## JwtBearerValidationConfig.SectionIdentifier Property
Can be overridden. Returns the expected configuration section identifier like in this example:<br />```csharp
  
"MySection": {  
  :  
}  
```
```csharp
public override string SectionIdentifier { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
