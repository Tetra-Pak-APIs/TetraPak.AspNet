﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    public class TetraPakTokenExchangeService : ITokenExchangeService, IMessageIdProvider
    {
        readonly TetraPakApiAuthConfig _config;
        readonly AmbientData _ambientData;

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        protected ILogger Logger => _config.Logger;

        /// <inheritdoc />
        public string GetMessageId(bool enforce = false) => _ambientData.GetMessageId();

        /// <inheritdoc />
        public async Task<Outcome<TokenExchangeResponse>> ExchangeAccessTokenAsync(
            Credentials credentials, 
            ActorToken accessToken,
            CancellationToken cancellationToken)
        {
            var args = new TokenExchangeArgs(
                credentials, 
                accessToken, 
                "urn:ietf:params:oauth:token-type:id_token");
            return await ExchangeAsync(args, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Outcome<TokenExchangeResponse>> ExchangeAsync(
            TokenExchangeArgs args, 
            CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            if (!(args.Credentials is BasicAuthCredentials basicAuthCredentials))
                return Outcome<TokenExchangeResponse>.Fail(
                    new InvalidOperationException(
                        $"Tetra Pak token exchange expects credentials to be of type {typeof(BasicAuthCredentials)}"));
                
            client.DefaultRequestHeaders.Authorization = basicAuthCredentials.ToAuthenticationHeaderValue();
            try
            {
                var discovery = await _config.GetDiscoveryDocumentAsync();
                var dictionary = args.ToDictionary();
                var response = await client.PostAsync(
                    discovery.TokenEndpoint, 
                    new FormUrlEncodedContent(dictionary), 
                    cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    var ex = new HttpException(response);
                    Logger.Error(ex, "Token exchange failure", GetMessageId());
                    return Outcome<TokenExchangeResponse>.Fail(ex);
                }

#if NET5_0_OR_GREATER
                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
#else
                var stream = await response.Content.ReadAsStreamAsync();
#endif
                var responseBody =
                    await JsonSerializer.DeserializeAsync<TokenExchangeResponse>(stream,
                        cancellationToken: cancellationToken);
                return Outcome<TokenExchangeResponse>.Success(responseBody);
            }
            catch (Exception ex)
            {
                return Outcome<TokenExchangeResponse>.Fail(ex);
            }
        }

        /// <inheritdoc />
        public virtual AuthenticationHeaderValue OnGetAuthorizationFrom(TokenExchangeResponse tokenExchangeResponse)
        {
            var accessToken = tokenExchangeResponse.AccessToken;
            return new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public TetraPakTokenExchangeService(TetraPakApiAuthConfig config, AmbientData ambientData)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _ambientData = ambientData;
        }
    }
}