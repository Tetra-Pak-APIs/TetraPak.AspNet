using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

#nullable enable

namespace TetraPak.AspNet
{
    class TetraPakSdkClientDecorator : IHttpClientDecorator
    {
        readonly TetraPakConfig _tetraPakConfig;

        public Task<Outcome<HttpClient>> DecorateAsync(HttpClient client)
        {
            var value = _tetraPakConfig.SdkVersion;
            if (!client.DefaultRequestHeaders.UserAgent.Any(i => i.Equals(value)))
            {
                client.DefaultRequestHeaders.UserAgent.TryParseAdd(value.ToString());
            }
            return Task.FromResult(Outcome<HttpClient>.Success(client));
        }

        public TetraPakSdkClientDecorator(TetraPakConfig tetraPakConfig)
        {
            _tetraPakConfig = tetraPakConfig;
        }
    }
}