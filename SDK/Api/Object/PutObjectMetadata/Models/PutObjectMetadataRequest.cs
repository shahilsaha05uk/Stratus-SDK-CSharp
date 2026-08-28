using StratusSDK;
using StratusSDK.Api.Object.PutObjectMetadata.Models;

namespace StratusSDK.Api.Object.PutObjectMetadata.Models
{
    public sealed class PutObjectMetadataRequest
    {
        public string ObjectKey { get; init; } = default!;
        public PutObjectMetadataRequestBody Body { get; init; } = default!;
    }
}