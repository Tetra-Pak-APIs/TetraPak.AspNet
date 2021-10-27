using System.Text.Json.Serialization;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Used as the meta data block in <see cref="ApiDataResponse{T}"/>. 
    /// </summary>
    public class ApiMetadata
    {
        /// <summary>
        ///   The totally number of items available to query
        ///   (actual data returned is often only a part of available data). 
        /// </summary>
        [JsonPropertyName("total")]
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public int Total { get; set; }

        /// <summary>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Global

        /// <summary>
        ///   Fluent API to assign the <see cref="MessageId"/> property. 
        /// </summary>
        /// <param name="messageId">
        ///   The message id value.
        /// </param>
        /// <returns>
        ///   <c>this</c> object.
        /// </returns>
        public ApiMetadata WithMessageId(string messageId)
        {
            MessageId = messageId;
            return this;
        }
        
        /// <summary>
        ///   Initializes an empty <see cref="ApiMetadata"/> object. 
        /// </summary>
        public ApiMetadata()
        {
        }

        /// <summary>
        ///   Initializes a <see cref="ApiMetadata"/> object and sets the <see cref="Total"/> value.
        /// </summary>
        public ApiMetadata(int total)
        {
            Total = total;
        }
    }
}