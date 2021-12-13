﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Debugging;
using TetraPak.Caching;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   A default service to support the client credentials grant type.
    /// </summary>
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class TetraPakClientCredentialsGrantService : IClientCredentialsGrantService
    {
        readonly TetraPakConfig _tetraPakConfig;
        readonly IHttpClientProvider _httpClientProvider;
        readonly IHttpContextAccessor _httpContextAccessor;

        const string CacheRepository = CacheRepositories.Tokens.ClientCredentials;

        ILogger? Logger => _tetraPakConfig.Logger;

        ITimeLimitedRepositories? Cache => _tetraPakConfig.Cache;

        HttpContext? HttpContext => _httpContextAccessor.HttpContext;

        /// <inheritdoc />
        public async Task<Outcome<ClientCredentialsResponse>> AcquireTokenAsync(
            CancellationToken? cancellationToken = null,
            Credentials? clientCredentials = null,
            MultiStringValue? scope = null, 
            bool forceAuthorization = false)
        {
            // todo Consider breaking up this method (it's too big) 
            try
            {
                var ct = cancellationToken ?? new CancellationToken();
                if (clientCredentials is null)
                {
                    var ccOutcome = await OnGetCredentialsAsync();
                    if (!ccOutcome)
                        return Outcome<ClientCredentialsResponse>.Fail(ccOutcome.Exception);

                    clientCredentials = ccOutcome.Value!;
                }

                var basicAuthCredentials = validateBasicAuthCredentials(clientCredentials);
                var cachedOutcome = forceAuthorization 
                        ? Outcome<ClientCredentialsResponse>.Fail()
                        : await OnGetCachedResponse(basicAuthCredentials);
                if (cachedOutcome)
                {
                    var cachedResponse = cachedOutcome.Value!;
                    if (cachedResponse.ExpiresIn.Subtract(TimeSpan.FromSeconds(2)) > TimeSpan.Zero)
                        return cachedOutcome;
                }
                
                var clientOutcome = await _httpClientProvider.GetHttpClientAsync();
                if (!clientOutcome)
                    return Outcome<ClientCredentialsResponse>.Fail(
                        new ServerConfigurationException(
                            "Client credentials service failed to obtain a HTTP client (see inner exception)", 
                            clientOutcome.Exception));
                
                using var client = clientOutcome.Value!;
                client.DefaultRequestHeaders.Authorization = basicAuthCredentials.ToAuthenticationHeaderValue();
                var formsValues = new Dictionary<string, string>
                {
                    ["grant_type"] = "client_credentials"
                };
                if (scope is { })
                {
                    formsValues.Add("scope", scope.Items.ConcatCollection(" "));
                }

                var keyValues = formsValues.Select(kvp 
                    => new KeyValuePair<string?, string?>(kvp.Key, kvp.Value));
                
                var request = new HttpRequestMessage(HttpMethod.Post, _tetraPakConfig.TokenIssuerUrl)
                {
                    Content = new FormUrlEncodedContent(keyValues)
                };
                var messageId = HttpContext?.Request.GetMessageId(_tetraPakConfig);
                var sb = Logger?.IsEnabled(LogLevel.Trace) ?? false
                    ? await (await request.ToAbstractHttpRequestAsync()).ToStringBuilderAsync(
                        new StringBuilder(), 
                        () => TraceRequestOptions.Default(messageId)
                            .WithInitiator(this, HttpDirection.Out)
                            .WithDefaultHeaders(client.DefaultRequestHeaders))
                    : null;

                var response = await client.SendAsync(request, ct);
                
                if (sb is { })
                {
                    sb.AppendLine();
                    await (await response.ToAbstractHttpResponseAsync()).ToStringBuilderAsync(sb);
                    Logger.Trace(sb.ToString());
                }
                
                if (!response.IsSuccessStatusCode)
                    return loggedFailedOutcome(response);

#if NET5_0_OR_GREATER
                var stream = await response.Content.ReadAsStreamAsync(ct);
#else
                var stream = await response.Content.ReadAsStreamAsync();
#endif
                var responseBody =
                    await JsonSerializer.DeserializeAsync<ClientCredentialsResponseBody>(
                        stream,
                        cancellationToken: ct);

                var outcome = ClientCredentialsResponse.TryParse(responseBody!);
                if (outcome)
                {
                    await OnCacheResponseAsync(basicAuthCredentials, outcome.Value!);
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
                var ex = new ServerException(response); 
                if (Logger is null)
                    return Outcome<ClientCredentialsResponse>.Fail(ex);

                var messageId = _tetraPakConfig.AmbientData.GetMessageId(true);
                var message = new StringBuilder();
                message.AppendLine("Client credentials failure (state dump to follow if DEBUG log level is enabled)");
                
                if (Logger.IsEnabled(LogLevel.Debug))
                {
                    // var options = new StateDumpContext(_config) obsolete 
                    //     .WithIgnored(
                    //         nameof(TetraPakApiConfig.GrantType),
                    //         nameof(TetraPakConfig.ClientId),
                    //         nameof(TetraPakConfig.ClientSecret),
                    //         nameof(TetraPakConfig.RequestMessageIdHeader),
                    //         nameof(TetraPakConfig.IsPkceUsed),
                    //         nameof(TetraPakConfig.CallbackPath))
                    //     .WithTargetLogger(Logger);
                    var dump = new StateDump().WithStackTrace();
                    dump.AddAsync(_tetraPakConfig, "AuthConfig");
                    dump.AddAsync(clientCredentials, "Credentials");
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
                ? Outcome<ClientCredentialsResponse>.Success(cachedOutcome.Value!.Clone(remainingLifeSpan))
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

        /// <summary>
        ///   This virtual asynchronous method is automatically invoked when <see cref="AcquireTokenAsync"/>
        ///   needs client credentials. 
        /// </summary>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="Credentials"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected virtual Task<Outcome<Credentials>> OnGetCredentialsAsync()
        {
            if (string.IsNullOrWhiteSpace(_tetraPakConfig.ClientId))
                return Task.FromResult(Outcome<Credentials>.Fail(
                    new ServerConfigurationException("Client credentials have not been provisioned")));

            return Task.FromResult(Outcome<Credentials>.Success(
                new BasicAuthCredentials(_tetraPakConfig.ClientId, _tetraPakConfig.ClientSecret)));
        }

        /// <summary>
        ///   Initializes the <see cref="TetraPakClientCredentialsGrantService"/>.
        /// </summary>
        /// <param name="tetraPakConfig">
        ///   The Tetra Pak integration configuration.
        /// </param>
        /// <param name="httpClientProvider">
        ///   A HttpClient factory.
        /// </param>
        /// <param name="httpContextAccessor">
        ///   Provides access to the current request/response <see cref="HttpContext"/>. 
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   Any parameter was <c>null</c>.
        /// </exception>
        public TetraPakClientCredentialsGrantService(
            TetraPakConfig tetraPakConfig, 
            IHttpClientProvider httpClientProvider,
            IHttpContextAccessor httpContextAccessor)
        {
            _tetraPakConfig = tetraPakConfig ?? throw new ArgumentNullException(nameof(tetraPakConfig));
            _httpClientProvider = httpClientProvider ?? throw new ArgumentNullException(nameof(httpClientProvider));
            _httpContextAccessor = httpContextAccessor;
        }
    }
}