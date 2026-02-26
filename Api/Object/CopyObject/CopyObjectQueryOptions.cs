
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class CopyObjectQueryOptions(StratusOptions options) : QueryProviderBase<CopyObjectRequest>
    {
        public override Dictionary<string, string?> ToQueries(CopyObjectRequest data)
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            AddRequired(QueryKeys.ObjectKey, data.ObjectKey);
            AddRequired(QueryKeys.Destination, data.Destination);
            return base.ToQueries(data);
        }
    }
}
