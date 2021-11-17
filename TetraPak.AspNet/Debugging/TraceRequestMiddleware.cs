using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

#nullable enable

namespace TetraPak.AspNet.Debugging
{
    class TraceRequestMiddleware
    {
        readonly TetraPakConfig _tetraPakConfig;
        readonly ILogger _logger;

        public Task InvokeAsync(HttpContext context) 
            => _logger.TraceHttpRequestAsync(
                context.Request, 
                bodyOptions: _tetraPakConfig.Logging.GetTraceBodyOptions());

        public TraceRequestMiddleware(TetraPakConfig tetraPakConfig, ILogger logger)
        {
            _tetraPakConfig = tetraPakConfig;
            _logger = logger;
        }
    }
}