using StratusSDK;
using StratusSDK.Api.Object.ExtractZipObject;
using StratusSDK.Api.Object.ExtractZipObject.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.ExtractZipObject
{
    public sealed class ExtractZipObjectOperation(
        StratusClient client,
        ExtractZipObjectQueryOptions queryOptions) :
        BaseOperation<ExtractZipObjectRequest, ExtractZipObjectResponse>(client)
    {
        protected override StratusRequest BuildRequest(ExtractZipObjectRequest request)
            => new()
            {
                Method = HttpMethod.Post,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/object/zip-extract",
                PathParameters = new()
                {
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(request),
            };
    }
}