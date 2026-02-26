using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class GetAllObjectVersionsDataResponse
    {
        [JsonPropertyName(JsonKeys.Truncated)]
        public bool Truncated { get; init; }

        [JsonPropertyName(JsonKeys.Key)]
        public string Key { get; init; } = default!;

        [JsonPropertyName(JsonKeys.VersionsCount)]
        public int VersionsCount { get; init; }

        [JsonPropertyName(JsonKeys.MaxVersions)]
        public int MaxVersions { get; init; }

        [JsonPropertyName(JsonKeys.IsTruncated)]
        public bool IsTruncated { get; init; }

        [JsonPropertyName(JsonKeys.NextContinuationToken)]
        public string? NextContinuationToken { get; init; }

        [JsonPropertyName(JsonKeys.Version)]
        public IReadOnlyList<ObjectVersion> Versions { get; init; }
            = [];
    }
}
