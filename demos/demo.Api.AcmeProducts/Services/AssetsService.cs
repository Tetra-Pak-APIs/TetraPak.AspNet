using System.Diagnostics.CodeAnalysis;
using TetraPak.AspNet.Api;

namespace demo.AcmeProducts.Services
{
    public class AssetsService : BackendService<AssetsService.AssetsEndpoints>
    {
        public class AssetsEndpoints : ServiceEndpoints
        {
            public ServiceEndpoint Assets => GetEndpoint();

            public ServiceEndpoint Files => GetEndpoint();
            
            // public ServiceEndpoint Files(string id) => GetEndpoint(new { Id = id });
        }

        public AssetsService(AssetsEndpoints endpoints) : base(endpoints)
        {
        }
    }
}