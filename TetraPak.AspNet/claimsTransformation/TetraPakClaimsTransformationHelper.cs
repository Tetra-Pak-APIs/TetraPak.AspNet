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
        public static void AddTetraPakClaimsTransformation(this IServiceCollection c)
        {
            try
            {
                c.AddScoped<IClaimsTransformation,TetraPakClaimsTransformation>();
            }
            catch (Exception ex)
            {
                var p = c.BuildServiceProvider();
                var logger = p.GetService<ILogger<TetraPakClaimsTransformation>>();
                logger.Error(ex, $"Failed to register Tetra Pak API Claims Transformation ({typeof(TetraPakClaimsTransformation)}) with service collection");
            }
            c.AddHttpContextAccessor();
            c.TryAddScoped<AmbientData>();
            c.TryAddSingleton<TetraPakAuthConfig>();
        }

        /// <summary>
        ///   Sets up DI for access to Tetra Pak's User Information services.
        /// </summary>
        public static void AddTetraPakUserInformation(this IServiceCollection c)
        {
            c.TryAddScoped<TetraPakUserInformation>();
        }

        public static bool TryResolveIdClaim(this ClaimsPrincipal self, out string id, string[] fallbackClaimTypes)
        {
            // if (self.Identity?.Name is { }) obsolete
            // {
            //     id = self.Identity.Name;
            //     return true;
            // }

            foreach (var type in fallbackClaimTypes)
            {
                var claim = self.Claims.FirstOrDefault(c => c.Type == type);
                if (claim is null)
                    continue;
                
                id = claim.Value;
                return true;
            }

            id = null;
            return false;
        }

    }
    
}