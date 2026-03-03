using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class PutObjectMetadataRequestBody
    {
        [JsonPropertyName(JsonKeys.Metadata)]
        public Dictionary<string, string> Metadata { get; set; } = default!;
    }
}
