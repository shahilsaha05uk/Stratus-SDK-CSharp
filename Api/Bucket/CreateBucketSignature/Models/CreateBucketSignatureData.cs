using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class CreateBucketSignatureData
    {
        [JsonPropertyName(JsonKeys.Signature)]
        public string Signature { get; set; } = default!;

        [JsonPropertyName(JsonKeys.ExpiryTime)]
        public long ExpiryTime { get; set; } = default!;
    }
}
