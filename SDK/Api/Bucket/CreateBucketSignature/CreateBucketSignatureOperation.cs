using StratusSDK;
using StratusSDK.Api.Bucket.CreateBucketSignature;
using StratusSDK.Api.Bucket.CreateBucketSignature.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Bucket.CreateBucketSignature
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