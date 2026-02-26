
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class CreateBucketSignatureOperation(
        StratusClient client,
        CreateBucketSignatureQueryOptions queryOptions) :
        BaseOperation<CreateBucketSignatureResponse>(client)
    {
        protected override StratusRequest BuildRequest()
            => new()
            {
                Method = HttpMethod.Post,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/signature",
                PathParameters = new()
                {
                    {PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(),
            };
    }
}
