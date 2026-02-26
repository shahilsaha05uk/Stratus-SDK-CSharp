using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class RenameObjectDataResponse
    {
        [JsonPropertyName(JsonKeys.CurrentKey)]
        public string CurrentKey { get; init; } = default!;

        [JsonPropertyName(JsonKeys.RenameTo)]
        public string RenameTo { get; init; } = default!;

        [JsonPropertyName(JsonKeys.Message)]
        public string Message { get; init; } = default!;
    }
}
