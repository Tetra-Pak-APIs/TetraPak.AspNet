using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TetraPak.AspNet.Api.Auth
{
    public static class TetraPakTokenExchangeHelper
    {
        public static IServiceCollection AddTetraPakTokenExchangeService(this IServiceCollection c)
        {
            c.TryAddSingleton<TetraPakApiAuthConfig>();
            c.TryAddSingleton<ITokenExchangeService, TetraPakTokenExchangeService>();
            return c;
        }

        public static IServiceCollection AddTetraPakClientCredentialsService(this IServiceCollection c)
        {
            c.TryAddSingleton<TetraPakApiAuthConfig>();
            c.TryAddSingleton<IClientCredentialsService, TetraPakClientCredentialsService>();
            return c;
        }
    }
}