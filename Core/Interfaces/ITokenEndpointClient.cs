namespace StratusSDK.Core.Interfaces
{
    public interface ITokenEndpointClient
    {
        Task<TokenResponse> RefreshTokenAsync(CancellationToken ct);
    }
}