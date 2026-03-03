
namespace StratusSDK
{
    /// <summary>
    /// Represents a request to upload an object to the Stratus bucket.
    /// </summary>
    public sealed class UploadObjectRequest : BaseUploadObjectRequest
    {
        public IStratusHttpContent? Content { get; init; }
    }
}
