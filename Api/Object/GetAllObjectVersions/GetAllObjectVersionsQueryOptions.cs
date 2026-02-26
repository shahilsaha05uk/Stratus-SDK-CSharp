

namespace StratusSDK
{
    public sealed class GetAllObjectVersionsQueryOptions(StratusOptions options) : 
        QueryProviderBase<GetAllObjectVersionsRequest>
    {
        public override Dictionary<string, string?> ToQueries(GetAllObjectVersionsRequest data)
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            AddRequired(QueryKeys.ObjectKey, data.ObjectKey);

            AddOptional(QueryKeys.MaxVersions, data.MaxVersions?.ToString());
            AddOptional(QueryKeys.ContinuationToken, data.ContinuationToken);
            return base.ToQueries(data);
        }
    }
}
