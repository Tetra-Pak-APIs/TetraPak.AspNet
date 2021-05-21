using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TetraPak.AspNet.Api.Auth.TokenExchange
{
    public static class TetraPakTokenExchangeHelper
    {
        public static IServiceCollection AddTetraPakTokenExchangeService(this IServiceCollection c)
        {
            c.TryAddSingleton<TetraPakApiAuthConfig>();
            c.AddSingleton<ITokenExchangeService, TetraPakTokenExchangeService>();
            return c;
        }
    }
}