using TetraPak.AspNet.Api;

namespace WebAPI.services
{
    public class GreetingsService : BackendService<GreetingsService.GreetingsEndpoints>
    {
        public class GreetingsEndpoints : ServiceEndpoints
        {
            public ServiceEndpoint Greetings => GetEndpoint();
        }

        public GreetingsService(GreetingsEndpoints endpoints) 
        : base(endpoints)
        {
            
        }
    }
}