using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Object.CopyObject.Models
{
    public sealed class CopyObjectDataResponse
    {
        [JsonPropertyName(JsonKeys.ObjectKey)]
        public string ObjectKey { get; set; } = default!;

        [JsonPropertyName(JsonKeys.CopyTo)]
        public string CopyTo { get; set; } = default!;

        [JsonPropertyName(JsonKeys.Message)]
        public string Message { get; set; } = default!;
    }
}
