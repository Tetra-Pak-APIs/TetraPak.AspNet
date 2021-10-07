using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TetraPak.AspNet.Api.Auth
{
    public static partial class TetraPakApiAuth
    {
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
            var authConfig = app.ApplicationServices.GetRequiredService<TetraPakConfig>();
            app.Use((context, func) =>
            {
                context.Request.GetMessageId(authConfig, true);
                return func();
            });
            
            return app;
        }
    }

    public class HostProvider
    {
        internal string GetHost() => TetraPakApiAuth.Host;
    }
}