using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class RenameObjectResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public RenameObjectDataResponse Data { get; init; } = default!;
    }
}
