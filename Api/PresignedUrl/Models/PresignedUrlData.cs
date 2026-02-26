using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class PresignedUrlData
    {
        [JsonPropertyName(JsonKeys.Signature)]
        public string Signature { get; set; } = default!;

        [JsonPropertyName(JsonKeys.ExpireInSeconds)]
        public int ExpriresInSeconds { get; set; } = default!;

        [JsonPropertyName(JsonKeys.ActiveFrom)]
        public int ActiveFrom { get; set; } = default!;
    }
}
