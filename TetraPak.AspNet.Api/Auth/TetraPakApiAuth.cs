using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TetraPak.AspNet.Api.Auth
{
    public static partial class TetraPakApiAuth
    {
        internal static string Host { get; private set; }

        public static IApplicationBuilder UseRequestReferenceId(this IApplicationBuilder app)
        {
            var authConfig = app.ApplicationServices.GetService<TetraPakApiAuthConfig>();
            if (authConfig is null)
                throw new InvalidOperationException(
                    "Cannot use request id middleware. "+
                    $"Unable to resolve a {typeof(TetraPakApiAuthConfig)} service");
                
            app.Use((context, func) =>
            {
                context.Request.GetRequestReferenceId(authConfig, true);
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