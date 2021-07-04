namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Used for configuring Sidecar JWT Bearer Assertion.
    /// </summary>
    public class SidecarJwBearerAssertionOptions
    {
        public TetraPakAuthApiConfig Config { get; }

        public SidecarJwBearerAssertionOptions(TetraPakAuthApiConfig config)
        {
            Config = config;
        }
    }
}