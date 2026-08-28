using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Api.Object.DeleteObject.Models;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Object.DeleteObject.Models
{
    /// <summary>
    /// Represents a request to delete one or more objects from the Stratus bucket.
    /// </summary>
    public sealed class DeleteObjectRequest
    {
        /// <summary>
        /// Gets or sets the list of objects to delete.
        /// </summary>
        /// <value>A list of DeleteObjectRequestData containing object keys.</value>
        [JsonPropertyName(JsonKeys.Objects)]
        public List<DeleteObjectRequestData> Objects { get; set; } = default!;

        /// <summary>
        /// Gets or sets the time-to-live in seconds for scheduled deletion (optional).
        /// </summary>
        /// <value>
        /// Time in seconds. Once this TTL is reached, the delete operation will be executed.
        /// If null, deletion occurs immediately.
        /// </value>
        [JsonPropertyName(JsonKeys.TtlInSeconds)]
        public int? TtlInSeconds { get; set; }
    }
}
