using System;
using System.Threading.Tasks;

namespace TetraPak.AspNet.Auth
{
    
    /// <summary>
    ///   Implementors of this contract can be used for obtaining client credentials,
    ///   typically for token exchange, or similar flows where such credentials are needed.
    /// </summary>
    public interface IClientCredentialsProvider
    {
        /// <summary>
        ///   Obtains and returns client credentials.
        /// </summary>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="Credentials"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<Credentials>> GetClientCredentialsAsync();
    }

    /// <summary>
    ///   Provides client credentials from the configuration framework.
    /// </summary>
    public class ConfiguredClientCredentialsProvider : IClientCredentialsProvider
    {
        readonly TetraPakConfig _config;

        /// <inheritdoc />
        public Task<Outcome<Credentials>> GetClientCredentialsAsync()
        {
            var clientId = _config.ClientId;
            var clientSecret = _config.ClientSecret;
            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
                return Task.FromResult(Outcome<Credentials>.Fail(
                    new Exception(
                        "Client credentials has not been fully configured. "+
                        $"Please add {nameof(TetraPakConfig.ClientId)} and {nameof(TetraPakConfig.ClientSecret)} to the configuration")));
            
            return Task.FromResult(Outcome<Credentials>.Success(new Credentials(clientId, clientSecret)));
        }

        /// <summary>
        ///   Initializes the <see cref="ConfiguredClientCredentialsProvider"/> object.
        /// </summary>
        /// <param name="config">
        ///   A <see cref="TetraPakConfig"/> object. 
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="config"/> was unassigned.
        /// </exception>
        public ConfiguredClientCredentialsProvider(TetraPakConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }
    }
}