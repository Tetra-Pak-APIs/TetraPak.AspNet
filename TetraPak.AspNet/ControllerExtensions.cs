using System;
using System.Diagnostics.CodeAnalysis;
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
        public static Task<Outcome<ActorToken>> GetAccessTokenAsync(this Controller self)
        {
            return self.HttpContext.Request.GetAccessTokenAsync();
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
        public static Task<Outcome<ActorToken>> GetIdentityTokenAsync(this Controller self)
        {
            return self.HttpContext.GetIdentityTokenAsync();
        }

        /// <summary>
        ///   Attempts obtaining the <see cref="TetraPakConfig"/> instance.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="Controller"/> instance.
        /// </param>
        /// <param name="tetraPakConfig">
        ///   Passes back the <see cref="TetraPakConfig"/> instance if successful; otherwise <c>null</c>. 
        /// </param>
        /// <returns>
        ///   <c>true</c> 
        /// </returns>
        // ReSharper disable once MemberCanBePrivate.Global
        public static bool TryGetTetraPakConfig(
            this Controller self, 
            [NotNullWhen(true)] out TetraPakConfig? tetraPakConfig)
        {
            tetraPakConfig = self.HttpContext.RequestServices.GetService<TetraPakConfig>();
            return tetraPakConfig is {};
        }
    }
}