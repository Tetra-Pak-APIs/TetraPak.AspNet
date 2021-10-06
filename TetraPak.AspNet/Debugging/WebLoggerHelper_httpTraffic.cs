using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet.Debugging
{
    partial class WebLoggerHelper 
    {
        /// <summary>
        ///   Traces a <see cref="HttpWebRequest"/> in the logs.
        /// </summary>
        /// <param name="logger">
        ///   The logger provider.
        /// </param>
        /// <param name="request">
        ///   The request to be traced.
        /// </param>
        /// <param name="bodyHandler">
        ///   (optional)<br/>
        ///   A handler that provides a content (body) to be traced.
        /// </param>
        public static void TraceAsync(this ILogger? logger, HttpWebRequest request, Func<string>? bodyHandler = null)
        {
            if (logger is null || !logger.IsEnabled(LogLevel.Trace))
                return;
            
            var sb = new StringBuilder();
            sb.Append(request.Method.ToUpper());
            sb.Append(' ');
            sb.AppendLine(request.RequestUri.ToString());
            addHeaders(sb, request.Headers);
            addBody();
            logger.Trace(sb.ToString());
            
            void addBody()
            {
                if (request.Method == HttpMethods.Get)
                    return;
                
                if (bodyHandler is {})
                {
                    sb.AppendLine();
                    sb.AppendLine(bodyHandler());
                    return;
                }

                try
                {
                    using var stream = request.GetRequestStream();
                    using var reader = new StreamReader(stream);
                    var bodyText = reader.ReadToEnd();
                    stream.Seek(0, SeekOrigin.Begin);
                    sb.AppendLine();
                    sb.AppendLine(bodyText);
                }
                catch (ProtocolViolationException)  { /* ignore */ }
            }
        }

        /// <summary>
        ///   Traces a <see cref="HttpWebRequest"/> in the logs.
        /// </summary>
        /// <param name="logger">
        ///   The logger provider.
        /// </param>
        /// <param name="request">
        ///   The request to be traced.
        /// </param>
        /// <param name="bodyHandler">
        ///   (optional)<br/>
        ///   A request body to be traced.
        /// </param>
        public static async Task TraceAsync(this ILogger? logger, HttpRequest request, Func<string>? bodyHandler = null)
        {
            if (logger is null || !logger.IsEnabled(LogLevel.Trace))
                return;
            
            var sb = new StringBuilder();
            sb.Append(request.Method.ToUpper());
            sb.Append(' ');
            sb.AppendLine(request.GetDisplayUrl());
            addHeaders(sb, request.Headers);
            await addBody();
            logger.Trace(sb.ToString());
            
            async Task addBody()
            {
                if (bodyHandler is {})
                {
                    sb.AppendLine();
                    sb.AppendLine(bodyHandler());
                    return;
                }

                var bodyText = await request.GetRawBodyStringAsync(Encoding.Default);
                if (string.IsNullOrEmpty(bodyText))
                    return;
                
                sb.AppendLine();
                sb.AppendLine(bodyText);
            }
        }
        
        /// <summary>
        ///   Retrieves the <see cref="HttpRequest"/> body as a <see cref="string"/>.  
        /// </summary>
        /// <param name="request">
        ///   The extended <see cref="HttpRequest"/>.
        /// </param>
        /// <param name="encoding">
        ///   The character encoding to use. 
        /// </param>
        /// <returns>
        ///   The (raw) textual representation of the request body as a <see cref="string"/>. 
        /// </returns>
        public static async Task<string> GetRawBodyStringAsync(this HttpRequest request, Encoding encoding)
        {
            var body = "";
            request.EnableBuffering();
            if (request.ContentLength is not > 0 || !request.Body.CanSeek) 
                return body;
            
            request.Body.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(request.Body, encoding, true, 1024, true))
            {
                body = await reader.ReadToEndAsync();
            }
            request.Body.Position = 0;
            return body;
        }


        /// <summary>
        ///   Traces a <see cref="HttpResponse"/> in the logs.
        /// </summary>
        /// <param name="logger">
        ///   The logger provider.
        /// </param>
        /// <param name="response">
        ///   The response to be traced.
        /// </param>
        /// <param name="bodyHandler">
        ///   (optional)<br/>
        ///   A handler that provides a content (body) to be traced.
        /// </param>
        /// <seealso cref="TraceAsync(Microsoft.Extensions.Logging.ILogger?,HttpResponse?,bool?)"/>
        public static async Task TraceAsync(this ILogger? logger, 
            HttpResponse? response, 
            Func<HttpResponse?,Task<string>>? bodyHandler = null)
        {
            await traceAsync(logger, response, bodyHandler);
        }
        
        /// <summary>
        ///   Traces a <see cref="HttpResponse"/> in the logs.
        /// </summary>
        /// <param name="logger">
        ///   The logger provider.
        /// </param>
        /// <param name="response">
        ///   The response to be traced.
        /// </param>
        /// <param name="includeBody">
        ///   (optional; default=<c>false</c>)<br/>
        ///   Specifies whether to also include the response body.
        /// </param>
        /// <seealso cref="TraceAsync(ILogger?,HttpResponse?,Func{HttpResponse?,Task{string}}?)"/>
        public static async Task TraceAsync(this ILogger? logger, HttpResponse? response, bool? includeBody = false)
        {
            await traceAsync(logger, response, includeBody!.Value ? defaultHttpResponseBodyHandler! : null);
        }
        
        /// <summary>
        ///   Traces a <see cref="WebResponse"/> in the logs.
        /// </summary>
        /// <param name="logger">
        ///   The logger provider.
        /// </param>
        /// <param name="response">
        ///   The response to be traced.
        /// </param>
        /// <param name="bodyHandler">
        ///   (optional)<br/>
        ///   A handler that provides a content (body) to be traced.
        /// </param>
        /// <seealso cref="TraceAsync(ILogger?,WebResponse?,Func{WebResponse?, Task{string}}?)"/>
        public static async Task TraceAsync(this ILogger? logger,
            WebResponse? response, 
            Func<WebResponse?,Task<string>>? bodyHandler = null)
        {
            await traceAsync(logger, response, bodyHandler);
        }
        
        /// <summary>
        ///   Traces a <see cref="WebResponse"/> in the logs.
        /// </summary>
        /// <param name="logger">
        ///   The logger provider.
        /// </param>
        /// <param name="response">
        ///   The response to be traced.
        /// </param>
        /// <param name="includeBody">
        ///   (optional; default=<c>false</c>)<br/>
        ///   Specifies whether to also include the response body.
        /// </param>
        /// <seealso cref="TraceAsync(ILogger?,HttpResponse?,Func{HttpResponse?,Task{string}}?)"/>
        public static async Task TraceAsync(this ILogger? logger,
            WebResponse? response,
            bool? includeBody = false)
        {
            await traceAsync(logger, response, includeBody!.Value ? defaultWebResponseBodyHandler! : null);
        }

        static async Task<string> defaultHttpResponseBodyHandler(HttpResponse response)
        {
            try
            {
                // todo Figure out how to read response body
                using var reader = new StreamReader(response.Body);
                return await reader.ReadToEndAsync();
            }
            catch
            {
                return "*** ERROR : Body could not be streamed *** ";
            }
        }

        static async Task<string> defaultWebResponseBodyHandler(WebResponse response)
        {
            try
            {
                var stream = response.GetResponseStream();
                if (stream is null) // <-- todo A Rider squiggly says "Expression is always"! Quite the mystery... -JR 210903
                    return string.Empty;
                
                using var r = new StreamReader(stream); 
                return await r.ReadToEndAsync();
            }
            catch
            {
                return "*** ERROR : Body could not be streamed *** ";
            }
        }

        static async Task traceAsync(ILogger? logger, HttpResponse? response, Func<HttpResponse?,Task<string>>? bodyHandler)
        {
            if (logger is null || response is null || !logger.IsEnabled(LogLevel.Debug))
                return;
            
            var sb = new StringBuilder();
            sb.Append(response.StatusCode);
            sb.Append(' ');
            sb.AppendLine(response.StatusCode.ToString());
            addHeaders(sb, response.Headers);
            await addBody();

            logger.Trace(sb.ToString());
            
            async Task addBody()
            {
                if (bodyHandler is null)
                    return;

                sb.AppendLine();
                sb.AppendLine(await bodyHandler(response));
            }
        }
        
        static async Task traceAsync(ILogger? logger, WebResponse? response, Func<WebResponse?,Task<string>>? bodyHandler)
        {
            if (logger is null || response is null || !logger.IsEnabled(LogLevel.Debug))
                return;
            
            var sb = new StringBuilder();
            if (response is HttpWebResponse webResponse)
            {
                sb.Append((int)webResponse.StatusCode);
                sb.Append(' ');
                sb.AppendLine(webResponse.StatusCode.ToString());
            }
            else
            {
                sb.AppendLine("(status code unavailable)");
            }
            addHeaders(sb, response.Headers);
            await addBody();

            logger.Trace(sb.ToString());
            
            async Task addBody()
            {
                if (bodyHandler is null)
                    return;
                
                sb.AppendLine();
                sb.AppendLine(await bodyHandler(response));
            }
        }
        
        static void addHeaders(StringBuilder sb, NameValueCollection headers)
        {
            foreach (string? header in headers)
            {
                if (header is null)
                    continue;
                
                var value = headers[header];
                if (value is null)
                {
                    sb.AppendLine(header);
                    continue;
                }
            
                sb.Append(header);
                sb.Append('=');
                sb.AppendLine(value);
            }
        }
    
        static void addHeaders(StringBuilder sb, IHeaderDictionary headers)
        {
            foreach (var (key, values) in headers)
            {
                if (values.Count == 0)
                {
                    sb.AppendLine(key);
                    continue;
                }
            
                sb.Append(key);
                sb.Append('=');
                sb.AppendLine(values.ConcatCollection());
            }
        }
    }
}