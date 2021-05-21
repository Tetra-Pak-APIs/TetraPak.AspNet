using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Debugging;
using TetraPak.Logging;

namespace TetraPak.AspNet
{
    partial class TetraPakAuth // refresh token flow
    {
        public static async Task<Outcome<TokenRefreshResponse>> RefreshTokenAsync(
            this TetraPakAuthConfig authConfig,
            string refreshToken,
            ILogger logger)
        {
            var body = makeRefreshTokenBody(refreshToken, authConfig.IsPkceUsed ? authConfig.ClientId : null);
            var uri = authConfig.TokenIssuerUrl;
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
                var response = await request.GetResponseAsync();
                stream = response.GetResponseStream() 
                    ?? throw new Exception("Unexpected error: No response when requesting token.");

                using var r = new StreamReader(stream); 
                var text = await r.ReadToEndAsync();
                logger.DebugWebResponse(response as HttpWebResponse, text);
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
            
            return Task.FromResult(Outcome<TokenRefreshResponse>.Success(new TokenRefreshResponse()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                IdToken = idToken,
                ExpiresInSeconds = expiresInSeconds
            }));
        }
    }
    
    public class TokenRefreshResponse
    {
        public string AccessToken { get; set; }
        
        public string RefreshToken { get; set; }
        
        public string IdToken { get; set; }

        public int? ExpiresInSeconds { get; set; }
    }
}