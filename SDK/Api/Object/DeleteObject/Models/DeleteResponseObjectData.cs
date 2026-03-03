using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class DeleteResponseObjectData
    {
        [JsonPropertyName(JsonKeys.Message)]
        public string Message { get; init; } = default!;
    }
}
