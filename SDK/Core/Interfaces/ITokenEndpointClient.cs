using StratusSDK;
using StratusSDK.Infrastructure.TokenManager;

namespace StratusSDK.Core.Interfaces
{
    public interface ITokenEndpointClient
    {
        Task<TokenResponse> RefreshTokenAsync(CancellationToken ct);
    }
}