using StratusSDK;
using StratusSDK.Api.Object.UploadObject;
using StratusSDK.Api.Object.UploadObject.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Core.Interfaces;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.UploadObject
{
    public sealed class UploadObjectOperation(
        UploadObjectQueryOptions queryOptions,
        StratusClient client) :
        BaseOperation<UploadObjectRequest, UploadObjectResponse>(client)
    {
        protected override IResponseStrategy<UploadObjectResponse>? ResponseStrategy => new UploadResponseStrategy();
        protected override StratusRequest BuildRequest(UploadObjectRequest request)
            => new()
            {
                Method = HttpMethod.Put,
                BaseUrl = Client.Options.GetBucketUrl(),
                PathTemplate = "/{+key}",
                PathParameters = new()
                {
                    { PathKeys.Key, request.ObjectKey },
                },
                Headers = request.HeaderOptions?.ToHeaders(),
                Query = queryOptions.ToQueries(request),
                Content = request.Content
            };
    }
}