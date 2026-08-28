using System.Net;
using StratusSDK.Api.Object.ExistsObject.Models;
using StratusSDK;
using StratusSDK.Core.Interfaces;
using StratusSDK.Transport;
using StratusSDK.StratusExceptions;

namespace StratusSDK.Api.Object.ExistsObject.Models
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