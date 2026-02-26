namespace StratusSDK.Core.Interfaces
{
    public interface IQueryProvider
    {
        Dictionary<string, string?> ToQueries();
    }
}