using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet.Auth
{
    // ReSharper disable UnusedMember.Global
    public class JwtBearerValidationConfig : ConfigurationSection
    {
        // ReSharper disable NotAccessedField.Local
        string _audience;
        string _issuer;
        bool? _validateLifetime;
        string _devProxy;
        // ReSharper restore NotAccessedField.Local

        protected override string SectionIdentifier => "ValidateJwtBearer";

        public string Audience
        {
            get => GetFromFieldThenSection<string>();
            set => _audience = value;
        }
        
        public string Issuer 
        {
            get => GetFromFieldThenSection<string>();
            set => _issuer = value;
        }

        public bool ValidateLifetime
        {
            get => GetFromFieldThenSection(true);
            set => _validateLifetime = value;
        }

        public string DevProxy
        {
            get => GetFromFieldThenSection(parser: (string value, out string result) =>
            {
                // support specifying just the proxy name ...
                result = value;
                if (string.IsNullOrWhiteSpace(value))
                    return false;

                if (!value.Contains('/'))
                {
                    result = $"https://api-dev.tetrapak.com/edge/developers/{value}/token";
                }
                return true;
            });
            set => _devProxy = value;
        }

        public JwtBearerValidationConfig(
            IConfiguration configuration,
            ILogger logger,
            string sectionIdentifier = null)
        : base(configuration, logger, sectionIdentifier)
        {
        }
    }
    // ReSharper restore UnusedMember.Global
}