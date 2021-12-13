using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

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
        public IBackendServiceProvider? BackendServiceProvider =>
            ServiceProvider.GetService<IBackendServiceProvider>();
        
        protected override ProductInfoHeaderValue OnGetSdkVersion()
        {
            var asm = typeof(TetraPakApiConfig).Assembly;
            var v = asm.GetName().Version!;
            return new ProductInfoHeaderValue(asm.GetName().Name!, $"{v.Major}.{v.Minor}.{v.Build}");
        }

        public TetraPakApiConfig(IServiceProvider provider) : base(provider)
        {
        }
    }
}