using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Object.DeleteObject.Models
{
    public sealed class DeleteResponseObjectData
    {
        [JsonPropertyName(JsonKeys.Message)]
        public string Message { get; init; } = default!;
    }
}
