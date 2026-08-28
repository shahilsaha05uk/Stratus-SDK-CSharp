using StratusSDK;

namespace StratusSDK.Api.Object.DownloadObject.Models
{
    public sealed class DownloadObjectResponse
    {
        public required bool Success { get; init; }
        public required string Message { get; init; }
        public byte[]? Data { get; set; } = [];
    }
}