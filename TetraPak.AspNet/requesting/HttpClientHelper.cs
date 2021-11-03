using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Provides convenient methods for registering a <see cref="IHttpClientProvider"/>.
    /// </summary>
    public static class HttpClientHelper
    {
        static readonly object s_syncRoot = new();
        static bool s_isTetraPackHttpClientProviderAdded;
        static IHttpClientProvider? s_singleton;
        
        /// <summary>
        ///   Registers a default Tetra Pak <see cref="IHttpClientProvider"/> implementation.
        /// </summary>
        /// <param name="collection">
        ///   The service collection.
        /// </param>
        /// <returns>
        ///   The <paramref name="collection"/>.
        /// </returns>
        public static IServiceCollection AddTetraPakHttpClientProvider(this IServiceCollection collection)
        {
            collection.AddTetraPakHttpClientProvider(p =>
            {
                if (s_singleton is { })
                    return s_singleton;

                s_singleton = new TetraPakHttpClientProvider(
                    p.GetRequiredService<TetraPakConfig>()
                    ,p.GetService<IAuthorizationService>());
                return s_singleton;
            });
            TetraPakHttpClientProvider.AddDecorator(new TetraPakSdkClientDecorator());
            return collection;
        }

        /// <summary>
        ///   Adds a custom <see cref="IHttpClientProvider"/> factory.
        /// </summary>
        /// <param name="collection">
        ///   The service collection.
        /// </param>
        /// <param name="factory">
        ///   The <see cref="IHttpClientProvider"/> factory, used to produce <see cref="HttpClient"/>a.
        /// </param>
        /// <returns>
        ///   The <paramref name="collection"/>.
        /// </returns>
        public static IServiceCollection AddTetraPakHttpClientProvider(
            this IServiceCollection collection,
            Func<IServiceProvider, IHttpClientProvider> factory)
        {
            lock (s_syncRoot)
            {
                if (s_isTetraPackHttpClientProviderAdded)
                    return collection;

                collection.AddSingleton(factory);
                s_isTetraPackHttpClientProviderAdded = true;
                return collection;
            }
        }
    }
}