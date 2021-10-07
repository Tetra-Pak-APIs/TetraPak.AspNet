using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Convenient extension methods for a <see cref="Controller"/>.
    /// </summary>
    public static class ControllerExtensions
    {
        /// <summary>
        ///   Gets an access token if present in the request.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="Controller"/> instance.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="ConfigurationException">
        ///   No <see cref="TetraPakConfig"/> service could be obtained from service locator.
        /// </exception>
        public static Task<Outcome<ActorToken>> GetAccessTokenAsync(this Controller self)
        {
            if (!self.TryGetTetraPakAuthConfig(out var config))
                return Task.FromResult(Outcome<ActorToken>.Fail(
                    new ConfigurationException(
                        "Cannot get access token. Failed to obtain a "+
                        $" configuration ({typeof(TetraPakConfig)})")));
                
            return self.HttpContext.Request.GetAccessTokenAsync(config);
        }

        /// <summary>
        ///   Gets an identity token if present in the request.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="Controller"/> instance.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="ConfigurationException">
        ///   No <see cref="TetraPakConfig"/> service could be obtained from service locator.
        /// </exception>
        public static Task<Outcome<ActorToken>> GetIdentityTokenAsync(this Controller self)
        {
            if (!self.TryGetTetraPakAuthConfig(out var config))
                return Task.FromResult(Outcome<ActorToken>.Fail(
                    new ConfigurationException(
                        "Cannot get identity token. Failed to obtain a "+
                        $" configuration ({typeof(TetraPakConfig)})")));
                
            return self.HttpContext.Request.GetAccessTokenAsync(config);
        }

        /// <summary>
        ///   Attempts obtaining the <see cref="TetraPakConfig"/> instance.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="Controller"/> instance.
        /// </param>
        /// <param name="config">
        ///   Passes back the <see cref="TetraPakConfig"/> instance if successful; otherwise <c>null</c>. 
        /// </param>
        /// <returns>
        ///   <c>true</c> 
        /// </returns>
        public static bool TryGetTetraPakAuthConfig(this Controller self, out TetraPakConfig config)
        {
            config = self.HttpContext.RequestServices.GetService<TetraPakConfig>();
            return config is {};
        }
    }
}