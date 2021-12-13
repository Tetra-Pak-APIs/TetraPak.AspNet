using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Identity;
using TetraPak.Logging;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Provides convenience methods fo setting up claims transformation.
    /// </summary>
    public static class TetraPakClaimsTransformationHelper
    {
        /// <summary>
        ///   Sets up DI correctly for claims transformation.
        /// </summary>
        public static IServiceCollection AddTetraPakClaimsTransformation(this IServiceCollection c)
        {
            try
            {
                c.AddSingleton<IClaimsTransformation, TetraPakClaimsTransformationDispatcher>();
                c.AddTetraPakCustomClaimsTransformation<TetraPakJwtClaimsTransformation>();
            }
            catch (Exception ex)
            {
                var p = c.BuildServiceProvider();
                var logger = p.GetService<ILogger<TetraPakJwtClaimsTransformation>>();
                logger.Error(ex, $"Failed to register Tetra Pak API Claims Transformation ({typeof(TetraPakJwtClaimsTransformation)}) with service collection");
            }
            c.AddHttpContextAccessor();
            c.AddAmbientData();
            c.TryAddSingleton<TetraPakConfig>();
            return c;
        }

        /// <summary>
        ///   Configures the claims transformation mechanism to include a custom Tetra Pak claims transformer.
        /// </summary>
        /// <param name="c">
        ///   The service collection to be configured.
        /// </param>
        /// <param name="serviceScope">
        ///   (optional; default <see cref="TetraPakClaimsTransformation.DefaultServiceScope"/>)<br/>
        ///   The service scope to be used by the service locator. 
        /// </param>
        /// <typeparam name="T">
        ///   The custom claims transformer <see cref="Type"/> (must implement <see cref="ITetraPakClaimsTransformation"/>).
        /// </typeparam>
        /// <returns>
        ///   The service collection.
        /// </returns>
        public static IServiceCollection AddTetraPakCustomClaimsTransformation<T>(
            this IServiceCollection c, 
            ServiceScope? serviceScope = null)
        where T : class, ITetraPakClaimsTransformation
        {
            TetraPakClaimsTransformationDispatcher.AddCustomClaimsTransformation<T>(c, serviceScope);
            return c;
        }

        /// <summary>
        ///   Sets up DI for access to Tetra Pak's User Information services.
        /// </summary>
        public static void AddTetraPakUserInformation(this IServiceCollection c)
        {
            c.TryAddScoped<TetraPakUserInformation>();
        }

        /// <summary>
        ///   Looks up a specified <see cref="ClaimsPrincipal"/> claim and returns the outcome. 
        /// </summary>
        /// <param name="self">
        ///   The <see cref="ClaimsPrincipal"/> carrying the requested claim.
        /// </param>
        /// <param name="claimType">
        ///   The requested claim type.
        /// </param>
        /// <param name="fallbackClaimTypes">
        ///   (optional)<br/>
        ///   One or more claim types to be looked for if <paramref name="claimType"/> cannot be found. 
        /// </param>
        /// <returns>
        ///   <c>true</c> if the requested <paramref name="claimType"/>
        ///   (or any <paramref name="fallbackClaimTypes"/>) was found; otherwise <c>false</c>. 
        /// </returns>
        public static bool TryResolveClaim(
            this ClaimsPrincipal self, 
            [NotNullWhen(true)] out string? claimType, 
            params string[] fallbackClaimTypes)
        {
            var claim = self.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType);
            if (claim is { })
            {
                claimType = claim.Value;
                return true;
            }
            foreach (var type in fallbackClaimTypes)
            {
                claim = self.Claims.FirstOrDefault(c => c.Type == type);
                if (claim is null)
                    continue;
                
                claimType = claim.Value;
                return true;
            }

            claimType = null;
            return false;
        }
    }
}