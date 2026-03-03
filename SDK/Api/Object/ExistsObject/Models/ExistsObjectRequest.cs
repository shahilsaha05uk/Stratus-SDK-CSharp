namespace StratusSDK
{
    /// <summary>
    /// Represents a request to check if an object exists in the Stratus bucket.
    /// </summary>
    public sealed class ExistsObjectRequest
    {
        /// <summary>
        /// Gets or initializes the key (path) of the object to check.
        /// </summary>
        /// <value>The object key as a string.</value>
        public string ObjectKey { get; init; } = default!;

        /// <summary>
        /// Gets or initializes the specific version ID to check (optional).
        /// </summary>
        /// <value>The version ID or null to check the latest version.</value>
        public string? VersionId { get; init; }
    }
}
