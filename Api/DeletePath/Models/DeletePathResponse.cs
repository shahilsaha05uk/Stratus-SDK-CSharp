using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class DeletePathResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public DeletePathData Data { get; init; } = default!;
    }
}
