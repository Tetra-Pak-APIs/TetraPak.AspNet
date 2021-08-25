using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Used to describe an auth request context.
    /// </summary>
    /// <seealso cref="TetraPakAuthConfig.ConfigDelegate"/>
    public class AuthContext
    {
        /// <summary>
        ///   Specifies the requested <see cref="GrantType"/>.
        /// </summary>
        public GrantType GrantType { get; }

        /// <summary>
        ///   Gets the <see cref="IServiceAuthConfig"/> object.
        /// </summary>
        public IServiceAuthConfig AuthConfig { get; }
        
        public AuthContext(GrantType grantType, IServiceAuthConfig authConfig)
        {
            GrantType = grantType;
            AuthConfig = authConfig;
        }
    }
}