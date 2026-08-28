using StratusSDK;
using StratusSDK.Api.Object.DeleteObject;
using StratusSDK.Api.Object.DeleteObject.Models;
using StratusSDK.ContentTypes;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.DeleteObject
{
    public sealed class DeleteObjectOperation(
        StratusClient client,
        DeleteObjectQueryOptions queryOptions) :
        BaseOperation<DeleteObjectRequest, DeleteObjectResponse>(client)
    {
        protected override StratusRequest BuildRequest(DeleteObjectRequest request)
            => new()
            {
                Method = HttpMethod.Put,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/object",
                PathParameters = new()
                {
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(),
                Content = new JsonStratusContent<DeleteObjectRequest>(request)
            };
    }
}