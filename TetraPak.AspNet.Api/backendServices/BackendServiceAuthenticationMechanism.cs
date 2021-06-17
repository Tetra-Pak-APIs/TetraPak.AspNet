namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   used to specify an authentication mechanism when communicating with a backend service.
    /// </summary>
    public enum BackendServiceAuthenticationMechanism
    {
        /// <summary>
        ///   The service is authenticating itself towards the backend service by exchanging its
        ///   requesting actor's credentials.
        /// </summary>
        TokenExchange,
        
        /// <summary>
        ///   The service is authenticating itself towards the backend service through
        ///   its own client credentials (client id and client secret).
        /// </summary>
        ClientCredentials,
        
        /// <summary>
        ///   The service do not have to authenticate itself when consuming its backend service.
        /// </summary>
        None
    }
}