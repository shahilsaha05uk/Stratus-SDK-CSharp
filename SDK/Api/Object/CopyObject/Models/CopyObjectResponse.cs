using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class CopyObjectResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public CopyObjectDataResponse Data { get; init; } = default!;
    }
}
