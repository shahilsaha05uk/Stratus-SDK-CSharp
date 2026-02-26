using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class UserInfo
    {
        [JsonPropertyName(JsonKeys.Zuid)]
        public long Zuid { get; init; }

        [JsonPropertyName(JsonKeys.IsConfirmed)]
        public bool IsConfirmed { get; init; }

        [JsonPropertyName(JsonKeys.EmailId)]
        public string EmailId { get; init; } = default!;

        [JsonPropertyName(JsonKeys.FirstName)]
        public string FirstName { get; init; } = default!;

        [JsonPropertyName(JsonKeys.LastName)]
        public string LastName { get; init; } = default!;

        [JsonPropertyName(JsonKeys.UserType)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EUserType UserType { get; init; }

        [JsonPropertyName(JsonKeys.UserId)]
        public long UserId { get; init; }
    }
}
