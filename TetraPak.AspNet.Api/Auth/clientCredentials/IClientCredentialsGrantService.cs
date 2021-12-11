﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Implementors of this interface are able to acquire a token using the
    ///   OAuth Client Credentials grant. 
    /// </summary>
    public interface IClientCredentialsGrantService
    {
        /// <summary>
        ///   Requests a token using the OAuth Client Credentials grant.   
        /// </summary>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   A cancellation token.
        /// </param>
        /// <param name="clientCredentials">
        ///   (optional)<br/>
        ///   Specifies client credentials.
        /// </param>
        /// <param name="scope">
        ///   (optional)<br/>
        ///   Scope to be requested for the authorization.
        /// </param>
        /// <param name="forceAuthorization">
        ///   (optional; default=<c>false</c>)<br/>
        ///   Specifies whether to force a new client credentials authorization
        ///   (overriding/replacing any cached authorization). 
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> instance indicating success/failure, and the requested token
        ///   when successful; otherwise an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<ClientCredentialsResponse>> AcquireTokenAsync(
            CancellationToken? cancellationToken = null,
            Credentials clientCredentials = null,
            MultiStringValue scope = null, 
            bool forceAuthorization = false);
    }
}