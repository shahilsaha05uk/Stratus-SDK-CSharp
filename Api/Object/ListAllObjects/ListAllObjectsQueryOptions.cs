

namespace StratusSDK
{
    public sealed class ListAllObjectsQueryOptions(StratusOptions options) : QueryProviderBase<ListAllObjectsRequest>
    {
        public override Dictionary<string, string?> ToQueries(ListAllObjectsRequest data)
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);

            AddOptional(QueryKeys.Prefix, data.Prefix);
            AddOptional(QueryKeys.ContinuationToken, data.ContinuationToken);
            AddOptional(QueryKeys.MaxKeys, data.MaxKeys?.ToString());
            return base.ToQueries(data);
        }
    }
}
