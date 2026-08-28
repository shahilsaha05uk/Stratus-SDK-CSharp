using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Api.Object.GetAllObjectVersions.Models;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Object.GetAllObjectVersions.Models
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
