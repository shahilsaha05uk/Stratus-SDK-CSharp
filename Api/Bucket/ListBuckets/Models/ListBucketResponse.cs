using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class ListBucketResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public List<ListBucketItem>? Data { get; init; }
    }
}
