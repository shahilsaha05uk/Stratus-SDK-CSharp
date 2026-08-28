using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Core.Enums;

namespace StratusSDK.Api.Bucket.GetBuckets.Models
{
    public sealed class CachingDetails
    {
        [JsonPropertyName(JsonKeys.Status)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ECachingStatus Status { get; init; }
    }
}
