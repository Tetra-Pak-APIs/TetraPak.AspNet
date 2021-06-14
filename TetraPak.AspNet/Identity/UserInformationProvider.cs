using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Debugging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Identity
{
    /// <summary>
    ///   Enables user information obtained from Tetra Pak's user information service.
    /// </summary>
    public class UserInformationProvider
    {
        static readonly IDictionary<string, object> s_cache = new Dictionary<string, object>();
        readonly TetraPakAuthConfig _authConfig;

        ILogger Logger => _authConfig.Logger;

        /// <summary>
        ///   Obtains (and, optionally, caches) user information. 
        /// </summary>
        /// <param name="accessToken">
        ///     An access token, authenticating the requesting actor. 
        /// </param>
        /// <param name="cached">
        ///     (optional; default=<c>true</c>)<br/>
        ///     When set, the value will cache the downloaded result (and fetch it from the internal cache if present). 
        /// </param>
        /// <returns>
        ///   A <see cref="UserInformation"/> value.
        /// </returns>
        public async Task<UserInformation> GetUserInformationAsync(string accessToken, bool cached = true)
        {
            object value = null;
            lock (s_cache)
            {
                if (cached)
                {
                    value = getCached(accessToken);
                }
            }
            if (value is {})
            {
                switch (value)
                {
                    case TaskCompletionSource<UserInformation> cachedTcs:
                    {
                        var result = await cachedTcs.Task;
                        lock (s_cache)
                        {
                            setCached(accessToken, result);
                        }

                        return result;
                    }

                    case UserInformation userInformation:
                        using (Logger?.BeginScope($"Cached user information was found: {userInformation}"))
                        {
                            Logger?.LogDictionary(userInformation.ToDictionary(), LogLevel.Debug);
                        }
                        return userInformation;
                }
            }

            Logger?.Debug("Obtains discovery document");
            var discoveryDocument = await _authConfig.GetDiscoveryDocumentAsync();
            if (discoveryDocument is null)
            {
                const string MissingDiscoDocErrorMessage =
                    "Could not obtain user information from Tetra Pak's User Information services. " +
                    "Failed when downloading discovery document";
                Logger?.Warning(MissingDiscoDocErrorMessage);
                throw new Exception(MissingDiscoDocErrorMessage);
            }
            var userInfoEndpoint = discoveryDocument.UserInformationEndpoint;
            var completionSource = downloadAsync(accessToken, new Uri(userInfoEndpoint));
            lock (s_cache)
            {
                if (cached)
                {
                    setCached(accessToken, completionSource);
                }
            }
            return await completionSource.Task;
        }

        TaskCompletionSource<UserInformation> downloadAsync(string accessToken, Uri userInfoUri)
        {
            Logger?.Debug($"Calls user info endpoint: {userInfoUri}");
            var tcs = new TaskCompletionSource<UserInformation>();
            Task.Run(async () =>
            {
                using (Logger?.BeginScope("[GET USER INFO BEGIN]"))
                {
                    var request = (HttpWebRequest) WebRequest.Create(userInfoUri);
                    var bearerToken = accessToken.ToBearerToken();
                    request.Method = "GET";
                    request.Accept = "*/*";
                    request.Headers.Add($"{HeaderNames.Authorization}: {bearerToken}");
                    try
                    {
                        Logger?.Debug(request);
                        var response = await request.GetResponseAsync();
                        var responseStream = response.GetResponseStream()
                                             ?? throw new Exception(
                                                 "Unexpected error: No response when requesting user information.");

                        using var r = new StreamReader(responseStream);
                        var text = await r.ReadToEndAsync();

                        Logger?.Debug(response as HttpWebResponse, text);

                        var dictionary = JsonSerializer.Deserialize<IDictionary<string, string>>(text);
                        tcs.SetResult(new UserInformation(dictionary));
                    }
                    catch (Exception ex)
                    {
                        Logger?.Error(ex);
                        tcs.SetException(ex);
                    }
                    finally
                    {
                        Logger?.Debug("[GET USER INFO END]");
                    }
                }
            });
            return tcs;
        }

        static object getCached(string accessToken) =>
            s_cache.TryGetValue(accessToken, out var value)
                ? value
                : null;

        static void setCached(string accessToken, object value) => s_cache[accessToken] = value;

        /// <summary>
        ///   Initializes the <see cref="UserInformationProvider"/>.
        /// </summary>
        /// <param name="authConfig">
        ///   Provides Tetra Pak auth configuration.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="authConfig"/> was unassigned.
        /// </exception>
        public UserInformationProvider(TetraPakAuthConfig authConfig)
        {
            _authConfig = authConfig ?? throw new ArgumentNullException(nameof(authConfig));
        }
    }
}