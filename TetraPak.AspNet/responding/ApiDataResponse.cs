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
    public class ApiDataResponse<T> : IApiDataResponse
    {
        internal const string MetaKey = "meta";
        
        internal const string DataKey = "data";
        
        /// <summary>
        ///   The response meta data block. 
        /// </summary>
        [JsonPropertyName(MetaKey)]
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public ApiMetadata Meta { get; set; }

        /// <summary>
        ///   The response data block. 
        /// </summary>
        [JsonPropertyName(DataKey)]
        public IEnumerable<T> Data { get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Global

        /// <summary>
        ///   Returns all data items as an array of <see cref="object"/>. 
        /// </summary>
        public object[] GetDataAsObjectArray() => Data?.Cast<object>().ToArray();

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
            var dataArray = outcome.Value ?? Array.Empty<T>();
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
}