
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class DownloadHeaderOptions : HeaderProviderBase
    {
        public int? Range { get; init; }
        public bool? RetrieveMeta { get; init; }

        public override Dictionary<string, string?> ToHeaders()
        {
            var headers = new Dictionary<string, string?>();
            AddIf(headers, HeaderKeys.Range, Range);
            AddIf(headers, HeaderKeys.RetrieveMeta, RetrieveMeta);
            return headers;
        }
    }
}
