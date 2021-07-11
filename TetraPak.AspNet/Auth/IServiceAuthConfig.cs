namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Classes implementing this contract can provide information needed fot authorization purposes.
    /// </summary>
    public interface IServiceAuthConfig
    {
        /// <summary>
        ///   Specifies the grant type (OAuth) or authorization mechanism. 
        /// </summary>
        GrantType GrantType { get; }
        
        /// <summary>
        ///   Gets the client id.
        /// </summary>
        string ClientId { get; }
        
        /// <summary>
        ///   Gets a client secret.
        /// </summary>
        string ClientSecret { get; }
        
        /// <summary>
        ///   Gets a scope to be requested for authorization.
        /// </summary>
        MultiStringValue Scope { get; }
    }
}