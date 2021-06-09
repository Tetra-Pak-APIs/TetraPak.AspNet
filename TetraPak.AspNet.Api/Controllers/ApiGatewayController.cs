using TetraPak.AspNet.Api.Auth;

namespace TetraPak.AspNet.Api.Controllers
{
    public abstract class ApiGatewayController<TBackend> : BusinessApiController
    where TBackend : IBackendService
    {
        public TBackend Backend { get; }

        public ApiGatewayController(TBackend backend, TetraPakApiAuthConfig authConfig)
        : base(authConfig)
        {
            Backend = backend;
        }
    }
}