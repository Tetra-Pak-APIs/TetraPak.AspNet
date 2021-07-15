namespace TetraPak.AspNet.Api.Controllers
{
    public abstract class ApiGatewayController<TBackendService> : BusinessApiController
    where TBackendService : IBackendService
    {
        TBackendService _service;
        
        protected TBackendService Service
        {
            get => _service ??= createService();
            private set => _service = value;
        }

        internal void SetService(TBackendService service) => Service = service;

        TBackendService createService() => TetraPakControllerFactory.CreateService(this);

        public ApiGatewayController() : base(null)
        {
        }
        
        public ApiGatewayController(TBackendService service, AmbientData ambientData)
        : base(ambientData)
        {
            Service = service;
        }
    }

    public abstract class ApiGatewayController : ApiGatewayController<BackendService<ServiceEndpoints>>
    {
        public ApiGatewayController()
        {
        }
        
        protected ApiGatewayController(AmbientData ambientData)
        : base(null, ambientData)
        {
        }
    }
}