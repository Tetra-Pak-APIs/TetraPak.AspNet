// using System;
// using System.Net.Http;
// using System.Threading;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Logging;
//
// namespace tetrapak.api.common.request failed_experiment obsolete
// {
//     /// <summary>
//     ///   A <see cref="IHttpClientProvider"/> that also raises requesting/responded events for all round trips. 
//     /// </summary>
//     public class EventfulHttpClientProvider : HttpClientProvider
//     {
//         readonly EventfulMessageHandler _messageHandler;
//         
//         /// <summary>
//         ///   Raised before every outgoing request.
//         /// </summary>
//         public event EventHandler<HttpRoundtripEventArgs> Requesting;
//
//         /// <summary>
//         ///   Raised for all responses.
//         /// </summary>
//         public event EventHandler<HttpRoundtripEventArgs> Responded;
//
//         protected virtual void OnRequesting(HttpRoundtripEventArgs e) => Requesting?.Invoke(this, e);
//
//         protected virtual void OnResponded(HttpRoundtripEventArgs e) => Responded?.Invoke(this, e);
//
//         internal virtual void DoRequesting(HttpRoundtripEventArgs e) => OnRequesting(e);
//
//         internal virtual void DoResponded(HttpRoundtripEventArgs e) => OnResponded(e);
//         
//         public override Task<HttpClient> GetHttpClientAsync(HttpClientOptions options = null, ILogger logger = null)
//         {
//             return base.GetHttpClientAsync(options ?? new HttpClientOptions {MessageHandler = _messageHandler}, logger);
//         }
//
//         public EventfulHttpClientProvider(
//             Func<HttpClientOptions,HttpClient> singletonClientFactory = null, 
//             HttpClientOptions singletonClientOptions = null) 
//         : base(singletonClientFactory, singletonClientOptions)
//         {
//             _messageHandler = new EventfulMessageHandler(this);
//         }
//     }
//     
//     class EventfulMessageHandler : HttpMessageHandler
//     {
//         readonly EventfulHttpClientProvider _clientProvider;
//
//         protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//         {
//             var e = new HttpRoundtripEventArgs(request);
//             _clientProvider.DoRequesting(e);
//             using var c = new HttpClient();
//             var response = await c.SendAsync(request, cancellationToken);
//             _clientProvider.DoResponded(e.WithResponse(response));
//             return response;
//         }
//
//         public EventfulMessageHandler(EventfulHttpClientProvider clientProvider)
//         {
//             _clientProvider = clientProvider;
//         }
//     }
//
//     /// <summary>
//     ///   Describes a complete request/response round trip.
//     /// </summary>
//     public class HttpRoundtripEventArgs : EventArgs
//     {
//         /// <summary>
//         ///   The outgoing request.
//         /// </summary>
//         public HttpRequestMessage Request { get; }
//
//         /// <summary>
//         ///   The incoming response.
//         /// </summary>
//         public HttpResponseMessage Response { get; private set; }
//
//         internal HttpRoundtripEventArgs WithResponse(HttpResponseMessage response)
//         {
//             Response = response;
//             return this;
//         }
//
//         internal HttpRoundtripEventArgs(HttpRequestMessage request)
//         {
//             Request = request;
//         }
//     }
// }