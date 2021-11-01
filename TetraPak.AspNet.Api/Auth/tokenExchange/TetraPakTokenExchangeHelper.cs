using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TetraPak.AspNet.Api.Auth
{
    public static class TetraPakTokenExchangeHelper
    {
        public static IServiceCollection AddTetraPakTokenExchangeService(this IServiceCollection c)
        {
            c.AddTetraPakConfiguration<TetraPakApiConfig>();
            c.TryAddSingleton<ITokenExchangeGrantService, TetraPakTokenExchangeGrantService>();
            return c;
        }

        public static IServiceCollection AddTetraPakClientCredentialsService(this IServiceCollection c)
        {
            c.AddTetraPakConfiguration<TetraPakApiConfig>();
            c.TryAddSingleton<IClientCredentialsGrantService, TetraPakClientCredentialsGrantService>();
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