using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api
{
    public static class TetraPakApiHelper
    {
        /// <summary>
        ///   Enforces the use of a message id for all request/response round trips.
        /// </summary>
        /// <param name="app">
        ///   The <see cref="IApplicationBuilder"/> instance.
        /// </param>
        /// <returns>
        ///   The <see cref="IApplicationBuilder"/> instance.
        /// </returns>
        public static IApplicationBuilder UseTetraPakMessageId(this IApplicationBuilder app)
        {
            var config = app.ApplicationServices.GetRequiredService<TetraPakAuthConfig>();
            config.Logger.Debug("Support for messageId in request/response flows was injected");
            app.Use(async (context, func) =>
            {
                var ambientData = context.RequestServices.GetRequiredService<AmbientData>();
                ambientData.GetMessageId(true);
                await func();
            });
            return app;
        }
    }
}