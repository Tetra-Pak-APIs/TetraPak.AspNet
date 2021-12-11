using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Debugging;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet.Auth
{
    partial class TetraPakAuth // refresh token flow 
    {
        public static async Task<Outcome<TokenRefreshResponse>> RefreshTokenAsync( // todo Consider refactoring to service (like with ITokenExchangeService)
            this TetraPakConfig config,
            string refreshToken,
            ILogger? logger,
            string? messageId)
        {
            var body = makeRefreshTokenBody(refreshToken, config.IsPkceUsed ? config.ClientId : null);
            var uri = config.TokenIssuerUrl;
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            var bodyData = Encoding.ASCII.GetBytes(body);
            request.ContentLength = bodyData.Length;
            var stream = request.GetRequestStream();
            await stream.WriteAsync(bodyData.AsMemory(0, bodyData.Length));
            stream.Close();

            try
            {
                var sb = logger?.IsEnabled(LogLevel.Trace) ?? false
                    ? await request.ToAbstractHttpRequestAsync().ToStringBuilderAsync(new StringBuilder(), () => TraceRequestOptions
                        .Default(messageId))
                    : null;
                
                var response = await request.GetResponseAsync();
                stream = response.GetResponseStream() 
                    ?? throw new Exception("Unexpected error: No response when requesting token.");

                if (sb is { })
                {
                    await response.ToAbstractHttpResponse().ToStringBuilderAsync(sb);
                    logger.Trace(sb.ToString());
                }
                
                using var r = new StreamReader(stream); 
                var text = await r.ReadToEndAsync();
                // await logger.TraceAsync(response,  _ => Task.FromResult(text)); obsolete
                return await buildAuthResultAsync(text);
            }
            catch (Exception ex)
            {
                ex = new Exception($"Refresh token flow failed: {ex.Message}", ex);
                logger.Error(ex);
                return Outcome<TokenRefreshResponse>.Fail(ex);
            }
        }
        
        static string makeRefreshTokenBody(string refreshToken, string clientId = null)
        {
            var sb = new StringBuilder();
            sb.Append("grant_type=refresh_token");
            sb.Append($"&refresh_token={refreshToken}");
            if (clientId is {})
            {
                sb.Append($"&client_id={clientId}");
            }
            return sb.ToString();
        }
        
        static Task<Outcome<TokenRefreshResponse>> buildAuthResultAsync(string responseText)
        {
            var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(responseText);
            if (dict is null || !dict.TryGetValue(AmbientData.Keys.AccessToken, out var accessToken))
                return Task.FromResult(Outcome<TokenRefreshResponse>.Fail(
                    new Exception("Could not get a valid access token.")));

            int? expiresInSeconds = dict.TryGetValue(AmbientData.Keys.ExpiresIn, out var exp) && int.TryParse(exp, out var seconds)
                ? seconds
                : null;

            dict.TryGetValue(AmbientData.Keys.RefreshToken, out var refreshToken);
            dict.TryGetValue("id_token", out var idToken);
            
            return Task.FromResult(Outcome<TokenRefreshResponse>.Success(new TokenRefreshResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                IdToken = idToken,
                ExpiresInSeconds = expiresInSeconds
            }));
        }

        /// <summary>
        ///   OBSOLETE!
        ///   This method will be removed in future versions.
        ///   Please use <see cref="UseTetraPakClientAuthentication"/> instead.
        /// </summary>
        [Obsolete("This method will be removed in future versions. Please use UseTetraPakClientAuthentication instead")]
        public static void UseTetraPakAuthentication(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseTetraPakClientAuthentication(env);
        }
        
        /// <summary>
        ///   Configures Tetra Pak specific auth behavior.
        /// </summary>
        /// <param name="app">
        ///   The application builder object.
        /// </param>
        /// <param name="env">
        ///   Provides information about the hosting environment. 
        /// </param>
        public static void UseTetraPakClientAuthentication(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var config = app.ApplicationServices.GetRequiredService<TetraPakConfig>();
            if (config.IsMessageIdEnabled)
            {
                app.UseTetraPakMessageId();
            }
        }
    }
}