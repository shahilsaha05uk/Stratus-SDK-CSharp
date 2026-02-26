using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class GetObjectResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public GetObjectResponseData Data { get; init; } = default!;
    }
}