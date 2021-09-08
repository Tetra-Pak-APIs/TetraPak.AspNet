using System;

#nullable enable

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Provides access to the main Tetra Pak authorization section in the configuration.  
    /// </summary>
    public class TetraPakApiAuthConfig : TetraPakAuthConfig // obsolete?
    {
        // protected override void OnSetProperty(PropertyInfo property, object value) // obsolete?
        // {
        //     if (value is string stringValue && property.PropertyType.IsAssignableFrom(typeof(ServiceEndpoint)))
        //     {
        //         value = new ServiceEndpoint(stringValue);
        //     }
        //
        //     base.OnSetProperty(property, value);
        // }

        public TetraPakApiAuthConfig(
            IServiceProvider provider,
            ITetraPakAuthConfigDelegate? configDelegate = null)
        : base(provider, configDelegate)
        {
        }
    }
}