
using System.Net;

namespace StratusSDK
{
    public sealed class DownloadObjectResponseStrategy : IResponseStrategy<DownloadObjectResponse>
    {
        public async Task<StratusException> HandleError(StratusClientResponse stratusResponse)
        {
            var statusCode = stratusResponse.HttpResponse.StatusCode;
            return await StratusExceptionFactory.CreateAsync(
                stratusResponse,
                message: statusCode switch
                {
                    HttpStatusCode.NotFound => "Bucket or object not found.",
                    HttpStatusCode.Forbidden => "Unauthorized access.",
                    _ => "Unexpected status code received."
                });
        }

        public async Task<DownloadObjectResponse> HandleSuccessAsync(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsByteArrayAsync();
            return new DownloadObjectResponse
            {
                Success = true,
                Message = "Download Request Success!!",
                Data = data
            };
        }
    }
}