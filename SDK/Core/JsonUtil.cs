using Microsoft.Extensions.Options;
using System.Text.Json;

namespace StratusSDK
{
    public static class JsonUtil
    {
        static readonly JsonSerializerOptions PrettyOptions =
            new(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

        public static async Task<T?> Deserialize<T>(
            HttpResponseMessage response,
            JsonSerializerOptions options,
            CancellationToken ct)
        {
            var raw = await response.Content.ReadAsStringAsync(ct);
            if (string.IsNullOrWhiteSpace(raw)) return default;
            return JsonSerializer.Deserialize<T>(
                raw,
                options);
        }


        public static string PrettyPrint(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return json;

            try
            {
                using var doc = JsonDocument.Parse(json);

                return JsonSerializer.Serialize(
                    doc.RootElement,
                    PrettyOptions);
            }
            catch
            {
                return json;
            }
        }

        public static StratusErrorInfo? TryExtractError(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;

            try
            {
                using var doc = JsonDocument.Parse(json);

                if (!doc.RootElement.TryGetProperty("data", out var data))
                    return null;

                string? code = null;
                string? message = null;

                if (data.TryGetProperty("error_code", out var codeElement))
                    code = codeElement.GetString();

                if (data.TryGetProperty("message", out var messageElement))
                    message = messageElement.GetString();

                if (code == null && message == null)
                    return null;

                return new StratusErrorInfo(code, message);
            }
            catch
            {
                return null;
            }
        }
    }

    public sealed record StratusErrorInfo(
    string? ErrorCode,
    string? Message);
}