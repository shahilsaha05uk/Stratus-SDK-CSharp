using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class DeleteObjectRequestData
    {
        /// <summary>
        /// Required: This JSON key will contain the required object’s name that needs to be deleted.
        /// </summary>
        [JsonPropertyName(JsonKeys.Key)]
        public required string Key { get; set; }

        [JsonPropertyName(JsonKeys.VersionId)]
        public string? VersionId { get; set; }
    }
}
