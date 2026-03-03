using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class ObjectVersion
    {
        [JsonPropertyName(JsonKeys.Latest)]
        public bool Latest { get; init; }

        [JsonPropertyName(JsonKeys.VersionId)]
        public string VersionId { get; init; } = default!;

        [JsonPropertyName(JsonKeys.IsLatest)]
        public bool IsLatest { get; init; }

        [JsonPropertyName(JsonKeys.LastModified)]
        public string LastModified { get; init; } = default!;

        [JsonPropertyName(JsonKeys.Size)]
        public long Size { get; init; }

        [JsonPropertyName(JsonKeys.ETag)]
        public string? ETag { get; init; }
    }
}
