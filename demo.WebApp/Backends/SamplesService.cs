using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api;

namespace demo.WebApp.Backends
{
    public class SamplesService : BackendService<SamplesEndpoints>
    {
        public SamplesService(
            SamplesEndpoints endpoints, 
            IHttpClientProvider httpClientProvider, 
            ILogger logger) 
        : base(endpoints, httpClientProvider, logger)
        {
        }
    }
}