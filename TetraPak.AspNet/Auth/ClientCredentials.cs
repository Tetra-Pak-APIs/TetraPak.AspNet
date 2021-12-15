namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Represents a set of client credentials, to reflect a certain "configuration level"
    ///   (<see cref="IServiceAuthConfig"/>). 
    /// </summary>
    public class ClientCredentials : Credentials
    {
        /// <summary>
        ///   Initializes the <see cref="ClientCredentials"/> from a specified
        ///   <see cref="IServiceAuthConfig"/>. 
        /// </summary>
        public ClientCredentials(IServiceAuthConfig config)
        : base(config.ClientId!, config.ClientSecret)
        {
        }
    }
}