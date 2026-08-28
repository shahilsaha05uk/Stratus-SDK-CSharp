using StratusSDK;

namespace StratusSDK.Api.Object.GetAllObjectVersions.Models
{
    public sealed class GetAllObjectVersionsRequest
    {
        public string ObjectKey { get; init; } = default!;
        public int? MaxVersions { get; init; } = default!;
        public string? ContinuationToken { get; init; } = default!;
    }
}