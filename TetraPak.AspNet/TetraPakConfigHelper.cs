using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.diagnostics;
using TetraPak.AspNet.Diagnostics;
using TetraPak.Logging;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Provides convenient helper methods for Tetra Pak configuration scenarios. 
    /// </summary>
    public static class TetraPakConfigHelper
    {
        static readonly object s_syncRoot = new object();
        static bool s_isTetraPakConfigAdded;
        static bool s_isTetraPakConfigDelegateConfigured;
        
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
            var config = app.ApplicationServices.GetRequiredService<TetraPakConfig>();
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
        ///   Adds the Tetra Pak configuration code API as a (DI) service. 
        /// </summary>
        /// <param name="c">
        ///   The service collection.
        /// </param>
        /// <returns>
        ///   The service collection.
        /// </returns>
        public static IServiceCollection AddTetraPakConfiguration(this IServiceCollection c) =>
            AddTetraPakConfiguration<TetraPakConfig>(c);

        /// <summary>
        ///   Adds a specific implementation for the Tetra Pak configuration API as a (DI) service. 
        /// </summary>
        /// <param name="c">
        ///   The service collection.
        /// </param>
        /// <typeparam name="T">
        ///   The type implementing the Tetra Pak integration configuration code API
        ///   (must derive from <see cref="TetraPakConfig"/>).  
        /// </typeparam>
        /// <returns>
        ///   The service collection.
        /// </returns>
        public static IServiceCollection AddTetraPakConfiguration<T>(this IServiceCollection c) 
        where T : TetraPakConfig
        {
            lock (s_syncRoot)
            {
                if (s_isTetraPakConfigAdded)
                    return c;

                try
                {
                    c.AddSingleton<TetraPakConfig, T>();
                    c.AddSingleton<T, T>();
                    s_isTetraPakConfigAdded = true;
                }
                catch (Exception ex)
                {
                    var p = c.BuildServiceProvider();
                    var logger = p.GetService<ILogger<TetraPakConfig>>();
                    logger.Error(ex, $"Failed to add Tetra Pak configuration API ({typeof(TetraPakConfig)}) to service collection");
                }

                return c;
            }
        }
        
        /// <summary>
        ///   Enabled various types of diagnostics features, such as timers and trackable message ids.
        /// </summary>
        /// <param name="app">
        ///   The <see cref="IApplicationBuilder"/> object.
        /// </param>
        /// <returns>
        ///   The <see cref="IApplicationBuilder"/> object.
        /// </returns>
        public static IApplicationBuilder UseTetraPakDiagnostics(this IApplicationBuilder app)
        {
            const string TotalName = "*";
            
            var config = app.ApplicationServices.GetService<TetraPakConfig>();
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

                    ServiceDiagnosticsHelper.End(diagnostics);
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
        
        /// <summary>
        ///   Configures a custom configuration delegate, to be used by <see cref="TetraPakConfig"/>. 
        /// </summary>
        /// <typeparam name="TDelegate">
        ///   The delegate type (must be a reference type that implements <see cref="ITetraPakConfigDelegate"/>).
        /// </typeparam>
        public static IServiceCollection AddTetraPakConfigDelegate<TDelegate>(this IServiceCollection self) 
        where TDelegate : class, ITetraPakConfigDelegate 
        {
            lock (s_syncRoot)
            {
                if (s_isTetraPakConfigDelegateConfigured)
                    return self;
        
                self.AddSingleton<ITetraPakConfigDelegate, TDelegate>();
                s_isTetraPakConfigDelegateConfigured = true;
                return self;
            }
        }
    }
}