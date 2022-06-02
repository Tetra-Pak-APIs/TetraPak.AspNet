using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Provides convenient methods for working with OAuth grant flows. 
    /// </summary>
    public static class TetraPakTokenExchangeHelper
    {
        /// <summary>
        ///   (fluent api)<br/>
        ///   Adds a Tetra Pak service to support the OAuth Token Exchange Grant flow
        ///   to the service collection and then returns the service collection.
        /// </summary>
        public static IServiceCollection AddTetraPakTokenExchangeService(this IServiceCollection collection)
        {
            collection.AddTetraPakConfiguration<TetraPakApiConfig>();
            collection.AddAmbientData();
            collection.AddTetraPakHttpClientProvider();
            collection.TryAddSingleton<ITokenExchangeGrantService, TetraPakTokenExchangeGrantService>();
            return collection;
        }

        /// <summary>
        ///   (fluent api)<br/>
        ///   Adds a Tetra Pak service to support the OAuth Client Credentials Grant flow
        ///   to the service collection and then returns the service collection.
        /// </summary>
        public static IServiceCollection AddTetraPakClientCredentialsService(this IServiceCollection collection)
        {
            collection.AddTetraPakConfiguration<TetraPakApiConfig>();
            collection.TryAddSingleton<IClientCredentialsGrantService, TetraPakClientCredentialsGrantService>();
            return collection;
        }

        /// <summary>
        ///   Parses and returns the <see cref="TokenExchangeResponse.ExpiresIn"/> value
        ///   as a <see cref="TimeSpan"/> value.
        /// </summary>
        public static TimeSpan? GetLifespan(this TokenExchangeResponse self)
        {
            if (string.IsNullOrWhiteSpace(self.ExpiresIn) || !int.TryParse(self.ExpiresIn, out var seconds))
                return null;
            
            return TimeSpan.FromSeconds(seconds);
        }
    }
}