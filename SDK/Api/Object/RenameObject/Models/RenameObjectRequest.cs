namespace StratusSDK
{
    /// <summary>
    /// Represents a request to rename an object in the Stratus bucket.
    /// </summary>
    public sealed class RenameObjectRequest
    {
        /// <summary>
        /// Gets or initializes the current key (path) of the object to rename.
        /// </summary>
        /// <value>The current object key as a string.</value>
        public string CurrentKey { get; init; } = default!;

        /// <summary>
        /// Gets or initializes the new key (path) to rename the object to.
        /// </summary>
        /// <value>The new object key as a string.</value>
        public string RenameTo { get; init; } = default!;
    }
}
