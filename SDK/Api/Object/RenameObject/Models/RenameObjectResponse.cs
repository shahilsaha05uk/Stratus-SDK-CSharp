using System.Text.Json.Serialization;
using StratusSDK.Api.Object.RenameObject.Models;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.RenameObject.Models
{
    public sealed class RenameObjectResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public RenameObjectDataResponse Data { get; init; } = default!;
    }
}
