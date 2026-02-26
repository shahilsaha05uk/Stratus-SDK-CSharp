
namespace StratusSDK
{
    public sealed class ListAllObjectsOperation(
        ListAllObjectsQueryOptions queryOptions,
        StratusClient client) :
        BaseOperation<ListAllObjectsRequest, ListAllObjectsResponse>(client)
    {
        protected override StratusRequest BuildRequest(ListAllObjectsRequest request)
            => new()
            {
                Method = HttpMethod.Get,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/objects",
                PathParameters = new()
                {
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(request),
            };
    }
}
