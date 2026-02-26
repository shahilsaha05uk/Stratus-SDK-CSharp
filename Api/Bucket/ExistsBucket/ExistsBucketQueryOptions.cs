

namespace StratusSDK
{
    public sealed class ExistsBucketQueryOptions(StratusOptions options) : QueryProviderBase
    {
        public override Dictionary<string, string?> ToQueries()
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            //AddRequired(QueryKeys.BucketName, "test-bucket");
            return base.ToQueries();
        }
    }
}
