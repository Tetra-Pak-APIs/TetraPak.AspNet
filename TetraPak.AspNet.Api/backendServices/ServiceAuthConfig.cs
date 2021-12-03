using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Configuration;
using TetraPak.Logging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

#nullable enable

namespace TetraPak.AspNet.Api
{
    [DebuggerDisplay("{" + nameof(ConfigPath) + "}")]
    class ServiceAuthConfig : ConfigurationSection, IServiceAuthConfig 
    {
        public const string ServicesConfigName = "Services";
        
        // ReSharper disable NotAccessedField.Local
        GrantType? _grantType;
        string? _clientId;
        string? _clientSecret;
        MultiStringValue? _scope;
        // ReSharper restore NotAccessedField.Local

        // IServiceProvider ServiceProvider { get; } obsolete

        /// <inheritdoc />
        public AmbientData AmbientData { get; }

        internal TetraPakConfig Config => AmbientData.TetraPakConfig;
        
        /// <inheritdoc />
        public IServiceAuthConfig ParentConfig { get; }
        
        /// <summary>
        ///   Gets a value indicating whether the configuration has been delegated.  
        /// </summary>
        /// <see cref="ITetraPakConfigDelegate"/>
        protected virtual bool IsConfigDelegated => AmbientData.TetraPakConfig.IsDelegated;

        /// <inheritdoc />
        public bool IsAuthIdentifier(string identifier) => TetraPakConfig.CheckIsAuthIdentifier(identifier);

        /// <inheritdoc />
        public string? GetConfiguredValue(string key) => Section?[key];
        
        /// <inheritdoc />
        [StateDump]
        public virtual GrantType GrantType
        {
            get => GetFromFieldThenSection(GrantType.Inherited, 
                (string? value, out GrantType grantType) =>
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
        
        [StateDump]
        public string? ClientId
        {
            get => GetClientIdAsync(new AuthContext(GrantType, this)).Result.Value;
            set => _clientId = value?.Trim() ?? null!;
        }

        [StateDump, RestrictedValue(DisclosureLogLevel = LogLevel.Debug)]
        public string? ClientSecret
        {
            get => GetClientSecretAsync(new AuthContext(GrantType, this)).Result.Value;
            set => _clientSecret = value?.Trim() ?? null!;
        }

        [StateDump]
        public MultiStringValue? Scope
        {
            get => GetScopeAsync(new AuthContext(GrantType, this)).Result.Value;
            set => _scope = value!;
        }
        
        public IConfiguration Configuration => Section!;

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
                return $"{TetraPakConfig.DefaultSectionIdentifier}{ConfigPath.ConfigDefaultSeparator}{ServicesConfigName}";

            return serviceName.Contains(':')
                ? serviceName 
                : $"{TetraPakConfig.DefaultSectionIdentifier}:{ServicesConfigName}:{serviceName}";
        }
        
        public ServiceInvalidEndpoint GetInvalidEndpoint(string endpointName, IEnumerable<Exception> issues)
        {
            return new ServiceInvalidEndpoint(endpointName, issues);
        }
        
        public async Task<bool> GetStateDumpAsync(object source, StateDumpContext context)
        {
            if (source is TetraPakConfig)
            {
                var stateDump = new StateDump(context);
                await stateDump.AddAsync(this, ConfigPath!.Last());
                return true;
            }

            if (source is ServiceAuthConfig)
            {
                var services = TetraPakBackendServiceProvider.GetConfiguredServices();
                foreach (var service in services)
                {
                    var stateDump = new StateDump(context);
                    await stateDump.AddAsync(service, service.ServiceName);
                }
                return true;
            }

            if (source is IBackendService backendService)
            {
                foreach (var (name, endpoint) in backendService.GetEndpoints())
                {
                    var stateDump = new StateDump(context);
                    await stateDump.AddAsync(endpoint, name);
                }
                return true;
            }

            if (source is ServiceEndpoint serviceEndpoint)
            {
                context.Append(context.Indentation);
                context.Append("\"Url\": \"");
                context.Append(serviceEndpoint.GetUrl(false));
                context.AppendLine("\"");
                return true;
            }

            return false;
        }
        
        // public ServiceAuthConfig(
        //     IServiceProvider serviceProvider, obsolete
        //     IServiceAuthConfig parentConfig,
        //     string sectionIdentifier = ServicesConfigName) 
        // : this(
        //     parentConfig,
        //     serviceProvider.GetRequiredService<AmbientData>(),
        //     GetServiceConfigPath(sectionIdentifier))
        // {
        //     // AmbientData = serviceProvider.GetRequiredService<AmbientData>();
        //     // ParentConfig = parentConfig;
        //     // ServiceProvider = serviceProvider;
        //     // StateDump.Attach(GetStateDumpAsync);
        // }
        
        internal ServiceAuthConfig(
            IServiceAuthConfig parentConfig,
            AmbientData ambientData,
            string sectionIdentifier = ServicesConfigName) 
        : base(
            parentConfig.Configuration,
            ambientData.Logger,
            GetServiceConfigPath(sectionIdentifier))
        {
            AmbientData = ambientData;
            ParentConfig = parentConfig;
            StateDump.Attach(GetStateDumpAsync);
        }
    }
}