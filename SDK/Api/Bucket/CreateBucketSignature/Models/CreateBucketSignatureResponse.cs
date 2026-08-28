using System.Text.Json.Serialization;
using StratusSDK.Api.Bucket.CreateBucketSignature.Models;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Bucket.CreateBucketSignature.Models
{
    public sealed class CreateBucketSignatureResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public CreateBucketSignatureData Data { get; set; } = default!;
    }
}
