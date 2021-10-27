using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using demo.Acme.Models;

namespace demo.Acme.DataTransferring
{
    public class ProductDTO : Product
    {
        [JsonIgnore]
        public override IEnumerable<string> AssetIds { get; set; }

        public IEnumerable<Asset> Assets { get; set; }

        public ProductDTO(string id) : base(id)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            AssetIds = Array.Empty<string>();
        }
    }
}