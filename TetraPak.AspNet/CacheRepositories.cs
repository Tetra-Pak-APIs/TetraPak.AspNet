using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.Caching;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Provides identifiers for supported caches as well as convenient methods
    ///   for working with caching.
    /// </summary>
    public static class CacheRepositories
    {
        static readonly object s_syncRoot = new();
        static bool s_isTetraPakCachingAdded;
        static ITimeLimitedRepositories? s_singletonCache;
        
        /// <summary>
        ///   Identifies the cache used for claims principals.
        /// </summary>
        public const string ClaimsPrincipals = "ClaimsPrincipals";
        
        /// <summary>
        ///   Provides identifiers for token caches. 
        /// </summary>
        public static class Tokens
        {
            /// <summary>
            ///   Identifies the cache repository used for identity tokens. 
            /// </summary>
            public const string Identity = "IdTokens";

            /// <summary>
            ///   Identifies the cache repository used for tokens acquired from token exchange grants. 
            /// </summary>
            public const string TokenExchange = "TxTokens";

            /// <summary>
            ///   Identifies the cache repository used for tokens acquired from client credential grants. 
            /// </summary>
            public const string ClientCredentials = "CcTokens";

            /// <summary>
            ///   Identifies the cache repository used for JWT bearer tokens acquired from the local DevProxy. 
            /// </summary>
            public const string DevProxy = "DpTokens";
        }

        /// <summary>
        ///   Adds support for Tetra Pak (configurable) caching.
        ///   This implementation relies on the <see cref="SimpleCache"/> but you can provide a custom caching
        ///   service by instead calling the <see cref="AddTetraPakCaching{T}"/> method.  
        /// </summary>
        /// <seealso cref="AddTetraPakCaching{T}"/>
        public static IServiceCollection AddTetraPakCaching(this IServiceCollection services) 
            => services.AddTetraPakCaching(p => new SimpleCache(p.GetService<ILogger<SimpleCache>>()));

        /// <summary>
        ///   Adds support for Tetra Pak (configurable) caching while specifying a caching implementation type.
        /// </summary>
        /// <typeparam name="T">
        ///   A type that implements the <see cref="ITimeLimitedRepositories"/> interface. 
        /// </typeparam>
        /// <seealso cref="AddTetraPakCaching{T}"/>
        public static IServiceCollection AddTetraPakCaching<T>(this IServiceCollection services, Func<IServiceProvider,T> factory)
            where T : class, ITimeLimitedRepositories
        {
            lock (s_syncRoot)
            {
                if (s_isTetraPakCachingAdded)
                    return services;

                services.AddTetraPakConfiguration();
                services.AddSingleton<ITimeLimitedRepositories,T>(p =>
                {
                    if (s_singletonCache is { })
                        return (T) s_singletonCache;
                    
                    var tetraPakConfig = p.GetRequiredService<TetraPakConfig>();
                    s_singletonCache = factory(p);
                    if (s_singletonCache is SimpleCache simpleCache)
                    {
                        var cacheConfig = tetraPakConfig.Caching.WithCache(simpleCache);
                        simpleCache.WithConfiguration(cacheConfig);
                    }
                    
                    var property = s_singletonCache.GetType().GetProperty(nameof(ITimeLimitedRepositories.DefaultLifeSpan));
                    if (property is null || !property.CanWrite)
                        return (T) s_singletonCache;
                    
                    property.SetValue(s_singletonCache, tetraPakConfig.DefaultCachingLifetime);
                    return (T) s_singletonCache;
                });
                s_isTetraPakCachingAdded = true;
                return services;
            }
        }
    }
}