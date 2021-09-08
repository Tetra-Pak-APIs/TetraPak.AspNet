using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.diagnostics;
using TetraPak.AspNet.Diagnostics;
using TetraPak.Logging;

namespace TetraPak.AspNet
{
    public static class TetraPakConfigHelper
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
        
        /// <summary>
        ///   Enabled various types of diagnostics features, such as timers and trackable message ids.
        /// </summary>
        /// <param name="app">
        ///   The <see cref="IApplicationBuilder"/> instance.
        /// </param>
        /// <returns></returns>
        public static IApplicationBuilder UseTetraPakDiagnostics(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            const string TotalName = "*";
            
            var config = app.ApplicationServices.GetService<TetraPakAuthConfig>();
            if (!(config?.EnableDiagnostics ?? false))
                return app;

            app.Use(async (context, func) =>
            {
                var logger = app.ApplicationServices.GetService<ILogger<ServiceDiagnostics>>();
                var diagnostics = context.BeginDiagnostics(logger);
                context.Response.OnStarting(() =>
                {
                    if (diagnostics is null)
                        return Task.CompletedTask;

                    diagnostics.End(logger);
                    var timers = diagnostics.GetValues(ServiceDiagnostics.TimerPrefix).ToArray();
                    var timerNameIndex = ServiceDiagnostics.TimerPrefix.Length + 1;
                    var sb = new StringBuilder();
                    var timer = (ServiceDiagnostics.Timer) timers[0].Value;
                    var key = timers[0].Key;
                    var name = key.Length == ServiceDiagnostics.TimerPrefix.Length 
                        ? TotalName 
                        : key[timerNameIndex..];
                    sb.Append($"{name}={timer.ElapsedMs().ToString()}");
                    for (var i = 1; i < timers.Length; i++)
                    {
                        sb.Append(", ");
                        timer = (ServiceDiagnostics.Timer) timers[i].Value;
                        key = timers[i].Key;
                        name = key.Length == ServiceDiagnostics.TimerPrefix.Length 
                            ? TotalName 
                            : key[timerNameIndex..];
                        sb.Append($"{name}={timer.ElapsedMs().ToString()}");
                    }

                    var timerValues = sb.ToString();
                    context.Response.Headers.Add(ServiceDiagnostics.TimerPrefix, timerValues);
                    return Task.CompletedTask;
                });

                await func();
            });

            return app;
        }
    }
}