using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Api.Object.GetObject.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.GetObject.Models
{
    public sealed class GetObjectResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public GetObjectResponseData Data { get; init; } = default!;
    }
}