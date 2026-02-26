using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class GetStatusOfZipExtractResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public GetStatusOfZipExtractData Data { get; set; } = default!;
    }
}
