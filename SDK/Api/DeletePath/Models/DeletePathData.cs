using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.DeletePath.Models
{
    public sealed class DeletePathData
    {
        [JsonPropertyName(JsonKeys.Prefix)]
        public string Prefix { get; init; } = default!;
        [JsonPropertyName(JsonKeys.Message)]
        public string Message { get; init; } = default!;
    }
}
