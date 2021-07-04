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
using TetraPak.Logging;

namespace TetraPak.AspNet.DevelopmentTools
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

            var tokenOutcome = await ambientData.GetAccessTokenAsync(_authConfig);
            if (!tokenOutcome)
            {
                Logger.Warning("Failed to resolve an access token");
                return false;
            }

            // ignore if token is already a JWT ...
            var actorToken = tokenOutcome.Value;
            if (actorToken.IsJwt)
            {
                Logger.Debug("Local development sidecar bails out. Token was already JWT token");
                return true;
            }

            var jwtBearerOutcome = await getJwtBearerAsync(tokenOutcome.Value.Identity);
            if (!jwtBearerOutcome)
            {
                string targetError = null;
                if (jwtBearerOutcome.Exception is HttpException httpException)
                {
                    targetError = await httpException.Response.Content.ReadAsStringAsync();
                }
                Logger.Error(jwtBearerOutcome.Exception);
                context.Response.OnStarting(async () =>
                {
                    var content = new
                    {
                        message = $"Local development sidecar failed to authenticate access token: {tokenOutcome.Value}",
                        targetError = targetError ?? "(none)"
                    };
                    await context.RespondAsync(HttpStatusCode.Unauthorized, content);
                });
                return false;
            }

            var bearer = jwtBearerOutcome.Value.Identity.ToBearerToken();
            context.Request.Headers[_authConfig.AuthorizationHeader] = bearer.ToString();
            return true;
        }

        async Task<Outcome<ActorToken>> getJwtBearerAsync(string accessToken)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await client.GetAsync(_url);
                if (!response.IsSuccessStatusCode)
                    return Outcome<ActorToken>.Fail(new HttpException(response));

                await using var stream = await response.Content.ReadAsStreamAsync();
                try
                {
                    var responseBody = await JsonSerializer.DeserializeAsync<SidecarResponseBody>(stream);
                    if (responseBody is null)
                        throw new Exception("JSON serialization returned an empty response body");

                    return Outcome<ActorToken>.Success(responseBody.Token);
                }
                catch (Exception ex)
                {
                    return Outcome<ActorToken>.Fail(new FormatException(
                        "Could not get a JWT bearer. Error while parsing successful response", ex));
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