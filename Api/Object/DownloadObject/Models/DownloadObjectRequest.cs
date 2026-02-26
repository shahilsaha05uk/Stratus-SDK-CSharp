
namespace StratusSDK
{
    /// <summary>
    /// Represents a request to download an object from the Stratus bucket.
    /// </summary>
    public sealed class DownloadObjectRequest
    {
        /// <summary>
        /// Gets or initializes the key (path) of the object to download.
        /// </summary>
        /// <value>The object key as a string.</value>
        public string ObjectKey { get; init; } = default!;

        /// <summary>
        /// Gets or initializes optional header options for the download operation.
        /// </summary>
        /// <value>The download header options or null.</value>
        public DownloadHeaderOptions? HeaderOptions { get; set; }

        /// <summary>
        /// Gets or initializes the specific version ID to download (optional).
        /// </summary>
        /// <value>The version ID or null for latest version.</value>
        public string? VersionId { get; set; }

        public DownloadOverridingQueryOptions? OverridingQueryOptions { get; set; }
    }
}
