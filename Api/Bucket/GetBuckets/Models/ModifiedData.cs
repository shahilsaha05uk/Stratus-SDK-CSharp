using StratusSDK.Core.Constants.Keys;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public sealed class ModifiedData
    {
        [JsonPropertyName(JsonKeys.Zuid)]
        public long Zuid { get; init; }

        [JsonPropertyName(JsonKeys.IsConfirmed)]
        public bool IsConfirmed { get; init; }

        [JsonPropertyName(JsonKeys.EmailId)]
        public string EmailID { get; init; } = default!;

        [JsonPropertyName(JsonKeys.FirstName)]
        public string FirstName { get; init; } = default!;

        [JsonPropertyName(JsonKeys.LastName)]
        public string LastName { get; init; } = default!;

        [JsonPropertyName(JsonKeys.UserType)]
        public EUserType UserType { get; init; }

        [JsonPropertyName(JsonKeys.UserId)]
        public long UserID { get; init; }
    }
}