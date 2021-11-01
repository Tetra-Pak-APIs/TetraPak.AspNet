using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet
{
    public abstract class TetraPakHttpClientProvider : IHttpClientProvider //, IMessageIdProvider //, IAuthorizationService obsolete
    {
        readonly Func<HttpClientOptions,HttpClient> _singletonClientFactory;
        readonly HttpClientOptions? _singletonClientOptions;
        HttpClient? _singletonClient;

        protected TetraPakConfig TetraPakConfig { get; }
        
        protected IHttpContextAccessor HttpContextAccessor { get; }

        // /// <summary>
        // ///   Gets a value that indicates whether the service can authorize the clients it produces.
        // /// </summary>
        // protected abstract bool CanAuthorizeClient { get; } obsolete
        
        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        protected ILogger? Logger => TetraPakConfig.Logger;
        
        protected HttpClient SingletonClient => _singletonClient ??= _singletonClientFactory(_singletonClientOptions!);

        string? getMessageId(bool enforce) => TetraPakConfig.AmbientData.GetMessageId(enforce);
        
        /// <inheritdoc />
        public async Task<Outcome<HttpClient>> GetHttpClientAsync(
            HttpClientOptions? options = null, 
            CancellationToken? cancellationToken = null)
        {
            var transient = options?.IsClientTransient ?? true;
            var client = transient
                ? options?.MessageHandler is {} 
                    ? new HttpClient(options.MessageHandler) 
                    : new HttpClient()
                : SingletonClient;

            if (options?.AuthorizationService is null) 
                return Outcome<HttpClient>.Success(client);

            var authOutcome = await OnAuthorizeClientAsync(options, cancellationToken);
            if (!authOutcome)
            {
                var exception = new HttpException(
                    HttpStatusCode.Unauthorized, 
                    "Failed to authenticate an HTTP client", 
                    authOutcome.Exception);
                Logger.Error(exception, messageId: getMessageId(false));
                return Outcome<HttpClient>.Fail(exception);
            }

            var token = authOutcome.Value;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token!.Identity);
            return Outcome<HttpClient>.Success(client);
        }
        
        /// <summary>
        ///   Called internally to authorize this service as a client.
        /// </summary>
        /// <param name="options">
        ///   Options, describing the client. 
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Allows cancelling the operation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected abstract Task<Outcome<ActorToken>> OnAuthorizeClientAsync(
            HttpClientOptions options,
            CancellationToken? cancellationToken = null);

        public TetraPakHttpClientProvider(
            IHttpContextAccessor httpContextAccessor,
            TetraPakConfig tetraPakConfig,
            Func<HttpClientOptions,HttpClient>? singletonClientFactory = null, 
            HttpClientOptions? singletonClientOptions = null)
        {
            TetraPakConfig = tetraPakConfig ?? throw new ArgumentNullException(nameof(tetraPakConfig));
            _singletonClientFactory = singletonClientFactory ?? (_ => new SingletonHttpClient());
            HttpContextAccessor = httpContextAccessor;
            _singletonClientOptions = singletonClientOptions;
        }
    }
    
    public class SingletonHttpClient : HttpClient
    {
        protected override void Dispose(bool disposing)
        {
            // ignore disposing
        }
    }
}