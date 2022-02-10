using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Debugging;
using TetraPak.Caching;
using TetraPak.Logging;

namespace TetraPak.AspNet.Identity
{
    /// <summary>
    ///   Enables user information obtained from Tetra Pak's user information service.
    /// </summary>
    public class UserInformationProvider
    {
        readonly string _instanceId = new RandomString(8)!;
        readonly AmbientData _ambientData;
        readonly ITimeLimitedRepositories? _cache;
        readonly IHttpClientProvider _httpClientProvider;

        TetraPakConfig Config => _ambientData.TetraPakConfig;
        
        string CacheRepository => $"{nameof(UserInformationProvider)}-{_instanceId}"; 
        
        ILogger? Logger => _ambientData.Logger;

        /// <summary>
        ///   Obtains (and, optionally, caches) user information. 
        /// </summary>
        /// <param name="accessToken">
        ///   An access token, authenticating the requesting actor. 
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Enables cancellation of the operation.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <param name="cached">
        ///   (optional; default=<c>true</c>)<br/>
        ///   When set, the value will cache the downloaded result (and fetch it from the internal cache if present). 
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="UserInformation"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        public async Task<Outcome<UserInformation>> GetUserInformationAsync(
            string accessToken,
            CancellationToken? cancellationToken = null,
            string? messageId = null, 
            bool cached = true)
        {
            object? value = null;
            if (cached)
            {
                value = await getCachedAsync(accessToken);
            }
            if (value is { })
            {
                switch (value)
                {
                    case TaskCompletionSource<UserInformation> cachedTcs:
                    {
                        var result = await cachedTcs.Task;
                        await setCachedAsync(accessToken, result);
                        return Outcome<UserInformation>.Success(result);
                    }

                    case UserInformation userInformation:
                        using (Logger?.BeginScope($"Cached user information was found: {userInformation}"))
                        {
                            Logger?.LogDictionary(userInformation.ToDictionary(), LogLevel.Debug);
                        }
                        return Outcome<UserInformation>.Success(userInformation);
                }
            }
            
            Logger.Trace("Obtains discovery document");
            var discoOutcome = await Config.GetDiscoveryDocumentAsync();
            if (!discoOutcome)
            {
                const string MissingDiscoDocErrorMessage =
                    "Could not obtain user information from Tetra Pak's User Information services. " +
                    "Failed when downloading discovery document";
                Logger.Warning(MissingDiscoDocErrorMessage, _ambientData.GetMessageId());
                throw new Exception(MissingDiscoDocErrorMessage);
            }

            var userInfoEndpoint = discoOutcome.Value!.UserInformationEndpoint!;
            var completionSource = downloadAsync(accessToken, new Uri(userInfoEndpoint), cancellationToken, messageId);
            if (cached)
            {
                await setCachedAsync(accessToken, completionSource);
            }
            return await completionSource.Task;
        }

        TaskCompletionSource<Outcome<UserInformation>> downloadAsync(
            string accessToken, 
            Uri userInfoUri,
            CancellationToken? cancellationToken = null,
            string? messageId = null)
        {
            Logger?.Trace($"Calls user info endpoint: {userInfoUri}");
            var tcs = new TaskCompletionSource<Outcome<UserInformation>>();
            Task.Run(async () =>
            {
                using (Logger?.BeginScope("[GET USER INFO BEGIN]"))
                {
                    try
                    {
                        var clientOutcome = await _httpClientProvider.GetHttpClientAsync();
                        if (!clientOutcome)
                            throw new HttpServerConfigurationException(
                                "Cannot download user information. Failed when obtaining HTTP client (see inner exception)",
                                clientOutcome.Exception);
                            
                        var request = new HttpRequestMessage(HttpMethod.Get, userInfoUri);
                        request.Headers.Accept.ResetTo(new MediaTypeWithQualityHeaderValue("*/*"));
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                        
                        var sb = Logger?.IsEnabled(LogLevel.Trace) ?? false
                            ? await (await request.ToGenericHttpRequestAsync()).ToStringBuilderAsync(
                                new StringBuilder(), 
                                () => TraceHttpRequestOptions.Default(messageId).WithInitiator(this, HttpDirection.Out))
                            : null;

                        var client = clientOutcome.Value!;
                        var ct = cancellationToken ?? CancellationToken.None;
                        var response = await client.SendAsync(request, ct);
                        if (!response.IsSuccessStatusCode)
                            tcs.SetResult(Outcome<UserInformation>.Fail(new HttpServerException(response, "Failed when downloading user information")));
                        
                        if (sb is { })
                        {
                            await (await response.ToGenericHttpResponseAsync()).ToStringBuilderAsync(sb);
                            Logger.Trace(sb.ToString());
                        }

#if NET5_0_OR_GREATER                                             
                        var responseStream = await response.Content.ReadAsStreamAsync(ct)
#else
                        var responseStream = await response.Content.ReadAsStreamAsync()
#endif
                                             ?? throw new Exception("Unexpected error: No response when requesting user information.");

                        using var r = new StreamReader(responseStream);
                        var text = await r.ReadToEndAsync();

                        var objDictionary = JsonSerializer.Deserialize<IDictionary<string, object>>(text);
                        if (objDictionary is null)
                        {
                            tcs.SetResult(Outcome<UserInformation>.Success(
                                new UserInformation(new Dictionary<string, string>())));
                            return;
                        }

                        var dictionary = new Dictionary<string, string>();
                        foreach (var (key, value) in objDictionary)
                        {
                            if (value is not JsonElement jsonElement)
                                throw new Exception();

                            dictionary[key] = jsonElement.GetRawText();
                        }

                        var userInformation = new UserInformation(dictionary);
                        tcs.SetResult(Outcome<UserInformation>.Success(userInformation));
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex);
                        tcs.SetException(ex);
                    }
                    finally
                    {
                        Logger.Trace("[GET USER INFO END]");
                    }
                }
            });
            return tcs;
        }

        async Task<object?> getCachedAsync(string accessToken)
        {
            if (_cache is null)
                return null;

            var outcome = await _cache.GetAsync<object>(CacheRepository, accessToken);
            return outcome
                ? outcome.Value
                : null;
        }
        
        async Task setCachedAsync(string accessToken, object value)
        {
            if (_cache is null)
                return;

            await _cache.AddAsync(CacheRepository, accessToken, value);
        }

        /// <summary>
        ///   Initializes the <see cref="UserInformationProvider"/>.
        /// </summary>
        /// <param name="ambientData">
        ///   Provides ambient data and configuration.
        /// </param>
        /// <param name="httpClientProvider">
        ///   A HttpClient factory.
        /// </param>
        /// <param name="cache">
        ///   (optional)<br/>
        ///   A caching service to be used for caching user information.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="ambientData"/> was unassigned.
        /// </exception>
        public UserInformationProvider(
            AmbientData ambientData,
            IHttpClientProvider httpClientProvider, 
            ITimeLimitedRepositories? cache = null)
        {
            _ambientData = ambientData ?? throw new ArgumentNullException(nameof(ambientData));
            _httpClientProvider = httpClientProvider;
            _cache = cache;
        }
    }
}