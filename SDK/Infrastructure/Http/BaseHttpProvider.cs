using System.Globalization;
using System.Net;

namespace StratusSDK
{
    public abstract class BaseHttpProvider
    {
        protected virtual void AddOptional(
            Dictionary<string, string?> items,
            string key,
            object? value)
        {
            if (value == null) return;

            var s = ConvertToString(value);
            if (string.IsNullOrWhiteSpace(s)) return;

            items[key] = s;
        }

        protected virtual void AddRequired(
            Dictionary<string, string?> items,
            string key,
            object? value,
            string? message = null)
        {
            if (value == null)
                throw new StratusException(
                    HttpStatusCode.BadRequest,
                    message ?? $"Missing required query parameter '{key}'.");

            var s = ConvertToString(value);
            if (string.IsNullOrWhiteSpace(s))
                throw new StratusException(
                    HttpStatusCode.BadRequest,
                    message ?? $"Missing required query parameter '{key}'.");

            items[key] = s;
        }
        protected static void AddIf(
            Dictionary<string, string?> items,
            string key,
            object? value)
        {
            if (value == null) return;
            items[key] = ConvertToString(value);
        }

        protected static string ConvertToString(object value)
            => value switch
            {
                string s => s,

                bool b => b.ToString().ToLower(),

                Enum e => e.ToString(),

                DateTime dt => dt.ToString("O"), // ISO 8601

                float f => f.ToString(CultureInfo.InvariantCulture),
                double d => d.ToString(CultureInfo.InvariantCulture),
                decimal m => m.ToString(CultureInfo.InvariantCulture),

                _ => value.ToString()!
            };

    }
}