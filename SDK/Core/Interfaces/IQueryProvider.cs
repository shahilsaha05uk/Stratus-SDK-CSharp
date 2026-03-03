namespace StratusSDK
{
    public interface IQueryProvider
    {
        Dictionary<string, string?> ToQueries();
    }
}