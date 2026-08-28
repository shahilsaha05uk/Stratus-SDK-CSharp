using StratusSDK;
using StratusSDK.Api.Object.ExistsObject;
using StratusSDK.Api.Object.ExistsObject.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Core.Interfaces;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.ExistsObject
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