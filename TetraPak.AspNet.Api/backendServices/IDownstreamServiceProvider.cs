using System;

#nullable enable

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Classes implementing this contract are able to resolve backend services.
    /// </summary>
    public interface IDownstreamServiceProvider
    {
        /// <summary>
        ///   Resolves a service, based on its type and (optionally) service name
        /// </summary>
        /// <param name="serviceType">
        /// </param>
        /// <param name="serviceName">
        ///   Specifies a configured service. This is required if <paramref name="serviceType"/>
        ///   if just a generic backend service. 
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="IBackendService"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Outcome<IBackendService> ResolveService(Type serviceType, string? serviceName = null);
    }
}