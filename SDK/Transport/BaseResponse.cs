using System.Text.Json.Serialization;
using StratusSDK.Core.Constants.Keys;
using StratusSDK;

namespace StratusSDK.Transport
{
    public abstract class BaseResponse
    {
        [JsonPropertyName(JsonKeys.Status)]
        [JsonPropertyOrder(-100)]
        public string Status { get; init; } = default!;
        [JsonIgnore]
        public bool Success =>
            Status.Equals("success", StringComparison.OrdinalIgnoreCase);
    }
}