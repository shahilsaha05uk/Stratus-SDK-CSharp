namespace StratusSDK
{
    public sealed class ExtractZipObjectRequest
    {
        public string ObjectKey { get; init; } = default!;
        public string Destination { get; init; } = default!;
    }
}