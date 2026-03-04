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

            var rawResponse = await SafeReadContentAsync(response.Content, ct)
                ?? string.Empty;

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
            var requestBody = await SafeReadContentAsync(request.Content, ct);
            var responseBody = await SafeReadContentAsync(response.Content, ct);

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

        private static async Task<string?> SafeReadContentAsync(
            HttpContent? content,
            CancellationToken ct)
        {
            if (content is null) return null;

            try
            {
                return await content.ReadAsStringAsync(ct);
            }
            catch (ObjectDisposedException)
            {
                return null;
            }
        }
    }
}
