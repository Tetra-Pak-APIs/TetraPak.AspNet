using System.Text.Json.Serialization;
using demo.Acme.Models;

namespace demo.Acme.DTO
{
    public class AssetDTO : DataTransferObject
    {
        public string? Description
        {
            get => Get<string?>();
            set => Set(value);
        }
        
        public string? Url 
        {
            get => Get<string?>();
            set => Set(value);
        }

        public string? MimeType
        {
            get => Get<string?>();
            set => Set(value);
        }

        [JsonConstructor]
        public AssetDTO()
        {
        }

        public AssetDTO(Asset asset)
        {
            Description = asset.Description;
            Url = asset.Url;
            MimeType = asset.MimeType;
        }
    }
}