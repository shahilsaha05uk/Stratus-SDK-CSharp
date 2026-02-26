using System.Text.Json.Serialization;

namespace StratusSDK
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EProjectType
    {
        Live,
        Development
    }
}
