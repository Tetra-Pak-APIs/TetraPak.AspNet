using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Implements base functionality for providing HTTP clients
    ///   to be used when consuming configured backend services. 
    /// </summary>
    public class HttpServiceProvider : IHttpServiceProvider
    {
        readonly Func<HttpClientOptions,HttpClient> _singletonClientFactory;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly AmbientData _ambientData;
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

        /// <inheritdoc />
        public string GetMessageId(bool enforce = false) => _ambientData.GetMessageId();

        /// <inheritdoc />
        public Task<Outcome<ActorToken>> GetAccessTokenAsync() => _ambientData.GetAccessTokenAsync();

        public Task<Outcome<ActorToken>> GetAccessTokenAsync(TetraPakAuthConfig authConfig) 
            => _httpContextAccessor.HttpContext.GetAccessTokenAsync(authConfig);

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        protected ILogger Logger => _ambientData.Logger;

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
            {
                var exception = new HttpException(
                    HttpStatusCode.Unauthorized, 
                    "Failed to authenticate an HTTP client", 
                    authOutcome.Exception);
                Logger.Error(exception, messageId: GetMessageId());
                return Outcome<HttpClient>.Fail(exception);
            }

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
            try
            {
                return options?.AuthConfig.GrantType switch
                {
                    GrantType.TokenExchange => await OnTokenExchangeAuthenticationAsync(
                        options.AuthConfig,
                        options.Authorization,
                        cancellationToken),

                    GrantType.ClientCredentials => await OnClientCredentialsAuthenticationAsync(
                        options.AuthConfig,
                        cancellationToken),
                
                    GrantType.None => throw new NotSupportedException($"Cannot authenticate with no specified grant type"), 
                    GrantType.Inherited => throw unexpectedMethod(),
                    null => throw unexpectedMethod(),
                    _ => throw unexpectedMethod()
                };
            }
            catch (Exception ex)
            {
                return Outcome<ActorToken>.Fail(ex);
            }

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
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpClient"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="ConfigurationException">
        ///   There where issues with the configured options, such as client id/secret.
        /// </exception>
        protected virtual async Task<Outcome<ActorToken>> OnTokenExchangeAuthenticationAsync(
            IServiceAuthConfig authConfig,
            ActorToken accessToken,
            CancellationToken? cancellationToken)
        {
            try
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
                    throw txOutcome.Exception;

                var token = txOutcome.Value.AccessToken;
                return Outcome<ActorToken>.Success(token);
            }
            catch (Exception ex)
            {
                var exception = new HttpException(
                    HttpStatusCode.Unauthorized,
                    "Token exchanged failed (see inner exception)", ex);
                Logger.Error(exception, GetMessageId());
                return Outcome<ActorToken>.Fail(exception);
            }
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
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpClient"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="ConfigurationException">
        ///   There where issues with the configured options, such as client id/secret.
        /// </exception>
        protected virtual async Task<Outcome<ActorToken>> OnClientCredentialsAuthenticationAsync(
            IServiceAuthConfig authConfig, 
            CancellationToken? cancellationToken)
        {
            try
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
                    throw ccOutcome.Exception;

                var token = ccOutcome.Value.AccessToken;
                return Outcome<ActorToken>.Success(token);
            }
            catch (Exception ex)
            {
                var exception = new HttpException(
                    HttpStatusCode.Unauthorized,
                    "Client credentials authentication failed (see inner exception)", ex);
                Logger.Error(exception, GetMessageId());
                return Outcome<ActorToken>.Fail(exception);
            }
        }
        
        /// <inheritdoc />
        public Task<ITokenExchangeService> GetTokenExchangeService() => Task.FromResult(TokenExchangeService);

        public ILogger GetLogger() => Logger;

        public HttpServiceProvider(
            ITokenExchangeService tokenExchangeService,
            IClientCredentialsService clientCredentialsService,
            IHttpContextAccessor httpContextAccessor,
            AmbientData ambientData,
            Func<HttpClientOptions,HttpClient> singletonClientFactory = null, 
            HttpClientOptions singletonClientOptions = null)
        {
            TokenExchangeService = tokenExchangeService ?? throw new ArgumentNullException(nameof(tokenExchangeService));
            ClientCredentialsService = clientCredentialsService;
            _singletonClientFactory = singletonClientFactory ?? (_ => new HttpClient());
            _httpContextAccessor = httpContextAccessor;
            _ambientData = ambientData;
            _singletonClientOptions = singletonClientOptions;
        }
    }
}