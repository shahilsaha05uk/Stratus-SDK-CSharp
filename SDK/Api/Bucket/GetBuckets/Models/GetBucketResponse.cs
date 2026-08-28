using System.Text.Json.Serialization;
using StratusSDK.Api.Bucket.GetBuckets.Models;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Bucket.GetBuckets.Models
{
    public sealed class GetBucketResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public List<GetBucketItem> Data { get; init; } = [];
    }
}
