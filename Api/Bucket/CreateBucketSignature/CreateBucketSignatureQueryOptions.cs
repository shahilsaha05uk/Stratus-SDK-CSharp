
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class CreateBucketSignatureQueryOptions(StratusOptions options) :
        QueryProviderBase
    {
        public override Dictionary<string, string?> ToQueries()
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            return base.ToQueries();
        }
    }
}
