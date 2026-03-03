namespace StratusSDK
{
    public sealed class ExistsBucketResponse
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
