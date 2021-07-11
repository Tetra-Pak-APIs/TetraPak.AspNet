namespace TetraPak.AspNet.Api.Controllers
{
    public abstract class ApiGatewayController<TBackendService> : BusinessApiController
    where TBackendService : IBackendService
    {
        public TBackendService Service { get; }

        public ApiGatewayController(TBackendService service, AmbientData ambientData)
        : base(ambientData)
        {
            Service = service;
        }
    }
}