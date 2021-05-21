using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TetraPak.AspNet.Api
{
    public interface IBackendService
    {
        Task<Outcome<HttpResponseMessage>> PostAsync(
            string path,
            HttpContent content,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null);
    }
}