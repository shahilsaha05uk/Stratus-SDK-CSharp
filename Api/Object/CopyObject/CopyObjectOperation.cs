

namespace StratusSDK
{
    public sealed class CopyObjectOperation(
        StratusClient client,
        CopyObjectQueryOptions queryOptions) :
        BaseOperation<CopyObjectRequest, CopyObjectResponse>(client)
    {
        protected override StratusRequest BuildRequest(CopyObjectRequest request)
            => new()
            {
                Method = HttpMethod.Post,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/object/copy",
                PathParameters = new()
                {
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(request),
            };
    }
}
