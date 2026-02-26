using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class GetAllObjectVersionsResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public GetAllObjectVersionsDataResponse? Data { get; init; }
    }
}
