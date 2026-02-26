namespace StratusSDK
{
    public interface IResponseStrategy<TResponse>
    {
        Task<TResponse> HandleSuccessAsync(HttpResponseMessage response);
        Task<StratusException> HandleError(StratusClientResponse stratusResponse);
    }
}