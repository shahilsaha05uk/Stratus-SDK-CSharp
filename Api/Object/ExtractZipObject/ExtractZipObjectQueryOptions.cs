
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class ExtractZipObjectQueryOptions(StratusOptions options) : QueryProviderBase<ExtractZipObjectRequest>
    {
        public override Dictionary<string, string?> ToQueries(ExtractZipObjectRequest data)
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            AddRequired(QueryKeys.ObjectKey, data.ObjectKey);
            AddRequired(QueryKeys.Destination, data.Destination);
            return base.ToQueries(data);
        }
    }
}
