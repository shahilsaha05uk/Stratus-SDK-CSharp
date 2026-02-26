using System.Text.Json.Serialization;

namespace StratusSDK
{
    /// <summary>
    /// Represents the caching status of a bucket.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ECachingStatus
    {
        /// <summary>
        /// Caching is enabled for the bucket.
        /// </summary>
        Enabled,

        /// <summary>
        /// Caching is disabled for the bucket.
        /// </summary>
        Disabled,

        /// <summary>
        /// Caching is currently being configured.
        /// </summary>
        InProgress
    }
}
