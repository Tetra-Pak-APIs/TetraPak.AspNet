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
        // ReSharper restore NotAccessedField.Local

        protected override string SectionIdentifier => "ValidateJwtBearer";

        public string Audience
        {
            get => GetFromFieldThenSection<string>(null);
            set => _audience = value;
        }
        
        public string Issuer 
        {
            get => GetFromFieldThenSection<string>(null);
            set => _issuer = value;
        }

        public bool ValidateLifetime
        {
            get => GetFromFieldThenSection(true);
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
    // ReSharper restore UnusedMember.Global
}