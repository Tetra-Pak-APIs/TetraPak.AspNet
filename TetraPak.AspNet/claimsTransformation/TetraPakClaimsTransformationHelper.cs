using System;
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
                c.AddCustomClaimsTransformation<TetraPakJwtClaimsTransformation>();
                // c.AddScoped<IDefaultClaimsTransformation, TetraPakClaimsTransformation>();
            }
            catch (Exception ex)
            {
                var p = c.BuildServiceProvider();
                var logger = p.GetService<ILogger<TetraPakJwtClaimsTransformation>>();
                logger.Error(ex, $"Failed to register Tetra Pak API Claims Transformation ({typeof(TetraPakJwtClaimsTransformation)}) with service collection");
            }
            c.AddHttpContextAccessor();
            c.AddAmbientData();
            c.TryAddSingleton<TetraPakAuthConfig>();
            return c;
        }

        public static IServiceCollection AddCustomClaimsTransformation<T>(
            this IServiceCollection c, 
            ServiceScope? serviceScope = null)
        where T : class, ITetraPakClaimsTransformation
        {
            TetraPakClaimsTransformationDispatcher.AddCustomClaimsTransformation<T>(c, serviceScope);
            return c;
        }

        public static IServiceCollection AddCustomClaimsTransformation(
            this IServiceCollection c,
            ClaimsTransformationFactory factory)
        {
            TetraPakClaimsTransformationDispatcher.AddCustomClaimsTransformation(factory);
            return c;
        }

        /// <summary>
        ///   Sets up DI for access to Tetra Pak's User Information services.
        /// </summary>
        public static void AddTetraPakUserInformation(this IServiceCollection c)
        {
            c.TryAddScoped<TetraPakUserInformation>();
        }

        public static bool TryResolveIdClaim(this ClaimsPrincipal self, out string id, params string[] fallbackClaimTypes)
        {
            var claim = self.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType);
            if (claim is { })
            {
                id = claim.Value;
                return true;
            }
            foreach (var type in fallbackClaimTypes)
            {
                claim = self.Claims.FirstOrDefault(c => c.Type == type);
                if (claim is null)
                    continue;
                
                id = claim.Value;
                return true;
            }

            id = null;
            return false;
        }

        public static bool TryResolveIdClaim(this ClaimsIdentity self, out string id, params string[] fallbackClaimTypes)
        {
            var claim = self.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType);
            if (claim is { })
            {
                id = claim.Value;
                return true;
            }
            foreach (var type in fallbackClaimTypes)
            {
                claim = self.Claims.FirstOrDefault(c => c.Type == type);
                if (claim is null)
                    continue;
                
                id = claim.Value;
                return true;
            }

            id = null;
            return false;
        }

    }

    public enum ServiceScope
    {
        Singleton,
        
        Scoped,
        
        Transient,
        
        Unspecified
    }
}