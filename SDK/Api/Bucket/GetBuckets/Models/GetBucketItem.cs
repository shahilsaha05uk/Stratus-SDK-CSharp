using System.Text.Json.Serialization;
using StratusSDK.Api.Bucket.GetBuckets.Models;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Bucket.GetBuckets.Models
{
    public sealed class GetBucketItem : BucketBase
    {
        [JsonPropertyName(JsonKeys.ObjectsCount)]
        public int ObjectsCount { get; init; }

        [JsonPropertyName(JsonKeys.SizeInBytes)]
        public long SizeInBytes { get; init; }
    }
}
