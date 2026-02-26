using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class CachingDetails
    {
        [JsonPropertyName(JsonKeys.Status)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ECachingStatus Status { get; init; }
    }
}
