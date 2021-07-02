using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet.Api
{
    public class ServicesConfig : ConfigurationSection, IServiceAuthConfig
    {
        // ReSharper disable NotAccessedField.Local
        GrantType? _grantType;
        string _clientId;
        string _clientSecret;
        MultiStringValue _scope;

        readonly TetraPakAuthConfig _authConfig;
        // ReSharper restore NotAccessedField.Local

        protected override string SectionIdentifier { get; }
        
        internal string Path { get; }

        public IConfiguration Configuration => _authConfig.Configuration;

        public virtual GrantType GrantType
        {
            get => GetFromFieldThenSection(GrantType.Inherited, 
                (string value, out GrantType grantType) =>
                {
                    if (string.IsNullOrWhiteSpace(value))
                        value = GrantType.Inherited.ToString();

                    if (!TetraPakAuthConfig.TryParseEnum(value, out grantType))
                        throw new FormatException($"Invalid auth mechanism: '{value}' ({Path}.{nameof(GrantType)})");

                    if (grantType == GrantType.Inherited)
                    {
                        grantType = _authConfig.GrantType;
                    }

                    return true;
                });
            set => _grantType = value;
        }
        
        public virtual string ClientId
        {
            get => GetFromFieldThenSection<string>() ?? _authConfig.ClientId;
            set => _clientId = value;
        }

        public virtual string ClientSecret
        {
            get => GetFromFieldThenSection<string>() ?? _authConfig.ClientSecret;
            set => _clientSecret = value;
        }
        
        public virtual MultiStringValue Scope
        {
            get => GetFromFieldThenSection<MultiStringValue>() ?? _authConfig.Scope;
            set => _scope = value;
        }

        static string getSectionPath(string sectionIdentifier) =>
            sectionIdentifier.Contains(':')
                ? sectionIdentifier
                : $"{TetraPakAuthConfig.Identifier}:{sectionIdentifier}";

        public ServicesConfig(
            TetraPakAuthConfig authConfig, 
            ILogger<ServicesConfig> logger, 
            string sectionIdentifier = "Services") 
        : base(authConfig.Configuration, logger, getSectionPath(sectionIdentifier))
        {
            _authConfig = authConfig;
            SectionIdentifier = sectionIdentifier;
            Path = getSectionPath(sectionIdentifier);
        }
    }
}