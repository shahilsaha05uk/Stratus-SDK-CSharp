using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class TokenResponse
    {
        [JsonPropertyName(JsonKeys.AccessToken)]
        public string AccessToken { get; init; } = default!;

        [JsonPropertyName(JsonKeys.Scope)]
        public string Scope { get; init; } = default!;

        [JsonPropertyName(JsonKeys.ApiDomain)]
        public string ApiDomain { get; init; } = default!;

        [JsonPropertyName(JsonKeys.TokenType)]
        public string TokenType { get; init; } = default!;

        [JsonPropertyName(JsonKeys.ExpiresIn)]
        public int ExpiresIn { get; init; } = default!;
    }
}