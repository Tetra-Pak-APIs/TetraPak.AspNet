using System.Threading.Tasks;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Provides api-specific configuration support.   
    /// </summary>
    public class TetraPakApiConfigDelegate : TetraPakConfigDelegate
    {
        const string ApiClientId = nameof(ApiClientId);
        const string ApiClientSecret = nameof(ApiClientSecret);

        /// <summary>
        ///   Changes how client credentials are fetched from configuration by first testing
        ///   'ApiClientId' and 'ApiClientSecret' before falling back to the default keys
        ///   ('ClientId' and 'ClientSecret'). 
        /// </summary>
        /// <seealso cref="TetraPakConfigDelegate.OnGetClientCredentialsAsync"/>
        protected override Task<Outcome<Credentials>> OnGetClientCredentialsFromConfiguration(GrantType grantType)
        {
            var clientId = _authConfig!.GetConfiguredValue(ApiClientId, nameof(TetraPakConfig.ClientId)); 
            if (string.IsNullOrWhiteSpace(clientId))
                return Task.FromResult(Outcome<Credentials>.Fail(
                    new HttpServerConfigurationException($"{nameof(TetraPakConfig.ClientId)} value is missing "+
                                                         "(or empty) in Tetra Pak configuration")));
            
            var clientSecret = _authConfig.GetConfiguredValue(ApiClientSecret, nameof(TetraPakConfig.ClientSecret));
            if (string.IsNullOrWhiteSpace(clientSecret) && grantType.IsClientSecretRequired())
                return Task.FromResult(Outcome<Credentials>.Fail(
                    new HttpServerConfigurationException($"{nameof(TetraPakConfig.ClientSecret)} value is missing "+
                                                         "(or empty) in Tetra Pak configuration")));

            return Task.FromResult(Outcome<Credentials>.Success(new Credentials(clientId, clientSecret)));
        }
    }
}