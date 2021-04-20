using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
        readonly TetraPakAuthConfig _authConfig;
        static readonly IDictionary<string, object> s_cache = new Dictionary<string, object>();

        ILogger Logger => _authConfig.Logger;

        /// <summary>
        ///   Obtains (and, optionally, caches) user information. 
        /// </summary>
        /// <param name="accessToken">
        ///   An access token, authenticating the requesting actor. 
        /// </param>
        /// <param name="scope">
        ///   (optional)<br/>
        ///   One or more scope identifiers used to specify the requested user information.
        /// </param>
        /// <param name="cached">
        ///   (optional; default=<c>true</c>)<br/>
        ///   When set, the value will cache the downloaded result (and fetch it from the internal cache if present). 
        /// </param>
        /// <returns>
        ///   A <see cref="UserInformation"/> value.
        /// </returns>
        public async Task<UserInformation> GetUserInformationAsync(string accessToken, IEnumerable<string> scope = null, bool cached = true)
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
                        return userInformation;
                }
            }

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
            var tcs = new TaskCompletionSource<UserInformation>();
            Task.Run(async () =>
            {
                using (Logger?.BeginScope("[GET USER INFO BEGIN]"))
                {
                    var request = (HttpWebRequest) WebRequest.Create(userInfoUri);
                    request.Method = "GET";
                    request.Accept = "*/*";
                    request.Headers.Add($"Authorization: Bearer {accessToken}");

                    Logger?.DebugWebRequest(request, null);

                    try
                    {
                        var response = await request.GetResponseAsync();
                        var responseStream = response.GetResponseStream()
                                             ?? throw new Exception(
                                                 "Unexpected error: No response when requesting token.");

                        using var r = new StreamReader(responseStream);
                        var text = await r.ReadToEndAsync();

                        Logger?.DebugWebResponse(response as HttpWebResponse, text);

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
        ///   Provides the required  
        /// </param>
        public UserInformationProvider(TetraPakAuthConfig authConfig)
        {
            _authConfig = authConfig;
        }
    }
}