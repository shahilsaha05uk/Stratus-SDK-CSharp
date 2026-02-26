
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class DeletePathQueryOptions(StratusOptions options) : QueryProviderBase<string>
    {
        public override Dictionary<string, string?> ToQueries(string prefix)
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            AddRequired(QueryKeys.Prefix, prefix);
            return base.ToQueries(prefix);
        }
    }
}
