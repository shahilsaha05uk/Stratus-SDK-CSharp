using StratusSDK;

namespace StratusSDK.Api.Object.ExtractZipObject.Models
{
    public sealed class ExtractZipObjectRequest
    {
        public string ObjectKey { get; init; } = default!;
        public string Destination { get; init; } = default!;
    }
}