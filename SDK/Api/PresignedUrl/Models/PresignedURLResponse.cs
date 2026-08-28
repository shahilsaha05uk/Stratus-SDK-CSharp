using System.Text.Json.Serialization;
using StratusSDK.Api.PresignedUrl.Models;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.PresignedUrl.Models
{
    public sealed class PresignedURLResponse : BaseResponse
    {
        [JsonPropertyName(JsonKeys.Data)]
        public PresignedUrlData Data { get; set; } = default!;
    }
}
