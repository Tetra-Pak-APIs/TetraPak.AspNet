using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TetraPak.AspNet.Auth;
using TetraPak.Configuration;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet.Api
{
    [DebuggerDisplay("{" + nameof(ConfigPath) + "}")]
    public class ServiceAuthConfig : ConfigurationSection, IServiceAuthConfig
    {
        public const string ServicesConfigName = "Services";
        
        // ReSharper disable NotAccessedField.Local
        GrantType? _grantType;
        string _clientId;
        string _clientSecret;
        MultiStringValue _scope;
        // ReSharper restore NotAccessedField.Local

        IServiceProvider ServiceProvider { get; }

        public AmbientData AmbientData { get; }

        internal TetraPakAuthConfig AuthConfig => AmbientData.AuthConfig;
        
        protected IServiceAuthConfig ParentConfig { get; }
        
        // internal string Path { get; } obsolete

        internal bool IsAuthIdentifier(string identifier)
        {
            return identifier switch
            {
                nameof(ConfigPath) => true,
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
                        throw new FormatException($"Invalid auth mechanism: '{value}' ({ConfigPath}.{nameof(GrantType)})");

                    if (grantType == GrantType.Inherited)
                    {
                        grantType = ParentConfig.GrantType;
                    }

                    return true;
                });
            set => _grantType = value;
        }
        
        public virtual string ClientId
        {
            get => GetFromFieldThenSection<string>() ?? ParentConfig.ClientId;
            set => _clientId = value;
        }

        public virtual string ClientSecret
        {
            get => GetFromFieldThenSection<string>() ?? ParentConfig.ClientSecret;
            set => _clientSecret = value;
        }
        
        public virtual MultiStringValue Scope
        {
            get => GetFromFieldThenSection<MultiStringValue>() ?? ParentConfig.Scope;
            set => _scope = value;
        }

        public IConfiguration Configuration => Section;

        public static ConfigPath GetServiceConfigPath(string serviceName = null)
        {
            if (serviceName is null or ServicesConfigName)
                return $"{TetraPakAuthConfig.Identifier}{ConfigPath.Separator}{ServicesConfigName}";

            return serviceName.Contains(':')
                ? serviceName 
                : $"{TetraPakAuthConfig.Identifier}:{ServicesConfigName}:{serviceName}";
        }
        
        public ServiceInvalidEndpoint GetInvalidEndpoint(string endpointName, IEnumerable<Exception> issues)
        {
            return ServiceProvider.GetService<ServiceInvalidEndpoint>()?.WithInformation(endpointName, issues);
        }

        public ServiceAuthConfig(
            AmbientData ambientData,
            IServiceAuthConfig parentConfig,
            IServiceProvider serviceProvider,
            string sectionIdentifier = ServicesConfigName) 
        : base(parentConfig.Configuration, ambientData.Logger, GetServiceConfigPath(sectionIdentifier))
        {
            AmbientData = ambientData;
            ParentConfig = parentConfig;
            ServiceProvider = serviceProvider;
        }
    }
}