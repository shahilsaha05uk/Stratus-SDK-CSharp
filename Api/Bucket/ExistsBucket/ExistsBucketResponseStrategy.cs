using System.Net;

namespace StratusSDK
{
    internal sealed class ExistsBucketResponseStrategy : IResponseStrategy<ExistsBucketResponse>
    {
        public async Task<StratusException> HandleError(StratusClientResponse stratusResponse)
        {
            var statusCode = stratusResponse.HttpResponse.StatusCode;
            return await StratusExceptionFactory.CreateAsync(
                stratusResponse, 
                message: statusCode switch
                {
                    HttpStatusCode.Forbidden => "Bucket exists but the user does not have permission to access it.",
                    HttpStatusCode.NotFound => "Bucket does not exist.",
                    _ => $"Unexpected status code: {statusCode}"
                });
        }

        public Task<ExistsBucketResponse> HandleSuccessAsync(HttpResponseMessage response)
        {
            return Task.FromResult(new ExistsBucketResponse
            {
                StatusCode = (int)response.StatusCode,
                Success = response.IsSuccessStatusCode,
                Message = "Bucket exists."
            });
        }
    }
}