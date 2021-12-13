using System;

namespace TetraPak.AspNet.OpenIdConnect
{
    /// <summary>
    ///   Used to specify a fallback policy to be used when reading a <see cref="DiscoveryDocument"/>.
    /// </summary>
    /// <seealso cref="DiscoveryDocument.ReadAsync"/>
    /// <seealso cref="ReadDiscoveryDocumentArgs"/>
    [Flags]
    public enum ReadDocumentPolicy
    {
        /// <summary>
        ///   No fallback allowed; reading document will fail.
        /// </summary>
        None = 0,
        
        /// <summary>
        ///   Try reading from master source, such as a remote service.
        /// </summary>
        Master = 1,
        
        /// <summary>
        ///   Fallback to cached document.
        /// </summary>
        Cached = 2,
        
        /// <summary>
        ///   Fallback to default document.
        /// </summary>
        Default = 4,
        
        /// <summary>
        ///   All fallback policies are supported.
        /// </summary>
        All = Master | Cached | Default,
        
        /// <summary>
        ///   Use configured fallback policy.
        /// </summary>
        Configured = 16
    }
}