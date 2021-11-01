using System;
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

#nullable enable


namespace TetraPak.AspNet.Api.DevelopmentTools
{
    class DevProxyMiddleware
    {
        const string CacheRepository = CacheRepositories.Tokens.DevProxy;
        
        readonly string _url;
        readonly TetraPakConfig _config;
        readonly HttpComparison? _isMutedWhenCriteria;

        readonly IHttpClientProvider _httpClientProvider;
        // readonly IHttpServiceProvider _httpService; obsolete

        ITimeLimitedRepositories? Cache => _config.Cache;
        
        ILogger? Logger => _config.Logger;

        public async Task<bool> InvokeAsync(HttpContext context)
        {
            const string TimerName = "dev-proxy";

            if (isMuted(context.Request))
            {
                Logger.Debug($"Desktop DevProxy is muted by criteria: \"{_isMutedWhenCriteria}\"");
                return true;
            }
                
            var messageId = context.Request.GetMessageId(_config);
            if (!context.GetEndpoint().IsAuthorizationRequired())
            {
                Logger.Debug("Local development proxy bails out. Endpoint does not require authorization", messageId);
                return true;
            }
                
            var ambientData = context.RequestServices.GetService<AmbientData>();
            if (ambientData is null)
                return false;

            // note: enforcing picking the access token from HTTP standard authorization header ...
            var tokenOutcome = await ambientData.GetAccessTokenAsync(true);
            if (!tokenOutcome)
            {
                Logger.Warning("Failed to resolve an access token", messageId);
                return false;
            }

            var accessToken = tokenOutcome.Value!;
            if (accessToken.IsJwt)
            {
                // access token is already a JWT; no need to get a new one ...
                Logger.Debug("Local development proxy bails out. Token was already JWT token");
                context.Request.Headers[_config.AuthorizationHeader] = accessToken.ToString();
                return true;
            }

            BearerToken jwtBearer;
            context.StartDiagnosticsTime(TimerName);
            var cachedJwtOutcome = await tryGetCachedJwt(accessToken);
            if (cachedJwtOutcome)
            {
                jwtBearer = cachedJwtOutcome.Value!.Identity.ToBearerToken();
                context.Request.Headers[_config.AuthorizationHeader] = jwtBearer.ToString();
                context.EndDiagnosticsTime(TimerName);
                return true;
            }

            var jwtBearerOutcome = await getJwtBearerAsync(tokenOutcome.Value!.Identity, messageId);
            object? description = null;
            if (!jwtBearerOutcome)
            {
                string? descriptionJson = null;
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

            jwtBearer = jwtBearerOutcome.Value!.Identity.ToBearerToken();
            context.Request.Headers[_config.AuthorizationHeader] = jwtBearer.ToString();
            await cacheToken(accessToken, jwtBearerOutcome.Value);
            context.EndDiagnosticsTime(TimerName);
 
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

            var expires = jwtBearerToken.ToJwtSecurityToken().Expires();
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

        async Task<Outcome<ActorToken>> getJwtBearerAsync(string accessToken, string? messageId)
        {
            try
            {
                var clientOutcome = await _httpClientProvider.GetHttpClientAsync();
                if (!clientOutcome)
                    return Outcome<ActorToken>.Fail(
                        new ConfigurationException(
                            "Token exchange failed to obtain a HTTP client (see inner exception)", 
                            clientOutcome.Exception));
                
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

        public DevProxyMiddleware(TetraPakConfig config, IHttpClientProvider httpClientProvider, string url,
            HttpComparison? isMutedWhenCriteria)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _httpClientProvider = httpClientProvider;
            _url = string.IsNullOrWhiteSpace(url) 
                ? throw new ArgumentNullException(nameof(url)) 
                : url;
            _isMutedWhenCriteria = isMutedWhenCriteria;
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