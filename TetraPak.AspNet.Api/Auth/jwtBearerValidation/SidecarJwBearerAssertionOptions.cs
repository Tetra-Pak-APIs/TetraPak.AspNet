namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Used for configuring Sidecar JWT Bearer Assertion.
    /// </summary>
    public class SidecarJwBearerAssertionOptions
    {
        public TetraPakApiAuthConfig AuthConfig { get; }

        public SidecarJwBearerAssertionOptions(TetraPakApiAuthConfig authConfig)
        {
            AuthConfig = authConfig;
        }
    }
}