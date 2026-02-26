
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class GetObjectQueryOptions(StratusOptions options) : QueryProviderBase<GetObjectRequest>
    {
        public override Dictionary<string, string?> ToQueries(GetObjectRequest data)
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            AddOptional(QueryKeys.VersionId, data.VersionId);
            AddRequired(QueryKeys.ObjectKey, data.ObjectKey);
            return base.ToQueries(data);
        }
    }
}