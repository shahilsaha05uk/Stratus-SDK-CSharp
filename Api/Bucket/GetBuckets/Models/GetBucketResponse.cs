using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class GetBucketResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public List<GetBucketItem> Data { get; init; } = [];
    }
}
