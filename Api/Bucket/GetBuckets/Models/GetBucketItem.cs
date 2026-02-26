using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class GetBucketItem : BucketBase
    {
        [JsonPropertyName(JsonKeys.ObjectsCount)]
        public int ObjectsCount { get; init; }

        [JsonPropertyName(JsonKeys.SizeInBytes)]
        public long SizeInBytes { get; init; }
    }
}
