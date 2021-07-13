using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   A default service to support the client credentials grant type.
    /// </summary>
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class TetraPakClientCredentialsService : IClientCredentialsService
    {
        readonly TetraPakApiAuthConfig _config;
        readonly AmbientData _ambientData;

        const string CacheRepository = CacheRepositories.Tokens.ClientCredentials;

        /// <summary>
        ///   Gets a logger provider.
        /// </summary>
        protected ILogger Logger => _config.Logger;

        /// <inheritdoc />
        public async Task<Outcome<ClientCredentialsResponse>> AcquireTokenAsync(
            CancellationToken cancellationToken,
            Credentials clientCredentials = null,
            MultiStringValue scope = null, 
            bool allowCached = true)
        {
            try
            {
                var basicAuthCredentials = validateBasicAuthCredentials(clientCredentials ?? OnGetCredentials());
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
                    _config.TokenIssuerUrl,
                    new FormUrlEncodedContent(formsValues),
                    cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    var ex = new HttpException(response); 
                    Logger?.LogError(ex, "Client credentials failure");
                    return Outcome<ClientCredentialsResponse>.Fail(ex);
                }

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
            if (_ambientData.Cache is null)
                return Outcome<ClientCredentialsResponse>.Fail(new Exception("No cached token"));

            var cachedOutcome = await _ambientData.Cache.GetAsync<ClientCredentialsResponse>(
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
            if (_ambientData.Cache is null) 
                return;

            await _ambientData.Cache.AddOrUpdateAsync(
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
            if (string.IsNullOrWhiteSpace(_config.ClientId))
                throw new InvalidOperationException(
                    $"Cannot create client credentials. Please specify '{nameof(TetraPakAuthConfig.ClientId)}' in configuration");
                
            return new BasicAuthCredentials(_config.ClientId, _config.ClientSecret);
        }

        // async void configureCache()
        // {
        //     await _ambientData.Cache.ConfigureTokenCacheAsync(TokenCacheRepository); obsolete
        // }

        public TetraPakClientCredentialsService(TetraPakApiAuthConfig config, AmbientData ambientData)
        {
            _config = config;
            _ambientData = ambientData;
            // configureCache(); obsolete
        }
    }
}