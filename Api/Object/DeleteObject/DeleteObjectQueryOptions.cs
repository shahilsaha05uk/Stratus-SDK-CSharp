

namespace StratusSDK
{
    public sealed class DeleteObjectQueryOptions(StratusOptions options) : QueryProviderBase
    {
        public override Dictionary<string, string?> ToQueries()
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            return base.ToQueries();
        }
    }
}
