namespace StratusSDK
{
    /// <summary>
    /// Represents a request to copy an object within the Stratus bucket.
    /// </summary>
    public sealed class CopyObjectRequest
    {
        /// <summary>
        /// Gets or initializes the source object key to copy from.
        /// </summary>
        /// <value>The source object key as a string.</value>
        public required string ObjectKey { get; init; } = default!;

        /// <summary>
        /// Gets or initializes the destination key where the object will be copied to.
        /// </summary>
        /// <value>The destination key as a string.</value>
        public string Destination { get; init; } = default!;
    }
}
