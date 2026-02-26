using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class GetAllObjectVersionsOperation(
        GetAllObjectVersionsQueryOptions queryOptions,
        StratusClient client) :
        BaseOperation<GetAllObjectVersionsRequest, GetAllObjectVersionsResponse>(client)
    {
        protected override StratusRequest BuildRequest(GetAllObjectVersionsRequest request)
            => new()
            {
                Method = HttpMethod.Get,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/objects/versions",
                PathParameters = new()
                {
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(request),
            };
    }
}
