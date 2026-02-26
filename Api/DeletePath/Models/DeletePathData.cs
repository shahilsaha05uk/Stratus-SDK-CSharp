using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class DeletePathData
    {
        [JsonPropertyName(JsonKeys.Prefix)]
        public string Prefix { get; init; } = default!;
        [JsonPropertyName(JsonKeys.Message)]
        public string Message { get; init; } = default!;
    }
}
