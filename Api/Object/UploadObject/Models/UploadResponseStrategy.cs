using System.Net;

namespace StratusSDK
{
    internal class UploadResponseStrategy : IResponseStrategy<UploadObjectResponse>
    {
        public async Task<StratusException> HandleError(StratusClientResponse stratusResponse)
        {
            var statusCode = stratusResponse.HttpResponse.StatusCode;
            return await StratusExceptionFactory.CreateAsync(
                stratusResponse,
                message: statusCode switch
                {
                    HttpStatusCode.NotFound => "Bucket or object not found.",
                    HttpStatusCode.Unauthorized => "Unauthorized access.",
                    HttpStatusCode.BadRequest => "Invalid filename",
                    HttpStatusCode.Conflict => "Duplicate object key.",
                    _ => "Unexpected status code received."
                });
        }

        public Task<UploadObjectResponse> HandleSuccessAsync(HttpResponseMessage response)
        {
            return Task.FromResult(new UploadObjectResponse
            {
                StatusCode = (int)response.StatusCode,
                Success = response.IsSuccessStatusCode,
                Message = "Upload successful.",
            });
        }
    }
}