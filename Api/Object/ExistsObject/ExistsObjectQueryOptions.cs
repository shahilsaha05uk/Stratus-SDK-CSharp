
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class ExistsObjectQueryOptions(StratusOptions options) : QueryProviderBase<ExistsObjectRequest>
    {
        public override Dictionary<string, string?> ToQueries(ExistsObjectRequest data)
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            AddRequired(QueryKeys.ObjectKey, new ObjectKey(data.ObjectKey));
            AddOptional(QueryKeys.VersionId, data.VersionId);
            return base.ToQueries(data);
        }
    }
}