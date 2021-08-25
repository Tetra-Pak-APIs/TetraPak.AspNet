using System;
using System.Threading.Tasks;

#nullable enable

namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Classes implementing this interface can be relied on to provide the app with a client id and client secret. 
    /// </summary>
    public interface IClientConfigProvider
    {
        /// <summary>
        ///   Gets (confidential) client secrets (client id and, optionally, client secret).
        /// </summary>
        /// <param name="authContext">
        ///   Details the auth context in which the (confidential) client secrets are requested.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="Credentials"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<Credentials>> GetClientSecretsAsync(AuthContext authContext);

        /// <summary>
        ///   Gets a scope to be used for the configured client.
        /// </summary>
        /// <param name="authContext">
        ///   Details the auth context in which the scope is requested.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="MultiStringValue"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<MultiStringValue>> GetScopeAsync(AuthContext authContext);

    }
}