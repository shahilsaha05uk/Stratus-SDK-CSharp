using System.Text.Json.Serialization;

namespace StratusSDK
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EUserType
    {
        Admin,
        User
    }
}
