namespace StratusSDK
{
    public interface IQueryProvider<T>
    {
        Dictionary<string, string?> ToQueries(T data);
    }

}
