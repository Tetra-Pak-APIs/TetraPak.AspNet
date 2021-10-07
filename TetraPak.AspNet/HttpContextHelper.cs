using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using TetraPak.AspNet.Diagnostics;
using TetraPak.Logging;
using TetraPak.Serialization;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Provides extension and convenience method for <see cref="HttpContext"/>.
    /// </summary>
    public static class HttpContextHelper
    {
        /// <summary>
        ///   Returns the request access token, or <c>null</c> if unavailable. 
        /// </summary>
        /// <returns>
        ///   An <see cref="ActorToken"/> instance representing the request's access token if one can be obtained;
        ///   otherwise <c>null</c>.
        /// </returns>
        /// <seealso cref="GetAccessToken(Microsoft.AspNetCore.Http.HttpContext, TetraPakConfig)"/>
        /// <see cref="GetAccessTokenAsync(Microsoft.AspNetCore.Http.HttpRequest, TetraPakConfig)"/>
        public static ActorToken GetAccessToken(this HttpRequest self, TetraPakConfig config) 
            => self.HttpContext.GetAccessToken(config);

        /// <summary>
        ///   Returns the request access token, or <c>null</c> if unavailable. 
        /// </summary>
        /// <returns>
        ///   An <see cref="ActorToken"/> instance representing the request's access token if one can be obtained;
        ///   otherwise <c>null</c>.
        /// </returns>
        /// <seealso cref="GetAccessToken(Microsoft.AspNetCore.Http.HttpRequest, TetraPakConfig)"/>
        /// <see cref="GetAccessTokenAsync(Microsoft.AspNetCore.Http.HttpContext, TetraPakConfig, bool)"/>
        public static ActorToken GetAccessToken(this HttpContext self, TetraPakConfig config)
        {
            var task = GetAccessTokenAsync(self, config);
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
        /// <seealso cref="GetAccessToken(Microsoft.AspNetCore.Http.HttpRequest, TetraPakConfig)"/>
        /// <see cref="GetAccessTokenAsync(Microsoft.AspNetCore.Http.HttpContext, TetraPakConfig, bool)"/>
        public static Task<Outcome<ActorToken>> GetAccessTokenAsync(this HttpRequest self, TetraPakConfig config)
            => self.HttpContext.GetAccessTokenAsync(config);

        /// <summary>
        ///   Tries obtaining an access token from the request. 
        /// </summary>
        /// <param name="self">
        ///   The <see cref="HttpContext"/>.
        /// </param>
        /// <param name="config">
        ///   A Tetra Pak configuration object.
        /// </param>
        /// <param name="forceStandardHeader">
        ///   (optional; default=<c>false</c>)<br/>
        ///   When set the configured (see <see cref="TetraPakConfig.AuthorizationHeader"/>) authorization
        ///   header is ignored in favour of the HTTP standard <see cref="HeaderNames.Authorization"/> header. 
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> instance indicating success/failure. On success the outcome
        ///   holds the access token in its <see cref="Outcome{T}.Value"/> property. On failure the outcome 
        ///   declares the problem via its <see cref="Outcome.Exception"/> property. 
        /// </returns>
        /// <seealso cref="GetAccessToken(Microsoft.AspNetCore.Http.HttpContext, TetraPakConfig)"/>
        /// <see cref="GetAccessTokenAsync(Microsoft.AspNetCore.Http.HttpRequest, TetraPakConfig)"/>
        public static Task<Outcome<ActorToken>> GetAccessTokenAsync(
            this HttpContext? self, 
            TetraPakConfig? config, 
            bool forceStandardHeader = false)
        {
            if (self is null)
                return Task.FromResult(Outcome<ActorToken>.Fail(new Exception($"No HTTP context available")));
            
            var headerKey = AmbientData.Keys.AccessToken;
            if (self.Items.TryGetValue(headerKey, out var o) && o is string s && ActorToken.TryParse(s, out var actorToken))
                return Task.FromResult(Outcome<ActorToken>.Success(actorToken));

            headerKey = forceStandardHeader || config?.AuthorizationHeader is null
                ? HeaderNames.Authorization
                : config.AuthorizationHeader;
            s = self.Request.Headers[headerKey].FirstOrDefault();
            if (s is {} && ActorToken.TryParse(s, out actorToken))
                return Task.FromResult(Outcome<ActorToken>.Success(actorToken));

            var messageId = self.Request.GetMessageId(config);
            config?.Logger.Warning($"Could not find an access token. Was looking for header '{headerKey}'", messageId);
            
            return Task.FromResult(Outcome<ActorToken>.Fail(new Exception("Access token not found")));
        }

        /// <summary>
        ///   Returns the request access token, or <c>null</c> if unavailable. 
        /// </summary>
        /// <returns>
        ///   An <see cref="ActorToken"/> instance representing the request's access token if one can be obtained;
        ///   otherwise <c>null</c>.
        /// </returns>
        /// <seealso cref="GetIdentityToken(Microsoft.AspNetCore.Http.HttpContext,TetraPakConfig)"/>
        public static ActorToken GetIdentityToken(this HttpRequest self, TetraPakConfig config) 
            => self.HttpContext.GetIdentityToken(config);

        /// <summary>
        ///   Returns the request identity token, or <c>null</c> if unavailable.
        /// </summary>
        /// <param name="self">
        ///   The request <see cref="HttpContext"/> object.
        /// </param>
        /// <param name="config">
        ///   (optional)<br/>
        ///   The Tetra Pak integration configuration object. When passed the method will look
        ///   for the identity token in the header specified by <see cref="TetraPakConfig.AuthorizationHeader"/>.
        ///   If not the identity token is assumed to be carried by the header named as <see cref="AmbientData.Keys.IdToken"/>.
        /// </param>
        /// <returns>
        ///   An <see cref="ActorToken"/> object representing the request's identity token if one can be obtained;
        ///   otherwise <c>null</c>.
        /// </returns>
        /// <seealso cref="GetIdentityToken(Microsoft.AspNetCore.Http.HttpRequest,TetraPakConfig)"/>
        public static ActorToken GetIdentityToken(this HttpContext self, TetraPakConfig? config = null)
        {
            var task = GetIdentityTokenAsync(self, config);
            return task.ConfigureAwait(false).GetAwaiter().GetResult();
        }
        
        /// <summary>
        ///   Asynchronously returns the request identity token, or <c>null</c> if unavailable.
        /// </summary>
        /// <param name="self">
        ///   The request <see cref="HttpContext"/> object.
        /// </param>
        /// <param name="authConfig">
        ///   (optional)<br/>
        ///   The Tetra Pak integration configuration object. When passed the method will look
        ///   for the identity token in the header specified by <see cref="TetraPakConfig.AuthorizationHeader"/>.
        ///   If not the identity token is assumed to be carried by the header named as <see cref="AmbientData.Keys.IdToken"/>.
        /// </param>
        /// <returns>
        ///   An <see cref="ActorToken"/> object representing the request's identity token if one can be obtained;
        ///   otherwise <c>null</c>.
        /// </returns>
        public static Task<Outcome<ActorToken>> GetIdentityTokenAsync(this HttpContext self, TetraPakConfig? authConfig = null)
        {
            if (self.Items.TryGetValue(AmbientData.Keys.IdToken, out var obj) && obj is string s 
                    && ActorToken.TryParse(s, out var actorToken))
                return Task.FromResult(Outcome<ActorToken>.Success(actorToken));
            
            var headerIdent = authConfig?.AuthorizationHeader ?? AmbientData.Keys.IdToken;
            s = self.Request.Headers[headerIdent].ToString();
            if (s is {} && ActorToken.TryParse(s, out actorToken))
                return Task.FromResult(Outcome<ActorToken>.Success(actorToken));

            return Task.FromResult(Outcome<ActorToken>.Fail(new Exception("Id token not found")));
        }
        
        /// <summary>
        ///   Gets all tokens from an <see cref="HttpContext"/>.
        /// </summary>
        /// <param name="self">
        ///   The <see cref="HttpContext"/>.
        /// </param>
        /// <param name="config">
        ///   The Tetra Pak integration configuration.
        /// </param>
        /// <returns>
        ///   
        /// </returns>
        public static async Task<EnumOutcome<ActorToken>> GetActorTokensAsync(this HttpContext? self, TetraPakConfig config)
        {
            if (self is null)
                return EnumOutcome<ActorToken>.Fail(new Exception("No HTTP context available"));
                
            var values = self.Request.Headers[HeaderNames.Authorization];
            if (!values.Any())
            {
                // the context is still in auth flow; use different mechanism ...
                var tokenList = new List<ActorToken>();
                var accessTokenOutcome = await self.GetAccessTokenAsync(config);
                if (accessTokenOutcome)
                {
                    tokenList.Add(accessTokenOutcome.Value!);
                }
                var idTokenOutcome = await self.GetIdentityTokenAsync(config);
                if (idTokenOutcome)
                {
                    tokenList.Add(idTokenOutcome.Value!);
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
        public static string? GetSingleValue(
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
        public static string? GetMessageId(
            this HttpRequest request,
            TetraPakConfig? authConfig,
            bool enforce = false)
        {
            var key = authConfig?.RequestMessageIdHeader ?? AmbientData.Keys.RequestMessageId;
            return request.Headers.GetSingleValue(key, enforce ? new RandomString() : null, enforce);
        }

        /// <summary>
        ///   Gets a telemetry level from the request (if any).
        /// </summary>
        /// <param name="request">
        ///   The <see cref="HttpRequest"/>.
        /// </param>
        /// <param name="logger">
        ///   A logger provider.
        /// </param>
        /// <param name="useDefault">
        ///   A default telemetry level to be returned when no level was specified, or when
        ///   the specified telemetry level could not be successfully parsed.  
        /// </param>
        /// <returns>
        ///   A <see cref="ServiceDiagnosticsLevel"/> value.
        /// </returns>
        public static ServiceDiagnosticsLevel GetDiagnosticsLevel(
            this HttpRequest request,
            ILogger logger,
            ServiceDiagnosticsLevel useDefault = ServiceDiagnosticsLevel.None)
        {
            if (!request.Headers.TryGetValue(Headers.ServiceDiagnostics, out var values))
                return useDefault;

            var value = values.First();
            if (Enum.TryParse<ServiceDiagnosticsLevel>(values, true, out var level)) 
                return level;
            
            logger.Warning($"Unknown telemetry level requested: '{value}'");
            return useDefault;
        }

        /// <summary>
        ///   Sets a value to the <see cref="HttpContext"/>.
        /// </summary>
        /// <param name="self"> 
        ///   The <see cref="HttpContext"/>.
        /// </param>
        /// <param name="key">
        ///   Identifies the value to be set.
        /// </param>
        /// <param name="value">
        ///   The value to be set.
        /// </param>
        public static void SetValue(this HttpContext self, string key, object value) => self.Items[key] = value; 

        /// <summary>
        ///   Gets a value from <see cref="HttpContext"/>.
        /// </summary>
        /// <param name="self">
        ///   The <see cref="HttpContext"/>.
        /// </param>
        /// <param name="key">
        ///   Identifies the requested value.
        /// </param>
        /// <param name="useDefault">
        ///   (optional)<br/>
        ///   A default value to be returned if the requested value is not carried by <paramref name="self"/>. 
        /// </param>
        /// <typeparam name="T">
        ///   The type of value requested.
        /// </typeparam>
        /// <returns>
        ///   The requested value if carried by the <see cref="HttpContext"/>;
        ///   otherwise the <paramref name="useDefault"/> value.
        /// </returns>
        public static T GetValue<T>(this HttpContext self, string key, T? useDefault = default)
            => self.Items.TryGetValue(key, out var obj) && obj is T tValue ? tValue : useDefault!; 

        /// <summary>
        ///   Writes a HTTP response.
        /// </summary>
        /// <param name="context">
        ///   The <see cref="HttpContext"/>.
        /// </param>
        /// <param name="statusCode">
        ///   The status code to be returned.
        /// </param>
        /// <param name="content">
        ///   (optional)<br/>
        ///   Content to be returned (objects will be JSON serialized).
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   A cancellation token.
        /// </param>
        public static Task RespondAsync(this HttpContext context, 
            HttpStatusCode statusCode, 
            object? content = null,
            CancellationToken cancellationToken = default)
        {
            string? contentType = null;
            string? stringContent;
            if (content is string stringValue)
            {
                stringContent = stringValue;
            }
            else
            {
                stringContent = content?.ToJson();
                contentType = stringContent is { } ? "application/json" : null;
            }

            return context.RespondAsync(statusCode, stringContent, contentType, cancellationToken);
        }

        /// <summary>
        ///   Writes a HTTP response.
        /// </summary>
        /// <param name="context">
        ///   The <see cref="HttpContext"/>.
        /// </param>
        /// <param name="statusCode">
        ///   The status code to be returned.
        /// </param>
        /// <param name="content">
        ///   (optional)<br/>
        ///   Content to be returned.
        /// </param>
        /// <param name="contentType">
        ///   (optional)<br/>
        ///   A content MIME type tp be returned.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   A cancellation token.
        /// </param>
        public static async Task RespondAsync(this HttpContext context,
            HttpStatusCode statusCode, 
            string? content = null,
            string? contentType = null, 
            CancellationToken cancellationToken = default)
        {
            context.Response.StatusCode = (int) statusCode;
            if (content is null)
                return;

            if (contentType is null)
            {
                if (isProbablyJson())
                {
                    contentType = "application/json";
                }
            }
            context.Response.ContentType = contentType ?? "";
            await context.Response.WriteAsync(content, cancellationToken);

            bool isProbablyJson()
            {
                if (content.Length < 2)
                    return false;

                if (content.StartsWith('{') && content.EndsWith('}'))
                    return true;

                return content.StartsWith('[') && content.EndsWith(']');
            }
        }
        
        /// <summary>
        ///   Examines the resolved endpoint of the context (if any) and returns a value indicating whether
        ///   it is protected (decorated with 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="HttpContext"/>.
        /// </param>
        /// <returns>
        ///   <c>true</c> if an endpoint is resolved and protected. 
        /// </returns>
        public static bool IsEndpointProtected(this HttpContext self) => self.GetEndpoint().IsAuthorizationRequired();

        public static string? GetItemValue(this HttpRequest request, HttpRequestElement element, string key)
            => element switch
            {
                HttpRequestElement.Header => request.Headers.ContainsKey(key) 
                    ? request.Headers[key].ToString()
                    : null,
                HttpRequestElement.Query => request.Query.ContainsKey(key) 
                    ? request.Query[key].ToString()
                    : null,
                _ => null
            };
        
        
        public static bool IsMatch(
            this HttpRequest request,
            HttpComparison criteria, 
            StringComparison comparison = StringComparison.InvariantCulture)
        {
            return criteria.IsMatch(request, comparison);
        }
        
        public static bool IsMatch(
            this HttpComparison criteria, 
            HttpRequest request, 
            StringComparison comparison = StringComparison.InvariantCulture)
        {
            return criteria.IsMatch(request, comparison);
        }

    }
}