using StratusSDK;

namespace StratusSDK.Api.Object.GetObject.Models
{
    public sealed class GetObjectRequest
    {
        public string ObjectKey { get; init; } = default!;
        public string? VersionId { get; init; }
    }
}