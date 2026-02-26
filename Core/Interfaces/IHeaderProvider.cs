namespace StratusSDK.Core.Interfaces
{
    public interface IHeaderProvider
    {
        Dictionary<string, string?> ToHeaders();
    }
}