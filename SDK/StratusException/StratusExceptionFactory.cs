using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace StratusSDK
{
    public static class StratusExceptionFactory
    {
        public static async Task<StratusException> CreateAsync(
            StratusClientResponse stratusResponse,
            string? message = null,
            CancellationToken ct = default)
        {
            var response = stratusResponse.HttpResponse;

            var rawResponse = response.Content is not null
                ? await response.Content.ReadAsStringAsync(ct)
                : string.Empty;

            return await CreateAsync(stratusResponse, rawResponse, message, ct);
        }
        public static async Task<StratusException> CreateAsync(
            StratusClientResponse stratusResponse,
            string rawResponse,
            string? message = null,
            CancellationToken ct = default)
        {
            var response = stratusResponse.HttpResponse;
            var request = stratusResponse.HttpRequest;

            var errorInfo = JsonUtil.TryExtractError(rawResponse);
            var requestBody = request.Content is null
                ? null
                : await request.Content.ReadAsStringAsync(ct);

            var responseBody = response.Content is null
                ? null
                : await response.Content.ReadAsStringAsync(ct);

            var uri = request.RequestUri;
            var path = uri?.AbsolutePath;
            var queryParams = uri is not null 
                ? QueryHelpers.ParseQuery(uri.Query)
                    .ToDictionary(k => k.Key, v => v.Value.ToString())
                : null;

            return new StratusException(
                response.StatusCode,
                message: MakeMessage(rawResponse, response.StatusCode, message),
                method: request.Method?.Method,
                requestUrl: request?.RequestUri?.ToString(),
                requestBody: requestBody,
                responseBody: responseBody,
                errorCode: errorInfo?.ErrorCode,
                queryParams: queryParams);
        }

        private static string MakeMessage(
            string rawResponse, 
            HttpStatusCode statusCode,
            string? message = null)
        {
            if(message is not null) return message;

            if (!string.IsNullOrWhiteSpace(rawResponse))
                return JsonUtil.PrettyPrint(rawResponse);
            return $"Request failed with status code {(int)statusCode} ({statusCode}).";
        }
    }
}
