using StratusSDK;
using StratusSDK.Api.Object.PutObjectMetadata.Models;
using StratusSDK.Config;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Object.PutObjectMetadata
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