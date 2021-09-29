using System;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Classes implementing this interface can be relied on to provide the app with (custom) configuration. 
    /// </summary>
    public interface IClientConfigDelegate
    {
        /// <summary>
        ///   Gets client credentials (client id and, optionally, client secret).
        /// </summary>
        /// <param name="authContext">
        ///   Details the auth context in which the client credentials are requested.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Enables operation cancellation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="Credentials"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<Credentials>> GetClientCredentialsAsync(
            AuthContext authContext, 
            CancellationToken? cancellationToken);

        /// <summary>
        ///   Gets a scope to be used for the configured client.
        /// </summary>
        /// <param name="authContext">
        ///   Details the auth context in which the scope is requested.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Enables operation cancellation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="MultiStringValue"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<MultiStringValue>> GetScopeAsync(AuthContext authContext, CancellationToken? cancellationToken);
    }
}