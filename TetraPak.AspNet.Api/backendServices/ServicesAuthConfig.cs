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

        internal TetraPakAuthConfig AuthConfig { get; }
        
        internal string Path { get; }

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
        
        public ServiceInvalidEndpointUrl GetInvalidEndpointUrl(string endpointName, IEnumerable<Exception> issues)
        {
            return ServiceProvider.GetService<ServiceInvalidEndpointUrl>()?.WithInformation(endpointName, issues);
        }

        public ServicesAuthConfig(
            TetraPakAuthConfig authConfig, 
            IServiceProvider serviceProvider,
            string sectionIdentifier = "Services") 
        : base(authConfig.Configuration, authConfig.Logger, getSectionPath(sectionIdentifier))
        {
            AuthConfig = authConfig;
            ServiceProvider = serviceProvider;
            Path = getSectionPath(sectionIdentifier);
        }
    }
}