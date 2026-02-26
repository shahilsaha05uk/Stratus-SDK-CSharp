namespace StratusSDK.Core.Interfaces
{
    public interface IQueryProvider<T>
    {
        Dictionary<string, string?> ToQueries(T data);
    }

}
