using System.Globalization;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class BucketObject
    {
        [JsonPropertyName(JsonKeys.KeyType)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EStratusKeyType KeyType { get; init; }

        [JsonPropertyName(JsonKeys.Key)]
        public string Key { get; init; } = default!;

        [JsonPropertyName(JsonKeys.VersionId)]
        public string? VersionId { get; init; }

        [JsonPropertyName(JsonKeys.Size)]
        public long Size { get; init; }

        [JsonPropertyName(JsonKeys.ContentType)]
        public string? ContentType { get; init; }

        [JsonPropertyName(JsonKeys.ETag)]
        public string? ETag { get; init; }

        [JsonPropertyName(JsonKeys.LastModified)]
        public string LastModifiedRaw { get; init; } = default!;

        [JsonIgnore]
        public DateTime LastModified =>
            DateTime.ParseExact(
                LastModifiedRaw,
                "MMM dd, yyyy hh:mm tt",
                CultureInfo.InvariantCulture);

        [JsonIgnore]
        public bool IsFile =>
            KeyType == EStratusKeyType.File;

        [JsonIgnore]
        public bool IsFolder =>
            KeyType == EStratusKeyType.Folder;
    }
}
