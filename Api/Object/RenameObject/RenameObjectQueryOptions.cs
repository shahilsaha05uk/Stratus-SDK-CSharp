
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class RenameObjectQueryOptions(StratusOptions options) : QueryProviderBase<RenameObjectRequest>
    {
        public override Dictionary<string, string?> ToQueries(RenameObjectRequest data)
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            AddRequired(QueryKeys.CurrentKey, data.CurrentKey);
            AddRequired(QueryKeys.RenameTo, data.RenameTo);
            return base.ToQueries(data);
        }
    }
}
