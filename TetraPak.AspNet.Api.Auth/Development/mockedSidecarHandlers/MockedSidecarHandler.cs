using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TetraPak.Api.Auth.Development;

namespace TetraPak.Api.Auth.Development
{
    public abstract class MockedSidecarHandler
    {
        static readonly AsyncLocal<SidecarServiceArgs> s_args = new AsyncLocal<SidecarServiceArgs>();
        static readonly AsyncLocal<object> s_options = new AsyncLocal<object>();

        protected readonly object SyncRoot = new object();

        public SidecarServiceArgs ServiceArgs => s_args.Value;
        protected HttpContext Context => s_args.Value.Context;

        protected object Options => s_options.Value;

        protected ILogger Log => s_args.Value.Log;

        public Task<bool> Handle(SidecarServiceArgs args, object options)
        {
            s_args.Value = args;
            s_options.Value = options;
            return OnHandle();
        }

        protected abstract Task<bool> OnHandle();

        protected async Task<bool> Ok(object data = null)
        {
            Context.Response.StatusCode = (int) HttpStatusCode.OK;
            if (data is null)
                return true;
                
            Context.Response.ContentType = "application/json";
            var jsonDocument = JsonSerializer.Serialize(data);
            await Context.Response.WriteAsync(jsonDocument);
            return true;
        }
    }
}