namespace StratusSDK
{
    public class StratusClientResponse
    {
        public required StratusRequest ClientRequest { get; init; }
        public required HttpRequestMessage HttpRequest { get; init; }
        public required HttpResponseMessage HttpResponse { get; init; }
    }
    public class StratusClientResponse<TContent> : StratusClientResponse
    {
        public TContent? Content { get; init; }
    }
}