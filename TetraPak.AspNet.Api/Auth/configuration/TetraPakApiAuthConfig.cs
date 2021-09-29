using System;

#nullable enable

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Provides access to the main Tetra Pak authorization section in the configuration.  
    /// </summary>
    public class TetraPakApiAuthConfig : TetraPakAuthConfig // obsolete?
    {
        public TetraPakApiAuthConfig(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}