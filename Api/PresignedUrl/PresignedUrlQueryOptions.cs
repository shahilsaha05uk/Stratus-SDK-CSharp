

namespace StratusSDK
{
    public sealed class PresignedUrlQueryOptions(StratusOptions options) : QueryProviderBase<PresignedUrlRequest>
    {
        public override Dictionary<string, string?> ToQueries(PresignedUrlRequest data)
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            AddRequired(QueryKeys.ObjectKey, data.ObjectKey);
            AddOptional(QueryKeys.ExpiryInSeconds, data.ExpireSeconds?.ToString());
            AddOptional(QueryKeys.ActiveFrom, data.ActiveFrom?.ToUnixTimeMilliseconds().ToString());
            AddOptional(QueryKeys.VersionId, data.VersionId);
            return base.ToQueries(data);
        }
    }
}
