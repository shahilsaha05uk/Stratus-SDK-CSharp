namespace StratusSDK
{
    public sealed class DownloadObjectResponse
    {
        public required bool Success { get; init; }
        public required string Message { get; init; }
        public byte[]? Data { get; set; } = [];
    }
}
