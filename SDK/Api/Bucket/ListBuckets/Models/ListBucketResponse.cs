using System.Text.Json.Serialization;
using StratusSDK.Api.Bucket.ListBuckets.Models;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Bucket.ListBuckets.Models
{
    public sealed class ListBucketResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public List<ListBucketItem>? Data { get; init; }
    }
}
