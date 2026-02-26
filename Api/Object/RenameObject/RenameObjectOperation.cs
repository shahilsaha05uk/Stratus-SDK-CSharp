using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class RenameObjectOperation(
        RenameObjectQueryOptions queryOptions,
        StratusClient client) :
        BaseOperation<RenameObjectRequest, RenameObjectResponse>(client)
    {
        protected override StratusRequest BuildRequest(RenameObjectRequest request)
            => new()
            {
                Method = HttpMethod.Patch,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/object",
                PathParameters = new()
                {
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(request),
            };
    }
}
