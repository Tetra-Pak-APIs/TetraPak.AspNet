using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TetraPak.AspNet.Api
{
    public class ApiDataResponse<T>
    {
        // ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
        // ReSharper disable MemberCanBePrivate.Global
        [JsonPropertyName("meta")]
        public ApiMetadata Metadata { get; set; }

        [JsonPropertyName("data")]
        public IEnumerable<T> Data { get; set; }
        // ReSharper restore AutoPropertyCanBeMadeGetOnly.Global
        // ReSharper restore MemberCanBePrivate.Global

#if NET5_0_OR_GREATER
        [JsonConstructor]
#endif
        public ApiDataResponse(IEnumerable<T> data, int skip = -1, int total = -1)
        {
            var dataArray = data?.ToArray() ?? Array.Empty<T>();
            var count = dataArray.Length;
            total = total < 0 ? count : total;
            Metadata = skip == -1
                ? new ApiMetadata(total) 
                : new ApiChunkedMetadata(new ReadChunk(skip, count), total);
            Data = dataArray;
        }

        public static ApiDataResponse<T> Empty(string messageId = null) => new(messageId);

        public ApiDataResponse(EnumOutcome<T> outcome, int totalCount = -1)
        {
            var dataArray = outcome.Value;
            var count = outcome.Count;
            totalCount = totalCount < 0 ? count : totalCount;
            if (outcome is ChunkOutcome<T> chunkOutcome)
            {
                Metadata = new ApiChunkedMetadata(chunkOutcome.Chunk, totalCount);
            }
            else
            {
                Metadata = new ApiMetadata(totalCount);
            }
            Data = dataArray;
        }

        ApiDataResponse(string messageId)
        {
            Metadata = new ApiMetadata { Total = 0, MessageId = messageId };
            Data = new T[0];
        }
    }

    public class ApiMetadata
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        public ApiMetadata()
        {
        }
        
        public ApiMetadata(int total)
        {
            Total = total;
        }
    }
    
    public class ApiChunkedMetadata : ApiMetadata
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("skip")]
        public int Skip { get; set; }

        public ApiChunkedMetadata(ReadChunk chunk, int total = -1)
        {
            Count = chunk.Count;
            Skip = chunk.Skip;
            Total = total < 0 ? chunk.Count : total;
        }
    }
}