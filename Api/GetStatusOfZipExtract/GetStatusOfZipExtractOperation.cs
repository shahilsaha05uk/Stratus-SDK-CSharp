
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    public sealed class GetStatusOfZipExtractOperation(
        StratusClient client,
        GetStatusOfZipExtractQueryOptions queryOptions) :
        BaseOperation<GetStatusOfZipExtractRequest, GetStatusOfZipExtractResponse>(client)
    {
        protected override StratusRequest BuildRequest(GetStatusOfZipExtractRequest request)
            => new()
            {
                Method = HttpMethod.Get,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/object/zip-extract/{taskId}",
                PathParameters = new()
                {
                    { PathKeys.TaskId, request.TaskId },
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(request),
            };
    }
}
