using StratusSDK.Core.Constants;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Core.Interfaces;
using System.Text.Json;

namespace StratusSDK
{
    public sealed class ZohoTokenEndpointClient(
        HttpClient http,
        StratusOptions options) : ITokenEndpointClient
    {
        public async Task<TokenResponse> RefreshTokenAsync(CancellationToken ct)
        {
            var content = GetFormContent();

            var response = await http.PostAsync(
                $"{AuthDomains.GetDomain(options.Region)}oauth/v2/token",
                content, ct);

            var body = await response.Content.ReadAsStringAsync(ct);

            if (!response.IsSuccessStatusCode)
                throw new StratusAuthenticationException(
                    $"Failed to fetch token. Status: {response.StatusCode}, Response: {body}");

            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(body,
                options.JsonOptions)
                ?? throw new StratusAuthenticationException(
                    "Token endpoint returned invalid response.");

            return tokenResponse;
        }

        FormUrlEncodedContent GetFormContent()
            => new(
            [
                CreateKeyValuePair(TokenKeys.RefreshToken, options.RefreshToken),
                CreateKeyValuePair(TokenKeys.ClientId, options.ClientID),
                CreateKeyValuePair(TokenKeys.ClientSecret, options.ClientSecret),
                CreateKeyValuePair(TokenKeys.GrantType, TokenKeys.RefreshToken),
                CreateKeyValuePair(TokenKeys.RedirectUri, options.RedirectUrl),
            ]);

        static KeyValuePair<string, string> CreateKeyValuePair(string key, string value)
            => new(key, value);
    }
}