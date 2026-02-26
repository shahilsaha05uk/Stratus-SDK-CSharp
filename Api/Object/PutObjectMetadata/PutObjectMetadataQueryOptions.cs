
namespace StratusSDK
{
    public sealed class PutObjectMetadataQueryOptions(StratusOptions options) : QueryProviderBase<PutObjectMetadataRequest>
    {
        public override Dictionary<string, string?> ToQueries(PutObjectMetadataRequest data)
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            AddRequired(QueryKeys.ObjectKey, data.ObjectKey);
            return base.ToQueries(data);
        }
    }
}
