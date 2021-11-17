using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TetraPak.DynamicEntities;

#nullable enable

namespace TetraPak.AspNet.DataTransfers
{
    /// <summary>
    ///   Represents an individual related resource and how to access it.  
    /// </summary>
    public class DtoRelationshipLocator : DynamicEntity
    {
        internal DtoRelationshipBase? Parent { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Uri.EnsurePrefix(FilePath.UnixSeparator)} ({Verbs.ConcatCollection()})";
        }

        /// <summary>
        ///   The locator (URI) used to access the related resource.
        /// </summary>
        [Required, JsonPropertyName("uri")]
        public string Uri
        {
            get => Get<string>(); 
            set => Set(value); 
        }

        /// <summary>
        ///   Gets or sets one or more HTTP methods (verbs) supported by the endpoint (<see cref="Uri"/>).
        ///   This can also be specified by the parent level (<see cref="DtoRelationshipBase.Verbs"/>).
        /// </summary>
        [JsonPropertyName("verbs")]
        public string[]? Verbs
        {
            get
            {
                var value = GetRaw(JsonKey(nameof(Verbs)));
                return value is string[] verbs
                    ? verbs
                    : Parent?.Verbs;
            }
            set => Set(value);
        }

        /// <summary>
        ///   Initializes an empty <see cref="DtoRelationshipLocator"/>. (mainly intended for serialization).
        /// </summary>
#if NET5_0_OR_GREATER 
        [JsonConstructor]
#endif
        public DtoRelationshipLocator()
        {
        }

        /// <summary>
        ///   Initializes the <see cref="DtoRelationshipLocator"/>.
        /// </summary>
        /// <param name="uri">
        ///   Initializes <see cref="Uri"/>.
        /// </param>
        /// <param name="verbs">
        ///   Initializes <see cref="Verbs"/>.
        /// </param>
        public DtoRelationshipLocator(string uri, string[]? verbs)
        {
            Uri = uri;
            Verbs = verbs;
        }
    }
}