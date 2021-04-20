using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TetraPak.AspNet.Api
{
    public class HttpClientProvider : IHttpClientProvider, IApiLoggerProvider
    {
        readonly Func<HttpClientOptions,HttpClient> _singletonClientFactory;
        readonly HttpClientOptions _singletonClientOptions;
        HttpClient _singletonClient;
        
        public ILogger Logger { get; private set; }

        public HttpClient SingletonClient => _singletonClient ??= _singletonClientFactory(_singletonClientOptions);
        
        public virtual Task<Outcome<HttpClient>> GetHttpClientAsync(
            HttpClientOptions options = null, 
            CancellationToken? cancellationToken = null,
            ILogger logger = null)
        {
            var transient = options?.IsClientTransient ?? true;
            if (options?.MessageHandler is { })
                return transient
                    ? Task.FromResult(Outcome<HttpClient>.Success(new HttpClient(options.MessageHandler)))
                    : Task.FromResult(Outcome<HttpClient>.Success(SingletonClient));
            
            return transient
                ? Task.FromResult(Outcome<HttpClient>.Success(new HttpClient()))
                : Task.FromResult(Outcome<HttpClient>.Success(SingletonClient));
        }

        public ILogger GetLogger() => Logger;

        public void SetLogger(ILogger logger) => Logger = logger;

        public HttpClientProvider(
            Func<HttpClientOptions,HttpClient> singletonClientFactory = null, 
            HttpClientOptions singletonClientOptions = null)
        {
            _singletonClientFactory = singletonClientFactory ?? (_ => new HttpClient());
            _singletonClientOptions = singletonClientOptions;
        }
    }
}