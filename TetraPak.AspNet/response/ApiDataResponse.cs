using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Represents a standardized Tetra Pak API data response.
    /// </summary>
    /// <typeparam name="T">
    ///   The <see cref="Type"/> of data included in response <see cref="Data"/> block.
    /// </typeparam>
    public class ApiDataResponse<T>
    {
        /// <summary>
        ///   The response meta data block. 
        /// </summary>
        [JsonPropertyName("meta")]
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public ApiMetadata Meta { get; set; }

        /// <summary>
        ///   The response data block. 
        /// </summary>
        [JsonPropertyName("data")]
        public IEnumerable<T> Data { get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Global

#if NET5_0_OR_GREATER
        /// <summary>
        ///   Initializes the <see cref="ApiDataResponse{T}"/>. 
        /// </summary>
        /// <param name="data">
        ///   A collection of items to be included in the response data block.
        /// </param>
        /// <param name="skip">
        ///   (optional)<br/>
        ///   Initializes the meta data "count" value (<see cref="ApiChunkedMetadata.Count"/>).
        /// </param>
        /// <param name="total">
        ///   Initialises the meta data "total" value (<see cref="ApiMetadata.Total"/>).
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   Initializes thw <see cref="messageId"/> property.
        /// </param>
        [JsonConstructor]
#endif
        public ApiDataResponse(IEnumerable<T> data, int skip = -1, int total = -1, string messageId = null)
        {
            var dataArray = data?.ToArray() ?? Array.Empty<T>();
            var count = dataArray.Length;
            total = total < 0 ? count : total;
            Meta = skip == -1
                ? new ApiMetadata(total).WithMessageId(messageId)
                : new ApiChunkedMetadata(new ReadChunk(skip, count), total).WithMessageId(messageId);
            Data = dataArray;
        }

        /// <summary>
        ///   Creates and returns an empty <see cref="ApiDataResponse{T}"/> object.
        /// </summary>
        /// <param name="messageId">
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <returns>
        ///   A <see cref="ApiDataResponse{T}"/> object.
        /// </returns>
        public static ApiDataResponse<T> Empty(string messageId = null) => new(messageId);

        /// <summary>
        ///   Initializes the <see cref="ApiDataResponse{T}"/> object from an <see cref="Outcome{T}"/> object. 
        /// </summary>
        /// <param name="outcome">
        ///   The <see cref="Outcome{T}"/> object, carrying the data to be included in response.
        /// </param>
        /// <param name="totalCount">
        ///   (optional)<br/>
        ///   Initializes the <see cref="ApiMetadata.Total"/> value. 
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        public ApiDataResponse(EnumOutcome<T> outcome, int totalCount = -1, string messageId = null)
        {
            var dataArray = outcome.Value;
            var count = outcome.Count;
            totalCount = totalCount < 0 ? count : totalCount;
            if (outcome is ChunkOutcome<T> chunkOutcome)
            {
                Meta = new ApiChunkedMetadata(chunkOutcome.Chunk, totalCount).WithMessageId(messageId);
            }
            else
            {
                Meta = new ApiMetadata(totalCount).WithMessageId(messageId);
            }
            Data = dataArray;
        }

        ApiDataResponse(string messageId)
        {
            Meta = new ApiMetadata { Total = 0, MessageId = messageId };
            Data = new T[0];
        }
    }

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
        [JsonPropertyName("id")]
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
    
    /// <summary>
    ///   Derived from <see cref="ApiMetadata"/> to add "chunked" meta data attributes.
    /// </summary>
    public class ApiChunkedMetadata : ApiMetadata
    {
        /// <summary>
        ///   The number of items in the chunk. 
        /// </summary>
        [JsonPropertyName("count")]
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public int Count { get; set; }

        /// <summary>
        ///   The number of items skipped from the total to produce the chunk
        /// </summary>
        [JsonPropertyName("skip")]
        public int Skip { get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Global

        /// <summary>
        ///   Initializes the <see cref="ApiChunkedMetadata"/> object.
        /// </summary>
        /// <param name="chunk">
        ///   Initializes the <see cref="Count"/> and <see cref="Skip"/> values.
        /// </param>
        /// <param name="total">
        ///   Initializes the <see cref="total"/> value.
        /// </param>
        public ApiChunkedMetadata(ReadChunk chunk, int total = -1)
        {
            Count = chunk.Count;
            Skip = chunk.Skip;
            Total = total < 0 ? chunk.Count : total;
        }
    }
}