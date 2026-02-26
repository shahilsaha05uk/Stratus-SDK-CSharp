using StratusSDK.Core.Constants.Keys;

namespace StratusSDK.Api.Bucket.ExistsBucket
{
    public sealed class ExistsBucketOperation(
        StratusClient client,
        ExistsBucketQueryOptions queryOptions) :
        BaseOperation<ExistsBucketResponse>(client)
    {
        protected override IResponseStrategy<ExistsBucketResponse>? ResponseStrategy 
            => new ExistsBucketResponseStrategy();
        protected override StratusRequest BuildRequest()
            => new()
            {
                Method = HttpMethod.Head,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/{bucket_name}",
                PathParameters = new()
                {
                    { PathKeys.BucketName, Options.BucketName },
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(),
            };
    }
}