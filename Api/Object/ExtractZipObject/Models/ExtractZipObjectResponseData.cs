using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class ExtractZipObjectResponseData
    {
        [JsonPropertyName(JsonKeys.ObjectKey)]
        public string ObjectKey { get; init; } = default!;
        [JsonPropertyName(JsonKeys.Destination)]
        public string Destination { get; init; } = default!;
        [JsonPropertyName(JsonKeys.Message)]
        public string Message { get; init; } = default!;
        [JsonPropertyName(JsonKeys.TaskId)]
        public string TaskId { get; init; } = default!;
    }
}
