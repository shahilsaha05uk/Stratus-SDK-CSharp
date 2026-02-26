using System.Net;

namespace StratusSDK
{
    internal class ExistsObjectResponseStrategy : IResponseStrategy<ExistsObjectResponse>
    {
        public async Task<StratusException> HandleError(StratusClientResponse stratusResponse)
        {
            var statusCode = stratusResponse.HttpResponse.StatusCode;
            return await StratusExceptionFactory.CreateAsync(
                stratusResponse,
                message: statusCode switch
                {
                    HttpStatusCode.NotFound => "Object doesnt exist!!",
                    _ => "Unexpected status code received."
                });
        }

        public Task<ExistsObjectResponse> HandleSuccessAsync(HttpResponseMessage response)
        {
            return Task.FromResult(new ExistsObjectResponse
            {
                Success = true,
                Message = "Object exists."
            });
        }
    }
}