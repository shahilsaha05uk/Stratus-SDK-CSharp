using System.Text.Json.Serialization;
using StratusSDK.Api.Object.GetAllObjectVersions.Models;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.GetAllObjectVersions.Models
{
    public sealed class GetAllObjectVersionsResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public GetAllObjectVersionsDataResponse? Data { get; init; }
    }
}
