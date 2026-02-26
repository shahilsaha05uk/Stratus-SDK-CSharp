using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class ListAllObjectsResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public ListAllObjectsResponseData Data { get; init; } = default!;
    }
}
