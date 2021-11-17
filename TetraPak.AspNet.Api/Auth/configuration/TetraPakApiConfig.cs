using System;
using Microsoft.Extensions.DependencyInjection;

#nullable enable

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   OBSOLETE!
    ///   This class is being deprecated. Please use <see cref="TetraPakApiConfig"/> 
    /// </summary>
    [Obsolete("This class is being deprecated. Please use TetraPakApiConfig")]
    public class TetraPakApiAuthConfig : TetraPakApiConfig
    {
        public TetraPakApiAuthConfig(IServiceProvider provider) : base(provider)
        {
        }
    }
    
    /// <summary>
    ///   Provides access to the main Tetra Pak authorization section in the configuration.  
    /// </summary>
    public class TetraPakApiConfig : TetraPakConfig 
    {
        public IDownstreamServiceProvider? BackendServiceProvider =>
            ServiceProvider.GetService<IDownstreamServiceProvider>();

        public TetraPakApiConfig(IServiceProvider provider) : base(provider)
        {
        }
    }
}