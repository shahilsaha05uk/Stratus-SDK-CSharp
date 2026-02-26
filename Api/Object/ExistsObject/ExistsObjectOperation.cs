
namespace StratusSDK
{
    public sealed class ExistsObjectOperation(
        ExistsObjectQueryOptions queryOptions,
        StratusClient client) :
        BaseOperation<ExistsObjectRequest, ExistsObjectResponse>(client)
    {
        protected override IResponseStrategy<ExistsObjectResponse>? ResponseStrategy 
            => new ExistsObjectResponseStrategy();
        protected override StratusRequest BuildRequest(ExistsObjectRequest request)
            => new()
            {
                Method = HttpMethod.Head,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/object",
                PathParameters = new()
                {
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(request)
            };
    }
}