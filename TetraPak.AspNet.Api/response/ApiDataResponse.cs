using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TetraPak.AspNet.Api
{
    public class ApiDataResponse<T>
    {
        [JsonPropertyName("meta")]
        public ApiMetadata Metadata { get; set; }

        [JsonPropertyName("data")]
        public IEnumerable<T> Data { get; set; }

        public ApiDataResponse()
        {
        }

        public ApiDataResponse(IEnumerable<T> data, int skip = -1, int total = -1)
        {
            var dataArray = data?.ToArray() ?? Array.Empty<T>();
            var count = dataArray.Length;
            skip = skip < 0 ? 0 : skip;
            total = total < 0 ? count : total;
            Metadata = new ApiMetadata(count, skip, total);
            Data = dataArray;
        }
    }

    public class ApiMetadata
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("skip")]
        public int Skip { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        public ApiMetadata()
        {
        }
        
        public ApiMetadata(int count, int skip, int total)
        {
            Count = count;
            Skip = skip;
            Total = total;
        }
    }
}