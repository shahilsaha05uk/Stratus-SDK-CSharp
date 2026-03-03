
namespace StratusSDK
{
    public sealed class PutObjectMetadataOperation(
        StratusClient client,
        PutObjectMetadataQueryOptions queryOptions) :
        BaseOperation<PutObjectMetadataRequest, PutObjectMetadataResponse>(client)
    {
        protected override StratusRequest BuildRequest(PutObjectMetadataRequest request)
            => new()
            {
                Method = HttpMethod.Put,
                PathTemplate = "/baas/v1/project/{project_id}/bucket/object/metadata",
                PathParameters = new()
                {
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(request),
                Content = new JsonStratusContent<PutObjectMetadataRequestBody>(request.Body),
            };
    }
}
