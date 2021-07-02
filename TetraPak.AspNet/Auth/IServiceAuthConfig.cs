namespace TetraPak.AspNet.Auth
{
    public interface IServiceAuthConfig
    {
        GrantType GrantType { get; }
        
        string ClientId { get; }
        
        string ClientSecret { get; }
        
        MultiStringValue Scope { get; }
    }
}