using IQueryProvider = StratusSDK.Core.Interfaces.IQueryProvider;

namespace StratusSDK.Infrastructure.Http.QueryProvider
{
    public abstract class QueryProviderBase : BaseHttpProvider, IQueryProvider
    {
        readonly Dictionary<string, string?> Queries = [];
        public virtual Dictionary<string, string?> ToQueries() => Queries;

        protected void AddRequired(string key, object? value, string? message = null)
        {
            AddRequired(Queries, key, value?.ToString(), message);
        }

        protected void AddOptional(string key, object? value) => base.AddOptional(Queries, key, value);
    }
}