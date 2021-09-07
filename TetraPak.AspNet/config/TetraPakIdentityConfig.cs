using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Describes how to populate the ambient <see cref="ClaimsPrincipal.Identity"/> value
    ///   available through <see cref="HttpContext"/>.
    /// </summary>
    public class TetraPakIdentityConfig : ConfigurationSection
    {
        internal static readonly string[] s_defaultScope = { "general", "profile", "email", "openid" };
        const string KeySource = "Source";
        const string SourceKeyIdToken = "id_token";
        const string SourceKeyApi = "api";

        /// <summary>
        ///   Gets the configuration section name.
        /// </summary>
        public override string SectionIdentifier => "Identity";

        /// <summary>
        ///   Specifies the source for identity claims.
        /// </summary>
        public TetraPakIdentitySource Source { get; set; }
        
        /// <summary>
        ///   Gets a configured scope to be requested to obtain identity claims (or default scope when omitted). 
        /// </summary>
        public string[] Scope { get; }
        
        /// <summary>
        ///   Initializes the <see cref="TetraPakIdentityConfig"/>.
        /// </summary>
        /// <param name="configuration">
        ///   The <see cref="IConfiguration"/> instance.
        /// </param>
        /// <param name="logger">
        ///   A <see cref="ILogger"/> instance.
        /// </param>
        /// <param name="serviceName">
        ///   (optional; default=<see cref="SectionIdentifier"/>)<br/>
        ///   A custom configuration section identifier. 
        /// </param>
        public TetraPakIdentityConfig(
            IConfiguration configuration, 
            ILogger logger, 
            string serviceName = null) 
            : base(configuration, logger, serviceName)
        {
            Source = parseSource();
            // var scope = Section.GetList<string>(TetraPakAuthConfig.KeyScope, logger);
            // if (scope.All(i => !i.Equals("openid", StringComparison.InvariantCultureIgnoreCase)))
            // {
            //     scope.Add("openid");
            // }
            // Scope = scope.ToArray();
        }

        TetraPakIdentitySource parseSource(TetraPakIdentitySource useDefault = TetraPakIdentitySource.IdToken)
        {
            var s = Section[KeySource];
            if (s.Equals(SourceKeyIdToken, StringComparison.OrdinalIgnoreCase))
            {
                s = nameof(TetraPakIdentitySource.IdToken);
            }
            else if (s.Equals(SourceKeyApi))
            {
                s = nameof(TetraPakIdentitySource.RemoteService);
            }
            return !string.IsNullOrWhiteSpace(s) && Enum.TryParse<TetraPakIdentitySource>(s, out var eSource)
                ? eSource
                : useDefault;
        }
    }
}