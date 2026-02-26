using System.Text;
using System.Text.Json;

namespace StratusSDK
{
    public sealed class JsonStratusContent<T> : IStratusHttpContent
    {
        private readonly T value;
        private readonly JsonSerializerOptions options;

        public JsonStratusContent(T value, JsonSerializerOptions? options = null)
        {
            this.value = value;
            this.options = options ?? new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public HttpContent ToContent()
        {
            var json = JsonSerializer.Serialize(value, options);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}