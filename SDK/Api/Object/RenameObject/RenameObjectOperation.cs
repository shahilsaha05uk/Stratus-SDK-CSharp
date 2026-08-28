using StratusSDK;
using StratusSDK.Api.Object.RenameObject;
using StratusSDK.Api.Object.RenameObject.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.RenameObject
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