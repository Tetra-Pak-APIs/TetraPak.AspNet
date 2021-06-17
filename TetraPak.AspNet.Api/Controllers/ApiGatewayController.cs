using TetraPak.AspNet.Api.Auth;

namespace TetraPak.AspNet.Api.Controllers
{
    public abstract class ApiGatewayController<TBackendService> : BusinessApiController
    where TBackendService : IBackendService
    {
        public TBackendService BackendService { get; }

        public ApiGatewayController(TBackendService backendService, TetraPakApiAuthConfig authConfig)
        : base(authConfig)
        {
            BackendService = backendService;
        }
    }
}