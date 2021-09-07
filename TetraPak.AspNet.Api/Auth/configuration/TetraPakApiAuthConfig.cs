using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

#nullable enable

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Provides access to the main Tetra Pak authorization section in the configuration.  
    /// </summary>
    public class TetraPakApiAuthConfig : TetraPakAuthConfig
    {
        protected override void OnSetProperty(PropertyInfo property, object value)
        {
            if (value is string stringValue && property.PropertyType.IsAssignableFrom(typeof(ServiceEndpoint)))
            {
                value = new ServiceEndpoint(stringValue);
            }

            base.OnSetProperty(property, value);
        }

        public ITetraPackServiceProvider? BackendServiceProvider =>
            ServiceProvider.GetService<ITetraPackServiceProvider>();

        public TetraPakApiAuthConfig(IServiceProvider provider, ITetraPakAuthConfigDelegate? configDelegate = null)
        : base(provider, configDelegate)
        {
        }
    }
}