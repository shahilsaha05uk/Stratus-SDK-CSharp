using StratusSDK;
using StratusSDK.Config;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Infrastructure.Http.QueryProvider;

namespace StratusSDK.Api.Bucket.CreateBucketSignature
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