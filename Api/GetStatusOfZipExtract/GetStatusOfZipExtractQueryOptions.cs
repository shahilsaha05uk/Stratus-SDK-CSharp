

namespace StratusSDK
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
