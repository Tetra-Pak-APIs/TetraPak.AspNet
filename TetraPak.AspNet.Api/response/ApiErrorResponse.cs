using System;
using System.Text.Json.Serialization;
using TetraPak.DynamicEntities;
using TetraPak.Serialization;

namespace TetraPak.AspNet.Api
{
    // [Serializable, JsonConverter(typeof(DynamicEntityJsonConverter<ApiErrorResponse>))]
    public class ApiErrorResponse  //: DynamicEntity
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        // {
        //     get => Get<string>("title");
        //     set => Set("title", value);
        // }

        [JsonPropertyName("description")]
        public string Description { get; set; }
        // {
        //     get => Get<string>("description");
        //     set => Set("description", value);
        // }

        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }
        // {
        //     get => Get<string>("messageId");
        //     set => Set("messageId", value);
        // }

        [JsonPropertyName("type")]
        public string Type { get; set; }
        // {
        //     get => Get<string>("type");
        //     set => Set("type", value);
        // }

        public ApiErrorResponse(string title)
        {
            Title = title;
        }
    }
}