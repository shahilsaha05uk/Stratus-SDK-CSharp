using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Bucket.CreateBucketSignature.Models
{
    public sealed class CreateBucketSignatureData
    {
        [JsonPropertyName(JsonKeys.Signature)]
        public string Signature { get; set; } = default!;

        [JsonPropertyName(JsonKeys.ExpiryTime)]
        public long ExpiryTime { get; set; } = default!;
    }
}
