using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class ListAllObjectsResponseData
    {
        [JsonPropertyName(JsonKeys.KeyCount)]
        public int KeyCount { get; init; }

        [JsonPropertyName(JsonKeys.MaxKeys)]
        public int MaxKeys { get; init; }

        [JsonPropertyName(JsonKeys.Truncated)]
        public bool Truncated { get; init; }

        [JsonPropertyName(JsonKeys.NextContinuationToken)]
        public string? NextContinuationToken { get; init; }

        [JsonPropertyName(JsonKeys.Contents)]
        public List<ListAllObjectResponseDataContent> Contents { get; init; } = [];
    }
}
