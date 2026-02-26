
namespace StratusSDK
{
    public sealed class GetObjectOperation(
        StratusClient client,
        GetObjectQueryOptions queryOptions) :
        BaseOperation<GetObjectRequest, GetObjectResponse>(client)
    {
        protected override StratusRequest BuildRequest(GetObjectRequest request)
            => new()
            {
                Method = HttpMethod.Get,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/object",
                PathParameters = new()
                {
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(request),
            };
    }
}