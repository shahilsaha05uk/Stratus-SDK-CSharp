using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class CreateBucketSignatureResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public CreateBucketSignatureData Data { get; set; } = default!;
    }
}
