using System.Net.Http.Headers;

namespace StratusSDK
{
    public sealed class StratusClient(HttpClient http, StratusOptions options)
    {
        public StratusOptions Options = options;

        public async Task<StratusClientResponse> SendAsync(
            StratusRequest request,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseHeadersRead,
            CancellationToken ct = default)
        {
            var message = CreateMessage(request);
            var response = await http.SendAsync(message, completionOption, ct);
            return new()
            {
                ClientRequest = request,
                HttpResponse = response,
                HttpRequest = message,
            };
        }

        private static HttpRequestMessage CreateMessage(StratusRequest request)
        {
            var uri = UriBuilder.Build(request);
            var message = new HttpRequestMessage(request.Method, uri);
            ToggleOptions(ref message, request);
            AddContent(ref message, request.Content, request.Headers);
            AddCustomHeaders(ref message, request.Headers!);
            return message;
        }

        private static void AddContent(
            ref HttpRequestMessage message,
            IStratusHttpContent? content,
            Dictionary<string, string?>? headers)
        {
            if (content is null) return;
            var httpContent = content.ToContent();

            if (httpContent is null) return;

            TryAddContentHeaders(ref httpContent, headers);
            message.Content = httpContent;
        }

        private static void ToggleOptions(ref HttpRequestMessage message, StratusRequest request)
        {
            Toggler(ref message, StratusRequestOptions.RequireAuth, request.RequireAuth);
            Toggler(ref message, StratusRequestOptions.IncludeOrgId, request.IncludeOrg);
            Toggler(ref message, StratusRequestOptions.IncludeEnvironment, request.IncludeEnvironment);
        }

        private static void AddCustomHeaders(ref HttpRequestMessage message, Dictionary<string, string>? headers)
        {
            if (headers == null) return;

            foreach (var header in headers)
            {
                if (!message.Headers.TryAddWithoutValidation(
                    header.Key,
                    header.Value))
                {
                    message.Content?.Headers.TryAddWithoutValidation(
                        header.Key,
                        header.Value);
                }
            }
        }

        private static void TryAddContentHeaders(
            ref HttpContent content,
            Dictionary<string, string?>? headers)
        {
            if (content == null) return;

            // If Content-Type is specified in headers and not already set in content, set it
            if (headers?.TryGetValue(HeaderKeys.ContentType, out var ct) == true &&
                content.Headers.ContentType == null)
            {
                var contentType = ct is not null && !string.IsNullOrEmpty(ct)
                    ? ct
                    : EContentType.TextPlain.ToMimeString();
                content.Headers.ContentType =
                    new MediaTypeHeaderValue(contentType);
            }
        }

        private static void Toggler(
            ref HttpRequestMessage message,
            HttpRequestOptionsKey<bool> option,
            bool value)
            => message.Options.Set(option, value);
    }
}