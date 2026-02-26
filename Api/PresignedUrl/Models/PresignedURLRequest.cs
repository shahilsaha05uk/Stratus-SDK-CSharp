
namespace StratusSDK
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
