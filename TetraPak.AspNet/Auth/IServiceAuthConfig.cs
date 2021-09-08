using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TetraPak.Configuration;

#nullable enable

namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Classes implementing this contract can provide information needed for authorization purposes. 
    /// </summary>
    public interface IServiceAuthConfig 
    {
        /// <summary>
        ///   Specifies the grant type (a.k.a. OAuth "flow") used at this configuration level.
        /// </summary>
        /// <exception cref="ConfigurationException">
        ///   The configured (textual) value could not be parsed into a <see cref="GrantType"/> (enum) value. 
        /// </exception>
        GrantType GrantType { get; }

        /// <summary>
        ///   Gets a client id.
        /// </summary>
        /// <param name="authContext">
        ///     Details the auth context in which the (confidential) client secrets are requested.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Cancellation token for cancellation the operation.
        /// </param>
        Task<Outcome<string>> GetClientIdAsync(AuthContext authContext, CancellationToken? cancellationToken = null);
        
        /// <summary>
        ///   Gets a client secret.
        /// </summary>
        /// <param name="authContext">
        ///   Details the auth context in which the (confidential) client secrets are requested.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Cancellation token for cancellation the operation.
        /// </param>
        Task<Outcome<string>> GetClientSecretAsync(AuthContext authContext, CancellationToken? cancellationToken = null);

        /// <summary>
        ///   Gets a scope to be requested for authorization.
        /// </summary>
        /// <param name="authContext">
        ///   Details the auth context in which the (confidential) client secrets are requested.
        /// </param>
        /// <param name="useDefault">
        ///   (optional)<br/>
        ///   Specifies a default value to be returned if scope cannot be resolved.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Cancellation token for cancellation the operation.
        /// </param>
        Task<Outcome<MultiStringValue>> GetScopeAsync(
            AuthContext authContext,
            MultiStringValue? useDefault = null,
            CancellationToken? cancellationToken = null);

        /// <summary>
        ///   Gets a "raw" configured value, as it is specified within the <see cref="IConfiguration"/> sources,
        ///   unaffected by delegates or other internal types of logic.
        /// </summary>
        /// <param name="key">
        ///   Identifies the requested value.
        /// </param>
        /// <returns>
        ///   A <see cref="string"/> when a value is configured; otherwise <c>null</c>.
        /// </returns>
        string? GetConfiguredValue(string key);

        /// <summary>
        ///   Gets the configuration path.
        /// </summary>
        ConfigPath? ConfigPath { get; }
        
        /// <summary>
        ///   Gets the <see cref="IConfiguration"/> instance used to populate the properties.
        /// </summary>
        IConfiguration Configuration { get; }
        
        /// <summary>
        ///   Gets an <see cref="AmbientData"/> object.
        /// </summary>
        AmbientData AmbientData { get; }

        /// <summary>
        ///   Gets a declaring configuration (when this configuration is a sub configuration).
        /// </summary>
        IServiceAuthConfig? ParentConfig { get; }
    }
}