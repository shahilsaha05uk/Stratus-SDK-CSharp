using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Infrastructure.Http.HeaderProvider;

namespace StratusSDK.Api.Object.DownloadObject.Headers
{
    public sealed class DownloadHeaderOptions : HeaderProviderBase
    {
        public int? Range { get; init; }
        public bool? RetrieveMeta { get; init; }

        public override Dictionary<string, string?> ToHeaders()
        {
            AddIf(HeaderKeys.Range, Range);
            AddIf(HeaderKeys.RetrieveMeta, RetrieveMeta);
            return base.ToHeaders();
        }
    }
}