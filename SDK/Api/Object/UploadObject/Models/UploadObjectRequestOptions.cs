namespace StratusSDK
{
    public sealed class UploadObjectRequestOptions
    {
        /// <summary>
        /// Gets or initializes optional header options for the upload operation.
        /// </summary>
        /// <value>The upload header options or null.</value>
        public UploadHeaderOptions? HeaderOptions { get; set; }

        /// <summary>
        /// Gets or initializes the version ID (optional).
        /// </summary>
        /// <value>The version ID or null.</value>
        public string? VersionId { get; set; }
    }
}
