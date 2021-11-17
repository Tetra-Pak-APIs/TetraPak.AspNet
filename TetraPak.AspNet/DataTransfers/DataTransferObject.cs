using System.Text.Json.Serialization;
using Newtonsoft.Json;
using TetraPak.DynamicEntities;

#nullable enable

namespace TetraPak.AspNet.DataTransfers
{
    /// <summary>
    ///   A basic Data Transfer Object (DTO).
    /// </summary>
    public class DataTransferObject : DynamicEntity
    {
        /// <summary>
        ///   Holds all the DTO relationships. 
        /// </summary>
        [JsonPropertyName("_rel"), JsonProperty("_rel")]
        public DtoRelationshipBase[]? Relationships
        {
            get => Get<DtoRelationshipBase[]?>();
            set => Set(value);
        }
    }
}