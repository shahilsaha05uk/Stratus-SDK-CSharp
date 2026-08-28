using System.Text.Json.Serialization;
using StratusSDK.Api.DeletePath.Models;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.DeletePath.Models
{
    public sealed class DeletePathResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public DeletePathData Data { get; init; } = default!;
    }
}
