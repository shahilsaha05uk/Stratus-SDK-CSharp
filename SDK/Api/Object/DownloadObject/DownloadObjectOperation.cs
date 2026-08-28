using StratusSDK;
using StratusSDK.Api.Object.DownloadObject;
using StratusSDK.Api.Object.DownloadObject.Models;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Core.Interfaces;
using StratusSDK.Transport;

namespace StratusSDK.Api.Object.DownloadObject
{
    public sealed class DownloadObjectOperation(
        StratusClient client,
        DownloadObjectQueryOptions queryOptions) :
        BaseOperation<DownloadObjectRequest, DownloadObjectResponse>(client)
    {
        protected override IResponseStrategy<DownloadObjectResponse>? ResponseStrategy
            => new DownloadObjectResponseStrategy();
        protected override StratusRequest BuildRequest(DownloadObjectRequest request)
            => new()
            {
                Method = HttpMethod.Get,
                BaseUrl = Client.Options.GetBucketUrl(),
                PathTemplate = "/{+object_key}",
                PathParameters = new()
                {
                    { PathKeys.Key, request.ObjectKey },
                },
                Headers = request.HeaderOptions?.ToHeaders(),
                Query = queryOptions.ToQueries(request)
            };
    }
}