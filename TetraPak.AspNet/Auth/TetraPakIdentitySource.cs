namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Used to specify a source for obtaining identity information.  
    /// </summary>
    public enum TetraPakIdentitySource
    {
        /// <summary>
        ///   Identity information is obtained from an existing identity token.
        ///   This is the fastest method and might be sufficient in scenarios where the app doesn't need
        ///   exhaustive user information, beyond the user's identity.
        /// </summary>
        IdToken,
        
        /// <summary>
        ///   Identity information is automatically requested from a (remote) service.
        ///   This method is slower but might be necessary to obtain more detailed user information. 
        /// </summary>
        RemoteService
    }
}