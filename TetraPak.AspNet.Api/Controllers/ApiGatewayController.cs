using Microsoft.Extensions.Logging;

namespace TetraPak.AspNet.Api.Controllers
{
    public abstract class ApiGatewayController<TBackend,TEndpoints> : BusinessApiController
    where TBackend : BackendService<TEndpoints>
    where TEndpoints : EndpointsConfig
    {
        public TBackend Backend { get; }

        public ApiGatewayController(TBackend backend, ILogger logger)
        : base(logger)
        {
            Backend = backend;
        }

    }
}