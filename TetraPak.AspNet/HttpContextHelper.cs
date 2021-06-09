using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet
{
    public static class HttpContextHelper
    {
        /// <summary>
        ///   Returns the request access token, or <c>null</c> if unavailable. 
        /// </summary>
        /// <returns>
        ///   An <see cref="ActorToken"/> instance representing the request's access token if one can be obtained;
        ///   otherwise <c>null</c>.
        /// </returns>
        /// <seealso cref="GetAccessToken(Microsoft.AspNetCore.Http.HttpContext, TetraPakAuthConfig)"/>
        /// <see cref="GetAccessTokenAsync(Microsoft.AspNetCore.Http.HttpRequest, TetraPakAuthConfig)"/>
        public static ActorToken GetAccessToken(this HttpRequest self, TetraPakAuthConfig authConfig) 
            => self.HttpContext.GetAccessToken(authConfig);

        /// <summary>
        ///   Returns the request access token, or <c>null</c> if unavailable. 
        /// </summary>
        /// <returns>
        ///   An <see cref="ActorToken"/> instance representing the request's access token if one can be obtained;
        ///   otherwise <c>null</c>.
        /// </returns>
        /// <seealso cref="GetAccessToken(Microsoft.AspNetCore.Http.HttpRequest, TetraPakAuthConfig)"/>
        /// <see cref="GetAccessTokenAsync(Microsoft.AspNetCore.Http.HttpContext, TetraPakAuthConfig)"/>
        public static ActorToken GetAccessToken(this HttpContext self, TetraPakAuthConfig authConfig)
        {
            var task = GetAccessTokenAsync(self, authConfig);
            return task.ConfigureAwait(false).GetAwaiter().GetResult();
        }
        
        /// <summary>
        ///   Tries obtaining an access token from the request. 
        /// </summary>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> instance indicating success/failure. On success the outcome
        ///   holds the access token in its <see cref="Outcome{T}.Value"/> property. On failure the outcome 
        ///   declares the problem via its <see cref="Outcome.Exception"/> property. 
        /// </returns>
        /// <seealso cref="GetAccessToken(Microsoft.AspNetCore.Http.HttpRequest, TetraPakAuthConfig)"/>
        /// <see cref="GetAccessTokenAsync(Microsoft.AspNetCore.Http.HttpContext, TetraPakAuthConfig)"/>
        public static Task<Outcome<ActorToken>> GetAccessTokenAsync(this HttpRequest self, TetraPakAuthConfig authConfig)
            => self.HttpContext.GetAccessTokenAsync(authConfig);
        
        /// <summary>
        ///   Tries obtaining an access token from the request. 
        /// </summary>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> instance indicating success/failure. On success the outcome
        ///   holds the access token in its <see cref="Outcome{T}.Value"/> property. On failure the outcome 
        ///   declares the problem via its <see cref="Outcome.Exception"/> property. 
        /// </returns>
        /// <seealso cref="GetAccessToken(Microsoft.AspNetCore.Http.HttpContext, TetraPakAuthConfig)"/>
        /// <see cref="GetAccessTokenAsync(Microsoft.AspNetCore.Http.HttpRequest, TetraPakAuthConfig)"/>
        public static Task<Outcome<ActorToken>> GetAccessTokenAsync(this HttpContext self, TetraPakAuthConfig authConfig)
        {
            if (self.Items.TryGetValue(AmbientData.Keys.AccessToken, out var o) && o is string s 
                && ActorToken.TryParse(s, out var actorToken))
                return Task.FromResult(Outcome<ActorToken>.Success(actorToken));

            var headerIdent = authConfig?.AuthorizationHeader ?? HeaderNames.Authorization;
            s = self.Request.Headers[headerIdent].FirstOrDefault();
            if (s is {} && ActorToken.TryParse(s, out actorToken))
                return Task.FromResult(Outcome<ActorToken>.Success(actorToken));
        
            return Task.FromResult(Outcome<ActorToken>.Fail(new Exception("Access token not found")));
        }

        /// <summary>
        ///   Returns the request access token, or <c>null</c> if unavailable. 
        /// </summary>
        /// <returns>
        ///   An <see cref="ActorToken"/> instance representing the request's access token if one can be obtained;
        ///   otherwise <c>null</c>.
        /// </returns>
        /// <seealso cref="GetIdToken(Microsoft.AspNetCore.Http.HttpContext, TetraPakAuthConfig)"/>
        /// <see cref="GetIdToken(Microsoft.AspNetCore.Http.HttpRequest, TetraPakAuthConfig)"/>
        public static ActorToken GetIdToken(this HttpRequest self, TetraPakAuthConfig authConfig) 
            => self.HttpContext.GetIdToken(authConfig);

        public static ActorToken GetIdToken(this HttpContext self, TetraPakAuthConfig authConfig)
        {
            var task = GetIdTokenAsync(self, authConfig);
            return task.ConfigureAwait(false).GetAwaiter().GetResult();
        }
        
        public static Task<Outcome<ActorToken>> GetIdTokenAsync(this HttpContext self, TetraPakAuthConfig authConfig)
        {
            if (self.Items.TryGetValue(AmbientData.Keys.IdToken, out var obj) && obj is string s && ActorToken.TryParse(s, out var actorToken))
                return Task.FromResult(Outcome<ActorToken>.Success(actorToken));
            
            var headerIdent = authConfig?.AuthorizationHeader ?? AmbientData.Keys.IdToken;
            s = self.Request.Headers[headerIdent].FirstOrDefault();
            if (s is {} && ActorToken.TryParse(s, out actorToken))
                return Task.FromResult(Outcome<ActorToken>.Success(actorToken));

            return Task.FromResult(Outcome<ActorToken>.Fail(new Exception("Id token not found")));
        }
        
        public static async Task<EnumOutcome<ActorToken>> GetActorTokensAsync(this HttpContext self, TetraPakAuthConfig authConfig)
        {
            var values = self.Request.Headers[HeaderNames.Authorization];
            if (!values.Any())
            {
                // the context is still in auth flow; use different mechanism ...
                var tokenList = new List<ActorToken>();
                var accessTokenOutcome = await self.GetAccessTokenAsync(authConfig);
                if (accessTokenOutcome)
                {
                    tokenList.Add(accessTokenOutcome.Value);
                }
                var idTokenOutcome = await self.GetIdTokenAsync(authConfig);
                if (idTokenOutcome)
                {
                    tokenList.Add(idTokenOutcome.Value);
                }
                return tokenList.Any()
                    ? EnumOutcome<ActorToken>.Success(tokenList.ToArray())
                    : EnumOutcome<ActorToken>.Fail(new Exception("Tokens not found"));
            }
        
            var list = new List<ActorToken>();
            foreach (var stringValue in values)
            {
                if (ActorToken.TryParse(stringValue, out var token))
                    list.Add(token);
            }
            return EnumOutcome<ActorToken>.Success(list.ToArray());
        }

        /// <summary>
        ///   Gets (and, optionally, sets) a single header value.
        /// </summary>
        /// <param name="dictionary">
        ///   The header dictionary to get (set) value from.
        /// </param>
        /// <param name="key">
        ///   Identifies the header value.
        /// </param>
        /// <param name="useDefault">
        ///   (optional)<br/>
        ///   A default value to be used if one cannot be found in the header dictionary.
        /// </param>
        /// <param name="setDefault">
        ///   (optional; default=<c>false</c>); only applies if <paramref name="useDefault"/> is assigned)<br/>
        ///   When set, the <paramref name="useDefault"/> value will automatically be added to the header dictionary,
        ///   affecting the request.
        /// </param>
        /// <returns>
        ///   A (single) <see cref="string"/> value.
        /// </returns>
        public static string GetSingleValue(
            this IHeaderDictionary dictionary,
            string key,
            string useDefault,
            bool setDefault = false)
        {
            if (dictionary.TryGetValue(key, out var values))
                return values.First();

            if (string.IsNullOrWhiteSpace(useDefault))
                return null;

            if (setDefault)
            {
                dictionary.Add(key, useDefault);
            }

            return useDefault;
        }

        /// <summary>
        ///   Gets a standardized value used for referencing a unique request. 
        /// </summary>
        /// <param name="request">
        ///   The <see cref="HttpRequest"/>.
        /// </param>
        /// <param name="authConfig">
        ///   Carries the Tetra Pak authorization configuration.
        /// </param>
        /// <param name="enforce">
        ///   (optional; default=<c>false</c>)<br/>
        ///   When set, a random unique string will be generated and attached to the request.  
        /// </param>
        /// <returns>
        ///   A unique <see cref="string"/> value. 
        /// </returns>
        public static string GetRequestReferenceId(
            this HttpRequest request,
            TetraPakAuthConfig authConfig,
            bool enforce = false)
        {
            var key = authConfig.RequestReferenceIdHeader;
            return request.Headers.GetSingleValue(key, new RandomString(), enforce);
        }

    }
}