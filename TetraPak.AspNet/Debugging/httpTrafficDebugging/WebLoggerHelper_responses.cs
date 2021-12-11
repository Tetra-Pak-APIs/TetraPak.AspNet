using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

#nullable enable

namespace TetraPak.AspNet.Debugging
{
    partial class WebLoggerHelper // responses
    {
        /// <summary>
        ///   Traces a <see cref="HttpResponse"/> in the logs.
        /// </summary>
        /// <param name="logger">
        ///   The logger provider.
        /// </param>
        /// <param name="response">
        ///   The response to be traced.
        /// </param>
        /// <param name="request">
        ///   (optional)<br/>
        ///   A request (resulting in the response). 
        /// </param>
        /// <param name="optionsFactory">
        ///   (optional)<br/>
        ///   Invoked to obtain options for how tracing is conducted. 
        /// </param>
        public static async Task TraceAsync(
            this ILogger? logger,
            HttpResponse? response,
            AbstractHttpRequest? request = null,
            Func<TraceRequestOptions>? optionsFactory = null)
        {
            if (response is null || logger is null || !logger.IsEnabled(LogLevel.Trace))
                return;

            optionsFactory ??= () => TraceRequestOptions.Default(null).WithDirection(HttpDirection.In);
            var contentStream = response.Body;
            if (await contentStream.ExceedsTraceThresholdAsync())
            {
#pragma warning disable CS4014
                logger.TraceAsync(response.ToAbstractHttpResponse(request), optionsFactory);
#pragma warning restore CS4014
            }
            else
            {
                await logger.TraceAsync(response.ToAbstractHttpResponse(request), optionsFactory);
            }
        }
        
        /// <summary>
        ///   Traces a <see cref="HttpResponseMessage"/> in the logs.
        /// </summary>
        /// <param name="logger">
        ///   The logger provider.
        /// </param>
        /// <param name="response">
        ///   The response to be traced.
        /// </param>
        /// <param name="optionsFactory">
        ///   (optional)<br/>
        ///   Invoked to obtain options for how tracing is conducted. 
        /// </param>
        public static async Task TraceAsync(
            this ILogger? logger,
            HttpResponseMessage? response,
            Func<TraceRequestOptions>? optionsFactory = null)
        {
            if (response is null || logger is null || !logger.IsEnabled(LogLevel.Trace))
                return;

            optionsFactory ??= () => TraceRequestOptions.Default(null).WithDirection(HttpDirection.In);
            var contentStream = await response.Content.ReadAsStreamAsync();
            if (await contentStream.ExceedsTraceThresholdAsync())
            {
#pragma warning disable CS4014
                logger.TraceAsync(await response.ToAbstractHttpResponseAsync(), optionsFactory);
#pragma warning restore CS4014
            }
            else
            {
                await logger.TraceAsync(await response.ToAbstractHttpResponseAsync(), optionsFactory);
            }
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
        /// <param name="request">
        ///   (optional)<br/>
        ///   A request (resulting in the response). 
        /// </param>
        /// <param name="optionsFactory">
        ///   (optional)<br/>
        ///   Invoked to obtain options for how tracing is conducted. 
        /// </param>
        public static async Task TraceAsync(
            this ILogger? logger,
            WebResponse? response, 
            AbstractHttpRequest? request,
            Func<TraceRequestOptions>? optionsFactory = null)
        {
            if (response is null || logger is null || !logger.IsEnabled(LogLevel.Trace))
                return;

            optionsFactory ??= () =>
                TraceRequestOptions.Default(null).WithDirection(HttpDirection.Response).WithAsyncBodyFactory(async () 
                    => 
                    await response.GetResponseStream().GetRawBodyStringAsync(Encoding.Default));
            
            var contentStream = response.GetResponseStream();
            if (await contentStream.ExceedsTraceThresholdAsync())
            {
#pragma warning disable CS4014
                logger.TraceAsync(response.ToAbstractHttpResponse(request), optionsFactory);
#pragma warning restore CS4014
            }
            else
            {
                await logger.TraceAsync(response.ToAbstractHttpResponse(request), optionsFactory);
            }
        }
    }
}