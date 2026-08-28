using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Api.Object.DeleteObject.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.DeleteObject.Models
{
    public sealed class DeleteObjectResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public DeleteResponseObjectData Data { get; init; } = default!;
    }
}
