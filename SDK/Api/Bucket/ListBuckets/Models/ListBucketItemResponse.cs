using System.Text.Json.Serialization;
using StratusSDK.Api.Bucket.GetBuckets.Models;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Bucket.ListBuckets.Models
{
    public sealed class ListBucketItemResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public BucketItemList Data { get; init; } = default!;
    }
}
