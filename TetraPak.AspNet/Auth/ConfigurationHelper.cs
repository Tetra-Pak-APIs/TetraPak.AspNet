using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Auth
{
    public static class ConfigurationHelper
    {
        public static List<T> GetList<T>(this IConfiguration configuration, string key, ILogger logger = null)
        {
            try
            {
                return configuration.GetSection(key).Get<List<T>>();
            }
            catch (Exception ex)
            {
                logger?.Error(ex, $"Invalid configuration section: '{key}'. {ex}");
                return new List<T>();
            }
        }
        
        public static T[] GetArray<T>(this IConfiguration configuration, string key, ILogger logger = null)
        {
            try
            {
                return configuration.GetList<T>(key).ToArray();
            }
            catch (Exception ex)
            {
                logger?.Error(ex, $"Invalid configuration section: '{key}'. {ex}");
                return Array.Empty<T>();
            }
        }

    }
}