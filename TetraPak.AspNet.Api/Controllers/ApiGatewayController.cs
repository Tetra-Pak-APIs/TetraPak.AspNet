using Microsoft.Extensions.Logging;

namespace TetraPak.AspNet.Api.Controllers
{
    public abstract class ApiGatewayController<TBackend> : BusinessApiController
    where TBackend : IBackendService
    {
        public TBackend Backend { get; }

        public ApiGatewayController(TBackend backend, ILogger logger)
        : base(logger)
        {
            Backend = backend;
        }
    }
}