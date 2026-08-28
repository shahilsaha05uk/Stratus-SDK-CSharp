using StratusSDK;
using StratusSDK.Api.Object.ExtractZipObject.Models;
using StratusSDK.Config;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Object.ExtractZipObject
{
    public sealed class ExtractZipObjectQueryOptions(StratusOptions options) : QueryProviderBase<ExtractZipObjectRequest>
    {
        public override Dictionary<string, string?> ToQueries(ExtractZipObjectRequest data)
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            AddRequired(QueryKeys.ObjectKey, data.ObjectKey);
            AddRequired(QueryKeys.Destination, data.Destination);
            return base.ToQueries(data);
        }
    }
}