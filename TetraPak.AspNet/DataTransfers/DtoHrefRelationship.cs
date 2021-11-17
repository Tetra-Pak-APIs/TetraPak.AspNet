using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace TetraPak.AspNet.DataTransfers
{
    /// <summary>
    ///   Reflects a category of related resources, represented as URLs.
    /// </summary>
    public class DtoHrefRelationship : DtoRelationshipBase
    {
        /// <summary>
        ///   Gets or sets one or more related resource locators. 
        /// </summary>
        [JsonPropertyName("href"), Newtonsoft.Json.JsonProperty("href")]
        public IEnumerable<DtoRelationshipLocator> Href
        {
            get => Get<IEnumerable<DtoRelationshipLocator>>();
            set
            {
                foreach (var loc in value)
                {
                    loc.Parent = this;
                }
                Set(value);
            }
        }

        /// <summary>
        ///   Initializes the <see cref="DtoHrefRelationship"/>.
        /// </summary>
        /// <param name="type">
        ///   Initializes the relationship <see cref="DtoRelationshipBase.Rel"/>.
        /// </param>
        /// <param name="href">
        ///   Initializes the <see cref="Href"/>.
        /// </param>
        /// <param name="verbs">
        ///   (optional)<br/>
        ///   One or more HTTP methods supported by all <paramref name="href"/>.
        /// </param>
        public DtoHrefRelationship(
            string type, 
            IEnumerable<DtoRelationshipLocator> href, 
            params HttpMethod[] verbs)
            : base(type, verbs)
        {
            Href = href;
        }

        /// <summary>
        ///   Initializes the <see cref="DtoHrefRelationship"/>.
        /// </summary>
        /// <param name="type">
        ///   Initializes the relationship <see cref="DtoRelationshipBase.Rel"/>.
        /// </param>
        /// <param name="locators">
        ///   Initializes the <see cref="Href"/>.
        /// </param>
        public DtoHrefRelationship(
            string type, 
            params DtoRelationshipLocator[] locators)
            : this(type, locators, Array.Empty<HttpMethod>())
        {
        }
    }
}