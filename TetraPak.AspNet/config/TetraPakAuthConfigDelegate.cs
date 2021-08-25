using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TetraPak.AspNet.Auth;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   A partial implementation of the <see cref="ITetraPakAuthConfigDelegate"/> contract.
    /// </summary>
    public abstract class TetraPakAuthConfigDelegate : ITetraPakAuthConfigDelegate
    {
        /// <inheritdoc />
        public virtual RuntimeEnvironment ResolveConfiguredEnvironment(string configuredValue) 
            => OnResolveConfiguredEnvironment(configuredValue);

        /// <inheritdoc />
        public Task<Outcome<Credentials>> GetClientSecretsAsync(AuthContext authContext) => OnGetClientSecretsAsync(authContext);

        /// <inheritdoc />
        public Task<Outcome<MultiStringValue>> GetScopeAsync(AuthContext authContext) => OnGetScopeAsync(authContext);

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
        protected abstract Task<Outcome<Credentials>> OnGetClientSecretsAsync(AuthContext authContext);

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
    }
}