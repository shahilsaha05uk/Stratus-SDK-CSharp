namespace StratusSDK.Core.Interfaces
{
    public interface ITokenManager
    {
        public Task<Token> GetToken(CancellationToken ct = default);
        public bool IsTokenValid();
    }
}
