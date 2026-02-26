using StratusSDK.Core.Interfaces;

namespace StratusSDK
{
    public sealed class StratusRequest
    {
        // New*

        public string? BaseUrl { get; set; }

        public HttpMethod Method { get; init; } = HttpMethod.Get;

        public required string PathTemplate { get; init; }
        public Dictionary<string, object?>? PathParameters { get; set; }

        public Dictionary<string, string?>? Query { get; init; }

        public Dictionary<string, string?>? Headers { get; init; }

        public IStratusHttpContent? Content { get; init; }

        // Toggle flags
        public bool RequireAuth { get; init; } = true;
        public bool IncludeOrg { get; init; } = false;
        public bool IncludeEnvironment { get; init; } = false;
    }
}
