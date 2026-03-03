
namespace StratusSDK
{
    public sealed class UploadObjectResponse
    {
        public required int StatusCode { get; init; }
        public required bool Success { get; init; }
        public required  string Message { get; init; }
    }
}
