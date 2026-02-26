using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class ListAllObjectResponseDataContent
    {
        [JsonPropertyName(JsonKeys.KeyType)]
        public string KeyType { get; init; } = default!;

        [JsonPropertyName(JsonKeys.Key)]
        public string Key { get; init; } = default!;

        [JsonPropertyName(JsonKeys.VersionId)]
        public string? VersionId { get; init; }

        [JsonPropertyName(JsonKeys.Size)]
        public int Size { get; init; }

        [JsonPropertyName(JsonKeys.ContentType)]
        public string? ContentType { get; init; }

        [JsonPropertyName(JsonKeys.ETag)]
        public string? ETag { get; init; }

        [JsonPropertyName(JsonKeys.LastModified)]
        public string LastModified { get; init; } = default!;
    }
}