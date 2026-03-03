namespace StratusSDK
{
    public sealed class StratusResponse<T>
    {
        public T? Value { get; }
        public HttpResponseMessage Raw { get; }

        public StratusResponse(HttpResponseMessage raw)
        {
            Value = default;
            Raw = raw;
        }
        public StratusResponse(T? value, HttpResponseMessage raw)
        {
            Value = value;
            Raw = raw;
        }
    }
}
