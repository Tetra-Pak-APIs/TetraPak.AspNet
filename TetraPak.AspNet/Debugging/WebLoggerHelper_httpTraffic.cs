using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet.Debugging
{
    partial class WebLoggerHelper 
    {
        static bool s_isTraceRequestAdded;
        static TraceRequestMiddleware? s_traceRequestMiddleware;
        
        /// <summary>
        ///   Injects middleware that traces all requests to the logger provider
        ///   when <see cref="LogLevel.Trace"/> is set.
        /// </summary>
        /// <param name="app">
        ///   The extended application builder. 
        /// </param>
        /// <returns></returns>
        public static IApplicationBuilder UseTetraPakTraceRequestAsync(this IApplicationBuilder app)
        {
            lock (s_syncRoot)
            {
                if (s_isTraceRequestAdded)
                    return app;

                s_isTraceRequestAdded = true;
                var config = app.ApplicationServices.GetRequiredService<TetraPakConfig>();
                var logger = app.ApplicationServices.GetService<ILogger<TraceRequestMiddleware>>();
                if (logger is null || !logger.IsEnabled(LogLevel.Trace))
                    return app;

                s_traceRequestMiddleware = new TraceRequestMiddleware(config, logger);
                app.Use(async (context, next) =>
                {
                    await s_traceRequestMiddleware.InvokeAsync(context);
                    await next();
                });
            }

            return app;
        }
        
        
        /// <summary>
        ///   Traces a <see cref="HttpWebRequest"/> in the logs. obsolete
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
        public static Task TraceWebRequestAsync(this ILogger? logger, HttpWebRequest request, Func<string>? bodyHandler = null)
        {
            if (logger is null || !logger.IsEnabled(LogLevel.Trace))
                return Task.CompletedTask;
            
            var sb = new StringBuilder();
            sb.Append(request.Method.ToUpper());
            sb.Append(' ');
            sb.AppendLine(request.RequestUri.ToString());
            addHeaders(sb, request.Headers);
            addBody();
            logger.Trace(sb.ToString());
            return Task.CompletedTask;
            
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
        /// <param name="bodyOptions">
        ///   (optional)<br/>
        ///   Specifies how tracing of request bodies is conducted. 
        /// </param>
        public static Task TraceHttpRequestAsync(
            this ILogger? logger, 
            HttpRequest request, 
            Func<string>? bodyHandler = null,
            TraceBodyOptions? bodyOptions = null)
        {
            if (logger is null || !logger.IsEnabled(LogLevel.Trace))
                return Task.CompletedTask;

            if (request.ContentLength > 2048)
                return Task.Run(async () => await logBodyAsync());

            logBodyAsync().Await();
            return Task.CompletedTask;

            async Task logBodyAsync()
            {
                var sb = new StringBuilder();
                sb.Append(request.Method.ToUpper());
                sb.Append(' ');
                sb.AppendLine(request.GetDisplayUrl());
                addHeaders(sb, request.Headers);
                await addBody(sb);
                logger.Trace(sb.ToString());
            }
            
            async Task addBody(StringBuilder sb)
            {
                if (bodyHandler is {})
                {
                    sb.AppendLine();
                    sb.AppendLine(bodyHandler());
                    return;
                }

                var bodyText = await request.GetRawBodyStringAsync(Encoding.Default, bodyOptions);
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
        /// <param name="bodyOptions">
        ///   (optional)<br/>
        ///   Specifies how tracing of request bodies is conducted. 
        /// </param>
        /// <returns>
        ///   The (raw) textual representation of the request body as a <see cref="string"/>. 
        /// </returns>
        public static async Task<string> GetRawBodyStringAsync(
            this HttpRequest request, 
            Encoding encoding, 
            TraceBodyOptions? bodyOptions = null)
        {
            var bufferSize = bodyOptions?.BufferSize ?? TraceBodyOptions.DefaultBuffersSize;
            
            request.EnableBuffering();
            if (request.ContentLength is not > 0 || !request.Body.CanSeek)
                return string.Empty;

            string body;
            if (bodyOptions is null)
            {
                // no need to read in chunks, just get and return the whole body ...
                using var bodyReader = new StreamReader(request.Body, encoding, true, 
                    bufferSize, 
                    true);
                body = await bodyReader.ReadToEndAsync();
                request.Body.Position = 0;
                return body;
            }
            
            // read body in chunks of buffer size and truncate if there's a max length
            // (to avoid performance issues with very large bodies, such as media or binaries) ... 
            request.Body.Seek(0, SeekOrigin.Begin);
            var buffer = new char[bufferSize];
            var remaining = bodyOptions.MaxSize;
            var isTruncated = false;

            var bodyStream = new MemoryStream();
            await using var writer = new StreamWriter(bodyStream);
            using var reader = new StreamReader(request.Body, encoding, true, bufferSize, true);
            
            while (await reader.ReadBlockAsync(buffer) != 0 && !isTruncated)
            {
                await writer.WriteAsync(buffer);
                remaining -= bufferSize;
                isTruncated = remaining <= 0; 
            }
            bodyStream.Position = 0;
            using (var memoryReader = new StreamReader(bodyStream, leaveOpen:true)) // leave open (`writer` will close)
            {
                body = await memoryReader.ReadToEndAsync();
            }
            request.Body.Position = 0;
            return isTruncated
                ? $"{body}...[--TRUNCATED--]"
                : body;
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

    /// <summary>
    ///   Used when request bodies gets dumped to the logger (at log level <see cref="LogLevel.Trace"/>).
    /// </summary>
    public class TraceBodyOptions
    {
        internal const int DefaultBuffersSize = 1024;
        const int DefaultMaxSizeFactor = 4;

        int _bufferSize;
        long _maxSize;

        /// <summary>
        ///   (static property)<br/>
        ///   Gets or sets a default value used for the <see cref="ContentLengthAsyncThreshold"/>
        ///   property's initial value.
        /// </summary>
        public static uint DefaultContentLengthAsyncThreshold { get; set; } = 1024;
        
        /// <summary>
        ///   Gets default <see cref="TraceBodyOptions"/>
        /// </summary>
        public static TraceBodyOptions Default => new();

        /// <summary>
        ///   The buffer size. Set for reading large bodies.
        ///   Please note that the setter enforces minimum value 128. 
        /// </summary>
        public int BufferSize
        {
            get => _bufferSize;
            set => _bufferSize = AdjustBufferSize(value);
        }

        /// <summary>
        ///   A maximum length. Set this value to truncate when tracing very large bodies such as media or binaries.
        /// </summary>
        /// <remarks>
        ///   This value should be a equally divisible by <see cref="BufferSize"/> for efficiency.
        ///   The setter automatically rounds (<c>value</c> / <see cref="BufferSize"/>)
        ///   and multiplies with <see cref="BufferSize"/>.
        /// </remarks>
        public long MaxSize
        {
            get => _maxSize;
            set => _maxSize = AdjustMaxSize(value, _bufferSize);
        }

        /// <summary>
        ///   Gets or sets a value that is used when tracing large requests. Requests that exceeds this value
        ///   in content length will automatically be traced in a background thread to reduce the performance hit.
        /// </summary>
        public uint ContentLengthAsyncThreshold { get; set; } = DefaultContentLengthAsyncThreshold;

        internal static int AdjustBufferSize(int value) => Math.Max(128, value);

        internal static long AdjustMaxSize(long value, int bufferSize) => (long)Math.Round((decimal)value / bufferSize) * bufferSize;

        /// <summary>
        ///   Initializes the <see cref="TraceBodyOptions"/> with default values.  
        /// </summary>
        public TraceBodyOptions()
        {
            _bufferSize = DefaultBuffersSize;
            _maxSize = _bufferSize * DefaultMaxSizeFactor;
        }
    }
}