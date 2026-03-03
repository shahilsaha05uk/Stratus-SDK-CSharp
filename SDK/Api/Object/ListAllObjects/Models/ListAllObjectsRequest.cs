namespace StratusSDK
{
    public sealed class ListAllObjectsRequest
    {
        public int? MaxKeys { get; init; }
        public string? ContinuationToken { get; init; }
        public string? Prefix { get; init; }
    }
}
