using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
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
