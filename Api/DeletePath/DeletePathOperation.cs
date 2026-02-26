using Microsoft.Extensions.Options;
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class DeletePathOperation(
        DeletePathQueryOptions queryOptions,
        StratusClient client) :
        BaseOperation<string, DeletePathResponse>(client)
    {
        protected override StratusRequest BuildRequest(string prefix)
            => new()
            {
                Method = HttpMethod.Delete,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/object/prefix",
                PathParameters = new()
                {
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(prefix),
            };
    }
}
