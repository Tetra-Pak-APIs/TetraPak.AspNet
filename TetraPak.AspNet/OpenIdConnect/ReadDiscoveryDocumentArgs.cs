using System;
using Microsoft.Extensions.Logging;

namespace TetraPak.AspNet.OpenIdConnect
{
  /// <summary>
    ///   Specifies behavior for reading a <see cref="DiscoveryDocument"/>.
    /// </summary>
    public class ReadDiscoveryDocumentArgs
    {
        /// <summary>
        ///   Gets or sets the master (remote) source for the discovery document.
        /// </summary>
        public string? MasterSourceUrl { get; set; }

        /// <summary>
        ///   Gets or sets a maximum allowed time for reading the <see cref="DiscoveryDocument"/>,
        ///   after which the operation will fail (and, potentially, fall back to some other source
        ///   as specified by the <see cref="Policy"/>).   
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        ///   Gets or sets a logging provider.
        /// </summary>
        public ILogger? Logger { get; set; }
        
        /// <summary>
        ///   Gets or sets a (fallback) policy for reading a <see cref="DiscoveryDocument"/>.
        /// </summary>
        public ReadDocumentPolicy Policy { get; set; }

        /// <summary>
        ///   Gets or sets the Tetra Pak integration configuration.
        /// </summary>
        public TetraPakConfig? TetraPakConfig { get; set; }

        /// <summary>
        ///   Gets or sets a local (file) path for locally caching the <see cref="DiscoveryDocument"/>. 
        /// </summary>
        public string? LocalCachePath { get; set; }

        internal string? GetMessageId() => TetraPakConfig?.AmbientData.GetMessageId();

        /// <summary>
        ///   Creates default configuration for reading <see cref="DiscoveryDocument"/> from a master (remote) source.
        /// </summary>
        /// <param name="config">
        ///   The Tetra Pak integration configuration.
        /// </param>
        /// <param name="timeout">
        ///   Gets or sets a maximum allowed time for reading the <see cref="DiscoveryDocument"/>,
        ///   after which the operation will fail (and, potentially, fall back to some other source
        ///   as specified by the <see cref="Policy"/>).
        /// </param>
        /// <param name="fallbackPolicy">
        ///   A (fallback) policy for reading a <see cref="DiscoveryDocument"/>.
        /// </param>
        /// <param name="localCachePath">
        ///   A local (file) path for locally caching the <see cref="DiscoveryDocument"/>.
        /// </param>
        /// <returns>
        ///   A <see cref="ReadDiscoveryDocumentArgs"/> object.
        /// </returns>
        public static ReadDiscoveryDocumentArgs FromMasterSource(
            TetraPakConfig config,
            TimeSpan? timeout = null,
            ReadDocumentPolicy fallbackPolicy = ReadDocumentPolicy.All,
            string? localCachePath = null)
        {
            return new ReadDiscoveryDocumentArgs
            {
                MasterSourceUrl = config.DiscoveryDocumentUrl,
                Logger = config.Logger,
                TetraPakConfig = config,
                Timeout = timeout,
                Policy = fallbackPolicy,
                LocalCachePath = string.IsNullOrWhiteSpace(localCachePath) 
                    ? defaultLocalCachePath()
                    : localCachePath
            };
        }

        static string defaultLocalCachePath()
        {
            return "./_discoveryDocument.json";
        }

        /// <summary>
        ///    Creates default configuration for reading <see cref="DiscoveryDocument"/>.
        /// </summary>
        /// <param name="config">
        ///    The Tetra Pak integration configuration.   
        /// </param>
        /// <returns>
        ///   A <see cref="ReadDiscoveryDocumentArgs"/> object.
        /// </returns>
        public static ReadDiscoveryDocumentArgs FromDefault(TetraPakConfig config)
        {
            return new ReadDiscoveryDocumentArgs
            {
                TetraPakConfig = config,
                Logger = config.Logger
            };
        }

        /// <summary>
        ///   Initializes the <see cref="ReadDiscoveryDocumentArgs"/>.
        /// </summary>
        /// <param name="logger">
        ///   A logger provider.
        /// </param>
        public ReadDiscoveryDocumentArgs(ILogger<ReadDiscoveryDocumentArgs>? logger = null)
        {
            Logger = logger;
            Policy = ReadDocumentPolicy.Configured;
        }
    }
}