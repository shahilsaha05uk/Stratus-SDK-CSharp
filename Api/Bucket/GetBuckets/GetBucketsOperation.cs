
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class GetBucketsOperation(
        StratusClient client,
        GetBucketQueryOptions queryOptions) :
        BaseOperation<GetBucketResponse>(client)
    {
        protected override StratusRequest BuildRequest()
            => new()
            {
                Method = HttpMethod.Get,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/{bucket_name}",
                PathParameters = new()
                {
                    { PathKeys.BucketName, Options.BucketName },
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries()
            };
    }
}
