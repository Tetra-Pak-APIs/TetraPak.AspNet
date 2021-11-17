using System;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using TetraPak.DynamicEntities;

#nullable enable

namespace TetraPak.AspNet.DataTransfers
{
    /// <summary>
    ///   (abstract class)<br/>
    ///   Represents a category of related resources.
    /// </summary>
    [DebuggerDisplay("{Rel}")]
    public abstract class DtoRelationshipBase : DynamicEntity
    {
        /// <summary>
        ///   Describes the relationship. 
        /// </summary>
        [JsonPropertyName("rel"), Newtonsoft.Json.JsonProperty("rel")]
        public string Rel
        {
            get => Get<string>();
            set => Set(value);
        }
        
        /// <summary>
        ///   Gets or sets one or more HTTP verbs supported by the relationship(s).
        /// </summary>
        [JsonPropertyName("verbs")]
        public string[]? Verbs
        {
            get => Get<string[]>();
            set => Set(value);
        }

        /// <summary>
        ///  Initializes an empty <see cref="DtoRelationshipBase"/>
        ///  (intended for serialization).
        /// </summary>
#if NET5_0_OR_GREATER 
        [JsonConstructor]
#endif
        public DtoRelationshipBase()
        {
        }
        
        /// <summary>
        ///   Initializes the <see cref="DtoRelationshipBase"/>.
        /// </summary>
        /// <param name="type">
        ///   Initializes the relationship <see cref="Rel"/>.
        /// </param>
        /// <param name="verbs">
        ///   (optional)<br/>
        ///   One or more HTTP methods supported by all related resources.
        /// </param>
        protected DtoRelationshipBase(string type, params HttpMethod[] verbs)
        {
            Rel = type.Trim();
            Verbs = verbs.Any() ? verbs.ToStringVerbs() : null;
        }
        
        /// <summary>
        ///   Initializes the <see cref="DtoRelationshipBase"/>.
        /// </summary>
        /// <param name="type">
        ///   Initializes the relationship <see cref="Rel"/>.
        /// </param>
        protected DtoRelationshipBase(string type)
        : this(type, Array.Empty<HttpMethod>())
        {
        }
    }
}