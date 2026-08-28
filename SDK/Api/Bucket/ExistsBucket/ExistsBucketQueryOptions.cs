using StratusSDK;
using StratusSDK.Config;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Infrastructure.Http.QueryProvider;

namespace StratusSDK.Api.Bucket.ExistsBucket
{
    public sealed class ExistsBucketQueryOptions(StratusOptions options) : QueryProviderBase
    {
        public override Dictionary<string, string?> ToQueries()
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            // AddRequired(QueryKeys.BucketName, "test-bucket");
            return base.ToQueries();
        }
    }
}