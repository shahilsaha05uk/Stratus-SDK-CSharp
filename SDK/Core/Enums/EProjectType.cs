using System.Text.Json.Serialization;
using StratusSDK;

namespace StratusSDK.Core.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EProjectType
    {
        Live,
        Development
    }
}
