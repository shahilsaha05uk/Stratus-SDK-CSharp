using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class ListBucketItemResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public BucketItemList Data { get; init; } = default!;
    }
}
