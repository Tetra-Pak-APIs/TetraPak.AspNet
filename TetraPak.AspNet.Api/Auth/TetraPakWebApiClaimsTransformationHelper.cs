using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TetraPak.AspNet.Api.Auth.TokenExchange;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet.Api.Auth
{
    public static class TetraPakWebApiClaimsTransformationHelper
    {
        /// <summary>
        ///   Sets up DI correctly for API claims transformation.
        /// </summary>
        /// <remarks>
        ///   The difference between claims transformation in an API is that token exchange services
        ///   must be available for fetching identity from a user information endpoint
        ///   (when <see cref="TetraPakAuthConfig.IdentitySource"/> = <see cref="TetraPakIdentitySource.Api"/>).
        /// </remarks>
        /// 
        public static void AddTetraPakWebApiClaimsTransformation(this IServiceCollection c)
        {
            c.AddHttpContextAccessor();
            c.TryAddTransient<AmbientData>();
            c.AddTransient<IClaimsTransformation, TetraPakWebApiClaimsTransformation>();
            c.AddTetraPakTokenExchangeService();
        }
    }
}