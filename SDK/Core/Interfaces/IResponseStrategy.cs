using StratusSDK.StratusExceptions;
using StratusSDK.Transport;

namespace StratusSDK.Core.Interfaces
{
    public interface IResponseStrategy<TResponse>
    {
        Task<TResponse> HandleSuccessAsync(HttpResponseMessage response);
        Task<StratusException> HandleError(StratusClientResponse stratusResponse);
    }
}