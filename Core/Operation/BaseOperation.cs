using Microsoft.Extensions.Options;
using System.Net;

namespace StratusSDK
{
    public abstract class BaseOperation(StratusClient client)
    {
        protected readonly StratusClient Client = client;
        protected StratusOptions Options => Client.Options;

        protected Task<StratusClientResponse> ExecuteRaw(
            StratusRequest request,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken ct = default)
            => Client.SendAsync(
                request,
                completionOption,
                ct);
        protected async Task<TResponse> HandleSuccess<TResponse>(
            HttpResponseMessage response,
            IResponseStrategy<TResponse>? strategy,
            CancellationToken ct)
        {
            if (strategy is not null)
                return await strategy.HandleSuccessAsync(response);

            return await JsonUtil.Deserialize<TResponse>(response, Options.JsonOptions, ct)
                ?? throw new StratusException(HttpStatusCode.InternalServerError, "Failed to deserialize the response");
        }

        protected static async Task HandleError<TResponse>(
            StratusClientResponse stratusResponse,
            IResponseStrategy<TResponse>? strategy,
            CancellationToken ct)
        {
            if (strategy is not null)
                throw await strategy.HandleError(stratusResponse);

            throw await StratusExceptionFactory.CreateAsync(
                stratusResponse,
                ct: ct);
        }
    }
}