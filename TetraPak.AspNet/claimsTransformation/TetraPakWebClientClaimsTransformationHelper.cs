using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Identity;

namespace TetraPak.AspNet
{
    public static class TetraPakWebClientClaimsTransformationHelper
    {
        /// <summary>
        ///   Sets up DI correctly for claims transformation.
        /// </summary>
        public static void AddTetraPakWebClientClaimsTransformation(this IServiceCollection c)
        {
            c.AddHttpContextAccessor();
            c.TryAddTransient<AmbientData>();
            c.TryAddSingleton<TetraPakAuthConfig>();
            c.AddTransient<IClaimsTransformation, TetraPakClaimsTransformation>();
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