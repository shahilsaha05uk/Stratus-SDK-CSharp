namespace StratusSDK
{
    public abstract class BaseOperation<TRequest, TResponse>(StratusClient client) : BaseOperation(client)
    {
        protected virtual IResponseStrategy<TResponse>? ResponseStrategy => null;

        public async Task<TResponse> ExecuteAsync(TRequest request, CancellationToken ct = default)
        {
            var response = await ExecuteRaw(BuildRequest(request), ct: ct);
            if (!response.HttpResponse.IsSuccessStatusCode)
                await HandleError(response, ResponseStrategy, ct);
            return await HandleSuccess(response.HttpResponse, ResponseStrategy, ct);
        }

        protected abstract StratusRequest BuildRequest(TRequest request);
    }
}