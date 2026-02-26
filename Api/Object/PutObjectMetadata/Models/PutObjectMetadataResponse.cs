using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class PutObjectMetadataResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public PutObjectMetadataDataResponse Data { get; init; } = default!;
    }
}
