using StratusSDK;

namespace StratusSDK.Core.Interfaces
{
    public interface IQueryOptions<T>
    {
        T? QueryOptions { get; set; }
    }
}