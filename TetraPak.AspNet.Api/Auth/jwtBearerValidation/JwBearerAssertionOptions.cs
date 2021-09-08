namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Used for configuring JWT Bearer Assertion.
    /// </summary>
    public class JwBearerAssertionOptions
    {
        /// <summary>
        ///   Provides access to the Tetra Pak configuration.
        /// </summary>
        public TetraPakApiAuthConfig Config { get; }

        /// <summary>
        ///   Initializes the <see cref="JwBearerAssertionOptions"/>.
        /// </summary>
        /// <param name="config"></param>
        public JwBearerAssertionOptions(TetraPakApiAuthConfig config)
        {
            Config = config;
        }
    }
}