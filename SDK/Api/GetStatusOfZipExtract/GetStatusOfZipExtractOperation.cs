using StratusSDK;
using StratusSDK.Api.GetStatusOfZipExtract;
using StratusSDK.Api.GetStatusOfZipExtract.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.GetStatusOfZipExtract
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