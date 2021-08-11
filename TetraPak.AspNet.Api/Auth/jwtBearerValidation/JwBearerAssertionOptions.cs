namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Used for configuring JWT Bearer Assertion.
    /// </summary>
    public class JwBearerAssertionOptions
    {
        public TetraPakApiAuthConfig Config { get; }

        public JwBearerAssertionOptions(TetraPakApiAuthConfig config)
        {
            Config = config;
        }
    }
}