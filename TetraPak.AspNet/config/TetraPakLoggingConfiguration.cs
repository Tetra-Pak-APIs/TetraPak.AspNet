using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Debugging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Represents the 
    /// </summary>
    public class TetraPakLoggingConfiguration : ConfigurationSection
    {
        // ReSharper disable NotAccessedField.Local
        int? _traceRequestBodyBufferSize;
        long? _traceRequestBodyMaxSize;
        // ReSharper restore NotAccessedField.Local
        
        /// <summary>
        ///   Gets or sets the default configuration section identifier
        ///   recognized by <see cref="TetraPakLoggingConfiguration"/>.
        /// </summary>
        public static string DefaultSectionIdentifier { get; set; } = "Logging";

        /// <summary>
        ///   The buffer size for tracing request body.
        ///   Please note that the setter enforces minimum value 128. 
        /// </summary>
        public int TraceRequestBodyBufferSize
        {
            get => GetFromFieldThenSection(0);
            set => _traceRequestBodyBufferSize = TraceHttpRequestOptions.AdjustBufferSize(value);
        }

        /// <summary>
        ///   A maximum length. Set this value to truncate when tracing very large bodies such as media or binaries.
        /// </summary>
        /// <remarks>
        ///   This value should be a equally divisible by <see cref="TraceRequestBodyBufferSize"/> for efficiency.
        ///   The setter automatically rounds (<c>value</c> / <see cref="TraceRequestBodyBufferSize"/>)
        ///   and multiplies with <see cref="TraceRequestBodyBufferSize"/>.
        /// </remarks>
        public long TraceBodyMaxSize
        {
            get => GetFromFieldThenSection<long>();
            set => _traceRequestBodyMaxSize = TraceHttpRequestOptions.AdjustMaxSize(value, TraceRequestBodyBufferSize);
        }

        /// <summary>
        ///   Constructs and returns a <see cref="TraceHttpRequestOptions"/> object from the configuration.
        ///   This can be used with the <see cref="WebLoggerHelper"/>'s tracing methods.
        /// </summary>
        /// <param name="tetraPakConfig"></param>
        /// <param name="httpContext"></param>
        /// <returns>
        ///   A <see cref="TraceHttpRequestOptions"/> if <see cref="TraceBodyMaxSize"/> is assigned
        ///   and greater then zero (0); otherwise <c>null</c>.
        /// </returns>
        public TraceHttpRequestOptions? GetTraceBodyOptions(TetraPakConfig tetraPakConfig, HttpContext httpContext) 
            => TraceBodyMaxSize > 0
                ? TraceHttpRequestOptions.Default(httpContext.Request.GetMessageId(tetraPakConfig, true))
                : null;
        
        /// <summary>
        ///   Initializes the code API. 
        /// </summary>
        /// <param name="configuration">
        ///   The <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> object.
        /// </param>
        /// <param name="logger">
        ///   A logger provider.
        /// </param>
        /// <param name="sectionIdentifier">
        ///   (optional; default=<see cref="DefaultSectionIdentifier"/>)<br/>
        ///   Specifies the section identifier for the code API. 
        /// </param>
        public TetraPakLoggingConfiguration(
            IConfiguration configuration,
            ILogger? logger,
            string? sectionIdentifier = null)
        : base(configuration, logger, sectionIdentifier ?? DefaultSectionIdentifier)
        {
        }
    }
}