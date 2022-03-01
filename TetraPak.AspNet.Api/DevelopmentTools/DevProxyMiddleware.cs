﻿using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.diagnostics;
using TetraPak.Caching;
using TetraPak.DynamicEntities;
using TetraPak.Logging;
using TetraPak.Serialization;

namespace TetraPak.AspNet.Api.DevelopmentTools
{
    class DevProxyMiddleware
    {
        const string DevProxy = nameof(DevProxy);
        const string CacheRepository = CacheRepositories.Tokens.DevProxy;
        
        readonly string _url;
        readonly TetraPakConfig _config;
        readonly ScriptComparisonExpression? _isMutedWhenCriteria;

        readonly IHttpClientProvider _httpClientProvider;

        ITimeLimitedRepositories? Cache => _config.Cache;
        
        ILogger? Logger => _config.Logger;

        bool IsDebugging { get; }

        public async Task<bool> InvokeAsync(HttpContext context)
        {
            const string TimerName = "dev-proxy";

            var messageId = context.Request.GetMessageId(_config);
            if (isMuted(context.Request))
            {
                Logger.Debug($"{DevProxy} is muted by criteria: \"{_isMutedWhenCriteria}\"", messageId);
                return true;
            }
                
            if (!context.GetEndpoint().IsAuthorizationRequired())
            {
                Logger.Debug($"{DevProxy} bails out. Endpoint does not require authorization", messageId);
                return true;
            }
                
            var ambientData = context.RequestServices.GetService<AmbientData>();
            if (ambientData is null)
                return false;

            // note: enforcing picking the access token from HTTP standard authorization header ...
            var tokenOutcome = await ambientData.GetAccessTokenAsync(true);
            if (!tokenOutcome)
            {
                Logger.Warning($"{DevProxy} failed to resolve an access token", messageId);
                return false;
            }

            var accessToken = tokenOutcome.Value!;
            if (accessToken.IsJwt)
            {
                // access token is already a JWT; no need to get a new one ...
                Logger.Debug($"{DevProxy} bails out. Token was already JWT token", messageId);
                context.Request.Headers[_config.AuthorizationHeader] = accessToken.ToString();
                return true;
            }

            BearerToken jwtBearer;
            context.DiagnosticsStartTimer(TimerName);
            var cachedJwtOutcome = await tryGetCachedJwt(accessToken);
            if (cachedJwtOutcome)
            {
                jwtBearer = cachedJwtOutcome.Value!.Identity.ToBearerToken();
                context.Request.Headers[_config.AuthorizationHeader] = jwtBearer.ToString();
                context.DiagnosticsStopTimer(TimerName);
                return true;
            }

            var jwtBearerOutcome = await getJwtBearerFromRemoteProxyAsync(tokenOutcome.Value!.Identity, messageId);
            object? description = null;
            if (!jwtBearerOutcome)
            {
                string? descriptionJson = null;
                if (jwtBearerOutcome.Exception is HttpServerException { Response: { } } httpException)
                {
                    var targetError = (await httpException.Response.Content.ReadAsStringAsync()).Trim();
                    if (targetError.StartsWith('{'))
                    {
                        try
                        {
                            description = JsonSerializer.Deserialize<DynamicEntity>(targetError);
                            descriptionJson = description.ToJson(true);
                        }
                        catch
                        {
                            description = targetError;
                        }
                    }
                }

                description ??= jwtBearerOutcome.Exception.Message;
                Logger.Error(
                    jwtBearerOutcome.Exception,
                    $"{DevProxy} failed to authenticate access token: " +
                    $"{tokenOutcome.Value}{Environment.NewLine}{descriptionJson ?? description}", 
                    messageId);
                context.Response.OnStarting(async () =>
                {
                    var error = new ApiErrorResponse(
                        $"{DevProxy} failed to authenticate access token: {tokenOutcome.Value}",
                        description,
                        messageId);
                    await context.RespondAsync(HttpStatusCode.Unauthorized, error);
                });
                context.DiagnosticsStopTimer(TimerName);
                return false;
            }

            jwtBearer = jwtBearerOutcome.Value!.Identity.ToBearerToken();
            context.Request.Headers[_config.AuthorizationHeader] = jwtBearer.ToString();
            await cacheToken(accessToken, jwtBearerOutcome.Value);
            context.DiagnosticsStopTimer(TimerName);
 
            return true;
        }

        bool isMuted(HttpRequest request) => _isMutedWhenCriteria?.IsMatch(request) ?? false;

        async Task<Outcome<ActorToken>> tryGetCachedJwt(Credentials accessToken)
        {
            if (Cache is null)
                return Outcome<ActorToken>.Fail(new Exception("Caching is not supported"));
                
            return await Cache.GetAsync<ActorToken>(CacheRepository, accessToken.Identity);
        }

        async Task cacheToken(Credentials accessToken, ActorToken jwtBearerToken)
        {
            if (Cache is null)
                return;

            var expires = jwtBearerToken.ToJwtSecurityToken()?.Expires();
            var lifespan = expires - DateTime.UtcNow ?? TimeSpan.FromSeconds(10);
            await Cache.AddAsync(CacheRepository, accessToken.Identity, jwtBearerToken, lifespan);
        }

        async void configureTokenCache()
        {
            if (Cache is null)
                return;
            
            var options = await Cache.GetRepositoryOptionsAsync(CacheRepository, false);
            if (options is {})
                return;
            
            var defaultOptions = SimpleTimeLimitedRepositoryOptions.Zero;
            defaultOptions.LifeSpan = TimeSpan.FromSeconds(10);
            await Cache.ConfigureAsync(CacheRepository, defaultOptions);
        }

        async Task<Outcome<ActorToken>> getJwtBearerFromRemoteProxyAsync(string accessToken, string? messageId)
        {
            try
            {
                var clientOutcome = await _httpClientProvider.GetHttpClientAsync();
                if (!clientOutcome)
                    return Outcome<ActorToken>.Fail(
                        new HttpServerConfigurationException(
                            "Token exchange failed to obtain a HTTP client (see inner exception)", 
                            clientOutcome.Exception));

                var client = clientOutcome.Value!;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await client.GetAsync(_url);
                if (!response.IsSuccessStatusCode)
                {
                    var exception = new HttpServerException(response);
                    Logger.Error(exception, $"Failed on acquiring JWT bearer from: {_url}", messageId);
                    return Outcome<ActorToken>.Fail(new HttpServerException(response));
                }

                await using var stream = await response.Content.ReadAsStreamAsync();
                var isEmptyResponseBody = false;
                try
                {
                    var responseBody = await JsonSerializer.DeserializeAsync<ProxyResponseBody>(stream);
                    if (responseBody is { }) 
                        return Outcome<ActorToken>.Success(responseBody.Token!);
                    
                    isEmptyResponseBody = true;
                    throw new Exception("JSON serialization returned an empty response body");
                }
                catch (Exception ex)
                {
                    const string EmptyResponseMessage = "Could not get a JWT bearer. Successful response body was empty";
                    if (isEmptyResponseBody)
                        return Outcome<ActorToken>.Fail(new FormatException(EmptyResponseMessage, ex));

                    var body = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrWhiteSpace(body))
                        return Outcome<ActorToken>.Fail(new FormatException(EmptyResponseMessage, ex));
                    
                    return Outcome<ActorToken>.Fail(new FormatException(
                        $"Could not get a JWT bearer. Error while parsing successful response: {body}", ex));
                }
            }
            catch (Exception ex)
            {
                return Outcome<ActorToken>.Fail(ex);
            }
        }

        public DevProxyMiddleware(
            TetraPakConfig config, 
            IHttpClientProvider httpClientProvider, 
            string url,
            ScriptComparisonExpression? isMutedWhenCriteria,
            bool isDebugging)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _httpClientProvider = httpClientProvider;
            _url = string.IsNullOrWhiteSpace(url) 
                ? throw new ArgumentNullException(nameof(url)) 
                : url;
            _isMutedWhenCriteria = isMutedWhenCriteria;
            IsDebugging = isDebugging;
            configureTokenCache();
        }

#pragma warning disable 8618
        // this class is only initiated from JSON deserialization 
        class ProxyResponseBody
        {
            [JsonPropertyName("assertion")]
            public string Token { get; set; }

            [JsonPropertyName("grant_type")]
            public string GrantType { get; set; }
        }
#pragma warning restore 8618
    }
}