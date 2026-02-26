using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class GetStatusOfZipExtractData
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EZipExtractStatus Status { get; set; }
    }
}
