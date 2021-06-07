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
    }
}