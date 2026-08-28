using StratusSDK;

namespace StratusSDK.Api.Object.ExistsObject.Models
{
    public sealed class ExistsObjectResponse
    {
        public required bool Success { get; init; }
        public required string Message { get; init; }
    }
}