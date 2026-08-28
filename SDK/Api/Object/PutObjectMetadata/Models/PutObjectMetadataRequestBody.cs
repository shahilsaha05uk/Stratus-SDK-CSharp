using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Object.PutObjectMetadata.Models
{
    public sealed class PutObjectMetadataRequestBody
    {
        [JsonPropertyName(JsonKeys.Metadata)]
        public Dictionary<string, string> Metadata { get; set; } = default!;
    }
}
