
namespace StratusSDK
{
    public abstract class HeaderProviderBase : BaseHttpProvider, IHeaderProvider
    {
        protected readonly Dictionary<string, string?> Headers = [];
        public virtual Dictionary<string, string?> ToHeaders() => Headers;

        protected override void AddRequired(Dictionary<string, string?> items, string key, object? value, string? message = null)
        {
            AddRequired(Headers, key, value?.ToString(), message);
        }

        protected void AddOptional(string key, object? value)
        {
            base.AddOptional(Headers, key, value);
        }

        protected void AddIf(string key, object? value)
        {
            AddIf(Headers, key, value);
        }
    }
}