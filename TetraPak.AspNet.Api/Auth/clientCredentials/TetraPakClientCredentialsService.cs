using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   A default service to support the client credentials grant type.
    /// </summary>
    public class TetraPakClientCredentialsService : IClientCredentialsService
    {
        readonly TetraPakAuthApiConfig _config;

        /// <summary>
        ///   Gets a logger provider.
        /// </summary>
        protected ILogger Logger => _config.Logger;

        /// <inheritdoc />
        public async Task<Outcome<ClientCredentialsResponse>> AcquireTokenAsync(
            CancellationToken cancellationToken, 
            Credentials clientCredentials = null,
            MultiStringValue scope = null)
        {
            try
            {
                var basicAuthCredentials = validateBasicAuthCredentials(clientCredentials ?? OnGetCredentials());
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = basicAuthCredentials.ToAuthenticationHeaderValue();
                var formsValues = new Dictionary<string, string>
                {
                    ["grant_type"] = "client_credentials"
                };
                if (scope is { })
                {
                    formsValues.Add("scope", scope.Items.ConcatCollection(" "));
                }
                var response = await client.PostAsync(
                    _config.TokenIssuerUrl,
                    new FormUrlEncodedContent(formsValues),
                    cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
// #if NET5_0_OR_GREATER
//                     var errorContent = await response.Content.ReadAsStringAsync(cancellationToken); obsolete
// #else                    
//                     var errorContent = await response.Content.ReadAsStringAsync();
// #endif
//                     var statusCode = ((int) response.StatusCode).ToString();
                    var ex = new HttpException(response); //  new Exception($"Call failed with status: {statusCode} {response.ReasonPhrase}. {errorContent}"); obsolete
                    Logger?.LogError(ex, "Client credentials failure");
                    return Outcome<ClientCredentialsResponse>.Fail(ex);
                }

#if NET5_0_OR_GREATER
                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
#else
                var stream = await response.Content.ReadAsStreamAsync();
#endif
                var responseBody =
                    await JsonSerializer.DeserializeAsync<ClientCredentialsResponseBody>(stream,
                        cancellationToken: cancellationToken);

                return ClientCredentialsResponse.TryParse(responseBody);
            }
            catch (Exception ex)
            {
                ex = new Exception($"Failed to acquire token using client credentials. {ex.Message}", ex);
                Logger.Error(ex);
                return Outcome<ClientCredentialsResponse>.Fail(ex);
            }
        }
        
        static BasicAuthCredentials validateBasicAuthCredentials(Credentials credentials)
        {
            if (string.IsNullOrWhiteSpace(credentials.Identity) || string.IsNullOrWhiteSpace(credentials.Secret))
                throw new InvalidOperationException("Invalid credentials. Please specify client id and secret");

            return new BasicAuthCredentials(credentials.Identity, credentials.Secret);
        }

        protected virtual Credentials OnGetCredentials()
        {
            if (string.IsNullOrWhiteSpace(_config.ClientId))
                throw new InvalidOperationException(
                    $"Cannot create client credentials. Please specify '{nameof(TetraPakAuthConfig.ClientId)}' in configuration");
                
            return new BasicAuthCredentials(_config.ClientId, _config.ClientSecret);
        }

        public TetraPakClientCredentialsService(TetraPakAuthApiConfig config)
        {
            _config = config;
        }
    }
}