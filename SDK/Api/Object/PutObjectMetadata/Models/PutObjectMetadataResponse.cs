using System.Text.Json.Serialization;
using StratusSDK.Api.Object.PutObjectMetadata.Models;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.PutObjectMetadata.Models
{
    public sealed class PutObjectMetadataResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public PutObjectMetadataDataResponse Data { get; init; } = default!;
    }
}
