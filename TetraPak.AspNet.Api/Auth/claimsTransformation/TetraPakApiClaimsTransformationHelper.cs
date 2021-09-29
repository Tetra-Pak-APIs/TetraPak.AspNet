using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Provides convenience methods fo setting up claims transformation.
    /// </summary>
    public static class TetraPakApiClaimsTransformationHelper
    {
        /// <summary>
        ///   Sets up DI correctly for API claims transformation.
        /// </summary>
        /// <remarks>
        ///   The difference between claims transformation in an API is that token exchange services
        ///   must be available for fetching identity from a user information endpoint
        ///   (when <see cref="TetraPakAuthConfig.IdentitySource"/> = <see cref="TetraPakIdentitySource.RemoteService"/>).
        /// </remarks>
        public static void AddTetraPakApiClaimsTransformation(this IServiceCollection c)
        {
            c.AddHttpContextAccessor();
            c.AddAmbientData();
            c.TryAddSingleton<TetraPakAuthConfig, TetraPakApiAuthConfig>();
            try
            {
                c.AddScoped<IClaimsTransformation, TetraPakApiClaimsTransformation>();
            }
            catch (Exception ex)
            {
                var p = c.BuildServiceProvider();
                var logger = p.GetService<ILogger<TetraPakApiClaimsTransformation>>();
                logger.Error(ex, $"Failed to register Tetra Pak API Claims Transformation ({typeof(TetraPakApiClaimsTransformation)}) with service collection");
            }
            c.AddTetraPakTokenExchangeService();
            c.AddTetraPakUserInformation();
        }
    }
}