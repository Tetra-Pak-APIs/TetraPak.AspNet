using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Debugging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Auth
{
    class TetraPakRefreshTokenGrantService : IRefreshTokenGrantService
    {
        readonly IHttpContextAccessor? _httpContextAccessor;
        readonly TetraPakConfig _tetraPakConfig;
        readonly IHttpClientProvider _httpClientProvider;

        ILogger<TetraPakRefreshTokenGrantService>? Logger { get; }

        HttpContext? HttpContext => _httpContextAccessor?.HttpContext;

        public string? MessageId => HttpContext?.Request.GetMessageId(_tetraPakConfig);

        public async Task<Outcome<RefreshTokenResponse>> RefreshTokenAsync(
            ActorToken refreshToken,
            CancellationToken? cancellationToken)
        {
            var clientOutcome = await _httpClientProvider.GetHttpClientAsync();
            if (!clientOutcome)
                return Outcome<RefreshTokenResponse>.Fail(clientOutcome.Exception);
            
            var uri = _tetraPakConfig.TokenIssuerUrl;
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new FormUrlEncodedContent(content())
            };

            try
            {
                var sb = Logger?.IsEnabled(LogLevel.Trace) ?? false
                    ? await (await request.ToGenericHttpRequestAsync())
                        .ToStringBuilderAsync(new StringBuilder(), () => TraceHttpRequestOptions
                            .Default(MessageId))
                    : null;

                var client = clientOutcome.Value!;
                var ct = cancellationToken ?? CancellationToken.None;
                var response = await client.SendAsync(request, ct); 
                if (!response.IsSuccessStatusCode)
                    return loggedFailedOutcome(response);

#if NET5_0_OR_GREATER
                var stream = await response.Content.ReadAsStreamAsync(ct);
#else
                var stream = await response.Content.ReadAsStreamAsync();
#endif
                if (sb is { })
                {
                    sb.AppendLine();
                    await (await response.ToGenericHttpResponseAsync()).ToStringBuilderAsync(sb);
                    Logger.Trace(sb.ToString());
                }
                
                return await buildAuthResultAsync(stream);
            }
            catch (Exception ex)
            {
                ex = new Exception($"Refresh token flow failed: {ex.Message}", ex);
                Logger.Error(ex);
                return Outcome<RefreshTokenResponse>.Fail(ex);
            }
            
            IEnumerable<KeyValuePair<string?,string?>> content()
            {
                yield return new KeyValuePair<string?, string?>("grant_type", "refresh_token");
                yield return new KeyValuePair<string?, string?>("refresh_token", refreshToken);
                var clientId = _tetraPakConfig.IsPkceUsed ? _tetraPakConfig.ClientId : null;
                if (clientId is {})
                    yield return new KeyValuePair<string?, string?>("client_id", clientId);
            }
        }

        static async Task<Outcome<RefreshTokenResponse>> buildAuthResultAsync(Stream stream)
        {
            using var r = new StreamReader(stream); 
            var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(await r.ReadToEndAsync());
            if (dict is null || !dict.TryGetValue(AmbientData.Keys.AccessToken, out var accessToken))
                return Outcome<RefreshTokenResponse>.Fail(
                    new Exception("Could not get a valid access token."));

            int? expiresInSeconds = dict.TryGetValue(AmbientData.Keys.ExpiresIn, out var exp) && int.TryParse(exp, out var seconds)
                ? seconds
                : null;

            dict.TryGetValue(AmbientData.Keys.RefreshToken, out var refreshToken);
            dict.TryGetValue("id_token", out var idToken);
            
            return Outcome<RefreshTokenResponse>.Success(new RefreshTokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                IdToken = idToken,
                ExpiresInSeconds = expiresInSeconds
            });
        }
        Outcome<RefreshTokenResponse> loggedFailedOutcome(HttpResponseMessage response)
        {
            var ex = new HttpServerException(response); 
            if (Logger is null)
                return Outcome<RefreshTokenResponse>.Fail(ex);

            var messageId = _tetraPakConfig.AmbientData.GetMessageId(true);
            var message = new StringBuilder();
            Logger.Error(ex, message.ToString(), messageId);
            return Outcome<RefreshTokenResponse>.Fail(ex);
        }
        
        // static string makeRefreshTokenBody(string refreshToken, string? clientId = null)
        // {
        //     var sb = new StringBuilder();
        //     sb.Append("grant_type=refresh_token");
        //     sb.Append($"&refresh_token={refreshToken}");
        //     if (clientId is {})
        //     {
        //         sb.Append($"&client_id={clientId}");
        //     }
        //     return sb.ToString();
        // }

        public TetraPakRefreshTokenGrantService(
            TetraPakConfig tetraPakConfig,
            IHttpClientProvider httpClientProvider,
            IHttpContextAccessor? httpContextAccessor, 
            ILogger<TetraPakRefreshTokenGrantService>? logger)
        {
            _tetraPakConfig = tetraPakConfig;
            _httpClientProvider = httpClientProvider;
            _httpContextAccessor = httpContextAccessor;
            Logger = logger;
        }
    }
}