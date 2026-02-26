using System.Text.Json.Serialization;

namespace StratusSDK
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
