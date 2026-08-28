using StratusSDK;

namespace StratusSDK.Api.Object.UploadObject.Models
{
    public sealed class UploadObjectResponse
    {
        public required int StatusCode { get; init; }
        public required bool Success { get; init; }
        public required string Message { get; init; }
    }
}