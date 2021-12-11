using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

#nullable enable

namespace TetraPak.AspNet.Debugging
{
    /// <summary>
    ///   Used when request bodies gets dumped to the logger (at log level <see cref="LogLevel.Trace"/>).
    /// </summary>
    public class TraceRequestOptions
    {
        internal const int DefaultBuffersSize = 1024;
        const int DefaultMaxSizeFactor = 4;

        /// <summary>
        ///   The default value for <see cref="ForceTraceBody"/>.
        /// </summary>
        public static bool DefaultForceTraceBody { get; set; } = false;

        int _bufferSize;
        long _maxSize;

        /// <summary>
        ///   (optional)<br/>
        ///   Gets or sets a request initiator (eg. "actor").
        /// </summary>
        /// <seealso cref="WithInitiator(string,HttpDirection?)"/>
        /// <seealso cref="WithInitiator(object,HttpDirection?)"/>
        public string? Initiator { get; set; }

        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="Direction"/> property and returns <c>this</c>.
        /// </summary>
        /// <param name="value">
        ///   The <see cref="Initiator"/> value.
        /// </param>
        /// <param name="direction">
        ///   (optional)<br/>
        ///   Assign this value to also invoke <see cref="WithDirection(HttpDirection,string?)"/>.
        /// </param>
        /// <seealso cref="Initiator"/>
        /// <seealso cref="WithDirection(HttpDirection,string?)"/>
        /// <seealso cref="WithDirection(HttpDirection,object?)"/>
        public TraceRequestOptions WithInitiator(string value, HttpDirection? direction)
        {
            Initiator = value;
            return direction is { } ? WithDirection(direction.Value, (object) null!) : this;
        }

        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="Direction"/> property and returns <c>this</c>.
        /// </summary>
        /// <param name="initiator">
        ///   The <see cref="Initiator"/> value.
        /// </param>
        /// <param name="direction">
        ///   (optional)<br/>
        ///   Assign this value to also invoke <see cref="WithDirection(HttpDirection,object?)"/>.
        /// </param>
        /// <seealso cref="Initiator"/>
        /// <seealso cref="WithDirection(HttpDirection,string?)"/>
        /// <seealso cref="WithDirection(HttpDirection,object?)"/>
        public TraceRequestOptions WithInitiator(object initiator, HttpDirection? direction)
            =>
            WithInitiator(initiator.ToString() ?? initiator.GetType().ToString(), direction);
        
        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="Direction"/> property and returns <c>this</c>.
        /// </summary>
        /// <param name="initiator">
        ///   The <see cref="Initiator"/> value.
        /// </param>
        /// <seealso cref="Initiator"/>
        /// <seealso cref="WithDirection(HttpDirection,string?)"/>
        /// <seealso cref="WithDirection(HttpDirection,object?)"/>
        public TraceRequestOptions WithInitiator(object initiator)
            =>
                WithInitiator(initiator.ToString() ?? initiator.GetType().ToString(), null);

        /// <summary>
        ///   (optional; default=<see cref="HttpDirection.Unknown"/>)<br/>
        ///   Gets or sets 
        /// </summary>
        /// <seealso cref="WithDirection(HttpDirection,string?)"/>
        /// <seealso cref="WithDirection(HttpDirection,object?)"/>
        public HttpDirection Direction { get; set; } = HttpDirection.Unknown;

        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="Direction"/> property and returns <c>this</c>.
        /// </summary>
        /// <param name="value">
        ///   The <see cref="HttpDirection"/> value.
        /// </param>
        /// <param name="initiator">
        ///   (optional)<br/>
        ///   Assign this value to also invoke <see cref="WithInitiator(string,HttpDirection?)"/>.
        /// </param>
        /// <seealso cref="Direction"/>
        /// <seealso cref="WithInitiator(string,HttpDirection?)"/>
        /// <seealso cref="WithInitiator(object,HttpDirection?)"/>
        public TraceRequestOptions WithDirection(HttpDirection value, string? initiator)
        {
            Direction = value;
            return string.IsNullOrEmpty(initiator) ? this : WithInitiator(initiator);
        }

        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="Direction"/> property and returns <c>this</c>.
        /// </summary>
        /// <param name="value">
        ///   The <see cref="HttpDirection"/> value.
        /// </param>
        /// <param name="initiator">
        ///   (optional)<br/>
        ///   Assign this value to also invoke <see cref="WithInitiator(object,HttpDirection?)"/>.
        /// </param>
        /// <seealso cref="Direction"/>
        /// <seealso cref="WithInitiator(string,HttpDirection?)"/>
        /// <seealso cref="WithInitiator(object,HttpDirection?)"/>
        public TraceRequestOptions WithDirection(HttpDirection value, object? initiator)
            =>
            WithDirection(value, initiator?.ToString() ?? initiator?.GetType().ToString());
        
        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="Direction"/> property and returns <c>this</c>.
        /// </summary>
        /// <param name="value">
        ///   The <see cref="HttpDirection"/> value.
        /// </param>
        /// <seealso cref="Direction"/>
        /// <seealso cref="WithInitiator(string,HttpDirection?)"/>
        /// <seealso cref="WithInitiator(object,HttpDirection?)"/>
        public TraceRequestOptions WithDirection(HttpDirection value)
            =>
                WithDirection(value, null);

        /// <summary>
        ///   Gets or sets a <see cref="string"/> to be used as a "detail" in textual representations of the traffic.
        /// </summary>
        /// <seealso cref="WithDetail"/>
        public string? Detail { get; set; }

        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="Detail"/> property and returns <c>this</c>.
        /// </summary>
        /// <seealso cref="Detail"/>
        public TraceRequestOptions WithDetail(string value)
        {
            Detail = value;
            return this;
        }

        /// <summary>
        ///   (static property)<br/>
        ///   Gets or sets a default value used for the <see cref="ContentLengthAsyncThreshold"/>
        ///   property's initial value.
        /// </summary>
        public static uint DefaultContentLengthAsyncThreshold { get; set; } = 1024;
        
        /// <summary>
        ///   Gets default <see cref="TraceRequestOptions"/>
        /// </summary>
        public static TraceRequestOptions Default(string? messageId) => new(messageId);
        
        /// <summary>
        ///   A base address used for the traced request message. This should be passed if
        ///   the request message's URI (<see cref="HttpRequestMessage.RequestUri"/>) is a relative path.
        ///   If <c>null</c> the request message's URI is expected to be an absolute URI (which may throw an
        ///   exception).
        /// </summary>
        public Uri? BaseAddress { get; set; }
        
        /// <summary>
        ///   Gets or sets a collection of default request headers to be passed, unless overridden
        ///   by <see cref="HttpRequestMessage.Headers"/>.
        /// </summary>
        public HttpRequestHeaders DefaultHeaders { get; set; }

        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="BaseAddress"/> property and returns <c>this</c>.
        /// </summary>
        public TraceRequestOptions WithBaseAddress(Uri baseAddress)
        {
            BaseAddress = baseAddress;
            return this;
        }

        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="DefaultHeaders"/> property and returns <c>this</c>.
        /// </summary>
        public TraceRequestOptions WithDefaultHeaders(HttpRequestHeaders headers)
        {
            DefaultHeaders = headers;
            return this;
        }

        /// <summary>
        ///   Assign this to construct custom body content (default = <c>null</c>).
        /// </summary>
        /// <seealso cref="WithAsyncBodyFactory"/>
        public Func<Task<string>>? AsyncBodyFactory { get; set; }

        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="AsyncBodyFactory"/> property and returns <c>this</c>.
        /// </summary>
        public TraceRequestOptions WithAsyncBodyFactory(Func<Task<string>>? factory)
        {
            AsyncBodyFactory = factory;
            return this;
        }
        
        /// <summary>
        ///   Gets or sets a unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </summary>
        public string? MessageId { get; set; }
        
        /// <summary>
        ///   A callback handler, invoked after the request message has been serialized to
        ///   a <see cref="string"/> but before the result is propagated to the logger provider.
        ///   Use this to decorate the result with custom content.
        /// </summary>
        /// <seealso cref="WithDecorator"/>
        internal Func<StringBuilder, Task<StringBuilder>>? AsyncDecorationHandler { get; set; }

        /// <summary>
        ///   (fluent API)<br/>
        ///   Assigns the <see cref="AsyncDecorationHandler"/> decorator and returns <c>this</c>.
        /// </summary>
        public TraceRequestOptions WithDecorator(Func<StringBuilder, Task<StringBuilder>> decorator)
        {
            AsyncDecorationHandler = decorator;
            return this;
        }

        /// <summary>
        ///   (default=<see cref="DefaultForceTraceBody"/>)<br/>
        ///   Gets or sets a value that forces the tracing of the request/response body
        /// </summary>
        public bool ForceTraceBody { get; set; } = DefaultForceTraceBody;

        /// <summary>
        ///   The buffer size. Set for reading large bodies.
        ///   Please note that the setter enforces minimum value 128. 
        /// </summary>
        public int BufferSize
        {
            get => _bufferSize;
            set => _bufferSize = AdjustBufferSize(value);
        }

        /// <summary>
        ///   A maximum length. Set this value to truncate when tracing very large bodies such as media or binaries.
        /// </summary>
        /// <remarks>
        ///   This value should be a equally divisible by <see cref="BufferSize"/> for efficiency.
        ///   The setter automatically rounds (<c>value</c> / <see cref="BufferSize"/>)
        ///   and multiplies with <see cref="BufferSize"/>.
        /// </remarks>
        public long MaxSize
        {
            get => _maxSize;
            set => _maxSize = AdjustMaxSize(value, _bufferSize);
        }

        /// <summary>
        ///   Gets or sets a value that is used when tracing large requests. Requests that exceeds this value
        ///   in content length will automatically be traced in a background thread to reduce the performance hit.
        /// </summary>
        public uint ContentLengthAsyncThreshold { get; set; } = DefaultContentLengthAsyncThreshold;

        internal static int AdjustBufferSize(int value) => Math.Max(128, value);

        internal static long AdjustMaxSize(long value, int bufferSize) => (long)Math.Round((decimal)value / bufferSize) * bufferSize;

        /// <summary>
        ///   Initializes the <see cref="TraceRequestOptions"/> with default values.  
        /// </summary>
        public TraceRequestOptions(string? messageId = null)
        {
            _bufferSize = DefaultBuffersSize;
            _maxSize = _bufferSize * DefaultMaxSizeFactor;
            MessageId = messageId;
        }
    }
}