using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Object.GetAllObjectVersions.Models
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
