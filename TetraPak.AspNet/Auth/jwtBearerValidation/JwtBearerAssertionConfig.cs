using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   This code API enables access and manipulation for the <see cref="IConfiguration"/> (appsettings.json)
    ///   sub section "JwtBearerAssertion";
    /// </summary>
    public class JwtBearerAssertionConfig : ConfigurationSection
    {
        // inserting this prefix into the DevProxy value will allow the DevProxy even if host is not local  
        const string DevProxyDebugQualifier = "debug://";
        
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
            get => GetFromFieldThenSection(parser: (string? value, out string? result) => tryGetDevProxy(value, out result));
            set => _devProxy = value;
        }

        /// <summary>
        ///   Gets a value that indicates whether a Development Proxy is specified to be run in debug mode.
        /// </summary>
        /// <remarks>
        ///   It is possible to force the use of a development proxy (in debug mode) even when the process
        ///   is not run in a local host. This will allow more diagnostic during JWT Bearer Assertion.   
        /// </remarks>
        public bool IsDebugDevProxy
        {
            get
            {
                var identifier = GetFromFieldThenSection(propertyName: nameof(DevProxy),  parser: (string? value, out string? result) =>
                    tryGetDevProxy(value, out result, false, false));
                return !string.IsNullOrWhiteSpace(identifier) && identifier.StartsWith(DevProxyDebugQualifier);
            }
        }

        static bool tryGetDevProxy(
            string? value, out string? result, 
            bool trimDebugQualifier = true,
            bool resolveAbsoluteUrl = true)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                result = value;
                return false;
            }
                
            result = trimDebugQualifier ? value.RejectPrefix(DevProxyDebugQualifier) : value;
            if (string.IsNullOrWhiteSpace(value))
                return false;

            if (resolveAbsoluteUrl && !result.Contains("://"))
            {
                result = $"https://api-dev.tetrapak.com/edge/developers/{result.RejectPrefix(DevProxyDebugQualifier)}/token";
            }
            return true;
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