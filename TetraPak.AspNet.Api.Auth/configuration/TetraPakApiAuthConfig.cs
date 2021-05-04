using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Provides access to the main Tetra Pak authorization section in the configuration.  
    /// </summary>
    public class TetraPakApiAuthConfig : TetraPakAuthConfig
    {
        /// <summary>
        ///   Gets configuration for all required token exchange.
        /// </summary>
        public IEnumerable<TokenExchangeConfig> TokenExchanges { get; }

        public TetraPakApiAuthConfig(
            IConfiguration configuration, 
            ILogger<TetraPakApiAuthConfig> logger,
            bool refreshDiscoveryDocument = true,
            // AuthConfigAutomaticDiscoveryStrategy discoveryStrategy = AuthConfigAutomaticDiscoveryStrategy.SafeDiscovery, obsolete    
            string sectionIdentifier = null)
        : base(configuration, logger, refreshDiscoveryDocument, sectionIdentifier)
        {
            var s = Section["Environment"];
            TokenExchanges = TokenExchangeConfig.Init(Section, logger);
        }
    }
}