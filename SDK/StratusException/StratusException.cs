using System.Net;

namespace StratusSDK
{

    public sealed class StratusException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string? ErrorCode { get; }

        public string? Method { get; }
        public string? RequestUrl { get; }
        public string? RequestBody { get; }

        public string? ResponseBody { get; }
        public IReadOnlyDictionary<string, string>? QueryParams { get; }

        public StratusException(
            HttpStatusCode statusCode,
            string message,
            string? method = null,
            string? requestUrl = null,
            string? requestBody = null,
            string? responseBody = null,
            string? errorCode = null,
            IReadOnlyDictionary<string, string>? queryParams = null)
            : base(message)
        {
            StatusCode = statusCode;
            Method = method;
            RequestUrl = requestUrl;
            RequestBody = requestBody;
            ResponseBody = responseBody;
            ErrorCode = errorCode;
            QueryParams = queryParams;
        }
    }
}
