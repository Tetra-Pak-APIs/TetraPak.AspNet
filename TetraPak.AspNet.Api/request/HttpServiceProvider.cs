using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Implements base functionality for providing HTTP clients
    ///   to be used when consuming configured backend services. 
    /// </summary>
    public class HttpServiceProvider : IHttpServiceProvider, IApiLoggerProvider
    {
        readonly Func<HttpClientOptions,HttpClient> _singletonClientFactory;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly HttpClientOptions _singletonClientOptions;
        HttpClient _singletonClient;
        
        /// <summary>
        ///   Gets a <see cref="ITokenExchangeService"/> for acquiring a token to be used
        ///   with clients consuming services.  
        /// </summary>
        protected ITokenExchangeService TokenExchangeService { get; }

        /// <summary>
        ///   Gets a <see cref="IClientCredentialsService"/> for acquiring a token to be used
        ///   with clients consuming services.
        /// </summary>
        protected IClientCredentialsService ClientCredentialsService { get; }
        
                
        public Task<Outcome<ActorToken>> GetAccessTokenAsync(TetraPakAuthConfig authConfig) 
            => _httpContextAccessor.HttpContext.GetAccessTokenAsync(authConfig);

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        protected ILogger Logger { get; private set; }

        public HttpClient SingletonClient => _singletonClient ??= _singletonClientFactory(_singletonClientOptions);
        
        /// <inheritdoc />
        public virtual async Task<Outcome<HttpClient>> GetClientAsync(
            HttpClientOptions options = null,
            CancellationToken? cancellationToken = null,
            ILogger logger = null,
            bool authenticate = true)
        {
            var transient = options?.IsClientTransient ?? true;
            var client = transient
                ? options?.MessageHandler is {} 
                    ? new HttpClient(options.MessageHandler) 
                    : new HttpClient()
                : SingletonClient;

            if (!authenticate) 
                return Outcome<HttpClient>.Success(client);
            
            var authOutcome = await AuthenticateAsync(options, cancellationToken, logger);
            if (!authOutcome)
                return Outcome<HttpClient>.Fail(authOutcome.Exception);

            var token = authOutcome.Value;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Identity);
            return Outcome<HttpClient>.Success(client);
        }

        /// <inheritdoc />
        public async Task<Outcome<ActorToken>> AuthenticateAsync(
            HttpClientOptions options,
            CancellationToken? cancellationToken = null,
            ILogger logger = null)
        {
            return options?.AuthConfig.GrantType switch
            {
                GrantType.TokenExchange => await OnTokenExchangeAuthenticationAsync(
                    options.AuthConfig,
                    options.Authentication.Parameter,
                    cancellationToken, logger),

                GrantType.ClientCredentials => await OnClientCredentialsAuthenticationAsync(
                    options.AuthConfig,
                    cancellationToken, 
                    logger),
                
                GrantType.None => throw new NotSupportedException($"Cannot authenticate with no specified grant type"), // Outcome<ActorToken>.Success(client), obsolete
                GrantType.Inherited => throw unexpectedMethod(),
                null => throw unexpectedMethod(),
                _ => throw unexpectedMethod()
            };

            Exception unexpectedMethod()
            {
                return options is null
                    ? new ArgumentOutOfRangeException(
                        nameof(options),
                        "Error when authenticating HTTP client. Unexpected auth mechanism: (null)")
                    : new ArgumentOutOfRangeException(
                        nameof(options),
                        $"Error when authenticating HTTP client. Unexpected auth mechanism: {options.AuthConfig.GrantType}");
            }
        }

        /// <summary>
        ///   This method is called to acquire a token using the Token Exchange grant type. 
        /// </summary>
        /// <param name="authConfig">
        ///   Specifies the authentication credentials and options.
        /// </param>
        /// <param name="accessToken">
        ///   The access token to be exchanged.
        /// </param>
        /// <param name="cancellationToken">
        ///   A <see cref="CancellationToken"/>.
        /// </param>
        /// <param name="logger">
        ///   A logging provider.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpClient"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="ConfigurationException">
        ///   There where issues with the configured options, such as client id/secret.
        /// </exception>
        protected virtual async Task<Outcome<ActorToken>> OnTokenExchangeAuthenticationAsync(
            IServiceAuthConfig authConfig,
            string accessToken,
            CancellationToken? cancellationToken,
            ILogger logger)
        {
            var ct = cancellationToken ?? CancellationToken.None;
            var clientId = authConfig.ClientId?.Trim();
            if (string.IsNullOrEmpty(clientId))
                throw new ConfigurationException("Token exchange error: No client id was provided");

            var clientSecret = authConfig.ClientSecret?.Trim();
            if (string.IsNullOrEmpty(clientSecret))
                throw new ConfigurationException("Token exchange error: No client secret was provided");
            
            var credentials = new BasicAuthCredentials(clientId, clientSecret);
            var txOutcome = await TokenExchangeService.ExchangeAccessTokenAsync(credentials, accessToken, ct);
            if (!txOutcome)
                return Outcome<ActorToken>.Fail(txOutcome.Exception);

            var token = txOutcome.Value.AccessToken;
            return Outcome<ActorToken>.Success(token);
        }

        /// <summary>
        ///   This method is called to acquire a token using the Client Credentials grant type. 
        /// </summary>
        /// <param name="authConfig">
        ///   Specifies the authentication credentials and options.
        /// </param>
        /// <param name="cancellationToken">
        ///   A <see cref="CancellationToken"/>.
        /// </param>
        /// <param name="logger">
        ///   A logging provider.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpClient"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="ConfigurationException">
        ///   There where issues with the configured options, such as client id/secret.
        /// </exception>
        protected virtual async Task<Outcome<ActorToken>> OnClientCredentialsAuthenticationAsync(
            IServiceAuthConfig authConfig, 
            CancellationToken? cancellationToken, 
            ILogger logger)
        {
            var ct = cancellationToken ?? CancellationToken.None;
            var clientId = authConfig.ClientId?.Trim();
            if (string.IsNullOrEmpty(clientId))
                throw new ConfigurationException("Token exchange error: No client id was provided");

            var clientSecret = authConfig.ClientSecret?.Trim();
            if (string.IsNullOrEmpty(clientSecret))
                throw new ConfigurationException("Token exchange error: No client secret was provided");

            var scope = authConfig.Scope;
            var credentials = new BasicAuthCredentials(clientId, clientSecret);
            var ccOutcome = await ClientCredentialsService.AcquireTokenAsync(ct, credentials, scope);
            if (!ccOutcome)
                return Outcome<ActorToken>.Fail(ccOutcome.Exception);

            var token = ccOutcome.Value.AccessToken;
            return Outcome<ActorToken>.Success(token);
        }
        
        /// <inheritdoc />
        public Task<ITokenExchangeService> GetTokenExchangeService() => Task.FromResult(TokenExchangeService);

        public ILogger GetLogger() => Logger;

        public void SetLogger(ILogger logger) => Logger = logger;

        public HttpServiceProvider(
            ITokenExchangeService tokenExchangeService,
            IClientCredentialsService clientCredentialsService,
            IHttpContextAccessor httpContextAccessor,
            Func<HttpClientOptions,HttpClient> singletonClientFactory = null, 
            HttpClientOptions singletonClientOptions = null)
        {
            TokenExchangeService = tokenExchangeService ?? throw new ArgumentNullException(nameof(tokenExchangeService));
            ClientCredentialsService = clientCredentialsService;
            _singletonClientFactory = singletonClientFactory ?? (_ => new HttpClient());
            _httpContextAccessor = httpContextAccessor;
            _singletonClientOptions = singletonClientOptions;
        }
    }
}