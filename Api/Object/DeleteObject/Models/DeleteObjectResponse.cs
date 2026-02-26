using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class DeleteObjectResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public DeleteResponseObjectData Data { get; init; } = default!;
    }
}
