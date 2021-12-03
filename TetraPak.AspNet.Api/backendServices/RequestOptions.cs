using System.Threading;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Can be used to control the behavior of a request. 
    /// </summary>
    public class RequestOptions
    {
        CancellationToken? _cancellationToken = CancellationToken.None;
        
        /// <summary>
        ///   (default=<see cref="RequestDistribution.Sequential"/>)<br/>
        ///   Gets or sets a value to control how a multi-request process is distributed. 
        /// </summary>
        /// <remarks>
        ///   This value affects the distribution in a situation where multiple requests are made (such
        ///   as calling <see cref="ServiceEndpointExtensions.GetAsync{T}(TetraPak.AspNet.Api.ServiceEndpoint,System.Collections.Generic.IEnumerable{string}?,TetraPak.AspNet.HttpQuery?,TetraPak.AspNet.Api.RequestOptions?,TetraPak.AspNet.HttpClientOptions?)"/>
        ///   passing a collection of keys). When set to <see cref="RequestDistribution.Sequential"/> 
        ///   all requests are made in sequence, on the same thread. Set to <see cref="RequestDistribution.Parallel"/>
        ///   to allow the process to be made in parallel, distributed over multiple worker threads.
        /// </remarks>
        public RequestDistribution Distribution { get; set; } = RequestDistribution.Sequential;

        /// <summary>
        ///   (default=<c>false</c>)<br/>
        ///   Gets or sets a value that specifies whether all requests should be cancelled if one request fails.
        /// </summary>
        /// <remarks>
        ///   This value affects how a process where multiple requests are made, such as requesting multiple
        ///   resources using a collection of resource keys. When set and one or more requests fails in a process,
        ///   the process should be cancelled and return a 'failed' overall result. Set to false
        ///   to allow the overall request process to continue.
        /// </remarks>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public bool IsFailureTolerant { get; set; }

        /// <summary>
        ///   (default=<see cref="System.Threading.CancellationToken.None"/>)<br/>
        ///   Gets or sets a cancellation token to be honored by the affected request.
        /// </summary>
        public CancellationToken CancellationToken
        {
            get => _cancellationToken ?? CancellationToken.None;
            set => _cancellationToken = value;
        }

        /// <summary>
        ///   (fluent API)<br/>
        ///   Sets the <see cref="CancellationToken"/> property and returns <c>this</c>.
        /// </summary>
        public RequestOptions WithCancellation(CancellationToken token)
        {
            CancellationToken = token;
            return this;
        }

        /// <summary>
        ///   (fluent API)<br/>
        ///   Sets the <see cref="Distribution"/> property and returns <c>this</c>.
        /// </summary>
        public RequestOptions WithDistribution(RequestDistribution value)
        {
            Distribution = value;
            return this;
        }

        /// <summary>
        ///   Gets a default configuration (see individual properties for default values).
        /// </summary>
        public static RequestOptions Default => new();
    }
}