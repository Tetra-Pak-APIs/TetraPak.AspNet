using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Configuration;
using TetraPak.Logging;

namespace TetraPak.AspNet.Debugging
{
    public  static partial class LoggerHelper
    {
        static bool s_isAssemblyVersionsAlreadyLogged;
        static bool s_isAuthConfigAlreadyLogged;
        static readonly object s_syncRoot = new();

        public static void DebugAssembliesInUse(this IServiceCollection c, bool justOnce = true)
        {
            var services = c.BuildServiceProvider();
            var logger = services.GetService<ILogger<TetraPakAuthConfig>>();
            logger.DebugAssembliesInUse(justOnce);
        }

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
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            sb.AppendLine(">===== ASSEMBLIES =====<");
            foreach (var assembly in assemblies)
            {
                sb.AppendLine(assembly.FullName);
            }
            sb.AppendLine(">======================<");
            logger.Debug(sb.ToString());
        }

        public static void Debug(this ILogger logger, TetraPakAuthConfig authConfig, bool justOnce = true)
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
                        if (value.IsCollection(out var _, out var items, out var _))
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