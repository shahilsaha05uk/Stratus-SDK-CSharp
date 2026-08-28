
using StratusSDK.Api.Object.UploadObject.Models;
using StratusSDK;
using StratusSDK.Core.Interfaces;

namespace StratusSDK.Api.Object.UploadObject.Models
{
    /// <summary>
    /// Represents a request to upload an object to the Stratus bucket.
    /// </summary>
    public sealed class UploadObjectRequest : BaseUploadObjectRequest
    {
        public IStratusHttpContent? Content { get; init; }
    }
}
