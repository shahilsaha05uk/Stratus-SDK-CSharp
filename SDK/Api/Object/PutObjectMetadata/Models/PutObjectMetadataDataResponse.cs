using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Object.PutObjectMetadata.Models
{
    public sealed class PutObjectMetadataDataResponse
    {
        [JsonPropertyName(JsonKeys.Message)]
        public string Message { get; init; } = default!;
    }
}
