using Corvus.UriTemplates.TavisApi;
using Microsoft.AspNetCore.WebUtilities;

namespace StratusSDK
{
    public static class UriBuilder
    {
        public static Uri Build(StratusRequest request)
        {
            var pathTemplate = request.PathTemplate;
            var template = new UriTemplate(pathTemplate);
            var resolved = template
                .AddParameters(request.PathParameters ?? [])
                .Resolve()
                .TrimStart('/');

            var pathWithQuery = request.Query is null
                ? resolved
                : QueryHelpers.AddQueryString(resolved, request.Query);

            return !string.IsNullOrEmpty(request.BaseUrl)
                ? new Uri(new Uri(request.BaseUrl), pathWithQuery)
                : new Uri(pathWithQuery, UriKind.Relative);
        }
    }
}
