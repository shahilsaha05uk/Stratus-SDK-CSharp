
namespace StratusSDK
{
    public sealed class PresignedUrlOptions
    {
        public int? ExpireSeconds { get; set; } = 3600;
        public DateTimeOffset? ActiveFrom { get; set; }
        public string? VersionId { get; set; }

    }
}
