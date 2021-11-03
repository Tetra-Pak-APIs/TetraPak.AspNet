using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

#nullable enable

namespace TetraPak.AspNet
{
    class TetraPakSdkClientDecorator : IHttpClientDecorator
    {
        static string? s_userAgentValue;

        static string userAgentValue()
        {
            if (s_userAgentValue is { }) 
                return s_userAgentValue;

            var asm = typeof(TetraPakSdkClientDecorator).Assembly;
            var v = asm.GetName().Version!;
            s_userAgentValue = $"{asm.GetName().Name}/{v.Major}.{v.Minor}.{v.Build}";
            return s_userAgentValue;
        }

        public Task<Outcome<HttpClient>> DecorateAsync(HttpClient client)
        {
            client.DefaultRequestHeaders.TryAddWithoutValidation(HeaderNames.UserAgent, new []{userAgentValue()});
            return Task.FromResult(Outcome<HttpClient>.Success(client));
        }
    }
}