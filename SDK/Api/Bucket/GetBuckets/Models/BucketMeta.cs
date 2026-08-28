using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Api.Bucket.GetBuckets.Models;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Bucket.GetBuckets.Models
{
    public sealed class BucketMeta
    {
        [JsonPropertyName(JsonKeys.Versioning)]
        public bool Versioning { get; init; }

        [JsonPropertyName(JsonKeys.Caching)]
        public CachingDetails Caching { get; init; } = default!;

        [JsonPropertyName(JsonKeys.Encryption)]
        public bool Encryption { get; init; }

        [JsonPropertyName(JsonKeys.AuditConsent)]
        public bool AuditConsent { get; init; }
    }
}
