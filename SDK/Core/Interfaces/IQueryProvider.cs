
namespace StratusSDK.Core.Interfaces
{
    public interface IQueryProvider
    {
        Dictionary<string, string?> ToQueries();
    }
    public interface IQueryProvider<in T>
    {
        Dictionary<string, string?> ToQueries(T data);
    }
}