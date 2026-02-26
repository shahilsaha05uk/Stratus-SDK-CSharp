
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
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
