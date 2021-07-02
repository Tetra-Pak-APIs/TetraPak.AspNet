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
using TetraPak.Caching;
using TetraPak.Logging;

namespace TetraPak.AspNet.Identity
{
    /// <summary>
    ///   Enables user information obtained from Tetra Pak's user information service.
    /// </summary>
    public class UserInformationProvider
    {
        readonly string _instanceId = new RandomString(8);
        readonly ITimeLimitedRepositories _cache;
        readonly TetraPakAuthConfig _authConfig;
        
        string CacheRepository => $"{nameof(UserInformationProvider)}-{_instanceId}"; 
        
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
            if (cached)
            {
                await setCachedAsync(accessToken, completionSource);
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
                    try
                    {
                        var request = (HttpWebRequest) WebRequest.Create(userInfoUri);
                        var bearerToken = accessToken.ToBearerToken();
                        request.Method = "GET";
                        request.Accept = "*/*";
                        request.Headers.Add($"{HeaderNames.Authorization}: {bearerToken}");
                        Logger?.Debug(request);
                        var response = await request.GetResponseAsync();
                        var responseStream = response.GetResponseStream()
                                             ?? throw new Exception(
                                                 "Unexpected error: No response when requesting user information.");

                        using var r = new StreamReader(responseStream);
                        var text = await r.ReadToEndAsync();

                        Logger?.Debug(response as HttpWebResponse, text);

                        var objDictionary = JsonSerializer.Deserialize<IDictionary<string, object>>(text);
                        if (objDictionary is null)
                        {
                            tcs.SetResult(new UserInformation(new Dictionary<string, string>()));
                            return;
                        }

                        var dictionary = new Dictionary<string, string>();
                        foreach (var (key, value) in objDictionary)
                        {
                            if (value is not JsonElement jsonElement)
                                throw new Exception();

                            dictionary[key] = jsonElement.GetRawText(); // parseJsonElement(jsonElement); obsolete
                        }

                        var userInformation = new UserInformation(dictionary);
                        tcs.SetResult(userInformation);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex);
                        tcs.SetException(ex);
                    }
                    finally
                    {
                        Logger?.Debug("[GET USER INFO END]");
                    }
                }
            });
            return tcs;

        //     static string parseJsonElement(JsonElement jsonElement) obsolete
        //     {
        //         switch (jsonElement.ValueKind)
        //         {
        //             case JsonValueKind.Undefined:
        //                 return "(undefined)";
        //                 
        //             case JsonValueKind.Object:
        //                 return jsonElement.GetRawText();
        //                 // var objectEnumerator = jsonElement.EnumerateObject();
        //                 // var dictionary = new Dictionary<string, string>();
        //                 // foreach (var jsonProperty in objectEnumerator)
        //                 // {
        //                 //     dictionary[jsonProperty.Name] = parseJsonElement(jsonProperty.Value);
        //                 // }
        //                 //
        //                 // var objectStringValue = new ObjectStringValue(dictionary);
        //                 // return objectStringValue;
        //             
        //             case JsonValueKind.Array:
        //                 return jsonElement.GetRawText();
        //                 // var stringsArray = new string[jsonElement.GetArrayLength()];
        //                 // var arrayEnumerator = jsonElement.EnumerateArray();
        //                 // var i = 0;
        //                 // foreach (var arrayElement in arrayEnumerator)
        //                 // {
        //                 //     stringsArray[i++] = parseJsonElement(arrayElement);
        //                 // }
        //                 //
        //                 // return new MultiStringValue(stringsArray);
        //
        //             case JsonValueKind.String:
        //             case JsonValueKind.Number:
        //             case JsonValueKind.True:
        //             case JsonValueKind.False:
        //             case JsonValueKind.Null:
        //                 return jsonElement.GetRawText();
        //
        //             default:
        //                 throw new ArgumentOutOfRangeException();
        //         }
        //
        //     }
        //
        }

        async Task<object> getCachedAsync(string accessToken)
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
        /// <param name="authConfig">
        ///   Provides Tetra Pak auth configuration.
        /// </param>
        /// <param name="cache">
        ///   (optional)<br/>
        ///   A caching service to be used for caching user information.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="authConfig"/> was unassigned.
        /// </exception>
        public UserInformationProvider(TetraPakAuthConfig authConfig, ITimeLimitedRepositories cache = null)
        {
            _authConfig = authConfig ?? throw new ArgumentNullException(nameof(authConfig));
            _cache = cache;
        }
    }
}