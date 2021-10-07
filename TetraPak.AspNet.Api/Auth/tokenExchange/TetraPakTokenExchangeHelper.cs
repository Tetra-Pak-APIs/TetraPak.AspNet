using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TetraPak.AspNet.Api.Auth
{
    public static class TetraPakTokenExchangeHelper
    {
        public static IServiceCollection AddTetraPakTokenExchangeService(this IServiceCollection c)
        {
            c.TryAddSingleton<TetraPakApiConfig>();
            c.TryAddSingleton<ITokenExchangeService, TetraPakTokenExchangeService>();
            return c;
        }

        public static IServiceCollection AddTetraPakClientCredentialsService(this IServiceCollection c)
        {
            c.TryAddSingleton<TetraPakApiConfig>();
            c.TryAddSingleton<IClientCredentialsService, TetraPakClientCredentialsService>();
            return c;
        }

        public static TimeSpan? GetLifespan(this TokenExchangeResponse self)
        {
            if (string.IsNullOrWhiteSpace(self.ExpiresIn) || !int.TryParse(self.ExpiresIn, out var seconds))
                return null;
            
            return TimeSpan.FromSeconds(seconds);
        }
    }
}