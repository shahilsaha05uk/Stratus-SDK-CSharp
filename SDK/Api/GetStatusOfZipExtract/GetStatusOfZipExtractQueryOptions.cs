using StratusSDK;
using StratusSDK.Api.GetStatusOfZipExtract.Models;
using StratusSDK.Config;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.GetStatusOfZipExtract
{
    public sealed class GetStatusOfZipExtractQueryOptions(StratusOptions options) :
        QueryProviderBase<GetStatusOfZipExtractRequest>
    {
        public override Dictionary<string, string?> ToQueries(GetStatusOfZipExtractRequest data)
        {
            AddRequired(QueryKeys.BucketName, options.BucketName);
            AddRequired(QueryKeys.ObjectKey, data.TaskId);
            return base.ToQueries(data);
        }
    }
}