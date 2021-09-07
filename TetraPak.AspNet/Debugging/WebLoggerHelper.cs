using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet.Debugging
{
    /// <summary>
    ///   Contains convenience/extension methods to assist with logging. 
    /// </summary>
    public  static partial class WebLoggerHelper
    {
        static bool s_isAssemblyVersionsAlreadyLogged;
        static bool s_isAuthConfigAlreadyLogged;
        static readonly object s_syncRoot = new();

        /// <summary>
        ///   Logs all assemblies currently in use by the process. This method is intended to be called
        ///   at a very early stage, where DI hasn't yet been fully set up, such as from the Program class
        ///   in a web application.
        /// </summary>
        /// <param name="c">
        ///   A <see cref="IServiceCollection"/>, used to set up DI.
        /// </param>
        /// <param name="justOnce">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to ignore logging if this method has already been invoked once by the process.
        ///   This is to help avoiding littering the log files with the same information multiple times.
        /// </param>
        public static void DebugAssembliesInUse(this IServiceCollection c, bool justOnce = true)
        {
            var services = c.BuildServiceProvider();
            var logger = services.GetService<ILogger<TetraPakAuthConfig>>();
            logger.DebugAssembliesInUse(justOnce);
        }

        /// <summary>
        ///   Logs all assemblies currently in use by the process.
        /// </summary>
        /// <param name="logger">
        ///   A logger provider.
        /// </param>
        /// <param name="justOnce">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to ignore logging if this method has already been invoked once by the process.
        ///   This is to help avoiding littering the log files with the same information multiple times.
        /// </param>
        public static void DebugAssembliesInUse(this ILogger logger, bool justOnce = true)
        {
            if (logger is null || !logger.IsEnabled(LogLevel.Debug))
                return;

            lock (s_syncRoot)
            {
                if (justOnce && s_isAssemblyVersionsAlreadyLogged)
                    return;

                s_isAssemblyVersionsAlreadyLogged = true;
            }

            var sb = new StringBuilder();
            sb.AppendLine(">===== ASSEMBLIES =====<");
            sb.appendAssembliesInUse();
            sb.AppendLine(">======================<");
            logger.Debug(sb.ToString());
        }

        static void appendAssembliesInUse(this StringBuilder sb)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                sb.AppendLine(assembly.FullName);
            }
        }

        /// <summary>
        ///   Gets the lowest <see cref="LogLevel"/> defined for the logger provider. 
        /// </summary>
        /// <param name="logger">
        ///   The logger provider.
        /// </param>
        /// <returns>
        ///   A <see cref="LogLevel"/> value.
        /// </returns>
        public static LogLevel GetLowestLogLevel(this ILogger logger)
        {
            var min = typeof(ILogger).GetEnumValues().Cast<int>().ToList().Min();
            return (LogLevel) min;
        }
        
        public static void TraceAsync(this ILogger logger, TetraPakAuthConfig authConfig, bool justOnce = true)
        {
            // ReSharper disable once InconsistentNaming
            const int Indent = 3;
            if (authConfig is null || !logger.IsEnabled(LogLevel.Debug))
                return;

            lock (s_syncRoot)
            {
                if (justOnce && s_isAuthConfigAlreadyLogged)
                    return;

                s_isAuthConfigAlreadyLogged = true;
            }

            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine(">===== AUTH CONFIGURATION =====<");
            sb.AppendLine(authConfig.GetSectionIdentifier());
            sb.AppendLine("{");
            buildContent(authConfig, Indent);
            sb.AppendLine("}");
            sb.AppendLine(">==============================<");
            logger.Debug(sb.ToString());

            void buildContent(ConfigurationSection sct, int indent)
            {
                var sIndent = new string(' ', indent);
                var propertyInfos = sct.GetType().GetProperties().Where(i => i.CanRead);
                foreach (var propertyInfo in propertyInfos)
                {
                    var jsonProperty = propertyInfo.GetCustomAttribute<JsonPropertyNameAttribute>();
                    var isIgnored = propertyInfo.GetCustomAttribute<JsonIgnoreAttribute>() is { };
                    if (isIgnored)
                        continue;

                    var isRestricted = propertyInfo.GetCustomAttribute<RestrictedValueAttribute>() is { }; 
                    var key = jsonProperty?.Name ?? propertyInfo.Name;

                    sb.Append(sIndent);
                    sb.Append('"');
                    sb.Append(key);
                    sb.Append("\": ");
                    try
                    {
                        if (isRestricted)
                        {
                            sb.AppendLine("\"**** RESTRICTED ****\",");
                            continue;
                        }
                        
                        var value = propertyInfo.GetValue(sct);
                        if (value.IsCollection(out _, out var items, out _))
                        {
                            value = items.Cast<object>().ConcatCollection();
                        }
                        switch (value)
                        {
                            case null:
                                sb.AppendLine("null,");
                                continue;
                            
                            case string sValue:
                                sb.Append('"');
                                sb.Append(sValue);
                                sb.AppendLine("\",");
                                continue;
                            
                            case ConfigurationSection section:
                                sb.AppendLine("{");
                                buildContent(section, indent + Indent);
                                sb.Append(sIndent);
                                sb.AppendLine("},");
                                continue;
                        }

                        sb.Append(value);
                        sb.AppendLine(",");
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine($"\"** ERROR READING VALUE: {ex.Message} **\",");
                    }
                }
            }
        }
    }
}