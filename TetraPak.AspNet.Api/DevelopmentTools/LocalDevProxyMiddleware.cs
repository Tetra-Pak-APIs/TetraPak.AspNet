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
    class LocalDevProxyMiddleware
    {
        const string CacheRepository = CacheRepositories.Tokens.DevProxy;
        
        readonly AmbientData _ambientData;
        readonly string _url;

        ILogger Logger => _ambientData.Logger;

        TetraPakAuthConfig AuthConfig => _ambientData.AuthConfig; 
        

        public async Task<bool> InvokeAsync(HttpContext context)
        {
            const string TimerName = "dev-proxy"; 
            
            var ambientData = context.RequestServices.GetService<AmbientData>();
            if (ambientData is null)
                return false;

            // note: enforcing picking the access token from HTTP standard authorization header ...
            var tokenOutcome = await ambientData.GetAccessTokenAsync(true);
            var messageId = context.Request.GetMessageId(AuthConfig);
            if (!tokenOutcome)
            {
                Logger.Warning("Failed to resolve an access token", messageId);
                return false;
            }

            var accessToken = tokenOutcome.Value;
            if (accessToken.IsJwt)
            {
                // access token is already a JWT; skip exchanging it ...
                Logger.Debug("Local development proxy bails out. Token was already JWT token");
                context.Request.Headers[AuthConfig.AuthorizationHeader] = accessToken.ToString();
                return true;
            }

            BearerToken bearer;
            context.StartDiagnosticsTime(TimerName);
            var cacheOutcome = await tryGetCachedToken(accessToken);
            if (cacheOutcome)
            {
                bearer = cacheOutcome.Value.Identity.ToBearerToken();
                context.Request.Headers[AuthConfig.AuthorizationHeader] = bearer.ToString();
                context.EndDiagnosticsTime(TimerName);
                return true;
            }

            var jwtBearerOutcome = await getJwtBearerAsync(tokenOutcome.Value.Identity, messageId);
            object description = null;
            if (!jwtBearerOutcome)
            {
                string descriptionJson = null;
                if (jwtBearerOutcome.Exception is HttpException httpException)
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
                    "Local development proxy failed to authenticate access token: " +
                    $"{tokenOutcome.Value}{Environment.NewLine}{descriptionJson ?? description}", 
                    messageId);
                context.Response.OnStarting(async () =>
                {
                    var error = new ApiErrorResponse(
                        $"Local development proxy failed to authenticate access token: {tokenOutcome.Value}",
                        description,
                        messageId);
                    await context.RespondAsync(HttpStatusCode.Unauthorized, error);
                });
                context.EndDiagnosticsTime(TimerName);
                return false;
            }

            bearer = jwtBearerOutcome.Value.Identity.ToBearerToken();
            context.Request.Headers[AuthConfig.AuthorizationHeader] = bearer.ToString();
            await cacheToken(accessToken, jwtBearerOutcome.Value);
            context.EndDiagnosticsTime(TimerName);
 
            return true;
        }

        async Task<Outcome<ActorToken>> tryGetCachedToken(Credentials accessToken)
        {
            if (_ambientData.Cache is null)
                return Outcome<ActorToken>.Fail(new Exception("Caching is not supported"));
                
            return await _ambientData.Cache.GetAsync<ActorToken>(CacheRepository, accessToken.Identity);
        }

        async Task cacheToken(Credentials accessToken, ActorToken jwtBearerToken)
        {
            if (_ambientData.Cache is null)
                return;

            var expires = jwtBearerToken.ToJwtSecurityToken().Expires();
            var lifespan = expires - DateTime.UtcNow ?? TimeSpan.FromSeconds(10);
            await _ambientData.Cache?.AddAsync(CacheRepository, accessToken.Identity, jwtBearerToken, customLifeSpan: lifespan);
        }

        async void configureTokenCache()
        {
            var options = await _ambientData.Cache.GetRepositoryOptionsAsync(CacheRepository, false);
            if (options is {})
                return;
            
            var defaultOptions = SimpleTimeLimitedRepositoryOptions.Zero;
            defaultOptions.LifeSpan = TimeSpan.FromSeconds(10);
            await _ambientData.Cache.ConfigureAsync(CacheRepository, defaultOptions);
        }

        async Task<Outcome<ActorToken>> getJwtBearerAsync(string accessToken, string messageId)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await client.GetAsync(_url);
                if (!response.IsSuccessStatusCode)
                {
                    var exception = new HttpException(response);
                    Logger.Error(exception, $"Failed on acquiring JWT bearer from: {_url}", messageId);
                    return Outcome<ActorToken>.Fail(new HttpException(response));
                }

                await using var stream = await response.Content.ReadAsStreamAsync();
                var isEmptyResponseBody = false;
                try
                {
                    var responseBody = await JsonSerializer.DeserializeAsync<ProxyResponseBody>(stream);
                    if (responseBody is { }) 
                        return Outcome<ActorToken>.Success(responseBody.Token);
                    
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

        public LocalDevProxyMiddleware(AmbientData ambientData, string url)
        {
            _ambientData = ambientData ?? throw new ArgumentNullException(nameof(ambientData));
            _url = string.IsNullOrWhiteSpace(url) 
                ? throw new ArgumentNullException(nameof(url)) 
                : url;
            configureTokenCache();
        }

        class ProxyResponseBody
        {
            [JsonPropertyName("assertion")]
            public string Token { get; set; }

            [JsonPropertyName("grant_type")]
            public string GrantType { get; set; }
        }
    }
}