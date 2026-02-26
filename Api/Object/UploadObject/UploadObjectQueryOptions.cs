
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class UploadObjectQueryOptions : QueryProviderBase<UploadObjectRequest>
    {
        /// <summary>
        /// Gets or initializes the specific version ID to upload (optional).
        /// </summary>
        /// <value>The version ID or null for latest version.</value>
        public string? VersionId { get; init; } = default!;

        public override Dictionary<string, string?> ToQueries(UploadObjectRequest data)
        {
            AddOptional(QueryKeys.VersionId, VersionId);
            return base.ToQueries(data);
        }
    }
}