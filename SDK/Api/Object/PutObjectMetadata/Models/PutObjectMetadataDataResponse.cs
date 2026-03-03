using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class PutObjectMetadataDataResponse
    {
        [JsonPropertyName(JsonKeys.Message)]
        public string Message { get; init; } = default!;
    }
}
