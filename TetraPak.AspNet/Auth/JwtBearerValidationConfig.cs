using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet.Auth
{
    public class JwtBearerValidationConfig : ConfigurationSection
    {
        string _audience;
        string _issuer;
        bool _validateLifetime;

        protected override string SectionIdentifier => "ValidateJwtBearer";

        public string Audience
        {
            get => _audience ?? Section[nameof(Audience)];
            set => _audience = value;
        }
        
        public string Issuer 
        {
            get => _issuer ?? Section[nameof(Issuer)];
            set => _issuer = value;
        }

        public bool ValidateLifetime
        {
            get => Section.GetNullableBool(nameof(ValidateLifetime)) ?? _validateLifetime;
            set => _validateLifetime = value;
        }

        public JwtBearerValidationConfig(
            IConfiguration configuration,
            ILogger logger,
            string sectionIdentifier = null)
        : base(configuration, logger, sectionIdentifier)
        {
        }
    }
}