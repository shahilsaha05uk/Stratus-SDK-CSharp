using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Api.Object.ExtractZipObject.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.ExtractZipObject.Models
{
    public sealed class ExtractZipObjectResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public ExtractZipObjectResponseData Data { get; init; } = default!;
    }
}
