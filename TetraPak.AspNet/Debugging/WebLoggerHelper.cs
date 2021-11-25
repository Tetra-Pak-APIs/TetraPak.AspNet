using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Debugging
{
    /// <summary>
    ///   Contains convenience/extension methods to assist with logging. 
    /// </summary>
    public static partial class WebLoggerHelper
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
            var logger = services.GetService<ILogger<TetraPakConfig>>();
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
        ///   Builds and a state dump from a <see cref="TetraPakConfig"/> object and writes it to the logger. 
        /// </summary>
        /// <param name="logger">
        ///   The extended logger provider.
        /// </param>
        /// <param name="tetraPakConfig">
        ///   The <see cref="TetraPakConfig"/> object to be state dumped to the logger. 
        /// </param>
        /// <param name="logLevel">
        ///   (optional; default=<see cref="LogLevel.Trace"/>)<br/>
        ///   A (custom) log level for the state dump information.
        /// </param>
        /// <param name="justOnce">
        ///   (optional; default=<c>true</c>)<br/>
        ///   When set the state dump will only be performed once.
        ///   The state dump will be ignored if invoked again and this value was set previously (and now).  
        /// </param>
        public static async Task LogTetraPakConfigAsync(
            this ILogger logger, 
            TetraPakConfig tetraPakConfig, 
            LogLevel logLevel = LogLevel.Trace,
            bool justOnce = true)
        {
            if (tetraPakConfig is null || !logger.IsEnabled(logLevel))
                return;

            lock (s_syncRoot)
            {
                if (justOnce && s_isAuthConfigAlreadyLogged)
                    return;

                s_isAuthConfigAlreadyLogged = true;
            }
            
            var stateDump = new StateDump("Tetra Pak Configuration", logger);
            await stateDump.AddAsync(tetraPakConfig, "TetraPak");

            logger.LogLevel(await stateDump.BuildAsStringAsync(), logLevel);
            // return;
            
            
            
            // var sb = new StringBuilder(); // obsolete (replaced by StateDump)
            // sb.AppendLine();
            // sb.AppendLine(">===== AUTH CONFIGURATION =====<");
            // sb.AppendLine(config.GetSectionIdentifier());
            // sb.AppendLine("{");
            // buildContent(config, Indent);
            // sb.AppendLine("}");
            // sb.AppendLine(">==============================<");
            // logger.Debug(sb.ToString());

            // void buildContent(ConfigurationSection sct, int indent)
            // {
            //     var sIndent = new string(' ', indent);
            //     var propertyInfos = sct.GetType().GetProperties().Where(i => i.CanRead);
            //     foreach (var propertyInfo in propertyInfos)
            //     {
            //         var jsonProperty = propertyInfo.GetCustomAttribute<JsonPropertyNameAttribute>();
            //         var isIgnored = propertyInfo.GetCustomAttribute<JsonIgnoreAttribute>() is { };
            //         if (isIgnored)
            //             continue;
            //
            //         var isRestricted = propertyInfo.GetCustomAttribute<RestrictedValueAttribute>() is { }; 
            //         var key = jsonProperty?.Name ?? propertyInfo.Name;
            //
            //         sb.Append(sIndent);
            //         sb.Append('"');
            //         sb.Append(key);                    
            //         sb.Append("\": ");
            //         try
            //         {
            //             if (isRestricted)
            //             {
            //                 sb.AppendLine("\"**** RESTRICTED ****\",");
            //                 continue;
            //             }
            //             
            //             var value = propertyInfo.GetValue(sct);
            //             if (value.IsCollection(out _, out var items, out _))
            //             {
            //                 value = items.Cast<object>().ConcatCollection();
            //             }
            //             switch (value)
            //             {
            //                 case null:
            //                     sb.AppendLine("null,");
            //                     continue;
            //                 
            //                 case string sValue:
            //                     sb.Append('"');
            //                     sb.Append(sValue);
            //                     sb.AppendLine("\",");
            //                     continue;
            //                 
            //                 case ConfigurationSection section:
            //                     sb.AppendLine("{");
            //                     buildContent(section, indent + Indent);
            //                     sb.Append(sIndent);
            //                     sb.AppendLine("},");
            //                     continue;
            //             }
            //
            //             sb.Append(value);
            //             sb.AppendLine(",");
            //         }
            //         catch (Exception ex)
            //         {
            //             sb.AppendLine($"\"** ERROR READING VALUE: {ex.Message} **\",");
            //         }
            //     }
            // }
        }
    }
}