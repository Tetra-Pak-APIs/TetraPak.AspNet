using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TetraPak.AspNet.Auth;
using TetraPak.Configuration;
using TetraPak.Logging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

#nullable enable

namespace TetraPak.AspNet.Api
{
    [DebuggerDisplay("{" + nameof(ConfigPath) + "}")]
    public class ServiceAuthConfig : ConfigurationSection, IServiceAuthConfig
    {
        public const string ServicesConfigName = "Services";
        
        // ReSharper disable NotAccessedField.Local
        GrantType? _grantType;
        string? _clientId;
        string? _clientSecret;
        MultiStringValue? _scope;
        // ReSharper restore NotAccessedField.Local

        IServiceProvider ServiceProvider { get; }

        /// <inheritdoc />
        public AmbientData AmbientData { get; }

        internal TetraPakConfig Config => AmbientData.Config;
        
        /// <inheritdoc />
        public IServiceAuthConfig ParentConfig { get; }
        
        /// <summary>
        ///   Gets a value indicating whether the configuration has been delegated.  
        /// </summary>
        /// <see cref="ITetraPakConfigDelegate"/>
        protected virtual bool IsConfigDelegated => AmbientData.Config.IsDelegated;

        /// <inheritdoc />
        public bool IsAuthIdentifier(string identifier) => TetraPakConfig.CheckIsAuthIdentifier(identifier);

        /// <inheritdoc />
        public virtual GrantType GrantType
        {
            get => GetFromFieldThenSection(GrantType.Inherited, 
                (string value, out GrantType grantType) =>
                {
                    if (string.IsNullOrWhiteSpace(value))
                        value = GrantType.Inherited.ToString();

                    if (!TetraPakConfig.TryParseEnum(value, out grantType))
                        throw new FormatException($"Invalid auth mechanism: '{value}' ({ConfigPath}.{nameof(GrantType)})");

                    if (grantType == GrantType.Inherited)
                    {
                        grantType = ParentConfig.GrantType;
                    }

                    return true;
                });
            set => _grantType = value;
        }

        /// <inheritdoc />
        public string? GetConfiguredValue(string key) => Section?[key];
        
        [StateDump]
        public string? ClientId
        {
            get => GetClientIdAsync(new AuthContext(GrantType, this)).Result;
            set => _clientId = value?.Trim() ?? null!;
        }

        [StateDump]
        public string? ClientSecret
        {
            get => GetClientSecretAsync(new AuthContext(GrantType, this)).Result;
            set => _clientSecret = value?.Trim() ?? null!;
        }

        [StateDump]
        public MultiStringValue? Scope
        {
            get => GetScopeAsync(new AuthContext(GrantType, this)).Result;
            set => _scope = value!;
        }
        
        public IConfiguration Configuration => Section;

        /// <inheritdoc />
        public Task<Outcome<string>> GetClientIdAsync(
            AuthContext authContext, 
            CancellationToken? cancellationToken = null)
        {
            if (IsConfigDelegated || string.IsNullOrWhiteSpace(_clientId))
                return ParentConfig.GetClientIdAsync(authContext, cancellationToken);
            
            return Task.FromResult(Outcome<string>.Success(_clientId));
        }

        /// <inheritdoc />
        public Task<Outcome<string>> GetClientSecretAsync(
            AuthContext authContext, 
            CancellationToken? cancellationToken = null)
        {
            if (IsConfigDelegated || string.IsNullOrWhiteSpace(_clientSecret))
                return ParentConfig.GetClientSecretAsync(authContext, cancellationToken);
            
            return Task.FromResult(Outcome<string>.Success(_clientSecret));
        }

        /// <inheritdoc />
        public Task<Outcome<MultiStringValue>> GetScopeAsync(
            AuthContext authContext, 
            MultiStringValue? useDefault = null,
            CancellationToken? cancellationToken = null)
        {
            if (IsConfigDelegated || string.IsNullOrWhiteSpace(_scope))
                return ParentConfig.GetScopeAsync(authContext, useDefault, cancellationToken);
            
            return Task.FromResult(Outcome<MultiStringValue>.Success(_scope));
        }
        
        public static ConfigPath GetServiceConfigPath(string serviceName = null!)
        {
            if (serviceName is null or ServicesConfigName)
                return $"{TetraPakConfig.DefaultSectionIdentifier}{ConfigPath.Separator}{ServicesConfigName}";

            return serviceName.Contains(':')
                ? serviceName 
                : $"{TetraPakConfig.DefaultSectionIdentifier}:{ServicesConfigName}:{serviceName}";
        }
        
        public ServiceInvalidEndpoint GetInvalidEndpoint(string endpointName, IEnumerable<Exception> issues)
        {
            return ServiceProvider.GetRequiredService<ServiceInvalidEndpoint>().WithInformation(endpointName, issues);
        }
        
        public ServiceAuthConfig(
            IServiceProvider serviceProvider,
            IServiceAuthConfig parentConfig,
            string sectionIdentifier = ServicesConfigName) 
        : base(
            parentConfig.Configuration,
            serviceProvider.GetRequiredService<AmbientData>().Logger,
            GetServiceConfigPath(sectionIdentifier))
        {
            AmbientData = serviceProvider.GetRequiredService<AmbientData>();
            ParentConfig = parentConfig;
            ServiceProvider = serviceProvider;
        }
    }
}