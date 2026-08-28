using StratusSDK;
using StratusSDK.Api.PresignedUrl;
using StratusSDK.Api.PresignedUrl.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Core.Enums;
using StratusSDK.Transport;

namespace StratusSDK.Api.PresignedUrl
{
    public sealed class PresignedUrlOperation(
        StratusClient client,
        PresignedUrlQueryOptions queryOptions) :
        BaseOperation<PresignedUrlRequest, PresignedURLResponse>(client)
    {
        protected override StratusRequest BuildRequest(PresignedUrlRequest request)
            => new()
            {
                Method = request.Type switch
                {
                    EPresignedType.Upload => HttpMethod.Put,
                    EPresignedType.Download => HttpMethod.Get,
                    _ => throw new ArgumentOutOfRangeException(
                        nameof(request.Type),
                        $"Not expected type value: {request.Type}"),
                },
                PathTemplate = "/baas/v1/project/{project_id}/bucket/object/signed-url",
                PathParameters = new()
                {
                    { PathKeys.ProjectId, Options.ProjectID },
                },
                Query = queryOptions.ToQueries(request),
            };
    }
}