using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.diagnostics;
using TetraPak.AspNet.Diagnostics;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api
{
    
    /// <summary>
    ///   This class is intended to be instantiated via a dependency injection mechanism. 
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    class TetraPakApiAuthorizationService : IAuthorizationService, ITetraPakDiagnosticsProvider
    {
        readonly IServiceProvider _provider;
        readonly IGrantTypeResolver _grantTypeResolver;

        ILogger? Logger => TetraPakConfig.Logger;

        TetraPakConfig TetraPakConfig => _provider.GetRequiredService<TetraPakConfig>();

        /// <summary>
        ///   Gets a <see cref="ITokenExchangeGrantService"/> for acquiring a token to be used
        ///   with clients consuming services.  
        /// </summary>
        ITokenExchangeGrantService TokenExchangeGrantService 
            => _provider.GetRequiredService<ITokenExchangeGrantService>();

        /// <summary>
        ///   Gets a <see cref="IClientCredentialsGrantService"/> for acquiring a token to be used
        ///   with clients consuming services.
        /// </summary>
        IClientCredentialsGrantService ClientCredentialsGrantService
            => _provider.GetRequiredService<IClientCredentialsGrantService>();

        string? getMessageId(bool enforce = false) => TetraPakConfig.AmbientData.GetMessageId(enforce);
        
        HttpContext? HttpContext => TetraPakConfig.AmbientData.HttpContext;

        /// <inheritdoc />
        public async Task<Outcome<ActorToken>> AuthorizeAsync(
            HttpClientOptions options,
            CancellationToken? cancellationToken = null)
        {
            const string TimerNameTx = "out-auth-tx";
            const string TimerNameCc = "out-auth-cc";

            if (options.AuthConfig is null)
                throw new InvalidOperationException(
                    $"{nameof(HttpClientOptions)}.{nameof(HttpClientOptions.AuthConfig)} must be assigned");
            
            try
            {
                var grantType = options.AuthConfig?.GrantType ?? GrantType.TX;
                if (grantType == GrantType.Automatic)
                {
                    grantType = await _grantTypeResolver.ResolveAutomaticGrantType(HttpContext!);
                }
                
                switch (grantType)
                {
                    case GrantType.TokenExchange:
                        ((ITetraPakDiagnosticsProvider) this).DiagnosticsStartTimer(TimerNameTx);
                        var outcome = await OnTokenExchangeAuthenticationAsync(
                            options.AuthConfig!,
                            options.ActorToken,
                            options.ForceAuthorization,
                            cancellationToken);
                        ((ITetraPakDiagnosticsProvider) this).DiagnosticsStopTimer(TimerNameTx);
                        return outcome;
                    
                    case GrantType.ClientCredentials:
                        ((ITetraPakDiagnosticsProvider) this).DiagnosticsStartTimer(TimerNameCc);
                        outcome = await OnClientCredentialsAuthenticationAsync(
                            options.AuthConfig!,
                            cancellationToken);
                        ((ITetraPakDiagnosticsProvider) this).DiagnosticsStopTimer(TimerNameCc);
                        return outcome;
                    
                    case GrantType.None:
                        throw new NotSupportedException($"Cannot authenticate with no specified grant type");
                    
                    case GrantType.Inherited:
                        throw unexpectedMethod();

                    case GrantType.Automatic: // should never happen; just keeping the code analyzer happy
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
                return /*options is null
                    ? new ArgumentOutOfRangeException(
                        nameof(options),
                        "Error when authenticating HTTP client. Unexpected auth mechanism: (null)") obsolete
                    : */
                    new ArgumentOutOfRangeException(
                        nameof(options),
                        $"Error when authenticating HTTP client. Unexpected auth mechanism: {options.AuthConfig?.GrantType}");
            }
        }
        
        /// <summary>
        ///   This method is called to acquire a token using the Token Exchange grant type. 
        /// </summary>
        /// <param name="authConfig">
        ///   Specifies the authentication credentials and options.
        /// </param>
        /// <param name="subjectToken">
        ///   The access token to be exchanged.
        /// </param>
        /// <param name="cancellationToken">
        ///   A <see cref="CancellationToken"/>.
        /// </param>
        /// <param name="forceAuthorization">
        ///   Specifies whether to force a new client authorization (overriding/replacing any cached authorization). 
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpClient"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="HttpServerConfigurationException">
        ///   There where issues with the configured options, such as client id/secret.
        /// </exception>
        protected virtual async Task<Outcome<ActorToken>> OnTokenExchangeAuthenticationAsync(
            IServiceAuthConfig authConfig,
            ActorToken? subjectToken,
            bool forceAuthorization,
            CancellationToken? cancellationToken)
        {
            if (subjectToken is null)
                return Outcome<ActorToken>.Fail(new InvalidOperationException("Expected an access token for token exchange"));
            
            try
            {
                var ct = cancellationToken ?? CancellationToken.None;
                var context = new AuthContext(GrantType.TokenExchange, authConfig);
                var idOutcome = await authConfig.GetClientIdAsync(context);
                if (!idOutcome)
                    throw new HttpServerConfigurationException("Token exchange error: No client id was provided");

                var clientId = idOutcome.Value;
                
                var secretOutcome = await authConfig.GetClientSecretAsync(context);
                if (!secretOutcome)
                    throw new HttpServerConfigurationException("Token exchange error: No client secret was provided");
                    
                var clientSecret = secretOutcome.Value;
            
                var credentials = new BasicAuthCredentials(clientId, clientSecret);
                var txOutcome = await TokenExchangeGrantService.ExchangeAccessTokenAsync(
                    credentials,
                    subjectToken,
                    forceAuthorization,
                    ct);
                if (!txOutcome)
                    throw txOutcome.Exception;

                var token = txOutcome.Value!.AccessToken;
                return Outcome<ActorToken>.Success(token!);
            }
            catch (Exception ex)
            {
                var exception = HttpServerException.Unauthorized("Token exchanged failed (see inner exception)", ex);
                Logger.Error(exception, messageId: getMessageId());
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
        /// <exception cref="HttpServerConfigurationException">
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
                    throw new HttpServerConfigurationException("Token exchange error: No client id was provided");

                var clientId = idOutcome.Value;

                var secretOutcome = await authConfig.GetClientSecretAsync(context);
                if (!secretOutcome)
                    throw new HttpServerConfigurationException("Token exchange error: No client secret was provided");
                    
                var clientSecret = secretOutcome.Value;

                var scopeOutcome = await authConfig.GetScopeAsync(context);
                if (!scopeOutcome)
                    throw new HttpServerConfigurationException("Token exchange error: No scope was provided");
                    
                var scope = scopeOutcome.Value;
                var credentials = new BasicAuthCredentials(clientId, clientSecret);
                var ccOutcome = await ClientCredentialsGrantService.AcquireTokenAsync(ct, credentials, scope);
                if (!ccOutcome)
                    throw ccOutcome.Exception;

                var token = ccOutcome.Value!.AccessToken;
                return Outcome<ActorToken>.Success(token);
            }
            catch (Exception ex)
            {
                var exception = HttpServerException.Unauthorized(
                    "Client credentials authentication failed (see inner exception)", ex);
                Logger.Error(exception, getMessageId());
                return Outcome<ActorToken>.Fail(exception);
            }
        }
        
        void ITetraPakDiagnosticsProvider.DiagnosticsStartTimer(string timerKey) => getDiagnostics()?.StartTimer(timerKey);

        long? ITetraPakDiagnosticsProvider.DiagnosticsStopTimer(string timerKey) => getDiagnostics()?.GetElapsedMs(timerKey);
        
        ServiceDiagnostics? getDiagnostics() => HttpContext?.GetDiagnostics(); 

        public TetraPakApiAuthorizationService(IServiceProvider provider)
        {
            _provider = provider;
            _grantTypeResolver = provider.GetService<IGrantTypeResolver>()
                                          ?? new TetraPakGrantTypeResolver();
        }
    }
}