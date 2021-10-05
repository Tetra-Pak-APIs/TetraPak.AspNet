using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

#nullable enable

namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   This code API enables access and manipulation for the <see cref="IConfiguration"/> (appsettings.json)
    ///   sub section "JwtBearerAssertion";
    /// </summary>
    public class JwtBearerAssertionConfig : ConfigurationSection
    {
        // ReSharper disable NotAccessedField.Local
        string? _audience;
        string? _issuer;
        bool? _validateLifetime;
        string? _devProxy;
        string? _authenticationScheme;
        HttpComparison? _devProxyIsMutedWhen;
        // ReSharper restore NotAccessedField.Local

        /// <summary>
        ///   Gets or sets a (custom) name for the JWT bearer assertion scheme.
        ///   If left unassigned the default will be "Bearer".
        /// </summary>
        public string? AuthenticationScheme
        {
            get => GetFromFieldThenSection<string>();
            set => _authenticationScheme = value;
        }

        /// <summary>
        ///   Gets or sets the default configuration section identifier
        ///   recognized by <see cref="JwtBearerAssertionConfig"/>.
        /// </summary>
        public static string DefaultSectionIdentifier { get; set; } = "JwtBearerAssertion";

        /// <summary>
        ///   Gets or sets the required JWT audience ("aud").
        /// </summary>
        public string? Audience
        {
            get => GetFromFieldThenSection<string>();
            set => _audience = value;
        }
        
        /// <summary>
        ///   Gets or sets the required JWT issuer ("iss").
        /// </summary>
        public string? Issuer 
        {
            get => GetFromFieldThenSection<string>();
            set => _issuer = value;
        }

        /// <summary>
        ///   Gets or sets a value specifying whether to validate the JWT lifetime.
        /// </summary>
        public bool ValidateLifetime
        {
            get => GetFromFieldThenSection(true);
            set => _validateLifetime = value;
        }

        /// <summary>
        ///   Specifies the proxy (a.k.a. "sidecar") protecting the API. The value can be the full
        ///   URL to the proxy's "development token endpoint" or just the proxy name.
        /// </summary>
        public string? DevProxy
        {
            get => GetFromFieldThenSection(parser: (string value, out string result) =>
            {
                // support specifying just the proxy name ...
                result = value;
                if (string.IsNullOrWhiteSpace(value))
                    return false;

                if (!value.Contains("://"))
                {
                    result = $"https://api-dev.tetrapak.com/edge/developers/{value}/token";
                }
                return true;
            });
            set => _devProxy = value;
        }
        
        /// <summary>
        ///   Gets or sets a criteria that (when true) disables the DevProxy during the current
        ///   request/response round trip. 
        /// </summary>
        public HttpComparison? DevProxyIsMutedWhen
        {
            get => GetFromFieldThenSection<string>();
            set => _devProxyIsMutedWhen = value;
        }

        /// <summary>
        ///   Initializes the code API. 
        /// </summary>
        /// <param name="configuration">
        ///   The <see cref="IConfiguration"/> object.
        /// </param>
        /// <param name="logger">
        ///   A logger provider.
        /// </param>
        /// <param name="sectionIdentifier">
        ///   (optional; default=<see cref="DefaultSectionIdentifier"/>)<br/>
        ///   Specifies the section identifier for the code API. 
        /// </param>
        public JwtBearerAssertionConfig(
            IConfiguration configuration,
            ILogger? logger,
            string? sectionIdentifier = null)
        : base(configuration, logger, sectionIdentifier ?? DefaultSectionIdentifier)
        {
        }
    }
}