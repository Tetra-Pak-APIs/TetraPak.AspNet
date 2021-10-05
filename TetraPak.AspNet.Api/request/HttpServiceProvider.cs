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
using TetraPak.AspNet.diagnostics;
using TetraPak.AspNet.Diagnostics;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Implements base functionality for providing HTTP clients
    ///   to be used when consuming configured backend services. 
    /// </summary>
    public class HttpServiceProvider : IHttpServiceProvider, ITetraPakDiagnosticsProvider
    {
        readonly Func<HttpClientOptions,HttpClient> _singletonClientFactory;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly HttpClientOptions _singletonClientOptions;
        HttpClient _singletonClient;
        readonly TetraPakAuthConfig _authConfig;

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
        public string GetMessageId(bool enforce = false) => _authConfig.AmbientData.GetMessageId();

        /// <inheritdoc />
        public Task<Outcome<ActorToken>> GetAccessTokenAsync(bool forceStandardHeader = false) 
            => _authConfig.AmbientData.GetAccessTokenAsync(forceStandardHeader);

        public Task<Outcome<ActorToken>> GetAccessTokenAsync(TetraPakAuthConfig authConfig) 
            => _httpContextAccessor.HttpContext.GetAccessTokenAsync(authConfig);

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        protected ILogger Logger => _authConfig.Logger;

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

        void ITetraPakDiagnosticsProvider.DiagnosticsStartTimer(string timerKey) => GetDiagnostics()?.StartTimer(timerKey);

        void ITetraPakDiagnosticsProvider.DiagnosticsEndTimer(string timerKey) => GetDiagnostics()?.GetElapsedMs(timerKey);

        protected ServiceDiagnostics GetDiagnostics() => _httpContextAccessor.HttpContext.GetDiagnostics(null); 

        /// <inheritdoc />
        public async Task<Outcome<ActorToken>> AuthenticateAsync(
            HttpClientOptions options,
            CancellationToken? cancellationToken = null,
            ILogger logger = null)
        {
            const string TimerNameTx = "out-auth-tx";
            const string TimerNameCc = "out-auth-cc";
            
            try
            {
                switch (options?.AuthConfig.GrantType)
                {
                    case GrantType.TokenExchange:
                        ((ITetraPakDiagnosticsProvider) this).DiagnosticsStartTimer(TimerNameTx);
                        var outcome = await OnTokenExchangeAuthenticationAsync(
                            options.AuthConfig,
                            options.Authorization,
                            cancellationToken);
                        ((ITetraPakDiagnosticsProvider) this).DiagnosticsEndTimer(TimerNameTx);
                        return outcome;
                    
                    case GrantType.ClientCredentials:
                        ((ITetraPakDiagnosticsProvider) this).DiagnosticsStartTimer(TimerNameCc);
                        outcome = await OnClientCredentialsAuthenticationAsync(
                            options.AuthConfig,
                            cancellationToken);
                        ((ITetraPakDiagnosticsProvider) this).DiagnosticsEndTimer(TimerNameCc);
                        return outcome;
                    
                    case GrantType.None:
                        throw new NotSupportedException($"Cannot authenticate with no specified grant type");
                    
                    case GrantType.Inherited:
                    case null:
                        throw unexpectedMethod();
                    
                    default:
                        throw unexpectedMethod();
                }
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
                              var context = new AuthContext(GrantType.TokenExchange, authConfig);
                var idOutcome = await authConfig.GetClientIdAsync(context);
                if (!idOutcome)
                    throw new ConfigurationException("Token exchange error: No client id was provided");

                var clientId = idOutcome.Value;
                
                var secretOutcome = await authConfig.GetClientSecretAsync(context);
                if (!secretOutcome)
                    throw new ConfigurationException("Token exchange error: No client secret was provided");
                    
                var clientSecret = secretOutcome.Value;
            
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
                Logger.Error(exception, messageId: GetMessageId());
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
                var context = new AuthContext(GrantType.TokenExchange, authConfig);
                var idOutcome = await authConfig.GetClientIdAsync(context);
                if (!idOutcome)
                    throw new ConfigurationException("Token exchange error: No client id was provided");

                var clientId = idOutcome.Value;

                var secretOutcome = await authConfig.GetClientSecretAsync(context);
                if (!secretOutcome)
                    throw new ConfigurationException("Token exchange error: No client secret was provided");
                    
                var clientSecret = secretOutcome.Value;

                var scopeOutcome = await authConfig.GetScopeAsync(context);
                if (!scopeOutcome)
                    throw new ConfigurationException("Token exchange error: No scope was provided");
                    
                var scope = scopeOutcome.Value;
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
            TetraPakAuthConfig authConfig,
            Func<HttpClientOptions,HttpClient> singletonClientFactory = null, 
            HttpClientOptions singletonClientOptions = null)
        {
            TokenExchangeService = tokenExchangeService ?? throw new ArgumentNullException(nameof(tokenExchangeService));
            ClientCredentialsService = clientCredentialsService;
            _authConfig = authConfig ?? throw new ArgumentNullException(nameof(authConfig));
            _singletonClientFactory = singletonClientFactory ?? (_ => new SingletonHttpClient());
            _httpContextAccessor = httpContextAccessor;
            _singletonClientOptions = singletonClientOptions;
        }
    }

    public class SingletonHttpClient : HttpClient
    {
        protected override void Dispose(bool disposing)
        {
            // ignore disposing
        }
    }

    public interface ITetraPakDiagnosticsProvider
    {
        void DiagnosticsStartTimer(string timerKey);

        void DiagnosticsEndTimer(string timerKey);
    }
}