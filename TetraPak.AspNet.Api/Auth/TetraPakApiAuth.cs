using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TetraPak.AspNet.Api.Auth
{
    public static partial class TetraPakApiAuth
    {
        static readonly object s_syncRoot = new();
        static bool s_isTetraPakOauthServicesAdded;
        
        internal static string Host { get; private set; }

        /// <summary>
        ///   Ensures a unique message id is available through the whole request/response roundtrip. 
        /// </summary>
        /// <param name="app">
        ///   The <see cref="IApplicationBuilder"/> instance.
        /// </param>
        /// <returns>
        ///   The <see cref="IApplicationBuilder"/> instance.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The method requires an <see cref="TetraPakConfig"/> service is available
        ///   though the DI service locator but no such service could be obtained. 
        /// </exception>
        public static IApplicationBuilder UseMessageId(this IApplicationBuilder app)
        {
            var tetraPakConfig = app.ApplicationServices.GetRequiredService<TetraPakConfig>();
            app.Use((context, func) =>
            {
                context.Request.GetMessageId(tetraPakConfig, true);
                return func();
            });
            
            return app;
        }

        /// <summary>
        ///   Registers a <see cref="IAuthorizationService"/> for Tetra Pak integration use
        ///   while providing a factory callback handler.
        /// </summary>
        /// <param name="collection">
        ///   The extended <see cref="IServiceCollection"/>.
        /// </param>
        /// <param name="factory">
        ///   The factory callback handler responsible for producing the service. 
        /// </param>
        /// <returns>
        ///   The <paramref name="collection"/>.
        /// </returns>
        public static IServiceCollection AddTetraPakAuthorizationService(
            this IServiceCollection collection, 
            Func<IServiceProvider,IAuthorizationService> factory)
        {
            lock (s_syncRoot)
            {
                if (s_isTetraPakOauthServicesAdded)
                    return collection;

                collection.AddSingleton(factory);
                s_isTetraPakOauthServicesAdded = true;
            }
            return collection;
        }

        /// <summary>
        ///   Registers a <see cref="IAuthorizationService"/> type for Tetra Pak integration use.
        /// </summary>
        /// <param name="collection">
        ///   The extended <see cref="IServiceCollection"/>.
        /// </param>
        /// <returns>
        ///   The <paramref name="collection"/>.
        /// </returns>
        public static IServiceCollection AddTetraPakAuthorizationService<T>(this IServiceCollection collection)
        where T : class, IAuthorizationService
        {
            lock (s_syncRoot)
            {
                if (s_isTetraPakOauthServicesAdded)
                    return collection;

                collection.AddSingleton<IAuthorizationService, T>();
                s_isTetraPakOauthServicesAdded = true;
            }

            return collection;
        }
    }

    public class HostProvider
    {
        internal string GetHost() => TetraPakApiAuth.Host;
    }
}