using StratusSDK.Core.Interfaces;

namespace StratusSDK
{
    public abstract class HeaderProviderBase : BaseHttpProvider, IHeaderProvider
    {
        public abstract Dictionary<string, string?> ToHeaders();
    }
}