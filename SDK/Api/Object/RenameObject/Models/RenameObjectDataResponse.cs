using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Object.RenameObject.Models
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
