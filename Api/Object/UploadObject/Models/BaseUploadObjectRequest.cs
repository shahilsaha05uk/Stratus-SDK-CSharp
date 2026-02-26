namespace StratusSDK
{

    public abstract class BaseUploadObjectRequest
    {
        /// <summary>
        /// Gets or initializes optional header options for the upload operation.
        /// </summary>
        /// <value>The upload header options or null.</value>
        public UploadHeaderOptions? HeaderOptions { get; set; }

        /// <summary>
        /// Gets or initializes the destination key (path) for the uploaded object.
        /// </summary>
        /// <value>The object key as a string.</value>
        public required string ObjectKey { get; init; }

        /// <summary>
        /// Gets or initializes the version ID (optional).
        /// </summary>
        /// <value>The version ID or null.</value>
        public string? VersionId { get; set; }
    }
}
