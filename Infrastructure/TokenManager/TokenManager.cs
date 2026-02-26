using StratusSDK.Core.Interfaces;

namespace StratusSDK
{
    public sealed class TokenManager(ITokenEndpointClient tokenEndpointClient) : ITokenManager
    {
        Token? TokenData { get; set; }
        public async Task<Token> GetToken(CancellationToken ct = default)
        {
            if (IsTokenValid()) return TokenData!;
            var tokenResponse = await tokenEndpointClient.RefreshTokenAsync(ct);
            TokenData = MakeTokenData(tokenResponse);
            return TokenData;
        }

        public bool IsTokenValid()
        {
            if (TokenData is null)
                return false;

            var expiryTime =
                TokenData.LastFetched
                .AddSeconds(TokenData.ExpiresIn);

            var buffer = TimeSpan.FromSeconds(60);

            return DateTime.UtcNow < expiryTime - buffer;
        }
        static Token MakeTokenData(TokenResponse response)
            => new(response.AccessToken, response.ExpiresIn, response.Scope);
    }
}