using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TetraPak.AspNet.Debugging
{
    partial class WebLoggerHelper // requests
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
        /// <param name="optionsFactory">
        ///   (optional)<br/>
        ///   Invoked to obtain options for how tracing is conducted. 
        /// </param>
        public static async Task TraceAsync(
            this ILogger? logger, 
            HttpRequest request, 
            Func<TraceRequestOptions>? optionsFactory = null)
        {
            if (logger is null || !logger.IsEnabled(LogLevel.Trace))
                return;

            optionsFactory ??= () => TraceRequestOptions.Default(null).WithDirection(HttpDirection.In);
            var contentStream = request.Body;
            if (await contentStream.ExceedsTraceThresholdAsync())
            {
#pragma warning disable CS4014
                logger.TraceAsync(request.ToAbstractHttpRequestAsync(), optionsFactory);
#pragma warning restore CS4014
            }
            else
            {
                await logger.TraceAsync(request.ToAbstractHttpRequestAsync(), optionsFactory);
            }
        }
        
        /// <summary>
        ///   Traces a <see cref="HttpWebRequest"/> in the logs.
        /// </summary>
        /// <param name="logger">
        ///   The logger provider.
        /// </param>
        /// <param name="request">
        ///   The request message to be traced.
        /// </param>
        /// <param name="optionsFactory">
        ///   (optional)<br/>
        ///   Invoked to obtain options for how tracing is conducted. 
        /// </param>
        /// <exception cref="InvalidOperationException">
        ///   <paramref name="request"/>'s URI is relative but <see cref="TraceRequestOptions.BaseAddress"/>
        ///   is <c>null</c> in the <see cref="TraceRequestOptions"/> provided by <paramref name="optionsFactory"/>.
        /// </exception>
        public static async Task TraceAsync(
            this ILogger? logger,
            HttpRequestMessage request,
            Func<TraceRequestOptions>? optionsFactory = null)
        {
            if (logger is null || !logger.IsEnabled(LogLevel.Trace))
                return;

            optionsFactory ??= () => TraceRequestOptions.Default(null).WithDirection(HttpDirection.In);
            var contentStream = request.Content is {} ? await request.Content?.ReadAsStreamAsync()! : null;
            if (await contentStream.ExceedsTraceThresholdAsync())
            {
#pragma warning disable CS4014
                logger.TraceAsync(await request.ToAbstractHttpRequestAsync(), optionsFactory);
#pragma warning restore CS4014
            }
            else
            {
                await logger.TraceAsync(await request.ToAbstractHttpRequestAsync(), optionsFactory);
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
        public static async Task TraceAsync(
            this ILogger? logger, 
            HttpWebRequest request, 
            Func<TraceRequestOptions>? optionsFactory)
        {
            if (logger is null || !logger.IsEnabled(LogLevel.Trace))
                return;

            optionsFactory ??= () => TraceRequestOptions.Default(null).WithDirection(HttpDirection.In);
            var contentStream = request.GetRequestStream();
            if (await contentStream.ExceedsTraceThresholdAsync())
            {
#pragma warning disable CS4014
                logger.TraceAsync(request.ToAbstractHttpRequestAsync(), optionsFactory);
#pragma warning restore CS4014
            }
            else
            {
                await logger.TraceAsync(request.ToAbstractHttpRequestAsync(), optionsFactory);
            }
        }
    }
}