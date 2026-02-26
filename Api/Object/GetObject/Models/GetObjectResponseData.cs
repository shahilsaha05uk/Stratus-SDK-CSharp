using System.Text.Json.Serialization;

namespace StratusSDK
{
    public class GetObjectResponseData
    {
        [JsonPropertyName(JsonKeys.Key)]
        public string Key { get; init; } = default!;

        [JsonPropertyName(JsonKeys.Size)]
        public int Size { get; init; }

        [JsonPropertyName(JsonKeys.LastModified)]
        public string LastModified { get; init; } = default!;

        [JsonPropertyName(JsonKeys.Metadata)]
        public Dictionary<string, string> Metadata { get; init; } = default!;

        [JsonPropertyName(JsonKeys.ContentType)]
        public string? ContentType { get; init; } = default!;

        [JsonPropertyName(JsonKeys.ObjectUrl)]
        public string ObjectUrl { get; init; } = default!;
    }
}