using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Api.Bucket.GetBuckets.Models;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Bucket.GetBuckets.Models
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
