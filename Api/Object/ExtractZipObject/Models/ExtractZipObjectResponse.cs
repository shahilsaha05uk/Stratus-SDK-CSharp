using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class ExtractZipObjectResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public ExtractZipObjectResponseData Data { get; init; } = default!;
    }
}
