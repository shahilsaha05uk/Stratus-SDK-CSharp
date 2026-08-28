using StratusSDK;
using StratusSDK.Api.Bucket.ListBuckets.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Bucket.ListBuckets
{
    public sealed class ListBucketOperation(
        StratusClient client) :
        BaseOperation<ListBucketResponse>(client)
    {
        protected override StratusRequest BuildRequest()
            => new()
            {
                Method = HttpMethod.Get,
                PathTemplate = "/baas/v1/project/{project_id}/bucket",
                PathParameters = new()
                {
                    { PathKeys.ProjectId, Options.ProjectID },
                },
            };
    }
}