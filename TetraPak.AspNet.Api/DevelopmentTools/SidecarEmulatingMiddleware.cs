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
using TetraPak.DynamicEntities;
using TetraPak.Logging;
using TetraPak.Serialization;

namespace TetraPak.AspNet.Api.DevelopmentTools
{
    class SidecarEmulatingMiddleware
    {
        readonly TetraPakAuthConfig _authConfig;
        readonly string _url;

        ILogger Logger => _authConfig.Logger;

        public async Task<bool> InvokeAsync(HttpContext context)
        {
            var ambientData = context.RequestServices.GetService<AmbientData>();
            if (ambientData is null)
                return false;

            // note: passing an unassigned Auth Config to ensure we always pick the access token from default header ...
            var tokenOutcome = await ambientData.GetAccessTokenAsync();
            var messageId = context.Request.GetMessageId(_authConfig);
            if (!tokenOutcome)
            {
                Logger.Warning("Failed to resolve an access token", messageId);
                return false;
            }

            // ignore if token is already a JWT ...
            var actorToken = tokenOutcome.Value;
            if (actorToken.IsJwt)
            {
                Logger.Debug("Local development sidecar bails out. Token was already JWT token");
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
                    "Local development sidecar failed to authenticate access token: " +
                    $"{tokenOutcome.Value}{Environment.NewLine}{descriptionJson ?? description}", 
                    messageId);
                context.Response.OnStarting(async () =>
                {
                    var error = new ApiErrorResponse(
                        $"Local development sidecar failed to authenticate access token: {tokenOutcome.Value}",
                        description,
                        messageId);
                    await context.RespondAsync(HttpStatusCode.Unauthorized, error);
                });
                return false;
            }

            var bearer = jwtBearerOutcome.Value.Identity.ToBearerToken();
            context.Request.Headers[_authConfig.AuthorizationHeader] = bearer.ToString();
            return true;
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
                    var responseBody = await JsonSerializer.DeserializeAsync<SidecarResponseBody>(stream);
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

        public SidecarEmulatingMiddleware(TetraPakAuthConfig authConfig, string url)
        {
            _authConfig = authConfig ?? throw new ArgumentNullException(nameof(authConfig));
            _url = string.IsNullOrWhiteSpace(url) 
                ? throw new ArgumentNullException(nameof(url)) 
                : url;
        }

        class SidecarResponseBody
        {
            [JsonPropertyName("assertion")]
            public string Token { get; set; }

            [JsonPropertyName("grant_type")]
            public string GrantType { get; set; }
        }
    }
}