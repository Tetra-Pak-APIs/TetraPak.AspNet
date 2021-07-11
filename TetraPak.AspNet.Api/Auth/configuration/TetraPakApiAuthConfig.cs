using System.Reflection;
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
        protected override void OnSetProperty(PropertyInfo property, object value)
        {
            if (value is string stringValue && property.PropertyType.IsAssignableFrom(typeof(ServiceEndpoint)))
            {
                value = new ServiceEndpoint(stringValue);
            }

            base.OnSetProperty(property, value);
        }

        public TetraPakApiAuthConfig(
            IConfiguration configuration,
            ILogger<TetraPakApiAuthConfig> logger,
            bool loadDiscoveryDocument = false,
            string sectionIdentifier = null)
        : base(configuration, logger, loadDiscoveryDocument, sectionIdentifier)
        {
        }
    }
}