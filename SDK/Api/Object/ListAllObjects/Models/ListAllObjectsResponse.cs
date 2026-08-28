using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Api.Object.ListAllObjects.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.ListAllObjects.Models
{
    public sealed class ListAllObjectsResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public ListAllObjectsResponseData Data { get; init; } = default!;
    }
}
