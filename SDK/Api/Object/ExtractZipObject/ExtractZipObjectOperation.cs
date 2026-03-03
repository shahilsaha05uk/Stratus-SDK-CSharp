
namespace StratusSDK
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
