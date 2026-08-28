using System.Text.Json.Serialization;
using StratusSDK.Api.Object.CopyObject.Models;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.CopyObject.Models
{
    public sealed class CopyObjectResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public CopyObjectDataResponse Data { get; init; } = default!;
    }
}
