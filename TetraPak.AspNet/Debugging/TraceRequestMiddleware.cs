using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

#nullable enable

namespace TetraPak.AspNet.Debugging
{
    static class TraceRequest
    {
        const string RequestOutQualifier = "REQ.OUT";
        const string RequestInQualifier = "REQ.IN";
        
        internal static string GetTraceRequestQualifier(bool outgoing) =>
            outgoing
                ? RequestOutQualifier
                : RequestInQualifier;
    }
    
    class TraceRequestMiddleware
    {
        readonly TetraPakConfig _tetraPakConfig;
        readonly ILogger _logger;

        public Task InvokeAsync(HttpContext context) 
            => _logger.TraceHttpRequestAsync(
                context.Request,
                () => _tetraPakConfig.Logging.GetTraceBodyOptions(_tetraPakConfig,  context) 
                      ?? TraceRequestOptions.Default(context.Request.GetMessageId(_tetraPakConfig)));

        public TraceRequestMiddleware(TetraPakConfig tetraPakConfig, ILogger logger)
        {
            _tetraPakConfig = tetraPakConfig;
            _logger = logger;
        }
    }
}