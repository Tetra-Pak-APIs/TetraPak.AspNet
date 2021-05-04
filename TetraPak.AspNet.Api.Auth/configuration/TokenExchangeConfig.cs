using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class TokenExchangeConfig 
    {
        internal const string KeySection = "TokenExchanges";

        public string ClientId { get; set; }

        [RestrictedValue]
        public string ClientSecret { get; set; }

        public string CallbackPath { get; set; }

        public string CallbackUrl { get; set; }

        public static IEnumerable<TokenExchangeConfig> Init(
            IConfigurationSection configuration,
            ILogger logger)
        {
            var section = configuration.GetSection(KeySection);
            if (!section.GetChildren().Any())
                return Array.Empty<TokenExchangeConfig>();

            try
            {
                return configuration.GetSection(KeySection).Get<List<TokenExchangeConfig>>().ToArray();
            }
            catch (Exception ex)
            {
                logger?.Error(ex, $"Invalid configuration section: '{KeySection}'. {ex}");
                return Array.Empty<TokenExchangeConfig>();
            }
        }

        [JsonConstructor]
        public TokenExchangeConfig()
        {
        }
    }
}