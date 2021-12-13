using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TetraPak.AspNet.Debugging
{
    class TraceRequestMiddleware
    {
        readonly TetraPakConfig _tetraPakConfig;
        readonly ILogger _logger;

        public Task InvokeAsync(HttpContext context) 
            => _logger.TraceAsync(
                context.Request,
                () => 
                    _tetraPakConfig.Logging.GetTraceBodyOptions(_tetraPakConfig,  context)
                    ?? TraceRequestOptions.Default(context.Request.GetMessageId(_tetraPakConfig))
                        .WithInitiator(RequestInitiators.Actor, HttpDirection.In));

        public TraceRequestMiddleware(TetraPakConfig tetraPakConfig, ILogger logger)
        {
            _tetraPakConfig = tetraPakConfig;
            _logger = logger;
        }
    }
}