namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Used for configuring Sidecar JWT Bearer Assertion.
    /// </summary>
    public class SidecarJwBearerAssertionOptions
    {
        public TetraPakApiAuthConfig Config { get; }

        public SidecarJwBearerAssertionOptions(TetraPakApiAuthConfig config)
        {
            Config = config;
        }
    }
}