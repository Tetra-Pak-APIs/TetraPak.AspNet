namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   used to specify an authentication method when communicating with a backend service.
    /// </summary>
    public enum GrantType
    {
        /// <summary>
        ///   The service do not have to authenticate itself when consuming its backend service.
        /// </summary>
        None,

        /// <summary>
        ///   Abbreviation for <see cref="TokenExchange"/>.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        TX,

        /// <summary>
        ///   The service is authenticating itself towards the backend service by exchanging its
        ///   requesting actor's credentials for it own credentials.
        /// </summary>
        TokenExchange = TX,

        /// <summary>
        ///   Abbreviation for <see cref="ClientCredentials"/>.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        CC,

        /// <summary>
        ///   The service is authenticating itself towards the backend service through
        ///   its own client credentials (client id and client secret).
        /// </summary>
        ClientCredentials = CC,
        
        /// <summary>
        ///   The service authentication mechanism is inherited from its parent service configuration.
        /// </summary>
        Inherited
    }
}