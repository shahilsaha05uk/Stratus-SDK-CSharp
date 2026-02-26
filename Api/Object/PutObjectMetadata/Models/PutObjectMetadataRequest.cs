namespace StratusSDK
{
    public sealed class PutObjectMetadataRequest
    {
        public string ObjectKey { get; init; } = default!;
        public PutObjectMetadataRequestBody Body { get; init; } = default!;
    }
}
