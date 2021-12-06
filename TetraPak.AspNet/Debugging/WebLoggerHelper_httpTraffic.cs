using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using TetraPak.Logging;
using TetraPak.Serialization;

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
        public static Task TraceWebRequestAsync(
            this ILogger? logger, 
            HttpWebRequest request, 
            Func<string>? bodyHandler = null)
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
        /// <param name="optionsFactory">
        ///   (optional)<br/>
        ///   Specifies how tracing of request bodies is conducted. 
        /// </param>
        public static Task TraceHttpRequestAsync(
            this ILogger? logger, 
            HttpRequest request, 
            Func<TraceRequestOptions>? optionsFactory = null)
        {
            if (logger is null || !logger.IsEnabled(LogLevel.Trace))
                return Task.CompletedTask;

            var options = optionsFactory?.Invoke() ?? TraceRequestOptions.Default(null);
            if (request.ContentLength > 2048)
                return Task.Run(async () => await logBodyAsync());

            logBodyAsync().Await();
            return Task.CompletedTask;

            async Task logBodyAsync()
            {
                var sb = new StringBuilder();
                sb.Append(TraceRequest.GetTraceRequestQualifier(false));
                sb.Append(" >>> ");
                sb.Append(request.Method.ToUpper());
                sb.Append(' ');
                sb.AppendLine(request.GetDisplayUrl());
                addHeaders(sb, request.Headers.ToKeyValuePairs());
                await addBody(sb);
                sb = options.AsyncDecorationHandler is { }
                    ? await options.AsyncDecorationHandler(sb)
                    : sb;
            
                logger.Trace(sb.ToString(), options?.MessageId);
            }
            
            async Task addBody(StringBuilder sb)
            {
                if (options.AsyncBodyFactory is {})
                {
                    sb.AppendLine();
                    sb.AppendLine(await options.AsyncBodyFactory());
                    return;
                }

                // var isEmptyOutcome = await request.Body.IsEmptyAsync(options?.ForceTraceBody ?? TraceRequestOptions.DefaultForceTraceBody);
                // if (!isEmptyOutcome.IsSuccess)
                // {
                //     sb.AppendLine();
                //     sb.AppendLine("(*** BODY UNAVAILABLE ***)");
                //     return;
                // }
                //
                // if (isEmptyOutcome && isEmptyOutcome.Value)
                // {
                //     sb.AppendLine();
                //     sb.AppendLine("(NO BODY)");
                //     return;
                // }   
                
                var bodyText = await request.Body.GetRawBodyStringAsync(Encoding.Default, options);
                if (string.IsNullOrEmpty(bodyText))
                    return;
                
                sb.AppendLine();
                sb.AppendLine(bodyText);
            }
        }
        
        /// <summary>
        ///   Traces a <see cref="HttpWebRequest"/> in the logs.
        /// </summary>
        /// <param name="logger">
        ///   The logger provider.
        /// </param>
        /// <param name="requestMessage">
        ///   The request message to be traced.
        /// </param>
        /// <param name="options">
        ///   (optional)<br/>
        ///   Specifies how tracing of request bodies is conducted. 
        /// </param>
        /// <exception cref="InvalidOperationException">
        ///   <paramref name="baseAddress"/> is <c>null</c> but the <paramref name="requestMessage"/>'s
        ///   URI is relative.
        /// </exception>
        public static async Task TraceHttpRequestMessageAsync(
            this ILogger? logger,
            HttpRequestMessage requestMessage,
            Func<TraceRequestOptions>? optionsFactory = null)
        {
            if (logger is null || !logger.IsEnabled(LogLevel.Trace))
                return;

            var options = optionsFactory?.Invoke();
            var contentStream = await requestMessage.Content?.ReadAsStreamAsync();
            if (contentStream.Length > 2048)
            {
                traceAsync();
            }
            else
            {
                await traceAsync();
            }

            async Task traceAsync()
            {
                var sb = await requestMessage.ToStringBuilder(new StringBuilder(), optionsFactory);
                logger.Trace(sb.ToString(), options?.MessageId);
            }
        }

        public static async Task<StringBuilder> ToStringBuilder(
            this HttpRequestMessage requestMessage,
            StringBuilder sb,
            Func<TraceRequestOptions>? optionsFactory = null)
        {
            var options = optionsFactory?.Invoke();
            sb.Append(requestMessage.Method.Method.ToUpper());
            sb.Append(' ');
            var uri = options?.BaseAddress is { }
                ? $"{options.BaseAddress.ToString().EnsurePostfix("/")}{requestMessage.RequestUri.ToString().TrimStart('/')}"
                : requestMessage.RequestUri.AbsoluteUri;
            sb.AppendLine(uri);
            addHeaders(sb, requestMessage.Headers);
            await addBodyAsync(sb);
            return options.AsyncDecorationHandler is { }
                ? await options.AsyncDecorationHandler(sb)
                : sb;
            
            async Task addBodyAsync(StringBuilder sb)
            {
                if (options?.AsyncBodyFactory is {})
                {
                    sb.AppendLine();
                    sb.AppendLine(await options.AsyncBodyFactory());
                    return;
                }

                if (requestMessage.Content is null)
                    return;
                
                var bodyText = await requestMessage.GetRawBodyStringAsync(Encoding.Default, options);
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
        /// <param name="options">
        ///   (optional)<br/>
        ///   Specifies how tracing of request bodies is conducted. 
        /// </param>
        /// <returns>
        ///   The (raw) textual representation of the request body as a <see cref="string"/>. 
        /// </returns>
        // public static async Task<string> GetRawBodyStringAsync( obsolete
        //     this HttpRequest request, 
        //     Encoding encoding, 
        //     TraceRequestOptions? options = null)
        // {
        //     var bufferSize = options?.BufferSize ?? TraceRequestOptions.DefaultBuffersSize;
        //     
        //     request.EnableBuffering();
        //     if (request.ContentLength == 0 || !request.Body.CanSeek)
        //         return string.Empty;
        //
        //     string body;
        //     if (options is null || request.Body.Length <= options.MaxSize)
        //     {
        //         // no need to read in chunks, just get and return the whole body ...
        //         using var bodyReader = new StreamReader(request.Body, encoding, true, 
        //             bufferSize, 
        //             true);
        //         body = await bodyReader.ReadToEndAsync();
        //         request.Body.Position = 0;
        //         return body;
        //     }
        //     
        //     // read body in chunks of buffer size and truncate if there's a max length
        //     // (to avoid performance issues with very large bodies, such as media or binaries) ... 
        //     request.Body.Seek(0, SeekOrigin.Begin);
        //     var buffer = new char[bufferSize];
        //     var remaining = options.MaxSize;
        //     var isTruncated = false;
        //
        //     var bodyStream = new MemoryStream();
        //     await using var writer = new StreamWriter(bodyStream);
        //     using var reader = new StreamReader(request.Body, encoding, true, bufferSize, true);
        //     
        //     while (await reader.ReadBlockAsync(buffer) != 0 && !isTruncated)
        //     {
        //         await writer.WriteAsync(buffer);
        //         remaining -= bufferSize;
        //         isTruncated = remaining <= 0; 
        //     }
        //     bodyStream.Position = 0;
        //     using (var memoryReader = new StreamReader(bodyStream, leaveOpen:true)) // leave open (`writer` will close)
        //     {
        //         body = await memoryReader.ReadToEndAsync();
        //     }
        //     request.Body.Position = 0;
        //     return isTruncated
        //         ? $"{body}...[--TRUNCATED--]"
        //         : body;
        // }
        
        public static async Task<string> GetRawBodyStringAsync(
            this HttpRequestMessage request, 
            Encoding encoding, 
            TraceRequestOptions? options = null)
        {
            if (request.Content is null)
                return string.Empty;
            
            var bufferSize = options?.BufferSize ?? TraceRequestOptions.DefaultBuffersSize;
            var stream = await request.Content.ReadAsStreamAsync();
            var isEmptyOutcome = await stream.IsEmptyAsync();
            if (isEmptyOutcome.IsSuccess && isEmptyOutcome.Value)
                return string.Empty;

            string body;
            if (options is null || stream.Length <= options.MaxSize)
            {
                // no need to read in chunks, just get and return the whole body ...
                using var bodyReader = new StreamReader(stream, encoding, true, 
                    bufferSize, 
                    true);
                body = await bodyReader.ReadToEndAsync();
                stream.Position = 0;
                return body;
            }
            
            // read body in chunks of buffer size and truncate if there's a max length
            // (to avoid performance issues with very large bodies, such as media or binaries) ... 
            var buffer = new char[bufferSize];
            var remaining = options.MaxSize;
            var isTruncated = false;

            var bodyStream = new MemoryStream();
            await using var writer = new StreamWriter(bodyStream);
            using var reader = new StreamReader(stream, encoding, true, bufferSize, true);
            
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
            stream.Position = 0;
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
            Func<TraceRequestOptions>? optionsFactory = null)
        =>
            await traceAsync(logger, response, optionsFactory);

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
        public static async Task TraceAsync(this ILogger? logger, HttpResponse? response, string? messageId, bool? includeBody = false)
        {
            var options = TraceRequestOptions.Default(messageId);
            if (!includeBody ?? false)
            {
                options.AsyncBodyFactory = () => Task.FromResult(string.Empty);
            }
            await traceAsync(logger, response, () => options);
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

        public static async Task<StringBuilder> ToStringBuilderAsync(
            this HttpResponse? response,
            StringBuilder sb,
            TraceRequestOptions options)
        {
            if (response is null)
                return sb;
            
            sb.Append(response.StatusCode);
            sb.Append(' ');
            sb.AppendLine(response.StatusCode.ToString());
            addHeaders(sb, response.Headers.ToKeyValuePairs());
            await addBody();
            return sb;

            async Task addBody()
            {
                if (options.AsyncBodyFactory is { })
                {
                    sb.AppendLine();
                    sb.AppendLine(await options.AsyncBodyFactory());
                    return;
                }

                var lengthOutcome = await response.Body.GetLengthAsync(options.ForceTraceBody);
                var length = lengthOutcome.Value;
                if (length == 0)
                    return;

                var body = await response.Body.GetRawBodyStringAsync(Encoding.UTF8, options);
                if (body.Length == 0)
                    return;
                
                sb.AppendLine();
                sb.AppendLine(body);
            }
        }
        public static async Task<StringBuilder> ToStringBuilderAsync(
            this HttpResponseMessage? response,
            StringBuilder sb,
            TraceRequestOptions options)
        {
            sb.Append((int) response.StatusCode);
            sb.Append(' ');
            sb.AppendLine(response.StatusCode.ToString());
            addHeaders(sb, response.Headers);
            await addBody();
            return sb;

            async Task addBody()
            {
                if (options.AsyncBodyFactory is { })
                {
                    sb.AppendLine();
                    sb.AppendLine(await options.AsyncBodyFactory());
                    return;
                }

                var stream = await response.Content.ReadAsStreamAsync();
                var lengthOutcome = await stream.GetLengthAsync(options.ForceTraceBody);
                var length = lengthOutcome.Value;
                if (length == 0)
                    return;

                var body = await stream.GetRawBodyStringAsync(Encoding.UTF8, options);
                if (body.Length == 0)
                    return;
                
                sb.AppendLine();
                sb.AppendLine(body);
            }
        }

        static async Task traceAsync(
            ILogger? logger, 
            HttpResponse? response,
            Func<TraceRequestOptions>? optionsFactory = null)
        {
            if (logger is null || response is null || !logger.IsEnabled(LogLevel.Trace))
                return;

            var sb = await response.ToStringBuilderAsync(new StringBuilder(), optionsFactory.Invoke());
            logger.Trace(sb.ToString());
        }
        
        public static async Task<string> GetRawBodyStringAsync(
            this Stream? stream, 
            Encoding encoding, 
            TraceRequestOptions? options = null)
        {
            var lengthOutcome = await stream.GetLengthAsync(options?.ForceTraceBody ?? TraceRequestOptions.DefaultForceTraceBody);
            var length = lengthOutcome.Value;
            if (length == 0)
                return string.Empty;

            if (!stream!.CanSeek)
                return "[*** BODY UNAVAILABLE ***]";
                
            var bufferSize = options?.BufferSize ?? TraceRequestOptions.DefaultBuffersSize;

            string body;
            if (options is null || length <= options.MaxSize)
            {
                // no need to read in chunks, just get and return the whole body ...
                using var bodyReader = new StreamReader(stream!, encoding, true, 
                    bufferSize, 
                    true);
                body = await bodyReader.ReadToEndAsync();
                stream!.Position = 0;
                return body;
            }
            
            // read body in chunks of buffer size and truncate if there's a max length
            // (to avoid performance issues with very large bodies, such as media or binaries) ... 
            var buffer = new char[bufferSize];
            var remaining = options.MaxSize;
            var isTruncated = false;

            var bodyStream = new MemoryStream();
            await using var writer = new StreamWriter(bodyStream);
            using var reader = new StreamReader(stream!, encoding, true, bufferSize, true);
            
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
            stream.Position = 0;
            return isTruncated
                ? $"{body}...[--TRUNCATED--]"
                : body;
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
    
        // static void addHeaders(StringBuilder sb, IHeaderDictionary headers) obsolete
        // {
        //     foreach (var (key, values) in headers)
        //     {
        //         if (values.Count == 0)
        //         {
        //             sb.AppendLine(key);
        //             continue;
        //         }
        //     
        //         sb.Append(key);
        //         sb.Append('=');
        //         sb.AppendLine(values.ConcatCollection());
        //     }
        // }
        
        static void addHeaders(StringBuilder sb, IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers)
        {
            foreach (var (key, values) in headers)
            {
                if (!values.Any())
                {
                    sb.AppendLine(key);
                    continue;
                }
            
                sb.Append(key);
                sb.Append('=');
                sb.AppendLine(values.ConcatCollection());
            }
        }

        static IEnumerable<KeyValuePair<string, IEnumerable<string>>> ToKeyValuePairs(
            this IDictionary<string, StringValues> dict)
        {
            foreach (var (key, values) in dict)
            {
                yield return new KeyValuePair<string, IEnumerable<string>>(key, values);
            }
        }
        
    }

    /// <summary>
    ///   Used when request bodies gets dumped to the logger (at log level <see cref="LogLevel.Trace"/>).
    /// </summary>
    public class TraceRequestOptions
    {
        internal const int DefaultBuffersSize = 1024;
        const int DefaultMaxSizeFactor = 4;

        /// <summary>
        ///   The default value for <see cref="ForceTraceBody"/>.
        /// </summary>
        public static bool DefaultForceTraceBody { get; set; } = false;

        int _bufferSize;
        long _maxSize;

        /// <summary>
        ///   (static property)<br/>
        ///   Gets or sets a default value used for the <see cref="ContentLengthAsyncThreshold"/>
        ///   property's initial value.
        /// </summary>
        public static uint DefaultContentLengthAsyncThreshold { get; set; } = 1024;
        
        /// <summary>
        ///   Gets default <see cref="TraceRequestOptions"/>
        /// </summary>
        public static TraceRequestOptions Default(string? messageId) => new(messageId);
        
        /// <summary>
        ///   A base address used for the traced request message. This should be passed if
        ///   the request message's URI (<see cref="HttpRequestMessage.RequestUri"/>) is a relative path.
        ///   If <c>null</c> the request message's URI is expected to be an absolute URI (which may throw an
        ///   exception).
        /// </summary>
        public Uri? BaseAddress { get; set; }

        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="BaseAddress"/> property and returns <c>this</c>.
        /// </summary>
        public TraceRequestOptions WithBaseAddress(Uri baseAddress)
        {
            BaseAddress = baseAddress;
            return this;
        }
        
        /// <summary>
        ///   Assign this to construct custom body content (default = <c>null</c>).
        /// </summary>
        public Func<Task<string>>? AsyncBodyFactory { get; set; }
        
        /// <summary>
        ///   Gets or sets a unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </summary>
        public string? MessageId { get; set; }
        
        /// <summary>
        ///   A callback handler, invoked after the request message has been serialized to
        ///   a <see cref="string"/> but before the result is propagated to the logger provider.
        ///   Use this to decorate the result with custom content.
        /// </summary>
        /// <seealso cref="WithDecorator"/>
        internal Func<StringBuilder, Task<StringBuilder>>? AsyncDecorationHandler { get; set; }

        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="AsyncDecorationHandler"/> decorator and returns <c>this</c>.
        /// </summary>
        public TraceRequestOptions WithDecorator(Func<StringBuilder, Task<StringBuilder>> decorator)
        {
            AsyncDecorationHandler = decorator;
            return this;
        }

        /// <summary>
        ///   (default=<see cref="DefaultForceTraceBody"/>)<br/>
        ///   Gets or sets a value that forces the tracing of the request/response body
        /// </summary>
        public bool ForceTraceBody { get; set; } = DefaultForceTraceBody;

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
        ///   Initializes the <see cref="TraceRequestOptions"/> with default values.  
        /// </summary>
        public TraceRequestOptions(string? messageId = null)
        {
            _bufferSize = DefaultBuffersSize;
            _maxSize = _bufferSize * DefaultMaxSizeFactor;
            MessageId = messageId;
        }
    }
}