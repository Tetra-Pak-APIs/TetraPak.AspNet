using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using TetraPak.AspNet.Auth;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet.Api
{
    public class ServicesAuthConfig : ConfigurationSection, IServiceAuthConfig
    {
        // ReSharper disable NotAccessedField.Local
        GrantType? _grantType;
        string _clientId;
        string _clientSecret;
        MultiStringValue _scope;
        // ReSharper restore NotAccessedField.Local

        IServiceProvider ServiceProvider { get; }

        public AmbientData AmbientData { get; }

        internal TetraPakAuthConfig AuthConfig => AmbientData.AuthConfig;
        
        internal string Path { get; }

        internal bool IsAuthIdentifier(string identifier)
        {
            return identifier switch
            {
                nameof(Path) => true,
                nameof(GrantType) => true,
                nameof(ClientId) => true,
                nameof(ClientSecret) => true,
                nameof(Scope) => true,
                _ => false
            };
        }

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
                        grantType = AuthConfig.GrantType;
                    }

                    return true;
                });
            set => _grantType = value;
        }
        
        public virtual string ClientId
        {
            get => GetFromFieldThenSection<string>() ?? AuthConfig.ClientId;
            set => _clientId = value;
        }

        public virtual string ClientSecret
        {
            get => GetFromFieldThenSection<string>() ?? AuthConfig.ClientSecret;
            set => _clientSecret = value;
        }
        
        public virtual MultiStringValue Scope
        {
            get => GetFromFieldThenSection<MultiStringValue>() ?? AuthConfig.Scope;
            set => _scope = value;
        }

        static string getSectionPath(string sectionIdentifier) =>
            sectionIdentifier.Contains(':')
                ? sectionIdentifier
                : $"{TetraPakAuthConfig.Identifier}:{sectionIdentifier}";
        
        public ServiceInvalidEndpoint GetInvalidEndpoint(string endpointName, IEnumerable<Exception> issues)
        {
            return ServiceProvider.GetService<ServiceInvalidEndpoint>()?.WithInformation(endpointName, issues);
        }

        public ServicesAuthConfig(
            AmbientData ambientData,
            IServiceProvider serviceProvider,
            string sectionIdentifier = "Services") 
        : base(ambientData.AuthConfig.Configuration, ambientData.Logger, getSectionPath(sectionIdentifier))
        {
            AmbientData = ambientData;
            ServiceProvider = serviceProvider;
            Path = getSectionPath(sectionIdentifier);
        }
    }
}