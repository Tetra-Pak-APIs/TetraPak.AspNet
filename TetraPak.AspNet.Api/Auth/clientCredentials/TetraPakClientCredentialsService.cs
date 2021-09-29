using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.Caching;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   A default service to support the client credentials grant type.
    /// </summary>
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class TetraPakClientCredentialsService : IClientCredentialsService
    {
        readonly TetraPakAuthConfig _authConfig;

        const string CacheRepository = CacheRepositories.Tokens.ClientCredentials;

        /// <summary>
        ///   Gets a logger provider.
        /// </summary>
        protected ILogger? Logger => _authConfig.Logger;

        ITimeLimitedRepositories? Cache => _authConfig.Cache;

        /// <inheritdoc />
        public async Task<Outcome<ClientCredentialsResponse>> AcquireTokenAsync(
            CancellationToken cancellationToken,
            Credentials? clientCredentials = null,
            MultiStringValue? scope = null, 
            bool allowCached = true)
        {
            try
            {
                clientCredentials ??= OnGetCredentials();
                var basicAuthCredentials = validateBasicAuthCredentials(clientCredentials);
                var cachedOutcome = await OnGetCachedResponse(basicAuthCredentials);
                if (cachedOutcome && cachedOutcome.Value.ExpiresIn.Subtract(TimeSpan.FromSeconds(2)) > TimeSpan.Zero)
                    return cachedOutcome;
                
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = basicAuthCredentials.ToAuthenticationHeaderValue();
                var formsValues = new Dictionary<string, string>
                {
                    ["grant_type"] = "client_credentials"
                };
                if (scope is { })
                {
                    formsValues.Add("scope", scope.Items.ConcatCollection(" "));
                }
                var response = await client.PostAsync(
                    _authConfig.TokenIssuerUrl,
                    new FormUrlEncodedContent(formsValues),
                    cancellationToken);

                if (!response.IsSuccessStatusCode)
                    return loggedFailedOutcome(response);

#if NET5_0_OR_GREATER
                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
#else
                var stream = await response.Content.ReadAsStreamAsync();
#endif
                var responseBody =
                    await JsonSerializer.DeserializeAsync<ClientCredentialsResponseBody>(stream,
                        cancellationToken: cancellationToken);

                var outcome = ClientCredentialsResponse.TryParse(responseBody);
                if (outcome)
                {
                    await OnCacheResponseAsync(basicAuthCredentials, outcome.Value);
                }

                return outcome;
            }
            catch (Exception ex)
            {
                ex = new Exception($"Failed to acquire token using client credentials. {ex.Message}", ex);
                Logger.Error(ex);
                return Outcome<ClientCredentialsResponse>.Fail(ex);
            }
            
            Outcome<ClientCredentialsResponse> loggedFailedOutcome(HttpResponseMessage response)
            {
                var ex = new HttpException(response); 
                if (Logger is null)
                    return Outcome<ClientCredentialsResponse>.Fail(ex);

                var messageId = _authConfig.AmbientData.GetMessageId(true);
                var message = new StringBuilder();
                message.AppendLine("Client credentials failure (state dump to follow if DEBUG log level is enabled)");
                
                if (Logger.IsEnabled(LogLevel.Debug))
                {
                    var options = new StateDumpOptions(_authConfig)
                        .WithIgnored(
                            nameof(TetraPakApiAuthConfig.GrantType),
                            nameof(TetraPakAuthConfig.ClientId),
                            nameof(TetraPakAuthConfig.ClientSecret),
                            nameof(TetraPakAuthConfig.RequestMessageIdHeader),
                            nameof(TetraPakAuthConfig.IsPkceUsed),
                            nameof(TetraPakAuthConfig.CallbackPath))
                        .WithTargetLogger(Logger);
                    var dump = new StateDump().WithStackTrace();
                    dump.Add(_authConfig, "AuthConfig", options);
                    options = new StateDumpOptions(clientCredentials).WithTargetLogger(Logger);
                    dump.Add(clientCredentials, "Credentials", options);
                    message.AppendLine(dump.ToString());
                }
                Logger.Error(ex, message.ToString(), messageId);
                return Outcome<ClientCredentialsResponse>.Fail(ex);
            }
        }

        /// <summary>
        ///   Invoked from <see cref="AcquireTokenAsync"/> when to try fetching a cached auth response.  
        /// </summary>
        /// <param name="credentials">
        ///     The credentials used to acquire the response.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ClientCredentialsResponse"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected virtual async Task<Outcome<ClientCredentialsResponse>> OnGetCachedResponse(Credentials credentials)
        {
            if (Cache is null)
                return Outcome<ClientCredentialsResponse>.Fail(new Exception("No cached token"));

            var cachedOutcome = await Cache.GetAsync<ClientCredentialsResponse>(
                CacheRepository, 
                credentials.Identity,
                out var remainingLifeSpan);

            return cachedOutcome
                ? Outcome<ClientCredentialsResponse>.Success(cachedOutcome.Value.Clone(remainingLifeSpan))
                : cachedOutcome;
        }

        /// <summary>
        ///   Invoked from <see cref="AcquireTokenAsync"/> when receiving a successful auth response.  
        /// </summary>
        /// <param name="credentials">
        ///     The credentials used to acquire the response.
        /// </param>
        /// <param name="response">
        ///     The response to be cached.
        /// </param>
        /// <returns>
        ///   The <paramref name="response"/> value.
        /// </returns>
        protected virtual async Task OnCacheResponseAsync(Credentials credentials,
            ClientCredentialsResponse response)
        {
            if (Cache is null) 
                return;

            await Cache.AddOrUpdateAsync(
                CacheRepository,
                credentials.Identity,
                response, 
                response.ExpiresIn);
        }
        
        static BasicAuthCredentials validateBasicAuthCredentials(Credentials credentials)
        {
            if (string.IsNullOrWhiteSpace(credentials.Identity) || string.IsNullOrWhiteSpace(credentials.Secret))
                throw new InvalidOperationException("Invalid credentials. Please specify client id and secret");

            return new BasicAuthCredentials(credentials.Identity, credentials.Secret);
        }

        protected virtual Credentials OnGetCredentials()
        {
            if (string.IsNullOrWhiteSpace(_authConfig.ClientId))
                throw new InvalidOperationException(
                    $"Cannot create client credentials. Please specify '{nameof(TetraPakAuthConfig.ClientId)}' in configuration");
                
            return new BasicAuthCredentials(_authConfig.ClientId, _authConfig.ClientSecret);
        }

        public TetraPakClientCredentialsService(TetraPakAuthConfig authConfig)
        {
            _authConfig = authConfig ?? throw new ArgumentNullException(nameof(authConfig));
        }
    }
}