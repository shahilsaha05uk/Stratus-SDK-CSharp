namespace StratusSDK
{
    public sealed class GetAllObjectVersionsRequest
    {
        public string ObjectKey { get; init; } = default!;
        public int? MaxVersions { get; init; } = default!;
        public string? ContinuationToken { get; init; } = default!;
    }
}
