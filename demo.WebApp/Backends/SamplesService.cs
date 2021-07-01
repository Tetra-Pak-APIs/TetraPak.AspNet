using TetraPak.AspNet.Api;

namespace demo.WebApp.Backends
{
    public class SamplesService : BackendService<SamplesEndpoints>
    {
        public SamplesService(SamplesEndpoints endpoints, IHttpServiceProvider httpServiceProvider) 
        : base(endpoints, httpServiceProvider)
        {
        }
    }
}