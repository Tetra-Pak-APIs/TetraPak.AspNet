using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TetraPak.AspNet.Auth;
using TetraPak.SecretsManagement;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   A partial implementation of the <see cref="ITetraPakAuthConfigDelegate"/> contract.
    /// </summary>
    public class TetraPakAuthConfigDelegate : ITetraPakAuthConfigDelegate
    {
        readonly ISecretsProvider? _secretsProvider;
        readonly IServiceAuthConfig _authConfig;

        /// <inheritdoc />
        public virtual RuntimeEnvironment ResolveConfiguredEnvironment(string configuredValue) 
            => OnResolveConfiguredEnvironment(configuredValue);

        /// <inheritdoc />
        public Task<Outcome<Credentials>> GetClientCredentialsAsync(AuthContext authContext, CancellationToken? cancellationToken)
             => OnGetClientCredentialsAsync(authContext);

        /// <inheritdoc />
        public Task<Outcome<MultiStringValue>> GetScopeAsync(AuthContext authContext, CancellationToken? cancellationToken)
             => OnGetScopeAsync(authContext);

        /// <summary>
        ///   Called to obtain the client secrets for a specified "path". 
        /// </summary>
        /// <param name="authContext">
        ///   Details the auth context in which the (confidential) client secrets are requested.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="Credentials"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <remarks>
        ///   <para>
        ///   This implementation will use a configured <see cref="ISecretsProvider"/> service when available
        ///   to obtain both client id and client secret. If a client id cannot be found it will
        ///   try resolve the client id from the configuration instead.
        ///   </para>
        /// </remarks>
        protected virtual Task<Outcome<Credentials>> OnGetClientCredentialsAsync(AuthContext authContext)
        {
            return _secretsProvider is { }
                ? getClientCredentialsFromSecretsProvider(authContext)
                : getClientCredentialsFromConfiguration(authContext.GrantType);
        }

        async Task<Outcome<Credentials>> getClientCredentialsFromSecretsProvider(AuthContext authContext)
        {
            string clientId;
            var clientIdOutcome = await _secretsProvider!.GetSecretStringAsync(Secrets.ClientIdUri);
            if (clientIdOutcome)
            {
                clientId = clientIdOutcome.Value!;
            }
            else
            {
                // no client id provided from secrets provider; try resolve it from configuration ...
                var clientCredentialsOutcome = await getClientCredentialsFromConfiguration(GrantType.None);
                if (!clientCredentialsOutcome)
                    return Outcome<Credentials>.Fail(clientCredentialsOutcome.Exception);

                clientId = clientCredentialsOutcome.Value!.Identity;
            }

            var grantType = authContext.GrantType;
            var clientSecretOutcome = await _secretsProvider.GetSecretStringAsync(Secrets.ClientSecretUri);
            if (!clientIdOutcome && authContext.GrantType.IsClientSecretRequired())
                return Outcome<Credentials>.Fail(
                    new ConfigurationException(
                        $"Could not resolve a client secret for grant type: {grantType.ToString()}"));

            var clientSecret = clientSecretOutcome.Value!;
            return Outcome<Credentials>.Success(new Credentials(clientId, clientSecret));
        }

        Task<Outcome<Credentials>> getClientCredentialsFromConfiguration(GrantType grantType)
        {
            var clientId = _authConfig.GetConfiguredValue(nameof(TetraPakAuthConfig.ClientId));
            if (string.IsNullOrWhiteSpace(clientId))
                return Task.FromResult(Outcome<Credentials>.Fail(
                    new ConfigurationException($"{nameof(TetraPakAuthConfig.ClientId)} value is missing "+
                                               "(or empty) in Tetra Pak configuration")));
            
            var clientSecret = _authConfig.GetConfiguredValue(nameof(TetraPakAuthConfig.ClientSecret));
            if (string.IsNullOrWhiteSpace(clientSecret) && grantType.IsClientSecretRequired())
                return Task.FromResult(Outcome<Credentials>.Fail(
                    new ConfigurationException($"{nameof(TetraPakAuthConfig.ClientSecret)} value is missing "+
                                               "(or empty) in Tetra Pak configuration")));

            return Task.FromResult(Outcome<Credentials>.Success(new Credentials(clientId, clientSecret)));
        }

        // bool tryGetTetraPakConfig(out IConfigurationSection section)
        // {
        //     var key = TetraPakAuthConfig.DefaultSectionIdentifier;
        //     section = _tetraPakConfig.GetSection(key);
        //     if (section is null || section.IsEmpty())
        //         return false;
        //
        //     return true;
        // }

        /// <summary>
        ///   Called to obtain the client's requested scope.
        /// </summary>
        /// <param name="authContext">
        ///   Details the auth context in which the (confidential) client secrets are requested.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="MultiStringValue"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected virtual Task<Outcome<MultiStringValue>> OnGetScopeAsync(AuthContext authContext)
        {
            return Task.FromResult(Outcome<MultiStringValue>.Success(MultiStringValue.Empty));
        }

        /// <summary>
        ///   Called internally to resolve the runtime environment.
        /// </summary>
        /// <param name="configuredValue">
        ///   A value obtained from the Tetra Pak configuration. 
        /// </param>
        /// <returns>
        ///   A <see cref="RuntimeEnvironment"/> value.
        /// </returns>
        protected virtual RuntimeEnvironment OnResolveConfiguredEnvironment(string? configuredValue)
        {
            return configuredValue is { } 
                ? Enum.Parse<RuntimeEnvironment>(configuredValue) 
                : TetraPakAuthConfig.ResolveRuntimeEnvironment(configuredValue);
        }
        
        /// <summary>
        ///   Looks for a configured value within the hierarchy of <see cref="IConfiguration"/> framework,
        ///   unaffected by delegate or other types of internal logic.
        /// </summary>
        /// <param name="key">
        ///   Identifies the requested configured value.
        /// </param>
        /// <param name="context">
        ///   The <see cref="AuthContext"/> instance.
        /// </param>
        /// <param name="value">
        ///   Passes back the value when found; otherwise <c>null</c>. 
        /// </param>
        /// <param name="fallbackToParentValue">
        ///   (optional; default=<c>false</c>)<br/>
        ///   Specifies whether to automatically traverse the <see cref="IConfiguration"/> framework,
        ///   looking for the requested value in configurations higher up in the hierarchy.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the requested value was found; otherwise <c>false</c>.
        /// </returns>
        protected static bool TryGetConfiguredValue(
            string key, 
            AuthContext context, 
            out string? value, 
            bool fallbackToParentValue = false)
        {
            return tryGetConfiguredValueTraversed(context.AuthConfig, out value);

            bool tryGetConfiguredValueTraversed(IServiceAuthConfig? authConfig, out string? configuredValue)
            {
                while (authConfig is {})
                {
                    configuredValue = authConfig.GetConfiguredValue(key);
                    if (configuredValue is { })
                        return true;

                    if (!fallbackToParentValue)
                    {
                        configuredValue = null;
                        return false;
                    }

                    authConfig = authConfig.ParentConfig;
                }
                
                configuredValue = null;
                return false;
            }
        }

        /// <summary>
        ///   Initializes the <see cref="TetraPakAuthConfigDelegate"/>.
        /// </summary>
        /// <param name="tetraPakConfig">
        ///   The Tetra Pak configuration code API.
        /// </param>
        /// <param name="secretsProvider">
        ///   (optional)<br/>
        ///   A provider of secrets. 
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="tetraPakConfig"/> was unassigned (<c>null</c>).
        /// </exception>
        public TetraPakAuthConfigDelegate(IServiceAuthConfig tetraPakConfig, ISecretsProvider? secretsProvider = default)
        {
            _authConfig = tetraPakConfig ?? throw new ArgumentNullException(nameof(tetraPakConfig));
            _secretsProvider = secretsProvider;
        }
    }
}