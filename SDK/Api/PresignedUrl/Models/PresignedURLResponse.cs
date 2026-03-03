using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class PresignedURLResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public PresignedUrlData Data { get; set; } = default!;
    }
}
