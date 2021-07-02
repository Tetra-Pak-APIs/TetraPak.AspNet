using System;
using System.Threading.Tasks;

namespace TetraPak.AspNet.Auth
{
    public interface IClientCredentialsProvider
    {
        Task<Outcome<Credentials>> GetClientCredentialsAsync();
    }

    /// <summary>
    ///   Provides client credentials from the configuration framework.
    /// </summary>
    public class ConfiguredClientCredentialsProvider : IClientCredentialsProvider
    {
        readonly TetraPakAuthConfig _authConfig;

        public Task<Outcome<Credentials>> GetClientCredentialsAsync()
        {
            var clientId = _authConfig.ClientId;
            var clientSecret = _authConfig.ClientSecret;
            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
                return Task.FromResult(Outcome<Credentials>.Fail(
                    new Exception(
                        "Client credentials has not been fully configured. "+
                        $"Please add {nameof(TetraPakAuthConfig.ClientId)} and {nameof(TetraPakAuthConfig.ClientSecret)} to the configuration")));
            
            return Task.FromResult(Outcome<Credentials>.Success(new Credentials(clientId, clientSecret)));
        }

        public ConfiguredClientCredentialsProvider(TetraPakAuthConfig authConfig)
        {
            _authConfig = authConfig ?? throw new ArgumentNullException(nameof(authConfig));
        }
    }
}