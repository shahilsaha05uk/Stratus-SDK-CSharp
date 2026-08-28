using System.Text.Json.Serialization;
using StratusSDK.Api.GetStatusOfZipExtract.Models;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.GetStatusOfZipExtract.Models
{
    public sealed class GetStatusOfZipExtractResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public GetStatusOfZipExtractData Data { get; set; } = default!;
    }
}
