using System.Text.Json.Serialization;

namespace TetraPak.AspNet
{
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