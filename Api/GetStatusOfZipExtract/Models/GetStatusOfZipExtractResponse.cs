using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class GetStatusOfZipExtractResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public GetStatusOfZipExtractData Data { get; set; } = default!;
    }
}
