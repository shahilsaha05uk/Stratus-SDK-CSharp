namespace StratusSDK
{
    public interface IHeaderProvider
    {
        Dictionary<string, string?> ToHeaders();
    }
}