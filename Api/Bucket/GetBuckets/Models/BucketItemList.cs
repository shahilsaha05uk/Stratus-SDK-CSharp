using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class BucketItemList
    {
        [JsonPropertyName(JsonKeys.KeyCount)]
        public int KeyCount { get; init; }

        [JsonPropertyName(JsonKeys.MaxKeys)]
        public int MaxKeys { get; init; }

        [JsonPropertyName(JsonKeys.Truncated)]
        public bool IsTruncated { get; init; }

        [JsonPropertyName(JsonKeys.NextContinuationToken)]
        public string? NextContinuationToken { get; init; }

        [JsonPropertyName(JsonKeys.Contents)]
        public IReadOnlyList<BucketObject> Contents { get; init; }
            = [];
    }
}
