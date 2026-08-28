using StratusSDK;
using StratusSDK.Core.Enums;

namespace StratusSDK.Api.PresignedUrl.Models
{
    public sealed class PresignedUrlRequest
    {
        public EPresignedType Type { get; set; }
        public string ObjectKey { get; set; } = string.Empty;
        public int? ExpireSeconds { get; set; } = 3600;
        public DateTimeOffset? ActiveFrom { get; set; }
        public string? VersionId { get; set; }
    }
}