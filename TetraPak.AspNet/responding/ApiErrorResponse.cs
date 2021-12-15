using System;
using System.Net;
using System.Text.Json.Serialization;
using TetraPak.DynamicEntities;
using TetraPak.Serialization;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Represents a standard Tetra Pak API error response (body). 
    /// </summary>
    [Serializable, JsonConverter(typeof(DynamicEntityJsonConverter<ApiErrorResponse>))]
    public class ApiErrorResponse : DynamicEntity
    {
        /// <summary>
        ///   Gets the response HTTP status code as <see cref="int"/>.
        /// </summary>
        [JsonIgnore]
        public int StatusCode => parseHttpStatusCode();
        
        /// <summary>
        ///   Gets the error response title element.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title 
        {
            get => Get<string>()!;
            set => Set(value);
        }

        /// <summary>
        ///   Gets the error response description.
        /// </summary>
        [JsonPropertyName("description")]
        public object? Description
        {
            get => Get<object>();
            set => Set(value);
        }

        /// <summary>
        ///   Gets any message id associated with the failed request.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string? MessageId
        {
            get => Get<string>();
            set => Set(value);
        }

        /// <summary>
        ///   Gets the standardized error type.
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type
        {
            get => Get<string>();
            set => Set(value);
        }

        /// <summary>
        ///   Gets the error status element.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status
        {
            get => Get<string>();
            set => Set(value);
        }

        int parseHttpStatusCode()
        {
            if (int.TryParse(Status, out var code))
                return code;

            if (Enum.TryParse<HttpStatusCode>(Status, out var httpStatusCode))
                return (int)httpStatusCode;

            return (int) HttpStatusCode.InternalServerError;
        }

        /// <summary>
        ///   Initializes the <see cref="ApiErrorResponse"/>.
        /// </summary>
        /// <param name="title">
        ///   Initializes the <see cref="Title"/> property.
        /// </param>
        /// <param name="messageId">
        ///   Initializes the <see cref="MessageId"/> property.
        /// </param>
        public ApiErrorResponse(string title, string? messageId)
        {
            Title = string.IsNullOrEmpty(title) ? throw new ArgumentNullException(nameof(title)) : title;
            if (messageId is { })
            {
                MessageId = messageId;
            }
        }
        
        /// <summary>
        ///   Initializes the <see cref="ApiErrorResponse"/>.
        /// </summary>
        /// <param name="title">
        ///   Initializes the <see cref="Title"/> property.
        /// </param>
        /// <param name="description">
        ///   Initializes the <see cref="Description"/> property.
        /// </param>
        /// <param name="messageId">
        ///   Initializes the <see cref="MessageId"/> property.
        /// </param>
        public ApiErrorResponse(string title, object? description, string? messageId)
        {
            Title = string.IsNullOrEmpty(title) ? throw new ArgumentNullException(nameof(title)) : title;
            Description = description;
            if (messageId is { })
            {
                MessageId = messageId;
            }
        }
    }
}