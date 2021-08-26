using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TetraPak.AspNet.Identity;

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
            c.AddHttpContextAccessor();
            c.TryAddTransient<AmbientData>();
            c.TryAddSingleton<TetraPakAuthConfig>();
            c.TryAddTransient<IClaimsTransformation, TetraPakClaimsTransformation>();
        }

        /// <summary>
        ///   Sets up DI for access to Tetra Pak's User Information services.
        /// </summary>
        public static void AddTetraPakUserInformation(this IServiceCollection c)
        {
            c.TryAddSingleton<TetraPakUserInformation>();
        }
    }
}