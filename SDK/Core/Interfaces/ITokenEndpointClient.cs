namespace StratusSDK
{
    public interface ITokenEndpointClient
    {
        Task<TokenResponse> RefreshTokenAsync(CancellationToken ct);
    }
}