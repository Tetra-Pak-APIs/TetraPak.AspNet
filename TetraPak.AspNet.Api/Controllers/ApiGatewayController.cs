using TetraPak.AspNet.Api.Auth;

namespace TetraPak.AspNet.Api.Controllers
{
    public abstract class ApiGatewayController<TBackendService> : BusinessApiController
    where TBackendService : IBackendService
    {
        public TBackendService Service { get; }

        public ApiGatewayController(TBackendService service, TetraPakApiAuthConfig authConfig)
        : base(authConfig)
        {
            Service = service;
           // this.Configure(authConfig);
        }
    }
}